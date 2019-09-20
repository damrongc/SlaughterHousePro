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

                    sql = @"Delete From product_slip_item 
								WHERE product_slip_no=@product_slip_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("product_slip_no", productSlip.ProductSlipNo);
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
                        cmd.Parameters.AddWithValue("location_code", item.Location);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("create_by", productSlip.CreateBy);
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
        public static bool Cancel(ProductSlip productSlip)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = "";

                    sql = @"UPDATE product_slip
								SET  active=@active 
								WHERE product_slip_no=@product_slip_no";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("product_slip_no", productSlip.ProductSlipNo);
                    cmd.Parameters.AddWithValue("active", productSlip.Active);
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
        public static DataTable GetProductSlipItem(string orderNo)
        {
            try
            { 
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select  
                                a.product_code,
                                b.product_name,
                                sum(Case when b.issue_unit_method = 'Q' then order_qty else order_wgh end) qty_wgh,
                                null as lot_no,
                                null as location_code,
                                null as location_name,
                                0 as qty_wgh_location,
                                u.unit_name,
                                b.issue_unit_method 
                                from orders_item a,product b, unit_of_measurement u
                                where a.product_code =b.product_code
                                and Case when b.issue_unit_method = 'Q' then unit_of_qty else unit_of_wgh end = u.unit_code
                                and a.order_no = @order_no
                                group by a.order_no, a.product_code,  
	                                b.product_name, 
	                                b.issue_unit_method,
	                                u.unit_name 
                                order by a.product_code asc
                                            ";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();

                    DataTable dtLocation = new DataTable();
                    DataTable sortedDT = new DataTable();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToDecimal(dt.Rows[i]["QTY_WGH_LOCATION"]) == 0)
                            { 
                                dtLocation = StockController.GetCfLocation(dt.Rows[i]["PRODUCT_CODE"].ToString());
                                if (dtLocation != null && dtLocation.Rows.Count > 0)
                                {
                                    int row = i;
                                    decimal qtyWghSo = Convert.ToDecimal(dt.Rows[row]["QTY_WGH"]);
                                    for (int j = 0; j < dtLocation.Rows.Count; j++)
                                    {
                                        if (Convert.ToDecimal(dtLocation.Rows[j]["QTY_WGH"]) >= qtyWghSo)
                                        {
                                            dt.Rows[row]["LOT_NO"] = dtLocation.Rows[j]["LOT_NO"].ToString();
                                            dt.Rows[row]["LOCATION_CODE"] = dtLocation.Rows[j]["LOCATION_CODE"].ToString();
                                            dt.Rows[row]["LOCATION_NAME"] = dtLocation.Rows[j]["LOCATION_NAME"].ToString();
                                            dt.Rows[row]["QTY_WGH_LOCATION"] = Convert.ToDecimal(dt.Rows[row]["QTY_WGH"]);
                                        }
                                        else if (Convert.ToDecimal(dtLocation.Rows[j]["QTY_WGH"]) > 0)
                                        {
                                            dt.Rows[row]["LOT_NO"] = dtLocation.Rows[j]["LOT_NO"].ToString();
                                            dt.Rows[row]["LOCATION_CODE"] = dtLocation.Rows[j]["LOCATION_CODE"].ToString();
                                            dt.Rows[row]["LOCATION_NAME"] = dtLocation.Rows[j]["LOCATION_NAME"].ToString();
                                            dt.Rows[row]["QTY_WGH_LOCATION"] = Convert.ToDecimal(dtLocation.Rows[j]["QTY_WGH"]);

                                            qtyWghSo = qtyWghSo - Convert.ToDecimal(dtLocation.Rows[j]["QTY_WGH"]);
                                            row = Create_Row(ref dt, i, qtyWghSo); 
                                        } 
                                    } 
                                }
                            }
                        }
                        DataView dv = dt.DefaultView;
                        dv.Sort = "PRODUCT_CODE ASC, LOT_NO ASC";
                        sortedDT = dv.ToTable();
                    }

                    return sortedDT;

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    return new Order
                    //    {

                    //        OrderNo = (string)ds.Tables[0].Rows[0]["order_no"],
                    //        RequestDate = (DateTime)ds.Tables[0].Rows[0]["order_date"],
                    //        Customer = new Customer
                    //        {
                    //            CustomerCode = (string)ds.Tables[0].Rows[0]["customer_code"]
                    //        },
                    //        Comments = (string)ds.Tables[0].Rows[0]["comments"],
                    //        OrderFlag = (int)ds.Tables[0].Rows[0]["order_flag"],
                    //        Active = (bool)ds.Tables[0].Rows[0]["active"],
                    //        CreateAt = (DateTime)ds.Tables[0].Rows[0]["create_at"],
                    //    };
                    //}
                    //else
                    //{
                    //    return null;
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static int Create_Row(ref DataTable dt, int idxRow, decimal cfQtyWgh)
        {
            //bool res = false;
            DataRow drNew = dt.NewRow();
            drNew["PRODUCT_CODE"] = dt.Rows[idxRow]["PRODUCT_CODE"];
            drNew["PRODUCT_NAME"] = dt.Rows[idxRow]["PRODUCT_NAME"];
            drNew["QTY_WGH"] = Convert.ToDecimal(dt.Rows[idxRow]["QTY_WGH"]);
            drNew["UNIT_NAME"] = dt.Rows[idxRow]["UNIT_NAME"]; 
            drNew["QTY_WGH_LOCATION"] = cfQtyWgh;
            dt.Rows.Add(drNew);
            //DataTable dtLocation = new DataTable();
            //dtLocation = StockController.GetCfLocation(dt.Rows[idxRow]["PRODUCT_CODE"].ToString(), dt.Rows[idxRow]["LOT_NO"].ToString());
            //if (dtLocation != null && dtLocation.Rows.Count > 0)
            //{
            //    drNew["LOT_NO"] = dtLocation.Rows[0]["LOT_NO"].ToString();
            //    drNew["LOCATION_CODE"] = dtLocation.Rows[0]["LOCATION_CODE"].ToString();
            //    drNew["LOCATION_NAME"] = dtLocation.Rows[0]["LOCATION_NAME"].ToString();
            //    if (Convert.ToDecimal(dtLocation.Rows[0]["QTY_WGH"]) >= Convert.ToDecimal(dt.Rows[idxRow]["QTY_WGH"]))
            //    {

            //        drNew["QTY_WGH_LOCATION"] = Convert.ToDecimal(drNew["QTY_WGH"]);
            //        dt.Rows.Add(drNew);
            //        res = false;
            //    }
            //    else if (Convert.ToDecimal(dtLocation.Rows[0]["QTY_WGH"]) > 0)
            //    {
            //        drNew["QTY_WGH_LOCATION"] = Convert.ToDecimal(dtLocation.Rows[0]["QTY_WGH"]);
            //        dt.Rows.Add(drNew);
            //        res = true;
            //    }
            //    else
            //    {
            //        res = false;
            //    }
            //}
            //else
            //{
            //    //dt.Rows.Add(drNew);
            //    //res = false;
            //}
            return dt.Rows.Count - 1;
        }
    }
}
