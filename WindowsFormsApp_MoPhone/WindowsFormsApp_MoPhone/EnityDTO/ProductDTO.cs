using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_MoPhone.EnityDTO
{
    class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> productDate { get; set; }
        public Nullable<decimal> unitPrice { get; set; }
        public string description { get; set; }
        public byte[] images { get; set; }
        public string supplierName { get; set; }
        public string categoryName { get; set; }
        public int discountId { get; set; }
    }
}
