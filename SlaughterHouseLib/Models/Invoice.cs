using System;
using System.Collections.Generic;


namespace SlaughterHouseLib.Models
{
    public class Invoice
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string RefDocumentNo { get; set; }
        public Customer Customer { get; set; }
        public Truck Truck { get; set; }
        public decimal GrossAmt { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal DiscAmtBill { get; set; }
        public decimal VatRate { get; set; }
        public decimal VatAmt { get; set; }
        public decimal NetAmt { get; set; }
        public int InvoiceFlag { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }

    }
}
