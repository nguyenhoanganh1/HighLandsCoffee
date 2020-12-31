using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Views;

namespace WindowsFormsApp2
{
    public partial class FormTrangChu : Form
    {
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void tsmQuanLySanPham_Click(object sender, EventArgs e)
        {
            FormQL_SanPham formQL_SanPham = new FormQL_SanPham();
            formQL_SanPham.Show();
        }

        private void tsmDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
        }
    }
}
