using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class CustomerPrice
    {
        public Customer Customer { get; set; } 
        public Product Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Day { get; set; }
        public decimal UnitPrice { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class CustomerPriceController
    {
        public static object GetAllCustomerPrices(DateTime startDate, string productCode = "")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();



                    sb.Append("SELECT a.customer_code, c.customer_name, a.product_code,");
                    sb.Append(" b.product_name,");
                    sb.Append(" a.start_date,");
                    sb.Append(" a.end_date,");
                    sb.Append(" a.unit_price,"); 
                    sb.Append(" DATEDIFF(a.end_date, a.start_date) as day,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by");
                    sb.Append(" FROM customer_price a, product b, customer c");
                    sb.Append(" WHERE a.product_code = b.product_code ");
                    sb.Append(" AND a.customer_code = c.customer_code ");
                    sb.Append(" AND a.start_date <= '" + startDate.ToString("yyyy-MM-dd") + "'");
                    sb.Append(" AND a.end_date >= '" + startDate.ToString("yyyy-MM-dd") + "'");
                    if (!string.IsNullOrEmpty(productCode))
                        sb.Append(" AND a.product_code =@product_code");
                    sb.Append(" ORDER BY a.start_date, a.product_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(productCode))
                        cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                   var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    CustomerCode = p.Field<string>("customer_code"),
                                    CustomerName = p.Field<string>("customer_name"),
                                    ProductCode = p.Field<string>("product_code"),
                                    ProductName = p.Field<string>("product_name"),
                                    StartDate = p.Field<DateTime>("start_date"),
                                    EndDate = p.Field<DateTime>("end_date"),
                                    UnitPrice = p.Field<decimal>("unit_price"), 
                                    Day = p.Field<Int64>("day"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                }).ToList();
                    return coll;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static CustomerPrice GetCustomerPrice(string customerCode, string productCode, DateTime startDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();

                    sb.Append("SELECT a.customer_code, c.customer_name, a.product_code,");
                    sb.Append(" b.product_name,");
                    sb.Append(" a.start_date,");
                    sb.Append(" a.end_date,");
                    sb.Append(" a.unit_price,"); 
                    sb.Append(" DATEDIFF(a.end_date, a.start_date) as day,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by");
                    sb.Append(" FROM customer_price a, product b, customer c");
                    sb.Append(" WHERE a.product_code =b.product_code");
                    sb.Append(" AND a.customer_code =c.customer_code");
                    sb.Append(" AND a.customer_code =@customer_code");
                    sb.Append(" AND a.product_code =@product_code");
                    sb.Append(" AND a.start_date =@start_date");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new CustomerPrice
                        {
                            Customer = new Customer
                            {
                                CustomerCode = (string)ds.Tables[0].Rows[0]["customer_code"],
                                CustomerName = (string)ds.Tables[0].Rows[0]["customer_name"],
                            },
                            Product = new Product
                            {
                                ProductCode = (string)ds.Tables[0].Rows[0]["product_code"],
                                ProductName = (string)ds.Tables[0].Rows[0]["product_name"],
                            },
                            StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"],
                            EndDate = (DateTime)ds.Tables[0].Rows[0]["end_date"],
                            UnitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"], 
                            Day = (int)(Int64)ds.Tables[0].Rows[0]["day"],
                            CreateAt = (DateTime)ds.Tables[0].Rows[0]["create_at"],
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
        public static bool Insert(CustomerPrice customerPrice)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO customer_price
                                    (customer_code, product_code, start_date, end_date, 
                                    unit_price, create_by) 
                                    VALUES 
                                     (@customer_code, @product_code, @start_date, @end_date, 
                                    @unit_price, @create_by) ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerPrice.Customer.CustomerCode); 
                    cmd.Parameters.AddWithValue("product_code", customerPrice.Product.ProductCode);
                    cmd.Parameters.AddWithValue("start_date", customerPrice.StartDate);
                    cmd.Parameters.AddWithValue("end_date", customerPrice.EndDate);
                    cmd.Parameters.AddWithValue("unit_price", customerPrice.UnitPrice);
                    cmd.Parameters.AddWithValue("create_by", customerPrice.CreateBy); 
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static bool Update(CustomerPrice customerPrice)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE customer_price 
                                set end_date =@end_date,
                                unit_price=@unit_price, 
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by 
                                WHERE product_code = @product_code
                                And customer_code = @customer_code
                                And start_date = @start_date";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerPrice.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("product_code", customerPrice.Product.ProductCode);
                    cmd.Parameters.AddWithValue("start_date", customerPrice.StartDate);
                    cmd.Parameters.AddWithValue("end_date", customerPrice.EndDate);
                    cmd.Parameters.AddWithValue("unit_price", customerPrice.UnitPrice); 
                    cmd.Parameters.AddWithValue("modified_by", customerPrice.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}