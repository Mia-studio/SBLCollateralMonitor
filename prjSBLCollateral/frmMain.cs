using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjSBLCollateral
{
    // 主畫面：上面三個狀態色塊，中間合約表格，下面 CSV 上傳區
    // 合約一次從資料庫取回放在記憶體，搜尋、排序、分頁都在記憶體做
    public partial class frmMain : Form
    {
        // ---------- 欄位 ----------

        // 負責跟資料庫溝通
        private readonly MonitorRepository _repo = new MonitorRepository();

        // 目前顯示的資料日期，null 表示最新一天
        private DateTime? _tradeDate = null;

        // 點色塊篩選的狀態(Call / Warning / Normal)，null 表示不篩選
        private string _statusFilter = null;

        private DataTable _contracts;           // 從資料庫取回的全部合約
        private DataView _view;                 // 負責篩選和排序
        private int _totalCount;                // 篩選前的總筆數
        private bool _hasPrices = false;        // 資料庫有沒有收盤價
        private readonly Font _emptyHintFont = new Font("微軟正黑體", 14F);   // 表格沒資料時提示文字的字型

        // 分頁與排序
        private int _pageIndex = 0;             // 目前頁碼，從 0 開始
        private int _pageSize = 20;             // 每頁筆數
        private string _sortColumn = null;      // 排序的欄位，null 表示沒排序
        private bool _sortDescending = false;   // true 是由大到小

        // 上傳區
        private bool _busy = false;             // 匯入中
        private string _pendingFile = null;     // 選好但還沒上傳的檔案，null 表示沒選
        private const string DropZoneText = "將 CSV 檔案拖曳到此處，或點擊選擇檔案";

        public frmMain()
        {
            InitializeComponent();

            // 重新繫結資料後取消選取
            dgvContracts.DataBindingComplete += dgvContracts_DataBindingComplete;

            // 表格沒資料時自己畫提示文字
            dgvContracts.Paint += dgvContracts_Paint;

            // 排序由程式處理，不用表格內建的(內建的只會排目前這一頁)
            foreach (DataGridViewColumn column in dgvContracts.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        // 重新繫結後取消選取，不然第一列的選取色會蓋掉維持率的底色
        private void dgvContracts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvContracts.ClearSelection();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboPageSize.SelectedIndex = 0;      // 預設每頁 20 筆
            RefreshData();
        }

        // 勾選「僅顯示異常」：條件在 SQL 裡，所以要重新查資料庫
        private void chkOnlyAbnormal_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        // ---------- 篩選 ----------

        // 輸入搜尋文字時馬上篩選
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // 點色塊：只看那個狀態，再點一次取消
        private void tile_Click(object sender, EventArgs e)
        {
            // 三個色塊共用這個事件，用 sender 判斷點的是哪一個
            string status = "Normal";
            if (sender == lblCall)
                status = "Call";
            else if (sender == lblWarning)
                status = "Warning";

            // 再點同一個就取消篩選
            if (_statusFilter == status)
                _statusFilter = null;
            else
                _statusFilter = status;

            // 「僅顯示異常」不包含正常的合約，點「正常」時先取消勾選
            if (_statusFilter == "Normal" && chkOnlyAbnormal.Checked)
            {
                chkOnlyAbnormal.Checked = false;    // 會重新載入資料
                return;                             // 重新載入時會自己篩選
            }
            ApplyFilter();
        }

        // 依色塊和搜尋文字設定篩選條件，然後回到第一頁
        private void ApplyFilter()
        {
            if (_view == null) return;      // 資料還沒載入

            var filters = new List<string>();
            if (_statusFilter != null)
                filters.Add("rate_status = '" + _statusFilter + "'");   // 固定值，不是使用者輸入

            string keyword = txtSearch.Text.Trim();
            if (keyword.Length > 0)
            {
                // 搜尋文字要先處理過，不然輸入 [ 或 ' 會出錯
                string safe = EscapeLike(keyword);
                filters.Add("(Contract_No LIKE '%" + safe + "%' OR Stock_ID LIKE '%" + safe + "%')");
            }
            _view.RowFilter = string.Join(" AND ", filters);    // 沒有條件就是不篩選

            // 有篩選的色塊加框
            lblCall.BorderStyle = _statusFilter == "Call" ? BorderStyle.FixedSingle : BorderStyle.None;
            lblWarning.BorderStyle = _statusFilter == "Warning" ? BorderStyle.FixedSingle : BorderStyle.None;
            lblNormal.BorderStyle = _statusFilter == "Normal" ? BorderStyle.FixedSingle : BorderStyle.None;

            _pageIndex = 0;
            BindPage();
        }

        // 處理搜尋文字：單引號要寫兩個，[ ] % * 要用中括號包起來，不然會被當成特殊符號
        private static string EscapeLike(string keyword)
        {
            var sb = new StringBuilder();
            foreach (char c in keyword)
            {
                if (c == '\'')
                    sb.Append("''");
                else if (c == '[' || c == ']' || c == '%' || c == '*')
                    sb.Append("[" + c + "]");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        // ---------- 分頁 ----------

        // 總頁數，沒資料也算 1 頁
        private int PageCount
        {
            get
            {
                int pages = _view.Count / _pageSize;            // 整數相除會捨去小數
                if (_view.Count % _pageSize != 0) pages++;      // 有餘數就多一頁
                if (pages < 1) pages = 1;
                return pages;
            }
        }

        // 只把目前這一頁的資料放進表格
        private void BindPage()
        {
            if (_view == null) return;

            // 頁碼不能超出範圍(篩選後頁數可能變少)
            if (_pageIndex > PageCount - 1) _pageIndex = PageCount - 1;
            if (_pageIndex < 0) _pageIndex = 0;
            int start = _pageIndex * _pageSize;                 // 這一頁的第一筆
            int end = start + _pageSize;                        // 這一頁最後一筆的下一個位置
            if (end > _view.Count) end = _view.Count;           // 最後一頁可能不滿

            // 複製表格結構，再放入這一頁的資料列
            DataTable page = _contracts.Clone();
            for (int i = start; i < end; i++)
                page.ImportRow(_view[i].Row);
            dgvContracts.DataSource = page;
            UpdateSortGlyphs();

            // 第一頁不能按「第一頁」「上一頁」，最後一頁不能按「下一頁」「最後一頁」
            lblPage.Text = string.Format("第 {0:N0} / {1:N0} 頁", _pageIndex + 1, PageCount);
            btnFirst.Enabled = _pageIndex > 0;
            btnPrev.Enabled = _pageIndex > 0;
            btnNext.Enabled = _pageIndex < PageCount - 1;
            btnLast.Enabled = _pageIndex < PageCount - 1;

            // 狀態列顯示目前是第幾筆到第幾筆
            string range = _view.Count == 0
                ? "共 0 筆"
                : string.Format("第 {0:N0}–{1:N0} 筆，共 {2:N0} 筆", start + 1, end, _view.Count);
            if (_view.Count != _totalCount)
                range += string.Format("(篩選自 {0:N0} 筆)", _totalCount);     // 有篩選時補上原本的總筆數
            tslCount.Text = range;
        }

        // 換頁按鈕(頁碼超出範圍時 BindPage 會自己修正)
        private void btnFirst_Click(object sender, EventArgs e) { _pageIndex = 0; BindPage(); }
        private void btnPrev_Click(object sender, EventArgs e) { _pageIndex--; BindPage(); }
        private void btnNext_Click(object sender, EventArgs e) { _pageIndex++; BindPage(); }
        private void btnLast_Click(object sender, EventArgs e) { _pageIndex = PageCount - 1; BindPage(); }

        // 改每頁筆數後回到第一頁
        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageSize = int.Parse(cboPageSize.Text);
            _pageIndex = 0;
            BindPage();
        }

        // 點欄位標題排序：第一次由小到大，再點一次由大到小
        private void dgvContracts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 用綁定的資料欄位名稱，不是標題文字
            string column = dgvContracts.Columns[e.ColumnIndex].DataPropertyName;

            // 點同一欄就換方向，換欄位就從由小到大開始
            if (_sortColumn == column)
                _sortDescending = !_sortDescending;
            else
                _sortDescending = false;
            _sortColumn = column;
            ApplySort();
            _pageIndex = 0;
            BindPage();
        }

        // 設定排序(排的是全部資料，不是只有這一頁)
        private void ApplySort()
        {
            if (_view == null) return;

            if (_sortColumn == null)
            {
                _view.Sort = "";
                return;
            }

            // 欄位名稱用中括號包起來
            string sort = "[" + _sortColumn + "]";
            if (_sortDescending)
                sort += " DESC";
            else
                sort += " ASC";
            if (_sortColumn != "Contract_No")
                sort += ", Contract_No";      // 值一樣時用合約編號排，順序才固定
            _view.Sort = sort;
        }

        // 重新繫結後排序箭頭會不見，要再設一次
        private void UpdateSortGlyphs()
        {
            foreach (DataGridViewColumn c in dgvContracts.Columns)
            {
                if (c.DataPropertyName != _sortColumn)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                else if (_sortDescending)
                    c.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                else
                    c.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
        }

        // ---------- CSV 上傳 ----------
        // 先選檔(拖曳或點擊)，檔案會暫存起來；按「上傳」才匯入，按「取消」就放棄

        // 拖曳經過上傳區時換底色
        private void SetDragOver(bool value)
        {
            lblDropZone.BackColor = value ? Color.AliceBlue : SystemColors.Control;
        }

        // 檔案拖進上傳區：匯入中或拖的不是檔案就不接受
        private void lblDropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (!_busy && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                SetDragOver(true);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // 拖出上傳區，底色還原
        private void lblDropZone_DragLeave(object sender, EventArgs e)
        {
            SetDragOver(false);
        }

        // 放開檔案：交給 StageFiles 檢查並暫存
        private void lblDropZone_DragDrop(object sender, DragEventArgs e)
        {
            SetDragOver(false);

            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || files.Length == 0) return;

            StageFiles(files);
        }

        // 點上傳區：開啟檔案選擇視窗
        private void lblDropZone_Click(object sender, EventArgs e)
        {
            if (_busy) return;

            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "選擇收盤價 CSV";
                dlg.Filter = "CSV 檔案 (*.csv)|*.csv";
                dlg.Multiselect = false;       // 一次只能選一份
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                StageFiles(dlg.FileNames);
            }
        }

        // 檢查檔案(只能一份、要是 .csv)，通過就暫存並顯示「上傳」「取消」按鈕
        private void StageFiles(string[] paths)
        {
            if (_busy || paths == null || paths.Length == 0) return;

            // 一次只能上傳一份
            if (paths.Length > 1)
            {
                ShowWarning("一次只能上傳一份 CSV 檔案");
                return;
            }

            string path = paths[0];
            if (!string.Equals(System.IO.Path.GetExtension(path), ".csv", StringComparison.OrdinalIgnoreCase))
            {
                ShowWarning("只支援 .csv 檔案");
                return;
            }

            // 重新選檔會取代原本暫存的
            _pendingFile = path;

            lblDropZone.Text = "已選擇檔案：" + System.IO.Path.GetFileName(path);
            lblDropZone.ForeColor = Color.SteelBlue;
            btnUpload.Visible = btnCancel.Visible = true;
            tslStatus.Text = "請按「上傳」匯入，或按「取消」放棄";
        }

        // 選檔時的警告視窗
        private void ShowWarning(string message)
        {
            MessageBox.Show(this, message, "選擇檔案", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // 清除暫存的檔案，上傳區回到預設文字
        private void ClearPending()
        {
            _pendingFile = null;
            btnUpload.Visible = btnCancel.Visible = false;
            RestoreDropZone();
        }

        // 上傳區還原成預設文字
        private void RestoreDropZone()
        {
            lblDropZone.Text = DropZoneText;
            lblDropZone.ForeColor = SystemColors.ControlText;
        }

        // 按「取消」：放棄選好的檔案
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_busy) return;

            ClearPending();
            tslStatus.Text = "已取消，未匯入任何檔案";
        }

        // 按「上傳」：解析 CSV → 沒有錯誤才寫入資料庫 → 重新載入畫面
        // 用 async / await 讓匯入時畫面不會卡住：Task.Run 在背景做事，await 等它做完
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            if (_busy || _pendingFile == null) return;

            // 先記下路徑再清掉暫存
            string path = _pendingFile;
            string fileName = System.IO.Path.GetFileName(path);
            ClearPending();

            _busy = true;       // 匯入中不能再選檔或拖曳
            UseWaitCursor = true;
            lblDropZone.Text = "匯入中…" + fileName;
            tslStatus.Text = "匯入中…";

            try
            {
                CsvParseResult parsed = await Task.Run(() => CsvPriceParser.Parse(path));
                if (parsed.Errors.Count > 0)
                {
                    // 有錯誤就整份不匯入，視窗最多列 5 項
                    string message = fileName + "：CSV 有錯誤，整份未匯入" + Environment.NewLine
                        + string.Join(Environment.NewLine, parsed.Errors.Take(5));
                    if (parsed.Errors.Count > 5)
                        message += Environment.NewLine + "…(共 " + parsed.Errors.Count + " 項錯誤)";
                    ShowImportFailure(message);
                    return;
                }

                // 寫入資料庫，回傳一列結果：Msg_status、Msg、新增／更新／略過的筆數
                DataTable importResult = await Task.Run(() => _repo.ImportPrices(fileName, parsed.Prices));
                DataRow result = importResult.Rows[0];
                if ((string)result["Msg_status"] != "Success")
                {
                    ShowImportFailure(fileName + "：" + result["Msg"]);
                    return;
                }

                // 切到這份檔案的日期並重新載入
                _tradeDate = parsed.TradeDate;
                RefreshData();

                int inserted = Convert.ToInt32(result["Inserted_Rows"]);
                int updated = Convert.ToInt32(result["Updated_Rows"]);
                int skipped = Convert.ToInt32(result["Skipped_Rows"]);
                tslStatus.Text = string.Format("匯入完成：新增 {0} 筆、更新 {1} 筆、略過 {2} 筆", inserted, updated, skipped);
                if (inserted + updated == 0)
                    tslStatus.Text += "(內容與資料庫相同，重複上傳不會產生重複資料)";

                // 上傳區也顯示結果，下次選檔或取消時會換掉
                if (inserted + updated == 0)
                    lblDropZone.Text = string.Format("內容與資料庫相同，沒有變動(略過 {0} 筆)", skipped);
                else
                    lblDropZone.Text = string.Format("匯入成功：新增 {0} 筆、更新 {1} 筆、略過 {2} 筆", inserted, updated, skipped);
                lblDropZone.ForeColor = Color.SeaGreen;
            }
            catch (Exception ex)
            {
                // 讀檔失敗、連不上資料庫等
                ShowImportFailure(fileName + "：" + ex.Message);
            }
            finally
            {
                _busy = false;      // 成功、失敗或中途 return 都會執行這裡
                UseWaitCursor = false;
            }
        }

        // 匯入失敗：狀態列和上傳區顯示失敗，原因用視窗顯示
        private void ShowImportFailure(string message)
        {
            tslStatus.Text = "匯入失敗";
            lblDropZone.Text = "匯入失敗，請看提示視窗";
            lblDropZone.ForeColor = Color.Firebrick;
            MessageBox.Show(this, message, "匯入失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // 表格沒資料時顯示原因：還沒匯入收盤價，或是沒有符合條件的合約
        private void dgvContracts_Paint(object sender, PaintEventArgs e)
        {
            if (dgvContracts.Rows.Count > 0) return;

            string text = _hasPrices ? "查無符合條件的合約" : "尚未匯入收盤價，請先上傳 CSV";

            // 畫在標題列下方，靠左上
            e.Graphics.DrawString(text, _emptyHintFont, Brushes.Gray, 20, dgvContracts.ColumnHeadersHeight + 20);
        }

        // ---------- 維持率顏色 ----------

        // 設定儲存格的顏色和文字，只改顯示，不改資料
        private void dgvContracts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;     // -1 是標題列

            // 取得這一列的維持率狀態(Call / Warning / Normal)
            var row = dgvContracts.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;
            string status = row["rate_status"] as string;
            string column = dgvContracts.Columns[e.ColumnIndex].DataPropertyName;   // 用綁定的欄位名稱判斷

            if (column == "Maintenance_Rate")
            {
                // 維持率底色：小於 120% 紅、小於 140% 黃、其他綠(狀態是資料庫算好的)
                switch (status)
                {
                    case "Call": e.CellStyle.BackColor = Color.IndianRed; break;
                    case "Warning": e.CellStyle.BackColor = Color.Gold; break;
                    default: e.CellStyle.BackColor = Color.LightGreen; break;
                }

                // 選取時也用同一個顏色，不然看不出紅黃綠
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                e.CellStyle.SelectionForeColor = Color.Black;
            }
            else if (column == "rate_status")
            {
                // 資料庫存英文，畫面顯示中文
                switch (status)
                {
                    case "Call": e.Value = "處置"; break;
                    case "Warning": e.Value = "預警"; break;
                    default: e.Value = "正常"; break;
                }
                e.FormattingApplied = true;
            }
        }

        // ---------- 載入資料 ----------

        // 從資料庫重新載入畫面：儀表板 → 資料日期 → 合約表格
        // 開啟視窗、勾選「僅顯示異常」、匯入成功後都會呼叫
        private void RefreshData()
        {
            try
            {
                // 儀表板(_tradeDate 是 null 時取最新一天)
                DataRow d = _repo.GetDashboard(_tradeDate).Rows[0];
                lblNormal.Text = "正常 (≥ 140%)" + Environment.NewLine + d["Normal_Cnt"];
                lblWarning.Text = "預警 (< 140%)" + Environment.NewLine + d["Warning_Cnt"];
                lblCall.Text = "處置 (< 120%)" + Environment.NewLine + d["Call_Cnt"];
                _totalCount = Convert.ToInt32(d["Total_Cnt"]);

                // 資料日期(還沒有價格時是空值)
                _hasPrices = d["Trade_Date"] != DBNull.Value;
                DateTime? tradeDate = null;
                if (_hasPrices)
                {
                    tradeDate = (DateTime)d["Trade_Date"];
                    lblTradeDate.Text = "資料日期：" + tradeDate.Value.ToString("yyyy-MM-dd");
                    lblTradeDate.ForeColor = SystemColors.ControlText;
                    tslStatus.Text = "就緒";
                }
                else
                {
                    lblTradeDate.Text = "資料日期：尚未匯入收盤價";
                    lblTradeDate.ForeColor = Color.Firebrick;       // 沒有價格算不出維持率，用紅字提醒
                    tslStatus.Text = "尚未匯入收盤價，請上傳 CSV";
                }

                // 合約表格：用上面查到的日期，這樣色塊和表格才會是同一天
                _contracts = _repo.GetContracts(tradeDate, chkOnlyAbnormal.Checked);
                _view = _contracts.DefaultView;
                ApplySort();        // 沿用目前的排序
                ApplyFilter();      // 會回到第一頁並顯示
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "載入失敗");
            }
        }
    }
}
