//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlaughterHouseClient
{
    using System;
    using System.Collections.Generic;
    
    public partial class receive_item
    {
        public string receive_no { get; set; }
        public string product_code { get; set; }
        public int seq { get; set; }
        public string lot_no { get; set; }
        public string sex_flag { get; set; }
        public int receive_qty { get; set; }
        public decimal receive_wgh { get; set; }
        public Nullable<int> chill_qty { get; set; }
        public Nullable<decimal> chill_wgh { get; set; }
        public int transfer_qty { get; set; }
        public decimal transfer_wgh { get; set; }
        public long barcode_no { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    
        public virtual receive receive { get; set; }
        public virtual product product { get; set; }
    }
}
