using System;

namespace SlaughterHouseLib.Models
{
    public class InvoiceItem
    {
        public string InvoiceNo { get; set; }
        public int Seq { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public decimal Wgh { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal GrossAmt { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal VatRate { get; set; }
        public decimal VatAmt { get; set; }
        public decimal NetAmt { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
