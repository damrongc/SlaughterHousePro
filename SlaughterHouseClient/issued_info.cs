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
    
    public partial class issued_info
    {
        public System.DateTime issued_date { get; set; }
        public string product_code { get; set; }
        public string lot_no { get; set; }
        public int issued_qty { get; set; }
        public decimal issued_wgh { get; set; }
        public Nullable<int> usage_qty { get; set; }
        public Nullable<decimal> usage_wgh { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    }
}
