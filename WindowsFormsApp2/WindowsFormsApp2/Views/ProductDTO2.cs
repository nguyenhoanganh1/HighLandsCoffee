using System;

namespace WindowsFormsApp2.Views
{
    internal class ProductDTO2
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public DateTime productDate { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[] images { get; set; } 
        public string supplierId { get; set; }
        public string categoryId { get; set; }
       
    }
}