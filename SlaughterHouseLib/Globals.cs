using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SlaughterHouseLib
{
    public static class Globals
    {
        public static string CONN_STR = System.Configuration.ConfigurationManager.AppSettings["connstr"].ToString();
        public static string FONT_FAMILY = "Kanit";
        public static float FONT_SIZE = 12;

        public static decimal GetPriceList(string customerCode, string productCode, DateTime priceDate)
        {
            try
            {
                using (var conn = new MySqlConnection(CONN_STR))
                {

                    conn.Open();
                    var sql = "";

                    sql = @"select COALESCE(unit_price) as unit_price
                         from customer_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                             and customer_code =@customer_code
                            order by end_date asc LIMIT 1 ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate);
                    cmd.Parameters.AddWithValue("end_date", priceDate);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                        {
                            return (decimal)ds.Tables[0].Rows[0]["unit_price"];
                        }
                    }

                    sql = @"select COALESCE(unit_price) as unit_price
                         from product_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                            order by end_date asc LIMIT 1 ";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate);
                    cmd.Parameters.AddWithValue("end_date", priceDate);

                    da = new MySqlDataAdapter(cmd);

                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return (decimal)ds.Tables[0].Rows[0]["unit_price"];
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
