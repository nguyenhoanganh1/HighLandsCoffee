using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Views.ThongKeBaoCao.TonKho
{
    class SanPhamTonKho
    {
        public int id { get; set; }

        public string Name { get; set; }

        public int? Quantity { get; set; }

        public DateTime? ProductDate { get; set; }

        public double? UnitPrice { get; set; }
    }
}
