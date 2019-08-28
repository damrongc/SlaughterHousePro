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

        public struct columnDt
        {
            public string order_no;
            public string product_code;
            public string product_name;
            public string bom_code; 
            public string seq;
            public string order_qty;
            public string order_wgh;
            public string unload_qty;
            public string unload_wgh;
            public string order_set_qty;
            public string order_set_wgh;
            public string product_set;
            public string create_at;
            public string create_by;
            public string modified_at;
            public string modified_by;
            public string qty_wgh;
            public string issue_unit_method;
            public string unit_code;
            public string unit_name;
        }
    }
}