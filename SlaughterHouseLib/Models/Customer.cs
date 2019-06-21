using System;

namespace SlaughterHouseLib.Models
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ShipTo { get; set; }
        public string TaxId { get; set; }
        public string ContactNo { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
