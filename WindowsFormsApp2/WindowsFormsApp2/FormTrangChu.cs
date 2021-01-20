using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;
using WindowsFormsApp2.Views;

namespace WindowsFormsApp2
{
    public partial class FormTrangChu : Form
    {
        //public static int maNhanVien;
        private string tendangnhap;
        List<string> DanhSachQuyen;
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void tsmQuanLySanPham_Click(object sender, EventArgs e)
        {
            string name = "tsmQuanLySanPham";
            HienThiFormQuanLySanPham(name);
        }

        private void tsmDangNhap_Click(object sender, EventArgs e)
        {
            string name = "tsmDangNhap";
            KhoaChucNangHeThong(false);
            HienThiFormDangNhap(name);
        }
        private void MoKhoaChucNangHeThong(bool islock)
        {
            tsmQuenMatKhau.Enabled = islock;
        }
        private void KhoaChucNangHeThong(bool islock)
        {
            // Cài đặt trạng thai
            tsmQuenMatKhau.Enabled = !islock;
            tsmTaoTaiKhoan.Enabled = islock;
            tsmDanhMucQuanLy.Enabled = islock;
            tsmDangXuat.Enabled = islock;
            tsmDangNhap.Enabled = !islock;
            tsmThongKe.Enabled = islock;
        }

        private bool HienThiForm(string nameForm)
        {
            Form form = this.MdiChildren.Where(f => f.Name == nameForm).FirstOrDefault();
            
            if (form != null)
            {
                
                form.Activate();
                return true;
            }
            return false;
        }

        private void HienThiFormQuanLySanPham(string name)
        {
            if (!HienThiForm(name))
            {
                FormQL_SanPham formQL_SanPham = new FormQL_SanPham();
                formQL_SanPham.MdiParent = this;
                formQL_SanPham.Show();
            }
        }

        private void HienThiFormDangNhap(string name)
        {
            if (!HienThiForm(name))
            {
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.MdiParent = this;
                formDangNhap.chungThucTaiKhoan += ChungThucTaiKhoan;
                formDangNhap.Show();
            }
        }

        private void HienThiFormDatHang(string name)
        {
            if (!HienThiForm(name))
            {
                FormDatHang formDatHang = new FormDatHang();
                formDatHang.MdiParent = this;
                formDatHang.Show();
            }
        }

        private void ChungThucTaiKhoan(object sender)
        {
            Employee employee = (Employee)sender;
            // lấy danh sách các quyền 
            string ten = FormDangNhap.tenNhanVien = employee.Name;
            this.Text = "Nhân viên: " + ten;
            DanhSachQuyen = employee.RoleDetails.Select(x => x.Role.NameRole).ToList();
            KhoaChucNangHeThong(true);
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            //HienThiFormDatHang("tsmDatHang");
            KhoaChucNangHeThong(false);

        }

        private void tsmDangXuat_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();

            }
            this.Text = "Hello ";
            KhoaChucNangHeThong(false);
            MessageBox.Show("Đăng xuất thành công");
        }

        private void tsmTrangChu_Click(object sender, EventArgs e)
        {
            HienThiFormDatHang("tsmDatHang");
        }
    }
}
