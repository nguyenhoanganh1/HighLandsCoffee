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
using WindowsFormsApp2.Views.ThongKeBaoCao;
using WindowsFormsApp2.Views.ThongKeBaoCao.cac;

namespace WindowsFormsApp2
{
    public partial class FormTrangChu : Form
    {
        //public static int maNhanVien;
        private string tendangnhap;
        public static List<string> DanhSachQuyen;
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
            tsmLapPhieuGhiNhan.Enabled = islock;
            tsmDatHang.Enabled = islock;
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
        private void HienThiFormBaoCaoDoanhThu(string name)
        {
            if (!HienThiForm(name))
            {
                FormDoanhThu form = new FormDoanhThu();
                form.MdiParent = this;
                form.Show();
            }
        }



        private void ChungThucTaiKhoan(object sender)
        {
            Employee employee = (Employee)sender;
            // lấy danh sách các quyền 
            string ten = FormDangNhap.tenNhanVien = employee.Name;

            DanhSachQuyen = employee.RoleDetails.Select(x => x.Role.NameRole).ToList();
            this.Text = "Nhân viên " + ten;
            if (DanhSachQuyen.Contains("bán hàng"))
            {
                tsmDatHang.Enabled = true;
                tsmDangNhap.Enabled = false;
                tsmQuenMatKhau.Enabled = false;
                tsmDangXuat.Enabled = true;
            }
            else if (DanhSachQuyen.Contains("admin"))
            {
                KhoaChucNangHeThong(true);
            }
            else if (DanhSachQuyen.Contains("quản lý"))
            {
                tsmDanhMucQuanLy.Enabled = true;
                tsmDangNhap.Enabled = false;
                tsmQuenMatKhau.Enabled = false;
                tsmDangXuat.Enabled = true;
            }
            else if (DanhSachQuyen.Contains("thủ kho"))
            {
                tsmDangNhap.Enabled = false;
                tsmQuenMatKhau.Enabled = false;
                tsmLapPhieuGhiNhan.Enabled = true;
                tsmDangXuat.Enabled = true;
            }
            else if (DanhSachQuyen.Contains("kế toán"))
            {
                tsmDangNhap.Enabled = false;
                tsmQuenMatKhau.Enabled = false;
                tsmThongKe.Enabled = true;
                tsmDangXuat.Enabled = true;
            }
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.MdiParent = this;
            f.chungThucTaiKhoan += ChungThucTaiKhoan;
            f.Show();
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

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiFormBaoCaoDoanhThu("tsmBaoCaoDoanhThu");
        }
        public void HienThiFormQLKhachHang(string name)
        {
            if (!HienThiForm(name))
            {
                FormQLKhachHang f = new FormQLKhachHang();
                f.MdiParent = this;
                f.Show();
            }

        }
        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiFormQLKhachHang("tsmQuanLyKhachHang");
        }
        public void HienThiFormTonKho(string name)
        {
            if (!HienThiForm(name))
            {
                FormTonKho f = new FormTonKho();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void tsmTonKho_Click(object sender, EventArgs e)
        {
            HienThiFormTonKho("tsmQuanLyKhachHang");
        }

        public void HienThiFormNhanVien(string name)
        {
            if (!HienThiForm(name))
            {
                FormQuanLyNhanVien f = new FormQuanLyNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void tsmQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            HienThiFormNhanVien("tsmQuanLyNhanVien");
        }
        public void HienThiFormPhanQuyen(string name)
        {
            if (!HienThiForm(name))
            {
                FormPhanQuyen f = new FormPhanQuyen();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void quảnLýPhânQuyênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiFormPhanQuyen("tsmPhanQuyen");
        }
        public void HienThiFormKhuyenMai(string name)
        {
            if (!HienThiForm(name))
            {
                FormKhuyenMai f = new FormKhuyenMai();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void tsmKhuyenMai_Click(object sender, EventArgs e)
        {
            HienThiFormKhuyenMai("tsmKhuyenMai");
        }
        public void HienThiFormNhaCungCap(string name)
        {
            if (!HienThiForm(name))
            {
                FormNhaCungCap f = new FormNhaCungCap();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void tsmNhaCungCap_Click(object sender, EventArgs e)
        {
            HienThiFormNhaCungCap("tsmNhaCungCap");
        }
    }
}
