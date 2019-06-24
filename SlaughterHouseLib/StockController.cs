using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;

namespace SlaughterHouseLib
{
    public class StockController
    {
        public static bool InsertStockSwineReceive(string receiveNo)
        {

            var receive = ReceiveController.GetReceive(receiveNo);
            var plant = PlantController.GetPlant();
            var conn = new MySqlConnection(Globals.CONN_STR);
            MySqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                var sql = @"SELECT MAX(stock_item) 
                                FROM stock 
                                WHERE stock_date=@stock_date
                                AND product_code=@product_code";
                var cmd = new MySqlCommand(sql, conn)
                {
                    Transaction = transaction
                };

                cmd.Parameters.AddWithValue("stock_date", plant.ProductionDate);
                cmd.Parameters.AddWithValue("product_code", "P001");
                string maxStockItem = cmd.ExecuteScalar().ToString();

                int stockItem = 1;
                if (!string.IsNullOrEmpty(maxStockItem))
                {
                    stockItem = maxStockItem.ToInt16() + 1;
                }

                var stock = new Stock
                {
                    StockDate = plant.ProductionDate,
                    StockItem = stockItem,
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

                sql = @"INSERT INTO stock
                        (stock_date,
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

    }
}
