using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{

    public static class OrderController
    {
        public static object GetAllOrders(DateTime requestDate, string customerCode = "")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT a.order_no,");
                    sb.Append(" a.order_date,");
                    sb.Append(" a.customer_code,");
                    sb.Append(" a.order_flag,");
                    sb.Append(" a.comments,");
                    sb.Append(" a.active,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by,");
                    sb.Append(" b.customer_name");
                    sb.Append(" FROM orders a,customer b");
                    sb.Append(" WHERE a.customer_code =b.customer_code");
                    sb.Append(" AND a.order_date =@order_date");
                    if (!string.IsNullOrEmpty(customerCode))
                        sb.Append(" AND a.customer_code =@customer_code");
                    sb.Append(" ORDER BY order_no ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("order_date", requestDate.ToString("yyyy-MM-dd"));


                    if (!string.IsNullOrEmpty(customerCode))
                        cmd.Parameters.AddWithValue("customer_code", customerCode);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    OrderNo = p.Field<string>("order_no"),
                                    RequestDate =  p.Field<DateTime>("order_date"),
                                    CustomerName = p.Field<string>("customer_name"),
                                    //Comments = p.Field<string>("comments"),
                                    //OrderFlag = p.Field<int>("order_flag"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                }).ToList();

                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Order GetOrder(string orderNo)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT order_no,
                                order_date,
                                customer_code,
                                comments,
                                order_flag, 
                                active,
                                create_at
                                FROM orders
                                WHERE order_no =@order_no";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Order
                        {

                            OrderNo = (string)ds.Tables[0].Rows[0]["order_no"],
                            RequestDate =  (DateTime)ds.Tables[0].Rows[0]["order_date"],
                            Customer = new Customer
                            {
                                CustomerCode = (string)ds.Tables[0].Rows[0]["customer_code"]
                            },
                            Comments = (string)ds.Tables[0].Rows[0]["comments"],
                            OrderFlag = (int)ds.Tables[0].Rows[0]["order_flag"],
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
        public static object GetOrderReadyToSell(DateTime requestDate, string customerCode = "")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT distinct a.order_no,");
                    sb.Append(" a.order_date, sk.stock_no, ");
                    sb.Append(" a.customer_code,");
                    sb.Append(" a.order_flag,");
                    sb.Append(" a.comments,");
                    sb.Append(" a.active,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by,");
                    sb.Append(" b.customer_name");
                    sb.Append(" FROM orders a, customer b, stock sk ");
                    sb.Append(" WHERE a.customer_code =b.customer_code");
                    sb.Append(" AND a.order_date =@order_date");
                    sb.Append(" AND a.order_no = sk.ref_document_no");
                    sb.Append(" AND a.order_flag = 1");
                    sb.Append(" AND sk.ref_document_Type ='SO' ");
                    if (!string.IsNullOrEmpty(customerCode))
                        sb.Append(" AND a.customer_code =@customer_code");
                    sb.Append(" ORDER BY order_no ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("order_date", requestDate.ToString("yyyy-MM-dd"));


                    if (!string.IsNullOrEmpty(customerCode))
                        cmd.Parameters.AddWithValue("customer_code", customerCode);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    OrderNo = p.Field<string>("order_no"),
                                    RequestDate =  p.Field<DateTime>("order_date"),
                                    CustomerName = p.Field<string>("customer_name"),
                                    //Comments = p.Field<string>("comments"),
                                    //OrderFlag = p.Field<int>("order_flag"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                }).ToList();
                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Insert(Order order)
        {
            MySqlTransaction tr = null;
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {


                    order.OrderNo = DocumentGenerate.GetDocumentRunning("SO");
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"INSERT INTO orders
                                (order_no,
                                order_date,
                                customer_code,
                                order_flag,
                                comments,
                                active,
                                create_by)
                                VALUES(@order_no,
                                @order_date,
                                @customer_code,
                                @order_flag,
                                @comments,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    cmd.Parameters.AddWithValue("order_date", order.RequestDate);
                    cmd.Parameters.AddWithValue("customer_code", order.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("order_flag", order.OrderFlag);
                    cmd.Parameters.AddWithValue("comments", order.Comments);
                    cmd.Parameters.AddWithValue("active", order.Active);
                    cmd.Parameters.AddWithValue("create_by", order.CreateBy);
                    cmd.ExecuteNonQuery(); 

                    sql = @"INSERT INTO order_item
                                (order_no,
                                product_code,
                                seq,
                                order_qty,
                                order_wgh,
                                create_by)
                                VALUES(
                                @order_no,
                                @product_code,
                                @seq,
                                @order_qty,
                                @order_wgh,
                                @create_by)";

                    foreach (var item in order.OrderItems)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("order_qty", item.OrderQty);
                        cmd.Parameters.AddWithValue("order_wgh", item.OrderWgh);
                        cmd.Parameters.AddWithValue("active", order.Active); 
                        cmd.Parameters.AddWithValue("create_by", order.CreateBy);
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
        }
        public static bool Update(Order order)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"SELECT order_flag FROM orders WHERE order_no=@order_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    var orderFlag = (int)cmd.ExecuteScalar();
                    if (orderFlag > 0)
                    {
                        throw new Exception("ไม่สามารถบันทึกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    }


                      sql = @"UPDATE orders
                                SET order_date=@order_date,
                                customer_code=@customer_code,
                                order_flag=@order_flag,
                                comments=@comments,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE order_no=@order_no"; 
                      cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    cmd.Parameters.AddWithValue("order_date", order.RequestDate);
                    cmd.Parameters.AddWithValue("customer_code", order.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("order_flag", order.OrderFlag);
                    cmd.Parameters.AddWithValue("comments", order.Comments);
                    cmd.Parameters.AddWithValue("active", order.Active); 
                    cmd.Parameters.AddWithValue("modified_by", order.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();

                    sql = @"Delete From order_item 
                                WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO order_item
                                (order_no,
                                product_code,
                                seq,
                                order_qty,
                                order_wgh,
                                create_by)
                                VALUES(
                                @order_no,
                                @product_code,
                                @seq,
                                @order_qty,
                                @order_wgh,
                                @create_by)";

                    foreach (var item in order.OrderItems)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("order_qty", item.OrderQty);
                        cmd.Parameters.AddWithValue("order_wgh", item.OrderWgh);
                        cmd.Parameters.AddWithValue("create_by", order.CreateBy);
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public static bool Delete(string orderNo)
        //{
        //    MySqlTransaction tr = null;
        //    try
        //    {
        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            tr = conn.BeginTransaction();

        //            //Check Order Flag
        //            // 0 = New Create
        //            // 1 = Next State 
        //            var sql = @"SELECT order_flag FROM orders WHERE order_no=@order_no";
        //            var cmd = new MySqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("order_no", orderNo);
        //            var orderFlag = (int)cmd.ExecuteScalar();
        //            if (orderFlag > 0)
        //            {
        //                throw new Exception("ไม่สามารถยกเลิกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
        //            }

        //            //Delete Order Item
        //            sql = @"DELETE FROM order_item WHERE order_no=@order_no";
        //            cmd = new MySqlCommand(sql, conn)
        //            {
        //                Transaction = tr
        //            };
        //            cmd.Parameters.AddWithValue("order_no", orderNo);
        //            cmd.ExecuteNonQuery();

        //            //Delete Order
        //            sql = @"DELETE FROM orders WHERE order_no=@order_no";
        //            cmd = new MySqlCommand(sql, conn)
        //            {
        //                Transaction = tr
        //            };
        //            cmd.Parameters.AddWithValue("order_no", orderNo);
        //            cmd.ExecuteNonQuery();

        //            tr.Commit();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        tr.Rollback();
        //        throw;
        //    }
        //}
    }
    public static class OrderItemController
    {
        public static DataTable GetOrderItems(string orderNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select a.seq,
                                a.product_code,
                                b.product_name,
                                order_qty,
                                order_wgh
                                from order_item a,product b
                                where a.product_code =b.product_code
                                and a.order_no =@order_no 
                                order by seq asc";
                    
                                //unload_qty,
                                //unload_wgh

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                OrderNo = p.Field<string>("order_no"),
                    //                Seq = p.Field<int>("seq"),
                    //                ProductCode = p.Field<string>("product_code"),
                    //                ProductName = p.Field<string>("product_name"),
                    //                OrderQty = p.Field<int>("order_qty"),
                    //                OrderWgh = p.Field<decimal>("order_wgh"),
                    //                UnloadQty = p.Field<int>("unload_qty"),
                    //                UnloadWgh = p.Field<decimal>("unload_wgh"),
                    //            }).ToList();
                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static DataTable GetOrderItemReadyToSell(string orderNo, DateTime? invoiceDate = null, bool flagReadPrice = false)
     public static DataTable GetOrderItemReadyToSell(string orderNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = ""; 
                        sql = @"select sk.stock_item as seq, 
                                sk.product_code, 
                                b.product_name,
                                '' as sale_unit_method,
                                sk.stock_qty,
                                sk.stock_wgh,
                                0 as unit_price, 0 as gross_amt
                                from order_item a,product b, stock sk 
                                where a.product_code =b.product_code
                                and a.order_no =@order_no 
                                and a.order_no = sk.ref_document_no 
                                and a.product_code = sk.product_code 
                                and sk.ref_document_type ='SO'  
                                order by sk.stock_item asc ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                     
                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
