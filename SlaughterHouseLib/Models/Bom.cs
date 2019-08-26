using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class Bom
    {
        public int BomCode { get; set; }
        public string ProductCode { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; } 
    }
    public class BomItem
    {
        public int BomCode { get; set; }
        public string ProductCode { get; set; }
        public int MutiplyQty { get; set; }
        public decimal MutiplyWgh { get; set; }
    }
    public static class BomController
    { 
        public static List<BomItem> GetBom(string productCode)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT distinct bi.bom_code, bi.product_code, Mutiply_Qty, Mutiply_wgh
                                    FROM bom b, bom_item bi
                                    Where b.product_code = @product_code
                                    and b.bom_code = bi.bom_code";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);


                    var bomItems = new List<BomItem>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        bomItems.Add(new BomItem
                        { 
                            BomCode = (int)ds.Tables[0].Rows[0]["breeder_code"],
                            ProductCode = ds.Tables[0].Rows[0]["product_code"].ToString(),
                            MutiplyQty = (int)ds.Tables[0].Rows[0]["Mutiply_Qty"],
                            MutiplyWgh = (decimal)ds.Tables[0].Rows[0]["Mutiply_wgh"],
                        });
                    }
                    return bomItems;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
 
    }
}
