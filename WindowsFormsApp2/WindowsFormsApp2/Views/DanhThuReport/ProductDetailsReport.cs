using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Views.DanhThuReport
{
    class ProductDetailsReport
    {

        public string tenLoai { get; set; }

        public int quantity { get; set; }

        public double unitPrice { get; set; }

        public double maxUnitPrice { get; set; }

        public double minUnitPrice { get; set; }

        public double avgUnitPrice { get; set; }
    }
}
