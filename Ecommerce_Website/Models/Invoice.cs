//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce_Website.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            this.Order_tbl = new HashSet<Order_tbl>();
        }
    
        public int InvoiceId { get; set; }
        public Nullable<int> Invoice_FK_User { get; set; }
        public Nullable<System.DateTime> Invoicedate { get; set; }
        public Nullable<double> InvoiceTotalBill { get; set; }
    
        public virtual User_tbl User_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_tbl> Order_tbl { get; set; }
    }
}
