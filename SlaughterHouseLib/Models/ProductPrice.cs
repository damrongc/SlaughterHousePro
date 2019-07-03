using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class ProductPrice
    {
        public Product Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Day { get; set; }
        public decimal UnitPrice { get; set; }
        public string SaleUnitMethod { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class ProductPriceController
    {
        public static object GetAllProductPrices(DateTime startDate, string productCode = "")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();



                    sb.Append("SELECT a.product_code,");
                    sb.Append(" b.product_name,");
                    sb.Append(" a.start_date,");
                    sb.Append(" a.end_date,");
                    sb.Append(" a.unit_price,");
                    sb.Append(" a.sale_unit_method,");
                    sb.Append(" a.end_date - a.start_date as day,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by");
                    sb.Append(" FROM product_price a, product b");
                    sb.Append(" WHERE a.product_code =b.product_code");
                    sb.Append(" AND a.start_date =@start_date");
                    if (!string.IsNullOrEmpty(productCode))
                        sb.Append(" AND a.product_code =@product_code");
                    sb.Append(" ORDER BY a.start_date, a.product_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(productCode))
                        cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ProductCode = p.Field<int>("product_code"),
                                    ProductName = p.Field<string>("product_name"),
                                    StartDate = p.Field<DateTime>("start_date"),
                                    EndDate = p.Field<DateTime>("end_date"),
                                    UnitPrice = p.Field<decimal>("unit_price"),
                                    SaleUnitMethod = p.Field<string>("sale_unit_method"),
                                    Day = p.Field<int>("day"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                }).ToList();
                    return coll;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ProductPrice GetAllProductPrice(string productCode, DateTime startDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();

                    sb.Append("SELECT a.product_code,");
                    sb.Append(" b.product_name,");
                    sb.Append(" a.start_date,");
                    sb.Append(" a.end_date,");
                    sb.Append(" a.unit_price,");
                    sb.Append(" a.sale_unit_method,");
                    sb.Append(" a.end_date - a.start_date as day,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by");
                    sb.Append(" FROM product_price a, product b");
                    sb.Append(" WHERE a.product_code =b.product_code");
                    sb.Append(" AND a.start_date =@start_date");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new ProductPrice
                        {
                            Product = new Product
                            {
                                ProductCode = (string)ds.Tables[0].Rows[0]["product_code"],
                                ProductName = (string)ds.Tables[0].Rows[0]["product_name"],
                            },
                            StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"],
                            EndDate = (DateTime)ds.Tables[0].Rows[0]["end_date"],
                            UnitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"],
                            SaleUnitMethod = (string)ds.Tables[0].Rows[0]["sale_unit_method"],
                            CreateAt = (DateTime)ds.Tables[0].Rows[0]["create_at"],
                        };
                    }
                    else
                    {
                        return null;
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