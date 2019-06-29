using System;
using System.Collections.Generic;


namespace SlaughterHouseLib.Models
{
    public class Order
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public int OrderFlag { get; set; }
        public string Comments { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }

}
