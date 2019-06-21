using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{

    public class OrderController
    {

        public object GetAllOrders(DateTime orderDate, string customerCode)
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
                    cmd.Parameters.AddWithValue("order_date", orderDate.ToString("yyyy-MM-dd"));

                    if (!string.IsNullOrEmpty(customerCode))
                        cmd.Parameters.AddWithValue("customer_code", customerCode);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    OrderNo = p.Field<string>("order_no"),
                                    OrderDate = p.Field<DateTime>("order_date"),
                                    CustomerName = p.Field<string>("customer_name"),
                                    Comments = p.Field<string>("comments"),
                                    OrderFlag = p.Field<int>("order_flag"),
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
        public Order GetOrder(string orderNo)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT order_no,
                                order_date,
                                customer_code,
                                order_flag
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
                            OrderDate = (DateTime)ds.Tables[0].Rows[0]["order_date"],
                            Customer = new Customer
                            {
                                CustomerCode = (string)ds.Tables[0].Rows[0]["customer_code"]
                            },


                            OrderFlag = (int)ds.Tables[0].Rows[0]["order_flag"],
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
        public bool Insert(Order order)
        {
            MySqlTransaction tr = null;
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {

                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"INSERT INTO orders
                                (order_no,
                                order_date,
                                customer_code,
                                order_flag,
                                comments,
                                create_by)
                                VALUES(@order_no,
                                @order_date,
                                @customer_code,
                                @order_flag,
                                @comments,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    cmd.Parameters.AddWithValue("order_date", order.OrderDate);
                    cmd.Parameters.AddWithValue("customer_code", order.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("order_flag", order.OrderFlag);
                    cmd.Parameters.AddWithValue("comments", order.Comments);
                    cmd.Parameters.AddWithValue("create_by", order.CreateBy);
                    cmd.ExecuteNonQuery();


                    sql = @"NSERT INTO order_item
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
                tr.Rollback();
                throw;
            }
        }
        public bool Update(Order Order)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE orders
                                SET order_date=@order_date,
                                customer_code=@customer_code,
                                order_flag=@order_flag,
                                comments=@comments,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE order_code=@order_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_code", Order.OrderNo);
                    cmd.Parameters.AddWithValue("order_date", Order.OrderDate);
                    cmd.Parameters.AddWithValue("customer_code", Order.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("comments", Order.Comments);
                    cmd.Parameters.AddWithValue("order_flag", Order.OrderFlag);
                    cmd.Parameters.AddWithValue("modified_by", Order.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string orderNo)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();

                    //Check Order Flag
                    // 0 = New Create
                    // 1 = Next State 
                    var sql = @"SELECT order_flag FROM orders WHERE order_no=@order_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var orderFlag = (int)cmd.ExecuteScalar();
                    if (orderFlag > 0)
                    {
                        throw new Exception("ไม่สามารถยกเลิกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    }

                    //Delete Order Item
                    sql = @"DELETE FROM order_item WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    cmd.ExecuteNonQuery();

                    //Delete Order
                    sql = @"DELETE FROM orders WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    cmd.ExecuteNonQuery();

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

    }
    public class OrderItemController
    {
        public List<OrderItem> GetOrderItems(string orderNo)
        {
            try
            {
                var orderItems = new List<OrderItem>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select a.order_no,
                                a.seq,
                                a.product_code,
                                order_qty,
                                order_wgh,
                                unload_qty,
                                unload_wgh,
                                b.product_name
                                from order_item a,product b
                                where a.product_code =b.product_code
                                and order_no =@order_no
                                order by seq asc";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        orderItems.Add(new OrderItem
                        {
                            OrderNo = (string)item["order_no"],
                            Seq = (int)item["seq"],
                            Product = new Product
                            {
                                ProductCode = item["product_code"].ToString(),
                                ProductName = item["product_name"].ToString(),
                            },
                            OrderQty = (int)item["order_qty"],
                            OrderWgh = (decimal)item["order_wgh"],
                            UnloadQty = (int)item["unload_qty"],
                            UnloadWgh = (decimal)item["unload_wgh"],
                        });
                    }

                }

                return orderItems;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
