using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{

    public static class BomController
    {
        public static object GetAllBoms(string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT b.bom_code, b.product_code, p.product_name, b.active, b.create_at, b.create_by ");
                    sb.Append("FROM bom b, product p ");
                    sb.Append("WHERE b.product_code = p.product_code and b.bom_code > 0 ");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" and ( b.bom_code LIKE @bom_code");
                        sb.Append(" OR p.product_name LIKE @product_name");
                        sb.Append(" OR b.product_code LIKE @product_code ) ");
                    }


                    sb.Append(" ORDER BY bom_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("bom_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("product_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("product_name", string.Format("%{0}%", keyword));
                    }

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    BomCode = p.Field<int>("bom_code"),
                                    ProductCode = p.Field<string>("product_code"),
                                    ProductName = p.Field<string>("product_name"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                }).ToList();
                    //ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                    //ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",

                    //GetData(ds.Tables[0]);
                    return coll;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //public static List<Bom> GetAllBoms()
        //{
        //    try
        //    {
        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            var sb = new StringBuilder();
        //            sb.Append("SELECT b.bom_code, b.product_code, p.product_name ");
        //            sb.Append("  FROM bom b, product p WHERE active=1  ");
        //            sb.Append(" and b.product_code = p.product_code  ");
        //            sb.Append(" ORDER BY bom_code ASC");
        //            var cmd = new MySqlCommand(sb.ToString(), conn);
        //            var da = new MySqlDataAdapter(cmd);

        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            var boms = new List<Bom>();
        //            foreach (DataRow row in ds.Tables[0].Rows)
        //            {
        //                boms.Add(new Bom
        //                {
        //                    BomCode = (Int32)row["bom_code"],
        //                    Product = new Product
        //                    {
        //                        ProductCode = (string)row["product_Code"].ToString(),
        //                        ProductName = (string)row["product_name"].ToString(),
        //                    },
        //                });
        //            }
        //            return boms;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public static DataTable GetBom(string productCode)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT distinct bi.bom_code, bi.product_code, 
                                    Mutiply_Qty, Mutiply_wgh, p.issue_unit_method as issue_unit_method,
                                    p.packing_size
                                FROM bom b, bom_item bi, product p
                                Where b.product_code = @product_code
                                    and b.bom_code = bi.bom_code
                                    and bi.product_code = p.product_code
                                ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Bom GetBomByCode(string bomCode)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT distinct b.bom_code, b.product_code, p.product_code, p.product_name,
                                    b.active, b.create_at
                                    FROM bom b, product p
                                    Where b.product_code = p.product_code
                                    and b.bom_code = @bom_code";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("bom_code", bomCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Bom
                        {

                            BomCode  = (int)ds.Tables[0].Rows[0]["bom_code"], 
                            Product  = new Product 
                            {
                                ProductCode  = (string)ds.Tables[0].Rows[0]["product_code"],
                                ProductName  = (string)ds.Tables[0].Rows[0]["product_name"],
                            },
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
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool Insert(Bom bom)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"INSERT INTO slaughterhouse.bom
                                (
                                product_code,
                                active, 
                                create_by)
								VALUES(
								@product_code, 
								@active,
								@create_by)";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    }; 
                    cmd.Parameters.AddWithValue("product_code", bom.Product.ProductCode);
                    cmd.Parameters.AddWithValue("active", bom.Active);
                    cmd.Parameters.AddWithValue("create_by", bom.CreateBy);
                    cmd.ExecuteNonQuery();


                    sql = @"SELECT max(bom_code) as bom_code
                                    FROM bom b ";

                    cmd = new MySqlCommand(sql, conn); 
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);


                    sql = @"INSERT INTO slaughterhouse.bom_item
                            (bom_code,
                            product_code,
                            mutiply_qty,
                            mutiply_wgh)
                            VALUES
                            (@bom_code,
                             @product_code,
                             @mutiply_qty,
                             @mutiply_wgh)
                          ";

                    foreach (var item in bom.BomItems)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("bom_code", ds.Tables[0].Rows[0][0]);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("mutiply_qty", item.MutiplyQty);
                        cmd.Parameters.AddWithValue("mutiply_wgh", item.MutiplyWgh);
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw;
            }
        }
        public static bool Update(Bom bom)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();

                    //var sql = @"SELECT bom_flag FROM boms WHERE bom_no=@bom_no";

                    //cmd.Parameters.AddWithValue("bom_no", bom.BomNo);
                    //var bomFlag = (int)cmd.ExecuteScalar();
                    //if (bomFlag > 0 || unloadWgh > 0)
                    //{
                    //    throw new Exception("ไม่สามารถบันทึกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    //}
                    var sql = @"UPDATE bom
								SET product_code=@product_code, 
								active=@active,
								modified_at=CURRENT_TIMESTAMP,
								modified_by=@modified_by
								WHERE bom_code=@bom_code";


                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("bom_code", bom.BomCode);
                    cmd.Parameters.AddWithValue("product_code", bom.Product.ProductCode);
                    cmd.Parameters.AddWithValue("active", bom.Active);
                    cmd.Parameters.AddWithValue("modified_by", bom.ModifiedBy );
                    var affRow = cmd.ExecuteNonQuery();

                    sql = @"Delete From bom_item 
								WHERE bom_code=@bom_code";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("bom_code", bom.BomCode);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO slaughterhouse.bom_item
                            (bom_code,
                            product_code,
                            mutiply_qty,
                            mutiply_wgh)
                            VALUES
                            (@bom_code,
                             @product_code,
                             @mutiply_qty,
                             @mutiply_wgh)
                          ";

                    foreach (var item in bom.BomItems)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("bom_code", bom.BomCode);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("mutiply_qty", item.MutiplyQty);
                        cmd.Parameters.AddWithValue("mutiply_wgh", item.MutiplyWgh);
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public static bool Cancel(Bom bom)
        //{
        //    MySqlTransaction tr = null;
        //    try
        //    {
        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            tr = conn.BeginTransaction();
        //            var sql = "";

        //            sql = @"UPDATE boms
        //SET  active=@active 
        //WHERE bom_no=@bom_no";
        //            var cmd = new MySqlCommand(sql, conn)
        //            {
        //                Transaction = tr
        //            };
        //            cmd.Parameters.AddWithValue("bom_no", bom.BomNo);
        //            cmd.Parameters.AddWithValue("active", bom.Active);
        //            var affRow = cmd.ExecuteNonQuery();

        //            tr.Commit();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
    public static class BomItemController
    {
        public static DataTable GetBomItem(string bomCode)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT distinct bi.bom_code, bi.product_code, p.product_name, Mutiply_Qty, Mutiply_wgh
                                    FROM bom_item bi, product p
                                    Where bi.product_code = p.product_code
                                    and bi.bom_code = @bom_code";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("bom_code", bomCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
