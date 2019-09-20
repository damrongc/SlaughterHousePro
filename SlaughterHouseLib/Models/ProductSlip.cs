using System;
using System.Collections.Generic;

namespace SlaughterHouseLib.Models
{
    public class ProductSlip
    {
        public string ProductSlipNo { get; set; }
        public DateTime ProductSlipDate { get; set; }  
        public string RefDocumentNo { get; set; }
        public string ProductSlipFlag { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<ProductSlipItem> ProductSlipItem { get; set; }
    }
}