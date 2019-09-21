using System;
using System.Collections.Generic;

namespace SlaughterHouseLib.Models
{
    public class ProductSlipItem
    {
        public string ProductSlipNo { get; set; }
        public Product Product { get; set; }
        public Location Location { get; set; }
        public string LotNo { get; set; }
        public int Seq { get; set; }
        public int Qty { get; set; }
        public decimal Wgh { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; } 
    }
}