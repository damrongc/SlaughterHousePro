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
    
    public partial class product_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product_group()
        {
            this.products = new HashSet<product>();
        }
    
        public int product_group_code { get; set; }
        public string product_group_name { get; set; }
        public bool active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
