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
    
    public partial class order
    {
        public order()
        {
            this.order_item = new HashSet<order_item>();
        }
    
        public string order_no { get; set; }
        public System.DateTime order_date { get; set; }
        public string customer_code { get; set; }
        public int order_flag { get; set; }
        public string comments { get; set; }
        public bool active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
        public int invoice_flag { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual ICollection<order_item> order_item { get; set; }
    }
}
