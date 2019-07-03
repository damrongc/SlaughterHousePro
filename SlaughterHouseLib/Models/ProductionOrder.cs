using System;
using System.Collections.Generic;


namespace SlaughterHouseLib.Models
{
    public class ProductionOrder
    {
        public string PoNo { get; set; }
        public DateTime PoDate { get; set; }
        public int PoFlag { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; } 
        public List<ProductionOrderItem> ProductionOrderItem { get; set; }

    }

}
