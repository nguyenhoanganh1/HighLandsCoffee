using System;

namespace WindowsFormsApp2.Views
{
    internal class ProductDTO2
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public DateTime productDate { get; set; }
        public double UnitPrice { get; set; }
        public string description { get; set; }
        public byte[] images { get; set; }
        public string supplierId { get; set; }
        public string categoryId { get; set; }
        public string DiscountName { get; set; }
    }
}