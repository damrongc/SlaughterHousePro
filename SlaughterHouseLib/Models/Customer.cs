﻿using MySql.Data.MySqlClient;
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
        public string Address { get; set; }
        public string ShipTo { get; set; }
        public string TaxId { get; set; }
        public string ContactNo { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
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
                    sb.Append("SELECT * FROM customer");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" WHERE customer_code LIKE @customer_code");
                        sb.Append(" OR customer_name LIKE @customer_name");
                        sb.Append(" OR address LIKE @address");
                    }

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
                                    Address = p.Field<string>("address"),
                                    ShipTo = p.Field<string>("ship_to"),
                                    TaxId = p.Field<string>("tax_id"),
                                    ContactNo = p.Field<string>("contact_no"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                    ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                                    ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                                }).ToList();

                    //GetData(ds.Tables[0]);
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
                    var sql = @"INSERT
                                INTO customer (
                                    customer_code, customer_name, address, 
                                    ship_to, tax_id, contact_no, 
                                    active, create_by 
                                )
                                VALUES (@customer_code, @customer_name, @address, 
                                    @ship_to, @tax_id, @contact_no, 
                                    @active, @create_by )";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("customer_code", customer.CustomerCode);
                    cmd.Parameters.AddWithValue("customer_name", customer.CustomerName);
                    cmd.Parameters.AddWithValue("address", customer.Address);
                    cmd.Parameters.AddWithValue("ship_to", customer.ShipTo);
                    cmd.Parameters.AddWithValue("tax_id", customer.TaxId );
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
                    var sql = @"UPDATE customer 
                                set customer_code =@customer_code,
                                customer_name=@customer_name,
                                address=address,
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