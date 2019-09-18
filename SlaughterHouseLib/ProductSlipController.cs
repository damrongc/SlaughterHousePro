using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{

    public static class ProductSlipController
    {
        public static bool Insert(ProductSlip productSlip)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    productSlip.ProductSlipNo = DocumentGenerate.GetDocumentRunning("PS");
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"INSERT INTO product_slip
									(product_slip_no,
									product_slip_date,
									ref_document_no,
                                    product_slip_flag,
									active,
									create_by)
								VALUES
									(@product_slip_no,
									 @product_slip_date,
									 @ref_document_no,
									 @product_slip_flag,
									 @active,
									 @create_by ) 
							   ";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("product_slip_no", productSlip.ProductSlipNo);
                    cmd.Parameters.AddWithValue("product_slip_date", productSlip.ProductSlipDate);
                    cmd.Parameters.AddWithValue("ref_document_no", productSlip.RefDocumentNo);
                    cmd.Parameters.AddWithValue("product_slip_flag", productSlip.ProductSlipFlag);
                    cmd.Parameters.AddWithValue("active", productSlip.Active);
                    cmd.Parameters.AddWithValue("create_by", productSlip.CreateBy);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO slaughterhouse.product_slip_item
							   (product_slip_no,
								product_code,
								location_code,
								seq,
								create_by )
							VALUES
							   (@product_slip_no ,
								@product_code ,
								@location_code ,
								@seq , 
								@create_by )
							";

                    foreach (var item in productSlip.ProductSlipItem)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("product_slip_no", productSlip.ProductSlipNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("location_code", item.Location.LocationCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("create_by", item.CreateBy);
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
        public static bool Update(ProductSlip productSlip)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"SELECT product_slip_flag FROM product_slip WHERE product_slip_no=@product_slip_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_slip_no", productSlip.ProductSlipNo);
                    var productSlipFlag = (int)cmd.ExecuteScalar();

                    if (productSlipFlag > 0)
                    {
                        throw new Exception("ไม่สามารถบันทึกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    }
                    sql = @"UPDATE slaughterhouse.product_slip
                            SET 
                                product_slip_date = @product_slip_date,
                                ref_document_no = @ref_document_no,
                                product_slip_flag = @product_slip_flag,
								active=@active,
								modified_at=CURRENT_TIMESTAMP,
								modified_by=@modified_by
                            WHERE product_slip_no = @product_slip_no
                          ";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("product_slip_no", productSlip.ProductSlipNo);
                    cmd.Parameters.AddWithValue("product_slip_date", productSlip.ProductSlipDate);
                    cmd.Parameters.AddWithValue("ref_document_no", productSlip.RefDocumentNo);
                    cmd.Parameters.AddWithValue("product_slip_flag", productSlip.ProductSlipFlag);
                    cmd.Parameters.AddWithValue("active", productSlip.Active);
                    cmd.Parameters.AddWithValue("modified_by", productSlip.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();

                    sql = @"Delete From orders_item 
								WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    //cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    //cmd.ExecuteNonQuery();

                    //sql = @"INSERT INTO orders_item
                    //			(order_no,
                    //			product_code,
                    //			seq,
                    //			order_qty,
                    //			order_wgh,
                    //			bom_code,
                    //			order_set_qty,
                    //			order_set_wgh,
                    //			create_by)
                    //			VALUES(
                    //			@order_no,
                    //			@product_code,
                    //			@seq,
                    //			@order_qty,
                    //			@order_wgh,
                    //			@bom_code,
                    //			@order_set_qty,
                    //			@order_set_wgh,
                    //			@create_by)";

                    //foreach (var item in order.OrderItems)
                    //{
                    //	cmd = new MySqlCommand(sql, conn)
                    //	{
                    //		Transaction = tr
                    //	};
                    //	cmd.Parameters.AddWithValue("order_no", order.OrderNo);
                    //	cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                    //	cmd.Parameters.AddWithValue("seq", item.Seq);
                    //	cmd.Parameters.AddWithValue("order_qty", item.OrderQty);
                    //	cmd.Parameters.AddWithValue("order_wgh", item.OrderWgh);
                    //	cmd.Parameters.AddWithValue("bom_code", item.BomCode);
                    //	cmd.Parameters.AddWithValue("order_set_qty", item.OrderSetQty);
                    //	cmd.Parameters.AddWithValue("order_set_wgh", item.OrderSetWgh);
                    //	cmd.Parameters.AddWithValue("create_by", order.CreateBy);
                    //	cmd.ExecuteNonQuery();
                    //}
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
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = "";

                    sql = @"UPDATE orders
								SET  active=@active 
								WHERE order_no=@order_no";
                    var cmd = new MySqlCommand(sql, conn)
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
    }
    public static class ProductSlipItemController
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
							CASE
								WHEN p.issue_unit_method = 'Q' 
								THEN case when a.bom_code = 0 then a.order_qty else a.order_set_qty end
								ELSE case when a.bom_code = 0 then a.order_wgh else a.order_set_wgh end
							END qty_wgh,
							p.issue_unit_method,
							u.unit_code,
							u.unit_name 
						FROM
							orders_item a,
							product p,
							unit_of_measurement u,
							bom bm
						WHERE
							a.order_no = @order_no 
							and a.bom_code = bm.bom_code
							and p.product_code = case when a.bom_code = 0 then a.product_code else bm.product_code end
							and CASE
								WHEN p.issue_unit_method = 'Q' THEN unit_of_qty
								ELSE unit_of_wgh
							END = u.unit_code  ";
                    }
                    else
                    {
                        sql = @"select 
							0 as seq,
							a.product_code,
							b.product_name,
							sum(Case when b.issue_unit_method = 'Q' then order_qty else order_wgh end) qty_wgh,
							b.issue_unit_method,
							u.unit_code,
							u.unit_name,
							sum(unload_qty) as unload_qty,
							sum(unload_wgh) as unload_wgh 
							from orders_item a,product b, unit_of_measurement u
							where a.product_code =b.product_code
							and Case when b.issue_unit_method = 'Q' then unit_of_qty else unit_of_wgh end = u.unit_code
							and a.order_no =@order_no 
							group by a.product_code,
								b.product_name, 
								b.issue_unit_method,
								u.unit_code,
								u.unit_name 
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
							'' as sale_unit_method, 
							case when a.bom_code = 0 then sum(a.unload_qty) else CEILING(sum(a.unload_qty) / sum(bmt.mutiply_qty)) end as qty,
							sum(a.unload_wgh) as wgh,
								0 as unit_price, 
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
							and p.product_code = case when a.bom_code = 0 then a.product_code else bm.product_code end
						group by p.product_code,
							p.product_name,
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
                    sql = @"
							select COALESCE(sum(case when p.issue_unit_method = 'Q' then a.unload_qty else a.unload_wgh end), 0) as qty_wgh_unload,
							 COALESCE(sum(case when p.issue_unit_method = 'Q' then a.order_qty else a.order_wgh end), 0) as qty_wgh
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
                    decimal unloadQtyWgh = (decimal)ds.Tables[0].Rows[0]["qty_wgh_unload"];
                    decimal qtyWgh = (decimal)ds.Tables[0].Rows[0]["qty_wgh"];
                    if (unloadQtyWgh == qtyWgh)
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
