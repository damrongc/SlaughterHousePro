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
    
    public partial class production_order
    {
        public production_order()
        {
            this.production_order_item = new HashSet<production_order_item>();
        }
    
        public string po_no { get; set; }
        public System.DateTime po_date { get; set; }
        public int po_flag { get; set; }
        public string comments { get; set; }
        public bool active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    
        public virtual ICollection<production_order_item> production_order_item { get; set; }
    }
}