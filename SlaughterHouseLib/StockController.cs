using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;

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

    }
}
