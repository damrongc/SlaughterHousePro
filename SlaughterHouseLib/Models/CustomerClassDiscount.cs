using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class CustomerClassDiscount
    {
        public MasterClass MasterClass { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Day { get; set; }
        public decimal DiscountPer { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class CustomerClassDiscountController
    {
        public static object GetAllCustomerClassDiscount(DateTime startDate, Int32 classId = 0)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT dis.class_id, cls.class_name, ");
                    sb.Append(" dis.start_date, ");
                    sb.Append(" dis.end_date, ");
                    sb.Append(" dis.discount_per, ");
                    sb.Append(" dis.create_at, ");
                    sb.Append(" dis.create_by, ");
                    sb.Append(" dis.modified_at, ");
                    sb.Append(" dis.modified_by  ");
                    sb.Append(" FROM customer_class_discount dis, master_class cls ");
                    sb.Append(" WHERE dis.class_id = cls.class_id ");
                    sb.Append(" AND dis.start_date <= '" + startDate.ToString("yyyy-MM-dd") + "'");
                    sb.Append(" AND dis.end_date >= '" + startDate.ToString("yyyy-MM-dd") + "'");
                    if (classId > 0)
                        sb.Append(" AND dis.class_id = @class_id");
                    sb.Append(" ORDER BY dis.class_id, dis.end_date ");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    if (classId > 0)
                        cmd.Parameters.AddWithValue("class_id", classId);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ClassId = p.Field<Int32>("class_id"),
                                    ClassName = p.Field<string>("class_name"),
                                    StartDate = p.Field<DateTime>("start_date"),
                                    EndDate = p.Field<DateTime>("end_date"),
                                    DiscountPer = p.Field<decimal>("discount_per"),
                                    Day = (Convert.ToDateTime(p.Field<DateTime>("end_date")) - Convert.ToDateTime(p.Field<DateTime>("start_date"))).TotalDays,
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
        public static CustomerClassDiscount GetCustomerClassDiscount(Int32 classId,  DateTime startDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();

                    sb.Append("SELECT dis.class_id, cls.class_name, ");
                    sb.Append(" dis.start_date, ");
                    sb.Append(" dis.end_date, ");
                    sb.Append(" dis.discount_per, ");
                    sb.Append(" dis.create_at, ");
                    sb.Append(" dis.create_by, ");
                    sb.Append(" dis.modified_at, ");
                    sb.Append(" dis.modified_by  ");
                    sb.Append(" FROM customer_class_discount dis, master_class cls ");
                    sb.Append(" WHERE dis.class_id = cls.class_id ");
                    sb.Append(" AND dis.class_id =@class_id");
                    sb.Append(" AND dis.start_date =@start_date");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("class_id", classId);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new CustomerClassDiscount
                        {
                            MasterClass = new MasterClass
                            {
                                ClassId = Convert.ToInt32(ds.Tables[0].Rows[0]["class_id"]),
                                ClassName = (string)ds.Tables[0].Rows[0]["class_name"],
                            },
                            StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"],
                            EndDate = (DateTime)ds.Tables[0].Rows[0]["end_date"],
                            DiscountPer = (decimal)ds.Tables[0].Rows[0]["discount_per"],
                            Day = Convert.ToInt32((Convert.ToDateTime(ds.Tables[0].Rows[0]["end_date"]) - Convert.ToDateTime(ds.Tables[0].Rows[0]["start_date"])).TotalDays),
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
        public static bool Insert(CustomerClassDiscount customerClassDiscount)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO customer_class_discount
                                    (class_id, start_date, end_date, 
                                    discount_per, create_by) 
                                    VALUES 
                                     (@class_id, @start_date, @end_date, 
                                    @discount_per, @create_by) ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", customerClassDiscount.MasterClass.ClassId);
                    cmd.Parameters.AddWithValue("start_date", customerClassDiscount.StartDate);
                    cmd.Parameters.AddWithValue("end_date", customerClassDiscount.EndDate);
                    cmd.Parameters.AddWithValue("discount_per", customerClassDiscount.DiscountPer);
                    cmd.Parameters.AddWithValue("create_by", customerClassDiscount.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(CustomerClassDiscount customerClassDiscount)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE customer_class_discount 
                                set end_date =@end_date,
                                discount_per=@discount_per, 
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by 
                                WHERE class_id = @class_id 
                                And start_date = @start_date";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", customerClassDiscount.MasterClass.ClassId);
                    cmd.Parameters.AddWithValue("start_date", customerClassDiscount.StartDate);
                    cmd.Parameters.AddWithValue("end_date", customerClassDiscount.EndDate);
                    cmd.Parameters.AddWithValue("discount_per", customerClassDiscount.DiscountPer);
                    cmd.Parameters.AddWithValue("modified_by", customerClassDiscount.ModifiedBy);
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