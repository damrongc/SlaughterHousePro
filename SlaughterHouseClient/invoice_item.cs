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
    
    public partial class invoice_item
    {
        public string invoice_no { get; set; }
        public string product_code { get; set; }
        public int seq { get; set; }
        public int qty { get; set; }
        public decimal wgh { get; set; }
        public Nullable<decimal> unit_price_current { get; set; }
        public Nullable<decimal> disc_per { get; set; }
        public decimal unit_price { get; set; }
        public decimal unit_disc { get; set; }
        public Nullable<decimal> disc_amt { get; set; }
        public decimal gross_amt { get; set; }
        public decimal net_amt { get; set; }
        public string sale_unit_method { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    
        public virtual invoice invoice { get; set; }
        public virtual product product { get; set; }
    }
}
