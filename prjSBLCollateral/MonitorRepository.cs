using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace prjSBLCollateral
{
    // 負責呼叫資料庫的預存程序
    public class MonitorRepository
    {
        // 從 App.config 讀連線字串
        private readonly string _connStr =  ConfigurationManager.ConnectionStrings["SBLCollateralDB"].ConnectionString;

        // 執行預存程序，把結果裝成表格回傳
        // spName 是預存程序名稱，parameters 是它需要的參數(個數不固定)
        private DataTable Run(string spName, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(_connStr))
            using (var cmd = new SqlCommand(spName, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);

                var table = new DataTable();
                adapter.Fill(table);      // 會自動開關連線，並把結果填進表格
                return table;
            }
        }

        // 日期是 null 時，要傳 DBNull.Value 給資料庫，不能直接傳 null
        private static object ToDbValue(DateTime? date)
        {
            if (date == null) return DBNull.Value;
            return date.Value;
        }

        // 儀表板：三種狀態的件數
        public DataTable GetDashboard(DateTime? tradeDate)
        {
            return Run("dbo.spGetDashboard",
                new SqlParameter("@TradeDate", ToDbValue(tradeDate)));
        }

        // 合約明細
        public DataTable GetContracts(DateTime? tradeDate, bool onlyAbnormal)
        {
            return Run("dbo.spGetContractMonitor",
                new SqlParameter("@TradeDate", ToDbValue(tradeDate)),
                new SqlParameter("@OnlyAbnormal", onlyAbnormal));
        }

        // 匯入 CSV 價格(欄位順序：Stock_ID、Closing_Price、Trade_Date)
        public DataTable ImportPrices(string fileName, DataTable prices)
        {
            return Run("dbo.spImportMarketPrice",
                new SqlParameter("@FileName", fileName),
                new SqlParameter("@Prices", SqlDbType.Structured)
                {
                    TypeName = "dbo.Market_Price_Type",
                    Value = prices
                });
        }
    }
}
