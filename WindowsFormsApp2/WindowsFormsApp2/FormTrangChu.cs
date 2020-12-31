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
            string name = "tsmQuanLySanPham";
            HienThiQuanLySanPham(name);
        }

        private void tsmDangNhap_Click(object sender, EventArgs e)
        {
            string name = "tsmDangNhap";
            KhoaChucNangHeThong();
            HienThiDangNhap(name);
        }
       
        private void KhoaChucNangHeThong()
        {

        }
        private bool HienThiForm(string nameForm)
        {
            Form form = this.MdiChildren.Where(f => f.Name == nameForm).FirstOrDefault();
            if(form != null)
            {
                form.Activate();
                return true;
            }
            return false;
        }

        private void HienThiQuanLySanPham(string name)
        {
            if(!HienThiForm(name))
            {
                FormQL_SanPham formQL_SanPham = new FormQL_SanPham();
                formQL_SanPham.MdiParent = this;
                formQL_SanPham.Show();
            }
            
        }

        private void HienThiDangNhap(string name)
        {
            if (!HienThiForm(name))
            {
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.MdiParent = this;
                formDangNhap.chungThucTaiKhoan += formDangNhap.chungThucTaiKhoan;
                formDangNhap.Show();
            }
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            this.Text = "Hello ";
        }
    }
}
