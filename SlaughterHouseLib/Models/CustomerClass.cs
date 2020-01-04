using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class CustomerClass
    {
        public Customer Customer { get; set; }
        public MasterClass MasterClass { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Day { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class CustomerClassController
    {


        public static DataTable GetClassAllByCustomer(string customerCode, string allFlag = "N")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @" SELECT cls.customer_code, c.customer_name , cls.class_id, mc.class_name, cls.start_date, cls.end_date,
                                 cls.create_at,   cls.create_by,  cls.modified_at,   cls.modified_by 
                                 FROM  customer_class cls, master_class mc, customer c
                                 WHERE  cls.customer_code = @customer_code ";
                    if (allFlag == "N")
                    {
                        //sql += " and cls.start_date <= DATE(SYSDATE()) ";
                        sql += " and cls.end_date >= DATE(SYSDATE()) ";
                    }
                    sql += @" and cls.class_id = mc.class_id
                              and cls.customer_code = c.customer_code
                             order by cls.start_date desc, cls.end_date, cls.class_id ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                ClassId = p.Field<string>("class_id"),
                    //                ClassName = p.Field<string>("class_name"),
                    //                StartDate = p.Field<DateTime>("start_date"),
                    //                EndDate = p.Field<DateTime>("end_date"),
                    //                Day = (Convert.ToDateTime(p.Field<DateTime>("end_date")) - Convert.ToDateTime(p.Field<DateTime>("start_date"))).TotalDays,
                    //                CreateAt = p.Field<DateTime?>("create_at") != null ? p.Field<DateTime?>("create_at") : null,
                    //                CreateBy = p.Field<string>("create_by") != "" ? p.Field<string>("create_by") : "",
                    //                ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                    //                ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                    //            }).ToList();
                    //return coll;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static CustomerClass GetClassByCustomer(int classId, string customerCode, DateTime startDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @" SELECT cls.customer_code, c.customer_name , cls.class_id, mc.class_name, cls.start_date, cls.end_date, cls.create_at
                                 FROM  customer_class cls, master_class mc, customer c
                                 WHERE  cls.customer_code = @customer_code
                                    and cls.class_id = @class_id ";
                    sql += @" and cls.start_date = @start_date ";
                    sql += @" and cls.class_id = mc.class_id
                              and cls.customer_code = c.customer_code  ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("class_id", classId);
                    cmd.Parameters.AddWithValue("start_date", startDate.ToString("yyyy-MM-dd"));
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new CustomerClass
                        {
                            Customer = new Customer
                            {
                                CustomerCode = (string)ds.Tables[0].Rows[0]["customer_code"],
                                CustomerName = (string)ds.Tables[0].Rows[0]["customer_name"],
                            },
                            MasterClass = new MasterClass
                            {
                                ClassId = (int)ds.Tables[0].Rows[0]["class_id"],
                                ClassName = (string)ds.Tables[0].Rows[0]["class_name"],
                            },
                            StartDate = (DateTime)ds.Tables[0].Rows[0]["start_date"],
                            EndDate = (DateTime)ds.Tables[0].Rows[0]["end_date"],
                            Day = Convert.ToInt32((Convert.ToDateTime(ds.Tables[0].Rows[0]["end_date"]) - Convert.ToDateTime(ds.Tables[0].Rows[0]["start_date"])).TotalDays + 1),
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
        public static bool Insert(CustomerClass CustomerClass)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    if (IsDuplicateData(CustomerClass))
                    {
                        throw new Exception($"รหัสลูกค้า {CustomerClass.Customer.CustomerCode} \n วันที่เริ่มมต้น {CustomerClass.StartDate.ToString("dd/MM/yyyy")} \n มีในระบบแล้ว");
                    }
                    var sql = @"INSERT INTO customer_class
                                  (class_id, customer_code, start_date, end_date, create_by)
                                VALUES
                                  (@class_id, @customer_code, @start_date, @end_date,  @create_by) ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", CustomerClass.MasterClass.ClassId);
                    cmd.Parameters.AddWithValue("customer_code", CustomerClass.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("start_date", CustomerClass.StartDate);
                    cmd.Parameters.AddWithValue("end_date", CustomerClass.EndDate);
                    cmd.Parameters.AddWithValue("create_by", CustomerClass.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(CustomerClass CustomerClass)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE customer_class
                                set class_id = @class_id,
                                  end_date =@end_date,
                                  modified_at=CURRENT_TIMESTAMP,
                                  modified_by=@modified_by
                                WHERE customer_code = @customer_code 
                                  And start_date = @start_date";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", CustomerClass.MasterClass.ClassId);
                    cmd.Parameters.AddWithValue("customer_code", CustomerClass.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("start_date", CustomerClass.StartDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", CustomerClass.EndDate);
                    cmd.Parameters.AddWithValue("modified_by", CustomerClass.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Delete(CustomerClass CustomerClass)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"delete from customer_class
                                WHERE customer_code = @customer_code
                                  And start_date = @start_date";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", CustomerClass.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("start_date", CustomerClass.StartDate.ToString("yyyy-MM-dd"));
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool IsDuplicateData(CustomerClass CustomerClass)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @" SELECT customer_code, class_id, start_date
                                FROM customer_class c
                                WHERE customer_code = @customer_code 
                                    and start_date = @start_date ";
                    var cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("customer_code", CustomerClass.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("start_date", CustomerClass.StartDate.ToString("yyyy-MM-dd"));
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}