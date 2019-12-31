using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class CustomerClassPrice
    {
        public MasterClass MasterClass { get; set; }
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

    public static class CustomerClassPriceController
    {
        public static object GetAllCustomerClassPrices(DateTime startDate, string productCode = "")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT a.class_id, c.class_name, a.product_code,");
                    sb.Append(" b.product_name,");
                    sb.Append(" a.start_date,");
                    sb.Append(" a.end_date,");
                    sb.Append(" a.unit_price,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by, a.modified_at, a.modified_by");
                    sb.Append(" FROM customer_class_price a, product b, master_class c");
                    sb.Append(" WHERE a.product_code = b.product_code ");
                    sb.Append(" AND a.class_id = c.class_id ");
                    sb.Append(" AND a.start_date <= '" + startDate.ToString("yyyy-MM-dd") + "'");
                    sb.Append(" AND a.end_date >= '" + startDate.ToString("yyyy-MM-dd") + "'");
                    if (!string.IsNullOrEmpty(productCode))
                        sb.Append(" AND a.product_code =@product_code");
                    sb.Append(" ORDER BY c.class_name, b.product_name, a.end_date ");
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
                                    ClassId = p.Field<int>("class_id"),
                                    ClassName = p.Field<string>("class_name"),
                                    ProductCode = p.Field<string>("product_code"),
                                    ProductName = p.Field<string>("product_name"),
                                    StartDate = p.Field<DateTime>("start_date"),
                                    EndDate = p.Field<DateTime>("end_date"),
                                    UnitPrice = p.Field<decimal>("unit_price"),
                                    Day = (Convert.ToDateTime(p.Field<DateTime>("end_date")) - Convert.ToDateTime(p.Field<DateTime>("start_date"))).TotalDays + 1,
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                    ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                                    ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                                }).ToList();
                    return coll;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CustomerClassPrice GetCustomerClassPrice(int classId, string productCode, DateTime startDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();

                    sb.Append("SELECT a.class_id, c.class_name, a.product_code,");
                    sb.Append(" b.product_name,");
                    sb.Append(" a.start_date,");
                    sb.Append(" a.end_date,");
                    sb.Append(" a.unit_price,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by");
                    sb.Append(" FROM customer_class_price a, product b, master_class c");
                    sb.Append(" WHERE a.product_code =b.product_code");
                    sb.Append(" AND a.class_id =c.class_id");
                    sb.Append(" AND a.class_id =@class_id");
                    sb.Append(" AND a.product_code =@product_code");
                    sb.Append(" AND a.start_date =@start_date");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("class_id", classId);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new CustomerClassPrice
                        {
                            MasterClass = new MasterClass
                            {
                                ClassId = (int)ds.Tables[0].Rows[0]["class_id"],
                                ClassName = (string)ds.Tables[0].Rows[0]["class_name"],
                            },
                            Product = new Product
                            {
                                ProductCode = (string)ds.Tables[0].Rows[0]["product_code"],
                                ProductName = (string)ds.Tables[0].Rows[0]["product_name"],
                            },
                            StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"],
                            EndDate = (DateTime)ds.Tables[0].Rows[0]["end_date"],
                            UnitPrice = (decimal)ds.Tables[0].Rows[0]["unit_price"],
                            Day = Convert.ToInt32((Convert.ToDateTime(ds.Tables[0].Rows[0]["end_date"]) - Convert.ToDateTime(ds.Tables[0].Rows[0]["start_date"])).TotalDays+1),
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
        public static bool Insert(CustomerClassPrice customerClassPrice)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO customer_class_price
                                    (class_id, product_code, start_date, end_date, 
                                    unit_price, create_by) 
                                    VALUES 
                                     (@class_id, @product_code, @start_date, @end_date, 
                                    @unit_price, @create_by) ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", customerClassPrice.MasterClass.ClassId);
                    cmd.Parameters.AddWithValue("product_code", customerClassPrice.Product.ProductCode);
                    cmd.Parameters.AddWithValue("start_date", customerClassPrice.StartDate);
                    cmd.Parameters.AddWithValue("end_date", customerClassPrice.EndDate);
                    cmd.Parameters.AddWithValue("unit_price", customerClassPrice.UnitPrice);
                    cmd.Parameters.AddWithValue("create_by", customerClassPrice.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(CustomerClassPrice customerClassPrice)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE customer_class_price 
                                set end_date =@end_date,
                                unit_price=@unit_price, 
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by 
                                WHERE product_code = @product_code
                                And class_id = @class_id
                                And start_date = @start_date";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", customerClassPrice.MasterClass.ClassId);
                    cmd.Parameters.AddWithValue("product_code", customerClassPrice.Product.ProductCode);
                    cmd.Parameters.AddWithValue("start_date", customerClassPrice.StartDate);
                    cmd.Parameters.AddWithValue("end_date", customerClassPrice.EndDate);
                    cmd.Parameters.AddWithValue("unit_price", customerClassPrice.UnitPrice);
                    cmd.Parameters.AddWithValue("modified_by", customerClassPrice.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}