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
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.barcodes = new HashSet<barcode>();
            this.boms = new HashSet<bom>();
            this.bom_item = new HashSet<bom_item>();
            this.invoice_item = new HashSet<invoice_item>();
            this.orders_item = new HashSet<orders_item>();
            this.production_order_item = new HashSet<production_order_item>();
            this.receive_item = new HashSet<receive_item>();
            this.product_slip_item = new HashSet<product_slip_item>();
            this.stocks = new HashSet<stock>();
            this.transport_item = new HashSet<transport_item>();
        }
    
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int product_group_code { get; set; }
        public int unit_of_qty { get; set; }
        public int unit_of_wgh { get; set; }
        public Nullable<decimal> min_weight { get; set; }
        public Nullable<decimal> max_weight { get; set; }
        public Nullable<decimal> std_yield { get; set; }
        public string sale_unit_method { get; set; }
        public string issue_unit_method { get; set; }
        public Nullable<int> shelflife { get; set; }
        public Nullable<decimal> packing_size { get; set; }
        public bool active { get; set; }
        public System.DateTime create_at { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public string modified_by { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<barcode> barcodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bom> boms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bom_item> bom_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice_item> invoice_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders_item> orders_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<production_order_item> production_order_item { get; set; }
        public virtual product_group product_group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receive_item> receive_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product_slip_item> product_slip_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stock> stocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transport_item> transport_item { get; set; }
        public virtual unit_of_measurement unit_of_measurement { get; set; }
        public virtual unit_of_measurement unit_of_measurement1 { get; set; }
    }
}
