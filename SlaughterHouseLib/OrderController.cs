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
                    sb.Append(" a.invoice_flag,");
                    sb.Append(" a.comments,");
                    sb.Append(" a.active,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by,");
                    sb.Append(" b.customer_name");
                    sb.Append(" FROM orders a,customer b");
                    sb.Append(" WHERE a.customer_code =b.customer_code");
                    sb.Append(" AND a.order_date =@order_date");
                    sb.Append(" AND a.active = 1");
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
                                    ORDER_NO = p.Field<string>("order_no"),
                                    REQUEST_DATE = p.Field<DateTime>("order_date"),
                                    CUSTOMER_NAME = p.Field<string>("customer_name"),
                                    COMMENTS = p.Field<string>("comments"),
                                    ORDER_FLAG = p.Field<int>("order_flag"),
                                    INVOICE_FLAG = p.Field<int>("invoice_flag"),
                                    ACTIVE = p.Field<bool>("active"),
                                    CREATE_AT = p.Field<DateTime>("create_at"),
                                    CREATE_BY = p.Field<string>("create_by"),
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
                            RequestDate = (DateTime)ds.Tables[0].Rows[0]["order_date"],
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
                    sb.Append(" a.order_date, ");
                    sb.Append(" a.customer_code,");
                    sb.Append(" a.order_flag,");
                    sb.Append(" a.comments,");
                    sb.Append(" a.active,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by,");
                    sb.Append(" b.customer_name");
                    sb.Append(" FROM orders a, customer b");
                    sb.Append(" WHERE a.customer_code =b.customer_code");
                    sb.Append(" AND a.order_date =@order_date");
                    sb.Append(" AND a.order_flag = 1");
                    sb.Append(" AND a.invoice_flag = 0");
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
                                    RequestDate = p.Field<DateTime>("order_date"),
                                    CustomerName = p.Field<string>("customer_name"),
                                    //Comments = p.Field<string>("comments"),
                                    //OrderFlag = p.Field<int>("order_flag"),
                                    //Active = p.Field<bool>("active"),
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

                    sql = @"INSERT INTO orders_item
								(order_no,
								product_code,
								seq,
								order_qty,
								order_wgh,
								bom_code,
								order_set_qty,
								order_set_wgh,
								create_by)
								VALUES(
								@order_no,
								@product_code,
								@seq,
								@order_qty,
								@order_wgh,
								@bom_code,
								@order_set_qty,
								@order_set_wgh,
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
                        cmd.Parameters.AddWithValue("bom_code", item.BomCode);
                        cmd.Parameters.AddWithValue("order_set_qty", item.OrderSetQty);
                        cmd.Parameters.AddWithValue("order_set_wgh", item.OrderSetWgh);
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
            MySqlTransaction tr;
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


                    sql = @"SELECT sum(unload_wgh) as unload_wgh FROM orders_item WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    var unloadWgh = (decimal)cmd.ExecuteScalar();
                    if (orderFlag > 0 || unloadWgh > 0)
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

                    sql = @"Delete From orders_item 
								WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO orders_item
								(order_no,
								product_code,
								seq,
								order_qty,
								order_wgh,
								bom_code,
								order_set_qty,
								order_set_wgh,
								create_by)
								VALUES(
								@order_no,
								@product_code,
								@seq,
								@order_qty,
								@order_wgh,
								@bom_code,
								@order_set_qty,
								@order_set_wgh,
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
                        cmd.Parameters.AddWithValue("bom_code", item.BomCode);
                        cmd.Parameters.AddWithValue("order_set_qty", item.OrderSetQty);
                        cmd.Parameters.AddWithValue("order_set_wgh", item.OrderSetWgh);
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
        public static bool Cancel(Order order)
        {
            MySqlTransaction tr;
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


                    sql = @"SELECT sum(unload_wgh) as unload_wgh FROM orders_item WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    var unloadWgh = (decimal)cmd.ExecuteScalar();
                    if (orderFlag > 0 || unloadWgh > 0)
                    {
                        throw new Exception("ไม่สามารถบันทึกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    }

                    sql = @"UPDATE orders
								SET  active=@active 
								WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    cmd.Parameters.AddWithValue("active", order.Active);
                    var affRow = cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CheckUseOrder(string orderNo)
        {
            bool res = false;
            MySqlTransaction tr;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"SELECT order_flag FROM orders WHERE order_no=@order_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var orderFlag = (int)cmd.ExecuteScalar();


                    sql = @"SELECT sum(unload_wgh) as unload_wgh FROM orders_item WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var unloadWgh = (decimal)cmd.ExecuteScalar();
                    if (orderFlag > 0 || unloadWgh > 0)
                    {
                        res = true;
                    }
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    public static class OrderItemController
    {
        public static DataTable GetOrderItems(string orderNo, string showProductSet = "Y")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = "";
                    if (showProductSet == "Y")
                    {
                        sql = @"SELECT  distinct 
							0 as seq,
							p.product_code,
							p.product_name, 
							case when a.bom_code = 0 then a.order_qty else a.order_set_qty end as qty,
							uq.unit_code as unit_code_qty,
							uq.unit_name as unit_name_qty,
							case when a.bom_code = 0 then a.order_wgh else a.order_set_wgh end as wgh,
							uw.unit_code as unit_code_wgh,
							uw.unit_name as unit_name_wgh,  
							0 as unload_qty,
							0 as unload_wgh,
                            p.issue_unit_method,
                            p.packing_size
						FROM
							orders_item a,
							product p,
							unit_of_measurement uq,
							unit_of_measurement uw,
							bom bm
						WHERE
							a.order_no = @order_no 
							and a.bom_code = bm.bom_code
							and p.product_code = case when a.bom_code = 0 then a.product_code else bm.product_code end 
							and p.unit_of_wgh = uw.unit_code 
							and p.unit_of_qty = uq.unit_code 
                        ";
                    }
                    else
                    {
                        sql = @"select a.order_no,
							    0 as seq,
							    a.product_code,
							    p.product_name,
                                sum(a.order_qty) as qty,
							    uq.unit_code as unit_code_qty,
							    uq.unit_name as unit_name_qty,
                                sum(a.order_wgh) as wgh,  
							    uw.unit_code as unit_code_wgh,
							    uw.unit_name as unit_name_wgh, 
							    sum(unload_qty) as unload_qty,
							    sum(unload_wgh) as unload_wgh,
                                p.issue_unit_method,
                                p.packing_size
							from orders_item a,product p, 
							    unit_of_measurement uq,
							    unit_of_measurement uw
							where a.product_code =p.product_code
							    and p.unit_of_qty = uq.unit_code
							    and p.unit_of_wgh = uw.unit_code
							    and a.order_no =@order_no 
							group by a.product_code,
								p.product_name, 
								uq.unit_code,
								uq.unit_name,
                                uw.unit_code,
								uw.unit_name
							order by seq asc";
                    }
                    //case when a.bom_code = 0 then 0 else 1 end as product_set
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
                    sql = @"SELECT    
							0 as seq,
							p.product_code,
							p.product_name, 
							p.sale_unit_method, 
							case when a.bom_code = 0 then sum(a.unload_qty) else CEILING(sum(a.unload_qty) / sum(bmt.mutiply_qty)) end as qty,
							sum(a.unload_wgh) as wgh,
								0 as unit_price, 
                                0 as unit_disc,
                                0 as unit_net,
                                0 as disc_amt,
								0 as gross_amt
						FROM
							orders_item a,
							product p, 
							bom bm,
							bom_item bmt
						WHERE
							a.order_no = @order_no
							and a.bom_code = bm.bom_code
							and bm.bom_code = bmt.bom_code
                            and a.product_code = case when a.bom_code = 0 then a.product_code else bmt.product_code end
							and p.product_code = case when a.bom_code = 0 then a.product_code else bm.product_code end
						group by p.product_code,
							p.product_name,
                            p.sale_unit_method, 
                            a.bom_code ";
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

        public static bool CheckPickingComplete(string orderNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = "";
                    //boy
                    sql = @"
                            select COALESCE(sum(a.unload_qty), 0) as qty_unload,
                                COALESCE(sum(a.unload_wgh), 0) as wgh_unload,
                                COALESCE(sum(a.order_qty), 0) as qty,
                                COALESCE(sum(a.order_wgh), 0) as wgh
                            from orders_item a , product p
                            where a.order_no = @order_no
                            and a.product_code = p.product_code  
							";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    bool pickingCompleteFlag = false;
                    decimal unloadQty = (decimal)ds.Tables[0].Rows[0]["qty_unload"];
                    decimal qty = (decimal)ds.Tables[0].Rows[0]["qty"];
                    decimal unloadWgh = (decimal)ds.Tables[0].Rows[0]["wgh_unload"];
                    decimal wgh = (decimal)ds.Tables[0].Rows[0]["wgh"];
                    if (unloadQty >= qty)
                    {
                        pickingCompleteFlag = true;
                    }

                    return pickingCompleteFlag;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
