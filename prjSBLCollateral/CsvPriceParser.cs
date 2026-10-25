using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

namespace prjSBLCollateral
{
    // CSV 解析結果
    // Prices 欄位的順序要和資料庫的 dbo.Market_Price_Type 一樣
    public class CsvParseResult
    {
        // 解析成功的資料列(Stock_ID、Closing_Price、Trade_Date)
        public DataTable Prices { get; } = CreatePriceTable();

        // 錯誤訊息，格式是「第 N 行：原因」，清單是空的才代表檔案沒問題
        public List<string> Errors { get; } = new List<string>();

        // 這份檔案的資料日期，沒有有效資料時是 null
        public DateTime? TradeDate { get; set; }

        // 建立空的價格表，欄位名稱和順序要跟資料庫的 TVP 一樣
        private static DataTable CreatePriceTable()
        {
            var table = new DataTable();
            table.Columns.Add("Stock_ID", typeof(string));
            table.Columns.Add("Closing_Price", typeof(decimal));    // 金額用 decimal，不用 double
            table.Columns.Add("Trade_Date", typeof(DateTime));
            return table;
        }
    }

    // 解析 Market_Price.csv(Stock_ID,Closing_Price,Trade_Date)
    // 第 1 行是標題列，一份檔案只能有一個交易日
    public static class CsvPriceParser
    {
        // 錯誤訊息最多記 50 筆，超過的不記，但還是會繼續解析
        private const int MaxErrors = 50;

        // 解析整份檔案，Errors 有內容就代表這份檔案不能用
        public static CsvParseResult Parse(string path)
        {
            var result = new CsvParseResult();

            // 記錄每支股票已經加入的那一列，同一支股票重複時用最後一筆
            var rowByStock = new Dictionary<string, DataRow>();

            // 這份檔案的日期，以第一筆有效資料為準
            DateTime? fileDate = null;

            // 第三個參數 true：檔案有 BOM 就自動判斷編碼
            using (var reader = new StreamReader(path, System.Text.Encoding.UTF8, true))
            {
                // 第 1 行一定要是標題列，不對就直接結束
                string header = reader.ReadLine();
                if (header == null || !IsHeader(header))
                {
                    AddError(result, 1, "標題列必須是 Stock_ID,Closing_Price,Trade_Date");
                    return result;
                }

                // 標題列是第 1 行，所以資料從第 2 行開始
                int lineNo = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNo++;
                    if (line.Trim().Length == 0) continue;      // 空白行略過

                    // 檢查這一行，error 是 null 才代表正確
                    string error = TryParseLine(line, out string stockId, out decimal price, out DateTime date);
                    if (error != null)
                    {
                        AddError(result, lineNo, error);    // 有錯的行不放進 Prices
                        continue;
                    }

                    // 一份檔案只能有一個日期，要和第一筆有效資料一樣
                    if (fileDate == null)
                    {
                        fileDate = date;
                    }
                    else if (date != fileDate)
                    {
                        AddError(result, lineNo, "Trade_Date " + date.ToString("yyyyMMdd")
                            + " 與第一列的 " + fileDate.Value.ToString("yyyyMMdd") + " 不同，一份檔案只能包含一個資料日期");
                        continue;
                    }

                    // 同一支股票出現多次，只留最後一筆
                    if (rowByStock.TryGetValue(stockId, out DataRow existing))
                    {
                        existing["Closing_Price"] = price;      // 已經有了，只改價格
                    }
                    else
                    {
                        // 第一次出現：新增一列並記下來(參數順序要和欄位順序一樣)
                        rowByStock[stockId] = result.Prices.Rows.Add(stockId, price, date);
                    }
                }
            }

            result.TradeDate = fileDate;

            // 只有標題列或全是空白行：沒有錯誤也沒有資料，要提醒使用者
            if (result.Errors.Count == 0 && result.Prices.Rows.Count == 0)
                result.Errors.Add("檔案沒有任何資料列");

            return result;
        }

        // 記錄一筆錯誤(最多 MaxErrors 筆)
        private static void AddError(CsvParseResult result, int lineNo, string message)
        {
            if (result.Errors.Count < MaxErrors)
                result.Errors.Add("第 " + lineNo + " 行：" + message);
        }

        // 標題列要剛好是 Stock_ID,Closing_Price,Trade_Date(不分大小寫)
        private static bool IsHeader(string line)
        {
            var cols = line.Split(',');
            return cols.Length == 3
                && cols[0].Trim().Equals("Stock_ID", StringComparison.OrdinalIgnoreCase)
                && cols[1].Trim().Equals("Closing_Price", StringComparison.OrdinalIgnoreCase)
                && cols[2].Trim().Equals("Trade_Date", StringComparison.OrdinalIgnoreCase);
        }

        // 檢查一行資料，回傳 null 代表正確，否則回傳錯誤原因
        // 解析出來的值用 out 傳回去，只有回傳 null 時才能用
        private static string TryParseLine(string line, out string stockId, out decimal price, out DateTime date)
        {
            // out 參數一定要先給值
            stockId = null;
            price = 0m;
            date = default(DateTime);

            // 用逗號切欄位，不支援欄位裡有逗號的格式(例如 "1,234")
            var cols = line.Split(',');
            if (cols.Length != 3) return "欄位數必須是 3 個";

            // 股票代號不能空白，最長 10 個字(和資料庫欄位一樣)
            stockId = cols[0].Trim();
            if (stockId.Length == 0) return "Stock_ID 不可空白";
            if (stockId.Length > 10) return "Stock_ID 長度不可超過 10";

            // 價格用 decimal 解析，只接受小數點(不接受 1,234 這種千分位)
            // InvariantCulture：小數點固定是 .，不受電腦地區設定影響
            // 沒有加正負號的選項，所以負數會被當成不是有效數字
            if (!decimal.TryParse(cols[1].Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price))
                return "Closing_Price「" + cols[1].Trim() + "」不是有效數字";
            if (price <= 0) return "Closing_Price 必須大於 0";

            // 最多 2 位小數(和資料庫欄位一樣)
            if (decimal.Round(price, 2) != price) return "Closing_Price 最多 2 位小數";

            // 日期格式固定是 yyyyMMdd，例如 20240105
            if (!DateTime.TryParseExact(cols[2].Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return "Trade_Date「" + cols[2].Trim() + "」格式必須是 yyyyMMdd";

            return null;
        }
    }
}
