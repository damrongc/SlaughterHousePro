using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SlaughterHouseLib
{
    public class StockController
    {
        public static bool InsertStockSwineReceive(string receiveNo)
        {
            //int stockItem = 1;
            //var stockNo = "";
            var receive = ReceiveController.GetReceive(receiveNo);
            var plant = PlantController.GetPlant();
            var conn = new MySqlConnection(Globals.CONN_STR);
            MySqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                //var sql = @"SELECT stock_item,
                //                   stock_no
                //                FROM stock_item_running 
                //                WHERE doc_no=@doc_no";

                //var cmd = new MySqlCommand(sql, conn)
                //{
                //    Transaction = transaction
                //};

                //cmd.Parameters.AddWithValue("doc_no", receiveNo);

                //var da = new MySqlDataAdapter(cmd);
                //var ds = new DataSet();
                //da.Fill(ds);
                //DataTable dt = ds.Tables[0];
                //if (dt.Rows.Count == 0)
                //{
                //    stockItem = 1;
                //    stockNo = DocumentGenerate.GetDocumentRunning("STK");
                //}
                //else
                //{
                //    stockNo = dt.Rows[0]["stock_no"].ToString();
                //    stockItem = dt.Rows[0]["stock_item"].ToString().ToInt16() + 1;
                //}

                var stockItemRunning = StockItemRunningController.GetStockItem(receiveNo);

                var stock = new Stock
                {
                    StockDate = plant.ProductionDate,
                    StockNo = stockItemRunning.StockNo,
                    StockItem = stockItemRunning.StockItem,
                    ProductCode = "P001",
                    RefDocumentNo = receive.ReceiveNo,
                    RefDocumentType = "REV",
                    LotNo = DocumentGenerate.GetSwineLotNo(plant.PlantId, plant.ProductionDate, receive.QueueNo),
                    StockQty = receive.FactoryQty,
                    StockWgh = receive.FactoryWgh,
                    BarcodeNo = 0,
                    TransactionType = 1,
                    LocationCode = 1,
                    CreateBy = "system",
                };

                var sql = @"INSERT INTO stock
                        (stock_date,
                        stock_no,
                        stock_item,
                        product_code,
                        stock_qty,
                        stock_wgh,  
                        ref_document_type,
                        ref_document_no,
                        lot_no,
                        location_code,
                        barcode_no,
                        transaction_type,
                        create_by)
                        VALUES
                        (
                        @stock_date,
                        @stock_no,
                        @stock_item,
                        @product_code,
                        @stock_qty,
                        @stock_wgh,
                        @ref_document_type,
                        @ref_document_no,
                        @lot_no,
                        @location_code,
                        @barcode_no,
                        @transaction_type,
                        @create_by)";

                var cmd = new MySqlCommand(sql, conn)
                {
                    Transaction = transaction
                };


                cmd.Parameters.AddWithValue("stock_date", stock.StockDate);
                cmd.Parameters.AddWithValue("stock_no", stock.StockNo);
                cmd.Parameters.AddWithValue("stock_item", stock.StockItem);
                cmd.Parameters.AddWithValue("product_code", stock.ProductCode);
                cmd.Parameters.AddWithValue("stock_qty", stock.StockQty);
                cmd.Parameters.AddWithValue("stock_wgh", stock.StockWgh);
                cmd.Parameters.AddWithValue("ref_document_type", stock.RefDocumentType);
                cmd.Parameters.AddWithValue("ref_document_no", stock.RefDocumentNo);
                cmd.Parameters.AddWithValue("lot_no", stock.LotNo);
                cmd.Parameters.AddWithValue("location_code", stock.LocationCode);
                cmd.Parameters.AddWithValue("barcode_no", stock.BarcodeNo);
                cmd.Parameters.AddWithValue("transaction_type", stock.TransactionType);
                cmd.Parameters.AddWithValue("create_by", stock.CreateBy);
                cmd.ExecuteNonQuery();

                sql = @"UPDATE receives SET receive_flag=1 WHERE receive_no=@receive_no";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("receive_no", receiveNo);
                cmd.ExecuteNonQuery();


                if (stock.StockItem == 1)
                {
                    //insert stock_item_running
                    sql = @"INSERT INTO stock_item_running(doc_no,stock_no,stock_item,create_by)
                                VALUES(@doc_no,@stock_no,@stock_item,@create_by)";

                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("doc_no", stock.RefDocumentNo);
                    cmd.Parameters.AddWithValue("stock_no", stock.StockNo);
                    cmd.Parameters.AddWithValue("stock_item", stock.StockItem);
                    cmd.Parameters.AddWithValue("create_by", stock.CreateBy);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                    //update stock_item_running
                    sql = @"UPDATE stock_item_running 
                            SET stock_item=@stock_item,
                                modified_at=@modified_at,
                                modified_by=@modified_by
                            WHERE doc_no=@doc_no 
                            AND stock_no=@stock_no";
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("doc_no", stock.RefDocumentNo);
                    cmd.Parameters.AddWithValue("stock_no", stock.StockNo);
                    cmd.Parameters.AddWithValue("stock_item", stock.StockItem);
                    cmd.Parameters.AddWithValue("modified_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("modified_by", stock.CreateBy);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();

                return true;

            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        public static bool InsertStock(Stock stock, MySqlCommand cmd)
        {

            try
            {


                //var stock = new Stock
                //{
                //    StockDate = plant.ProductionDate,
                //    StockNo = stockNo,
                //    StockItem = stockItem,
                //    ProductCode = "P001",
                //    RefDocumentNo = receive.ReceiveNo,
                //    RefDocumentType = "REV",
                //    LotNo = DocumentGenerate.GetSwineLotNo(plant.PlantId, plant.ProductionDate, receive.QueueNo),
                //    StockQty = receive.FactoryQty,
                //    StockWgh = receive.FactoryWgh,
                //    BarcodeNo = 0,
                //    TransactionType = 1,
                //    LocationCode = 1,
                //    CreateBy = "system",
                //};

                var sql = @"INSERT INTO stock
                        (stock_date,
                        stock_no,
                        stock_item,
                        product_code,
                        stock_qty,
                        stock_wgh,  
                        ref_document_type,
                        ref_document_no,
                        lot_no,
                        location_code,
                        barcode_no,
                        transaction_type,
                        create_by)
                        VALUES
                        (
                        @stock_date,
                        @stock_no,
                        @stock_item,
                        @product_code,
                        @stock_qty,
                        @stock_wgh,
                        @ref_document_type,
                        @ref_document_no,
                        @lot_no,
                        @location_code,
                        @barcode_no,
                        @transaction_type,
                        @create_by)";


                cmd.CommandText = sql;
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("stock_date", stock.StockDate);
                cmd.Parameters.AddWithValue("stock_no", stock.StockNo);
                cmd.Parameters.AddWithValue("stock_item", stock.StockItem);
                cmd.Parameters.AddWithValue("product_code", stock.ProductCode);
                cmd.Parameters.AddWithValue("stock_qty", stock.StockQty);
                cmd.Parameters.AddWithValue("stock_wgh", stock.StockWgh);
                cmd.Parameters.AddWithValue("ref_document_type", stock.RefDocumentType);
                cmd.Parameters.AddWithValue("ref_document_no", stock.RefDocumentNo);
                cmd.Parameters.AddWithValue("lot_no", stock.LotNo);
                cmd.Parameters.AddWithValue("location_code", stock.LocationCode);
                cmd.Parameters.AddWithValue("barcode_no", stock.BarcodeNo);
                cmd.Parameters.AddWithValue("transaction_type", stock.TransactionType);
                cmd.Parameters.AddWithValue("create_by", stock.CreateBy);
                cmd.ExecuteNonQuery();

                if (stock.StockItem == 1)
                {
                    //insert stock_item_running
                    sql = @"INSERT INTO stock_item_running(doc_no,stock_no,stock_item,create_by)
                                VALUES(@doc_no,@stock_no,@stock_item,@create_by)";

                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("doc_no", stock.RefDocumentNo);
                    cmd.Parameters.AddWithValue("stock_no", stock.StockNo);
                    cmd.Parameters.AddWithValue("stock_item", stock.StockItem);
                    cmd.Parameters.AddWithValue("create_by", stock.CreateBy);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                    //update stock_item_running
                    sql = @"UPDATE stock_item_running 
                            SET stock_item=@stock_item,
                                modified_at=@modified_at,
                                modified_by=@modified_by
                            WHERE doc_no=@doc_no 
                            AND stock_no=@stock_no";
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("doc_no", stock.RefDocumentNo);
                    cmd.Parameters.AddWithValue("stock_no", stock.StockNo);
                    cmd.Parameters.AddWithValue("stock_item", stock.StockItem);
                    cmd.Parameters.AddWithValue("modified_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("modified_by", stock.CreateBy);
                    cmd.ExecuteNonQuery();
                }

                return true; 
            }
            catch (Exception)
            {

                throw;
            }


        }
        public static DataTable GetCfLocation(string productCode, string lotNo = "")
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    string sql = @"
                                Select  p.product_name, stk.lot_no, loc.location_code, loc.location_name, 
                                case when p.issue_unit_method = 'W' 
                                    then sum(case when stk.transaction_type = '1' then stk.stock_wgh else stk.stock_wgh*-1 end)
                                    else sum(case when stk.transaction_type = '1' then stk.stock_qty else stk.stock_qty*-1 end)
                                    end as qty_wgh, p.issue_unit_method
                                From stock stk, product p, location loc
                                where 1 = 1 
                                 and stk.stock_date = DATE_FORMAT(SYSDATE(), '%Y-%m-%d')
                                 and stk.product_code = @product_code ";
                        if (lotNo != "") {
                            sql += " and stk.lot_no = @lot_no ";
                        }
                                 
                        sql += @" and stk.product_code = p.product_code
                                and stk.location_code = loc.location_code
                                group by p.product_name, stk.lot_no,  stk.transaction_type, loc.location_code, loc.location_name, p.issue_unit_method, p.sale_unit_method
                                having case when p.sale_unit_method = 'W' 
                                then sum(case when stk.transaction_type = '1' then stk.stock_wgh else stk.stock_wgh*-1 end) 
                                else sum(case when stk.transaction_type = '1' then stk.stock_qty else stk.stock_qty*-1 end) 
                                end > 0
                                order by stk.lot_no 
                                        ";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    if (lotNo != "")
                    {
                        cmd.Parameters.AddWithValue("lot_no", lotNo);
                    } 
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);


                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                LocationCode = p.Field<int>("location_code"),
                    //                LocationName = p.Field<string>("location_name"),
                    //                LotNo = p.Field<string>("lot_no"),
                    //                QtyWgh = p.Field<decimal>("qty_wgh"),
                    //            }).ToList();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
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
        public static object GetProductionDate()
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    string sql = @" SELECT production_date FROM slaughterhouse.plant
                                   where plant_id = 1 ";

                    var cmd = new MySqlCommand(sql, conn); 
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds); 
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return (DateTime)ds.Tables[0].Rows[0]["production_date"];
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
        public static DataTable  GetStockBfOfDay(DateTime pDate)
        {
            try
            { 
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    string sql = @" SELECT s.stock_date,
                                    s.stock_no,
                                    s.stock_item,
                                    loc.location_name,
                                    s.product_code,
                                    p.product_name,
                                    s.lot_no,
                                    s.stock_qty as qty,
                                    s.stock_wgh as wgh
                                FROM stock s,
                                  location loc,
                                  product p 
                                where s.stock_date = @stock_date
                                and s.location_code = loc.location_code
                                and s.transaction_type ='1'
                                and s.ref_document_type = 'BF' 
                                and s.product_code = p.product_code ";

                    var cmd = new MySqlCommand(sql, conn); 
                    cmd.Parameters.AddWithValue("stock_date", pDate.ToString("yyyy-MM-dd"));
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
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
        public static int GenStockBfDay(DateTime pDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    MySqlCommand cmd = new MySqlCommand("GenStockBfDay", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("pDate", pDate.ToString("yyyy-MM-dd")));
                    conn.Open();
                    return cmd.ExecuteNonQuery();  
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int CancelStockBfDay(DateTime pDate)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    MySqlCommand cmd = new MySqlCommand("CancelStockBfDay", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("pDate", pDate.ToString("yyyy-MM-dd")));
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
