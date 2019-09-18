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
                        cmd.Parameters.AddWithValue("location_code", item.Location) ;
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
  
    }
}
