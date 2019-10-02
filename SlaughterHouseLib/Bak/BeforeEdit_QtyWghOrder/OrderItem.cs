using System;

namespace SlaughterHouseLib.Models
{
    public class OrderItem
    {
        public string OrderNo { get; set; }
        public int Seq { get; set; }
        public Product Product { get; set; }
        public int OrderQty { get; set; }
        public decimal OrderWgh { get; set; }
        public int UnloadQty { get; set; }
        public decimal UnloadWgh { get; set; }
        public int BomCode { get; set; }
        public int OrderSetQty { get; set; }
        public decimal OrderSetWgh { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
 
    }
}