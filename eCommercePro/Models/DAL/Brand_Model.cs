//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eCommercePro.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brand_Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand_Model()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int id { get; set; }
        public int model_id { get; set; }
        public int brand_id { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}