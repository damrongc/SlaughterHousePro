using System;

namespace SlaughterHouseLib.Models
{
    public class ProductionOrderItem
    {
        public string PoNo { get; set; }
        public int Seq { get; set; }
        public Product Product { get; set; }
        public int PoQty { get; set; }
        public decimal PoWgh { get; set; }
        public int UnloadQty { get; set; }
        public decimal UnloadWgh { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }


}
