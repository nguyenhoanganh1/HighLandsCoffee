namespace WindowsFormsApp2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductDate { get; set; }

        public double? UnitPrice { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Images { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public int? DiscountId { get; set; }

        public virtual CategoryProduct CategoryProduct { get; set; }

        public virtual Discount Discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
