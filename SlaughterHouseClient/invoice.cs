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
    
    public partial class invoice
    {
        public invoice()
        {
            this.invoice_item = new HashSet<invoice_item>();
        }
    
        public string invoice_no { get; set; }
        public System.DateTime invoice_date { get; set; }
        public string ref_document_no { get; set; }
        public string customer_code { get; set; }
        public decimal gross_amt { get; set; }
        public decimal discount { get; set; }
        public decimal vat_rate { get; set; }
        public decimal vat_amt { get; set; }
        public decimal net_amt { get; set; }
        public int invoice_flag { get; set; }
        public string comments { get; set; }
        public bool active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    
        public virtual ICollection<invoice_item> invoice_item { get; set; }
    }
}
