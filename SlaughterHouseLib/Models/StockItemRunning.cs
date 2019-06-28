using MySql.Data.MySqlClient;
using System.Data;

namespace SlaughterHouseLib.Models
{


    public class StockItemRunning
    {

        public string DocNo { get; set; }
        public string StockNo { get; set; }
        public int StockItem { get; set; }
    }

    public static class StockItemRunningController
    {
        public static StockItemRunning GetStockItem(string docNo)
        {
            var conn = new MySqlConnection(Globals.CONN_STR);
            StockItemRunning stockItemRunning = new StockItemRunning();
            try
            {
                var sql = @"SELECT stock_item,
                                   stock_no
                                FROM stock_item_running 
                                WHERE doc_no=@doc_no";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("doc_no", docNo);

                var da = new MySqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    stockItemRunning.StockItem = 1;
                    stockItemRunning.StockNo = DocumentGenerate.GetDocumentRunning("STK");
                }
                else
                {

                    stockItemRunning.StockItem = dt.Rows[0]["stock_item"].ToString().ToInt16() + 1;
                    stockItemRunning.StockNo = dt.Rows[0]["stock_no"].ToString();
                }
                return stockItemRunning;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
