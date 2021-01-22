namespace WindowsFormsApp2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductDetail
    {
        public int Id { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
