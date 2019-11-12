using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class CustomerClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }


    }

    public static class CustomerClassController
    {
        public static List<CustomerClass> GetAllCustomerClass()
        {
            try
            {
                List<CustomerClass> customerClass = new List<CustomerClass>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM customer_class WHERE active=1");
                    sb.Append(" ORDER BY class_id asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        customerClass.Add(new CustomerClass
                        {
                            ClassId = (int)item["class_id"],
                            ClassName = item["class_name"].ToString(),
                        });
                    }


                    return customerClass;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static object GetAllCustomerClass(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from customer_class");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" where class_name like @class_name");

                    }

                    sb.Append(" order by class_id asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("class_name", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ClassId = p.Field<int>("class_id"),
                                    ClassName = p.Field<string>("class_name"),
                                    Active = p.Field<bool>("active"),
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
        public static CustomerClass GetCustomerClass(string class_id)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from customer_class");
                    sb.Append(" where class_id = @class_id");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("class_id", class_id);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var customerClass = new CustomerClass();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new CustomerClass
                        {

                            ClassId = (int)ds.Tables[0].Rows[0]["class_id"],
                            ClassName = ds.Tables[0].Rows[0]["class_name"].ToString(),
                            Active = (bool)ds.Tables[0].Rows[0]["active"],
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
