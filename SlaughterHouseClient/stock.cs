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
    
    public partial class stock
    {
        public System.DateTime stock_date { get; set; }
        public string stock_no { get; set; }
        public int stock_item { get; set; }
        public string product_code { get; set; }
        public int stock_qty { get; set; }
        public decimal stock_wgh { get; set; }
        public string ref_document_type { get; set; }
        public string ref_document_no { get; set; }
        public string lot_no { get; set; }
        public int location_code { get; set; }
        public int barcode_no { get; set; }
        public int transaction_type { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
    
        public virtual location location { get; set; }
        public virtual product product { get; set; }
    }
}
