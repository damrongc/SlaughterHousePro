//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlaughterHouseClient
{
    using System;
    using System.Collections.Generic;
    
    public partial class barcode
    {
        public int barcode_no { get; set; }
        public string product_code { get; set; }
        public int qty { get; set; }
        public decimal wgh { get; set; }
        public bool active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
    
        public virtual product product { get; set; }
    }
}