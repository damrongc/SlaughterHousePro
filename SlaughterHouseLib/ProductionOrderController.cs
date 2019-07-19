using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{

    public static class ProductionOrderController
    {
        public static object GetAllProductionOrders(DateTime poDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append(" SELECT a.po_no,");
                    sb.Append(" a.po_date,");
                    sb.Append(" a.po_flag,");
                    sb.Append(" a.comments,");
                    sb.Append(" a.active,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by");
                    sb.Append(" FROM production_order a");
                    sb.Append(" WHERE a.po_date =@po_date");
 
                    sb.Append(" AND a.active = 1"); 
                    sb.Append(" ORDER BY po_no ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("po_date", poDate.ToString("yyyy-MM-dd"));

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    PoNo = p.Field<string>("po_no"),
                                    PoDate = p.Field<DateTime>("po_date"),
                                    Comments = p.Field<string>("comments"),
                                    PoFlag = p.Field<int>("po_flag"),
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
        public static ProductionOrder GetProductionOrder(string poNo)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT po_no,
                                po_date, 
                                comments,
                                po_flag, active, create_at
                                FROM production_order 
                                WHERE po_no =@po_no";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("po_no", poNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new ProductionOrder
                        {

                            PoNo = (string)ds.Tables[0].Rows[0]["po_no"],
                            PoDate = (DateTime)ds.Tables[0].Rows[0]["po_date"],
                            Comments = (string)ds.Tables[0].Rows[0]["comments"],
                            PoFlag = (int)ds.Tables[0].Rows[0]["po_flag"],
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
        public static bool Insert(ProductionOrder po)
        {
            MySqlTransaction tr = null;
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {


                    po.PoNo = DocumentGenerate.GetDocumentRunning("PO");
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"INSERT INTO production_order 
                                (po_no,
                                po_date, 
                                po_flag,
                                active,  
                                comments,
                                create_by)
                                VALUES(
                                @po_no,
                                @po_date, 
                                @po_flag,
                                @active,
                                @comments,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("po_no", po.PoNo);
                    cmd.Parameters.AddWithValue("po_date", po.PoDate);
                    cmd.Parameters.AddWithValue("po_flag", po.PoFlag);
                    cmd.Parameters.AddWithValue("active", po.Active);
                    cmd.Parameters.AddWithValue("comments", po.Comments);
                    cmd.Parameters.AddWithValue("create_by", po.CreateBy);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO production_order_item
                                (po_no,
                                product_code,
                                seq,
                                po_qty,
                                po_wgh,
                                create_by)
                                VALUES(
                                @po_no,
                                @product_code,
                                @seq,
                                @po_qty,
                                @po_wgh,
                                @create_by)";

                    foreach (var item in po.ProductionOrderItem)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("po_no", po.PoNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("po_qty", item.PoQty);
                        cmd.Parameters.AddWithValue("po_wgh", item.PoWgh);
                        cmd.Parameters.AddWithValue("create_by", po.CreateBy);
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
        public static bool Update(ProductionOrder po)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"SELECT po_flag FROM production_order  WHERE po_no=@po_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("po_no", po.PoNo);
                    var orderFlag = (int)cmd.ExecuteScalar();
                    if (orderFlag > 0)
                    {
                        throw new Exception("ไม่สามารถบันทึกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    }


                    sql = @"UPDATE production_order 
                                SET po_date=@po_date, 
                                po_flag=@po_flag,
                                comments=@comments,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE po_no=@po_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("po_no", po.PoNo);
                    cmd.Parameters.AddWithValue("po_date", po.PoDate);
                    cmd.Parameters.AddWithValue("comments", po.Comments);
                    cmd.Parameters.AddWithValue("po_flag", po.PoFlag);
                    cmd.Parameters.AddWithValue("active", po.Active);
                    cmd.Parameters.AddWithValue("modified_by", po.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();

                    sql = @"Delete From production_order_item 
                                WHERE po_no=@po_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("po_no", po.PoNo);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO production_order_item
                                (po_no,
                                product_code,
                                seq,
                                po_qty,
                                po_wgh,
                                create_by)
                                VALUES(
                                @po_no,
                                @product_code,
                                @seq,
                                @po_qty,
                                @po_wgh,
                                @create_by)";

                    foreach (var item in po.ProductionOrderItem)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("po_no", po.PoNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("po_qty", item.PoQty);
                        cmd.Parameters.AddWithValue("po_wgh", item.PoWgh);
                        cmd.Parameters.AddWithValue("create_by", po.CreateBy);
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
    }
    public static class ProductionOrderItemController
    {
        public static DataTable GetProductionOrderItems(string poNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select a.seq,
                                a.product_code,
                                b.product_name,
                                po_qty,
                                po_wgh,
                                unload_qty,
                                unload_wgh
                                from production_order_item a,product b
                                where a.product_code =b.product_code
                                and a.po_no =@po_no 
                                order by seq asc";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("po_no", poNo);
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
