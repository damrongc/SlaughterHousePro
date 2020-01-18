using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        //public MasterClass MasterClass { get; set; }
        public string Address { get; set; }
        public string ShipTo { get; set; }
        public string TaxId { get; set; }
        public string ContactNo { get; set; }
        //public DateTime StartDateClass { get; set; }
        //public DateTime EndDateClass { get; set; }
        public int Day { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        //start_date_class
    }

    public static class CustomerController
    {
        public static object GetAllCustomers(string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append(" SELECT cv.customer_code, cv.customer_name, ");
                    //sb.Append(" cv.class_id, cls.class_name, ");
                    sb.Append(" cv.address, cv.ship_to, ");
                    sb.Append(" cv.tax_id, cv.contact_no, ");
                    //sb.Append("  cv.start_date_class, cv.end_date_class, ");
                    sb.Append(" cv.active, cv.create_at, ");
                    sb.Append(" cv.create_by, cv.modified_at, cv.modified_by ");
                    sb.Append(" FROM customer cv  ");
                    sb.Append(" WHERE 1=1 ");

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" and (customer_code LIKE @customer_code");
                        sb.Append(" OR customer_name LIKE @customer_name");
                        sb.Append(" OR address LIKE @address) ");
                    }
                    //sb.Append(" and cv.class_id = cls.class_id ");
                    sb.Append(" ORDER BY customer_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("customer_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("customer_name", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("address", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    CustomerCode = p.Field<string>("customer_code"),
                                    CustomerName = p.Field<string>("customer_name"),
                                    //ClassId = p.Field<Int32>("class_id"),
                                    //ClassName = p.Field<string>("class_name"),
                                    Address = p.Field<string>("address"),
                                    ShipTo = p.Field<string>("ship_to"),
                                    TaxId = p.Field<string>("tax_id"),
                                    ContactNo = p.Field<string>("contact_no"),
                                    //StartDateClass = p.Field<DateTime>("start_date_class"),
                                    //EndDateClass = p.Field<DateTime>("end_date_class"),
                                    //Day = (Convert.ToDateTime(p.Field<DateTime>("end_date_class")) - Convert.ToDateTime(p.Field<DateTime>("start_date_class"))).TotalDays,
                                    Active = p.Field<bool>("active"),
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
        public static List<Customer> GetAllCustomers()
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM customer WHERE active=1");
                    sb.Append(" ORDER BY customer_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var customers = new List<Customer>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        customers.Add(new Customer
                        {
                            CustomerCode = row["Customer_Code"].ToString(),
                            CustomerName = row["Customer_Name"].ToString()
                        });
                    }
                    return customers;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Customer GetCustomer(string customer_code)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from customer");
                    sb.Append(" where customer_code = @customer_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("customer_code", customer_code);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var customer = new Customer();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Customer
                        {
                            CustomerCode = ds.Tables[0].Rows[0]["customer_code"].ToString(),
                            CustomerName = ds.Tables[0].Rows[0]["customer_name"].ToString(),
                            Address = ds.Tables[0].Rows[0]["address"].ToString(),
                            ShipTo = ds.Tables[0].Rows[0]["ship_to"].ToString(),
                            TaxId = ds.Tables[0].Rows[0]["tax_id"].ToString(),
                            ContactNo = ds.Tables[0].Rows[0]["contact_no"].ToString(),
                            //Day = Convert.ToInt32((Convert.ToDateTime(ds.Tables[0].Rows[0]["end_date_class"]) - Convert.ToDateTime(ds.Tables[0].Rows[0]["start_date_class"])).TotalDays),
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
        public static bool Insert(Customer customer)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    if (IsDuplicateData(customer.CustomerCode))
                    {
                        throw new Exception($"รหัสลูกค้า {customer.CustomerCode} มีในระบบแล้ว");
                    }
                    var sql = @"INSERT
                                INTO customer (
                                    customer_code, customer_name,  address,
                                    ship_to, tax_id, contact_no,
                                    active, create_by )
                                VALUES (@customer_code, @customer_name,  @address,
                                    @ship_to, @tax_id, @contact_no,
                                    @active, @create_by )";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customer.CustomerCode);
                    cmd.Parameters.AddWithValue("customer_name", customer.CustomerName);
                    cmd.Parameters.AddWithValue("address", customer.Address);
                    cmd.Parameters.AddWithValue("ship_to", customer.ShipTo);
                    cmd.Parameters.AddWithValue("tax_id", customer.TaxId);
                    cmd.Parameters.AddWithValue("contact_no", customer.ContactNo);
                    cmd.Parameters.AddWithValue("active", customer.Active);
                    cmd.Parameters.AddWithValue("create_by", customer.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool Update(Customer customer)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    //var sql = @"UPDATE customer 
                    //            set customer_code =@customer_code,
                    //            customer_name=@customer_name,
                    //            class_id=@class_id,
                    //            address=@address,
                    //            ship_to=@ship_to,
                    //            tax_id=@tax_id,
                    //            contact_no=@contact_no,
                    //            start_date_class=@start_date_class,
                    //            end_date_class=@end_date_class,
                    //            active=@active, 
                    //            modified_at=CURRENT_TIMESTAMP,
                    //            modified_by=@modified_by 
                    //            WHERE customer_code = @customer_code";
                    var sql = @"UPDATE customer 
                                set customer_code =@customer_code,
                                customer_name=@customer_name, 
                                address=@address,
                                ship_to=@ship_to,
                                tax_id=@tax_id,
                                contact_no=@contact_no, 
                                active=@active, 
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by 
                                WHERE customer_code = @customer_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customer.CustomerCode);
                    cmd.Parameters.AddWithValue("customer_name", customer.CustomerName);
                    cmd.Parameters.AddWithValue("address", customer.Address);
                    cmd.Parameters.AddWithValue("ship_to", customer.ShipTo);
                    cmd.Parameters.AddWithValue("tax_id", customer.TaxId);
                    cmd.Parameters.AddWithValue("contact_no", customer.ContactNo);
                    cmd.Parameters.AddWithValue("active", customer.Active);
                    cmd.Parameters.AddWithValue("modified_by", customer.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int GetCustomerClassId(string customerCode, DateTime requestDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @" SELECT cls.class_id
                                FROM customer c , customer_class cls
                                WHERE c.active=1
	                                and c.customer_code = @customer_code
	                                and cls.start_date <= @start_date
	                                and cls.end_date >= @end_date
	                                and c.customer_code = cls.customer_code 
                                order by cls.start_date desc limit 1 ";
                    //ต้อง where เรื่อง วันนี้ start end date;
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);
                    cmd.Parameters.AddWithValue("start_date", requestDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("end_date", requestDate.ToString("yyyy-MM-dd"));

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    int res = MasterClassController.GetMasterClassDefaultFlag();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = Convert.ToInt32(ds.Tables[0].Rows[0]["class_id"]);
                    }
                    return res;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsDuplicateData(string customerCode)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @" SELECT customer_code
                                FROM customer c
                                WHERE customer_code = @customer_code  ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customerCode);

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

        //public List<dynamic> GetData(DataTable dt)
        //{
        //    List<dynamic> coll = new List<dynamic>();

        //    foreach (var item in dt.AsEnumerable())
        //    {
        //        IDictionary<string, object> dn = new ExpandoObject();

        //        foreach (var column in dt.Columns.Cast<DataColumn>()) dn[column.ColumnName] = item[column];

        //        coll.Add(dn);
        //    }

        //    return coll;
        //}

    }
}
