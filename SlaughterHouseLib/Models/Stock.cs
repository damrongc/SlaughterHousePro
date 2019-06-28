using System;

namespace SlaughterHouseLib.Models
{
    public class Stock
    {
        public DateTime StockDate { get; set; }
        public string StockNo { get; set; }
        public int StockItem { get; set; }
        public string ProductCode { get; set; }
        public int StockQty { get; set; }
        public decimal StockWgh { get; set; }
        public string RefDocumentType { get; set; }
        public string RefDocumentNo { get; set; }
        public string LotNo { get; set; }
        public int LocationCode { get; set; }
        public int BarcodeNo { get; set; }
        public int TransactionType { get; set; }
        public string CreateBy { get; set; }
    }
}
