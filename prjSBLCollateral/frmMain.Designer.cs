namespace prjSBLCollateral
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlUpload = new System.Windows.Forms.TableLayoutPanel();
            this.lblDropZone = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCall = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblNormal = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkOnlyAbnormal = new System.Windows.Forms.CheckBox();
            this.lblTradeDate = new System.Windows.Forms.Label();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.colContractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCollateral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPager = new System.Windows.Forms.TableLayoutPanel();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.tslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMain.SuspendLayout();
            this.pnlUpload.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.pnlPager.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.pnlUpload, 0, 1);
            this.tlpMain.Controls.Add(this.lblCall, 2, 0);
            this.tlpMain.Controls.Add(this.lblWarning, 1, 0);
            this.tlpMain.Controls.Add(this.lblNormal, 0, 0);
            this.tlpMain.Controls.Add(this.pnlToolbar, 0, 2);
            this.tlpMain.Controls.Add(this.dgvContracts, 0, 3);
            this.tlpMain.Controls.Add(this.pnlPager, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpMain.Size = new System.Drawing.Size(1200, 737);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlUpload
            // 
            this.pnlUpload.ColumnCount = 3;
            this.tlpMain.SetColumnSpan(this.pnlUpload, 3);
            this.pnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlUpload.Controls.Add(this.lblDropZone, 0, 0);
            this.pnlUpload.Controls.Add(this.btnUpload, 1, 0);
            this.pnlUpload.Controls.Add(this.btnCancel, 2, 0);
            this.pnlUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpload.Location = new System.Drawing.Point(12, 115);
            this.pnlUpload.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlUpload.Name = "pnlUpload";
            this.pnlUpload.RowCount = 1;
            this.pnlUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlUpload.Size = new System.Drawing.Size(1176, 42);
            this.pnlUpload.TabIndex = 3;
            // 
            // lblDropZone
            // 
            this.lblDropZone.AllowDrop = true;
            this.lblDropZone.AutoEllipsis = true;
            this.lblDropZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDropZone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDropZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDropZone.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDropZone.Location = new System.Drawing.Point(0, 0);
            this.lblDropZone.Margin = new System.Windows.Forms.Padding(0);
            this.lblDropZone.Name = "lblDropZone";
            this.lblDropZone.Size = new System.Drawing.Size(974, 42);
            this.lblDropZone.TabIndex = 3;
            this.lblDropZone.Text = "將 CSV 檔案拖曳到此處，或點擊選擇檔案";
            this.lblDropZone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDropZone.Click += new System.EventHandler(this.lblDropZone_Click);
            this.lblDropZone.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblDropZone_DragDrop);
            this.lblDropZone.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblDropZone_DragEnter);
            this.lblDropZone.DragLeave += new System.EventHandler(this.lblDropZone_DragLeave);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpload.AutoSize = true;
            this.btnUpload.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUpload.Location = new System.Drawing.Point(984, 3);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUpload.MinimumSize = new System.Drawing.Size(92, 36);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(92, 36);
            this.btnUpload.TabIndex = 8;
            this.btnUpload.Text = "上傳";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(1084, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(92, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 36);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCall
            // 
            this.lblCall.BackColor = System.Drawing.Color.IndianRed;
            this.lblCall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCall.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCall.Location = new System.Drawing.Point(799, 15);
            this.lblCall.Margin = new System.Windows.Forms.Padding(5);
            this.lblCall.Name = "lblCall";
            this.lblCall.Size = new System.Drawing.Size(384, 90);
            this.lblCall.TabIndex = 2;
            this.lblCall.Text = "處置 (< 120%)";
            this.lblCall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCall.Click += new System.EventHandler(this.tile_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.Gold;
            this.lblWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarning.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWarning.Location = new System.Drawing.Point(408, 15);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(5);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(381, 90);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "預警 (< 140%)";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarning.Click += new System.EventHandler(this.tile_Click);
            // 
            // lblNormal
            // 
            this.lblNormal.BackColor = System.Drawing.Color.LightGreen;
            this.lblNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNormal.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNormal.Location = new System.Drawing.Point(17, 15);
            this.lblNormal.Margin = new System.Windows.Forms.Padding(5);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(381, 90);
            this.lblNormal.TabIndex = 0;
            this.lblNormal.Text = "正常 (≥ 140%)";
            this.lblNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNormal.Click += new System.EventHandler(this.tile_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.ColumnCount = 5;
            this.tlpMain.SetColumnSpan(this.pnlToolbar, 3);
            this.pnlToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.pnlToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlToolbar.Controls.Add(this.lblSearch, 0, 0);
            this.pnlToolbar.Controls.Add(this.txtSearch, 1, 0);
            this.pnlToolbar.Controls.Add(this.chkOnlyAbnormal, 2, 0);
            this.pnlToolbar.Controls.Add(this.lblTradeDate, 4, 0);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToolbar.Location = new System.Drawing.Point(12, 162);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.RowCount = 1;
            this.pnlToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlToolbar.Size = new System.Drawing.Size(1176, 44);
            this.pnlToolbar.TabIndex = 5;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearch.Location = new System.Drawing.Point(0, 3);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(201, 38);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "搜尋合約編號或標的代碼：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSearch.Location = new System.Drawing.Point(207, 7);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(334, 29);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // chkOnlyAbnormal
            // 
            this.chkOnlyAbnormal.AutoSize = true;
            this.chkOnlyAbnormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOnlyAbnormal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkOnlyAbnormal.Location = new System.Drawing.Point(571, 3);
            this.chkOnlyAbnormal.Margin = new System.Windows.Forms.Padding(24, 3, 0, 3);
            this.chkOnlyAbnormal.Name = "chkOnlyAbnormal";
            this.chkOnlyAbnormal.Size = new System.Drawing.Size(108, 38);
            this.chkOnlyAbnormal.TabIndex = 8;
            this.chkOnlyAbnormal.Text = "僅顯示異常";
            this.chkOnlyAbnormal.UseVisualStyleBackColor = true;
            this.chkOnlyAbnormal.CheckedChanged += new System.EventHandler(this.chkOnlyAbnormal_CheckedChanged);
            // 
            // lblTradeDate
            // 
            this.lblTradeDate.AutoSize = true;
            this.lblTradeDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTradeDate.Font = new System.Drawing.Font("微軟正黑體", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTradeDate.Location = new System.Drawing.Point(1087, 0);
            this.lblTradeDate.Name = "lblTradeDate";
            this.lblTradeDate.Size = new System.Drawing.Size(86, 44);
            this.lblTradeDate.TabIndex = 5;
            this.lblTradeDate.Text = "資料日期:";
            this.lblTradeDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvContracts
            // 
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToResizeRows = false;
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContracts.BackgroundColor = System.Drawing.Color.White;
            this.dgvContracts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvContracts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContracts.ColumnHeadersHeight = 34;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContractNo,
            this.colStockId,
            this.colQty,
            this.colCollateral,
            this.colPrice,
            this.colRate,
            this.colStatus});
            this.tlpMain.SetColumnSpan(this.dgvContracts, 3);
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(228)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContracts.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContracts.EnableHeadersVisualStyles = false;
            this.dgvContracts.GridColor = System.Drawing.Color.Silver;
            this.dgvContracts.Location = new System.Drawing.Point(12, 212);
            this.dgvContracts.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            this.dgvContracts.RowHeadersVisible = false;
            this.dgvContracts.RowTemplate.Height = 30;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.Size = new System.Drawing.Size(1176, 473);
            this.dgvContracts.TabIndex = 6;
            this.dgvContracts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvContracts_CellFormatting);
            this.dgvContracts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContracts_ColumnHeaderMouseClick);
            // 
            // colContractNo
            // 
            this.colContractNo.DataPropertyName = "Contract_No";
            this.colContractNo.FillWeight = 140F;
            this.colContractNo.HeaderText = "合約編號";
            this.colContractNo.Name = "colContractNo";
            this.colContractNo.ReadOnly = true;
            // 
            // colStockId
            // 
            this.colStockId.DataPropertyName = "Stock_ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStockId.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStockId.FillWeight = 70F;
            this.colStockId.HeaderText = "標的代碼";
            this.colStockId.Name = "colStockId";
            this.colStockId.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Borrowed_Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQty.FillWeight = 90F;
            this.colQty.HeaderText = "借出數量(張)";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colCollateral
            // 
            this.colCollateral.DataPropertyName = "Collateral_Val";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colCollateral.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCollateral.FillWeight = 130F;
            this.colCollateral.HeaderText = "擔保品總市值";
            this.colCollateral.Name = "colCollateral";
            this.colCollateral.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Closing_Price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPrice.FillWeight = 80F;
            this.colPrice.HeaderText = "收盤價";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colRate
            // 
            this.colRate.DataPropertyName = "Maintenance_Rate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.Format = "N2";
            this.colRate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colRate.FillWeight = 90F;
            this.colRate.HeaderText = "維持率 (%)";
            this.colRate.Name = "colRate";
            this.colRate.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "rate_status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.colStatus.FillWeight = 70F;
            this.colStatus.HeaderText = "狀態";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // pnlPager
            // 
            this.pnlPager.ColumnCount = 8;
            this.tlpMain.SetColumnSpan(this.pnlPager, 3);
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlPager.Controls.Add(this.lblPageSize, 1, 0);
            this.pnlPager.Controls.Add(this.cboPageSize, 2, 0);
            this.pnlPager.Controls.Add(this.btnFirst, 3, 0);
            this.pnlPager.Controls.Add(this.btnPrev, 4, 0);
            this.pnlPager.Controls.Add(this.lblPage, 5, 0);
            this.pnlPager.Controls.Add(this.btnNext, 6, 0);
            this.pnlPager.Controls.Add(this.btnLast, 7, 0);
            this.pnlPager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPager.Location = new System.Drawing.Point(12, 685);
            this.pnlPager.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.RowCount = 1;
            this.pnlPager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPager.Size = new System.Drawing.Size(1176, 44);
            this.pnlPager.TabIndex = 7;
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPageSize.Location = new System.Drawing.Point(537, 13);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(78, 18);
            this.lblPageSize.TabIndex = 0;
            this.lblPageSize.Text = "每頁筆數：";
            // 
            // cboPageSize
            // 
            this.cboPageSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageSize.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "200"});
            this.cboPageSize.Location = new System.Drawing.Point(621, 9);
            this.cboPageSize.Margin = new System.Windows.Forms.Padding(3, 3, 24, 3);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(70, 26);
            this.cboPageSize.TabIndex = 1;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFirst.AutoSize = true;
            this.btnFirst.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFirst.Location = new System.Drawing.Point(718, 7);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.btnFirst.Size = new System.Drawing.Size(75, 30);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Text = "第一頁";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrev.AutoSize = true;
            this.btnPrev.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrev.Location = new System.Drawing.Point(799, 7);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.btnPrev.Size = new System.Drawing.Size(75, 30);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "上一頁";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblPage
            // 
            this.lblPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPage.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPage.Location = new System.Drawing.Point(880, 12);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(120, 20);
            this.lblPage.TabIndex = 4;
            this.lblPage.Text = "第 1 / 1 頁";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.AutoSize = true;
            this.btnNext.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNext.Location = new System.Drawing.Point(1006, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.btnNext.Size = new System.Drawing.Size(75, 30);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一頁";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLast.AutoSize = true;
            this.btnLast.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLast.Location = new System.Drawing.Point(1087, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.btnLast.Size = new System.Drawing.Size(86, 30);
            this.btnLast.TabIndex = 6;
            this.btnLast.Text = "最後一頁";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // tslCount
            // 
            this.tslCount.Name = "tslCount";
            this.tslCount.Size = new System.Drawing.Size(0, 18);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tslCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 737);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(1185, 18);
            this.tslStatus.Spring = true;
            this.tslStatus.Text = "就緒";
            this.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "借券擔保品維持率監控";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlUpload.ResumeLayout(false);
            this.pnlUpload.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.pnlPager.ResumeLayout(false);
            this.pnlPager.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel pnlToolbar;
        private System.Windows.Forms.TableLayoutPanel pnlPager;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.Label lblDropZone;
        private System.Windows.Forms.TableLayoutPanel pnlUpload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCall;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.CheckBox chkOnlyAbnormal;
        private System.Windows.Forms.Label lblTradeDate;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCollateral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}

