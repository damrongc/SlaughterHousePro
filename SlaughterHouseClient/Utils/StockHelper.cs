using System;
using System.Linq;

namespace SlaughterHouseClient.Utils
{
    public static class StockHelper

    {
        public static stock_item_running GetStockNo(string documentNo)
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    var documentGenerate = db.document_generate.Find(Constants.STK);

                    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(documentNo)).SingleOrDefault();
                    if (stockItemRunning == null)
                    {
                        //get new stock doc no

                        var stockNo = Constants.STK + documentGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');

                        //insert stock_item_running
                        var newStockItem = new stock_item_running
                        {
                            doc_no = documentNo,
                            stock_no = stockNo,
                            stock_item = 1,
                            create_by = Helper.GetLocalIPAddress()
                        };

                        db.stock_item_running.Add(newStockItem);


                        documentGenerate.running += 1;
                        db.Entry(documentGenerate).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return newStockItem;
                    }
                    else
                    {
                        //documentGenerate.running += 1;
                        //db.Entry(documentGenerate).State = System.Data.Entity.EntityState.Modified;
                        //db.SaveChanges();

                        stockItemRunning.stock_item += 1;
                        db.Entry(stockItemRunning).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return stockItemRunning;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
