using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
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

                    //decimal discountPer = GetDiscountPer(customerCode, priceDate);

                    int classId = CustomerController.GetCustomerClassId(customerCode, priceDate);

                    sql = @"select COALESCE(unit_price, 0) as unit_price
                         from customer_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                             and customer_code =@customer_code
                            order by start_date desc LIMIT 1 ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", priceDate.ToString("yyyy-MM-dd"));
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                        {
                            decimal unitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"];
                            //if (discountPer > 0)
                            //{
                            //    unitPrice = unitPrice - (Math.Round((unitPrice * discountPer) / 100, 2));
                            //}
                            return unitPrice;
                        }
                    }

                    sql = @"select COALESCE(unit_price, 0) as unit_price
                         from customer_class_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                             and class_id =@class_id
                            order by start_date desc LIMIT 1 ";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", classId);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", priceDate.ToString("yyyy-MM-dd"));
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                        {
                            decimal unitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"];
                            //if (discountPer > 0)
                            //{
                            //    unitPrice = unitPrice - (Math.Round((unitPrice * discountPer) / 100, 2));
                            //}
                            return unitPrice;
                        }
                    }

                    sql = @"select COALESCE(unit_price, 0) as unit_price
                         from customer_class_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                             and class_id =@class_id
                            order by start_date desc LIMIT 1 ";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", 1);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", priceDate.ToString("yyyy-MM-dd"));
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                        {
                            decimal unitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"];
                            //if (discountPer > 0)
                            //{
                            //    unitPrice = unitPrice - (Math.Round((unitPrice * discountPer) / 100, 2));
                            //}
                            return unitPrice;
                        }
                    }

                    return 0;

                    //####### Product price, now not use
                    //sql = @"select COALESCE(unit_price, 0) as unit_price
                    //     from product_price p
                    //        where start_date <=@start_date
                    //         and end_date >=@end_date
                    //         and product_code =@product_code
                    //        order by start_date desc LIMIT 1 ";
                    //cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("product_code", productCode);
                    //cmd.Parameters.AddWithValue("start_date", priceDate);
                    //cmd.Parameters.AddWithValue("end_date", priceDate);
                    //da = new MySqlDataAdapter(cmd);
                    //ds = new DataSet();
                    //da.Fill(ds);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                    //    {
                    //        decimal unitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"];
                    //        //if (discountPer > 0)
                    //        //{
                    //        //    unitPrice = unitPrice - (Math.Round((unitPrice * discountPer) / 100, 2));
                    //        //}
                    //        return unitPrice;
                    //    }
                    //    else
                    //    {
                    //        return 0;
                    //    }
                    //}
                    //else
                    //{
                    //    return 0;
                    //}
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static decimal GetPriceListCurrent(string customerCode, string productCode, DateTime priceDate)
        {
            try
            {
                using (var conn = new MySqlConnection(CONN_STR))
                {
                    conn.Open();
                    var sql = "";
                    sql = @"select COALESCE(unit_price, 0) as unit_price
                         from customer_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                             and customer_code =@customer_code
                            order by end_date asc LIMIT 1 ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", priceDate.ToString("yyyy-MM-dd"));
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                        {
                            decimal unitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"];
                            return unitPrice;
                        }
                    }

                    sql = @"select COALESCE(unit_price, 0) as unit_price
                         from product_price p
                            where start_date <=@start_date
                             and end_date >=@end_date
                             and product_code =@product_code
                            order by end_date asc LIMIT 1 ";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", priceDate.ToString("yyyy-MM-dd"));
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["unit_price"]) > 0)
                        {
                            decimal unitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"];
                            return unitPrice;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static decimal GetDiscountPer(string customerCode, DateTime priceDate)
        {
            try
            {
                using (var conn = new MySqlConnection(CONN_STR))
                {
                    conn.Open();
                    var sql = "";

                    decimal discountPer = 0;
                    sql = @"SELECT COALESCE(dis.discount_per, 0) as discount_per
                            FROM slaughterhouse.customer_class_discount dis, customer cv
                            where dis.start_date <=@start_date
                                and dis.end_date >=@end_date
                                and cv.customer_code = @customer_code
                                and dis.class_id = cv.class_id
                            order by dis.end_date asc LIMIT 1 ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("start_date", priceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", priceDate.ToString("yyyy-MM-dd"));
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["discount_per"]) > 0)
                        {
                            discountPer = (decimal)ds.Tables[0].Rows[0]["discount_per"];
                            return discountPer;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
