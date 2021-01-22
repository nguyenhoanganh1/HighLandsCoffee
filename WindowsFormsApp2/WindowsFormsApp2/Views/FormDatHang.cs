using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;
using static WindowsFormsApp2.Views.FormDangNhap;

namespace WindowsFormsApp2.Views
{
    public partial class FormDatHang : Form
    {
        public static List<string> DanhSachQuyen;
        Model1 context = new Model1();
        public FormDatHang()
        {
            InitializeComponent();
        }

        private void FormDatHang_Load(object sender, EventArgs e)
        {

            HienThi(false);
            SettingForm();
            Display();
        }
        private void ChungThucTaiKhoan(object sender)
        {
            Employee employee = (Employee)sender;
            // lấy danh sách các quyền 
            string ten = FormDangNhap.tenNhanVien = employee.Name;
            this.Text = "Nhân viên: " + ten;
            DanhSachQuyen = employee.RoleDetails.Select(x => x.Role.NameRole).ToList();


        }
        public void Display()
        {

            List<ProductDTO2> _studentList = new List<ProductDTO2>();
            _studentList = context.Products.Select(x => new ProductDTO2
            {
                id = x.id,
                name = x.Name,
                quantity = x.Quantity.Value,
                productDate = x.ProductDate.Value,
                UnitPrice = x.UnitPrice.Value,
                description = x.Description,
                images = x.Images,
                categoryId = x.CategoryProduct.Name,
                supplierId = x.Supplier.Name,
                DiscountName = x.Discount.Discount1.Value
            }).ToList();
            dgvDanhSachSanPham.DataSource = _studentList;

        }
        private void SettingForm()
        {
            dgvDanhSachSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            try
            {

                txtNgayTao.Text = Convert.ToString(DateTime.Now);
                int ma = context.Orders.Select(x => x.Id).Max();
                txtMaHoaDon.Text = (ma + 1).ToString();
                Order orderId = context.Orders.Where(x => x.Id == ma + 1).FirstOrDefault();
                if (orderId != null)
                {
                    MessageBox.Show("Mã đã tồn tại. xin nhập Mã khác " + orderId);
                }
                else
                {
                    Order order = new Order();
                    order.Id = ma;
                    order.OrderDate = Convert.ToDateTime(txtNgayTao.Text);
                    order.CustomerId = Convert.ToInt32(txtMaKhachHang.Text);
                    context.Orders.Add(order);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng tạo hóa đơn");
            }
            else if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng");

            }
            else
            {

                ProductDetail productDetail = new ProductDetail();

                for (int i = 0; i < dgvDatHang.Rows.Count - 1; i++)
                {
                    if (dgvDatHang.Rows.Count > 0)
                    {
                        productDetail.OrderId = Convert.ToInt32(txtMaHoaDon.Text);
                        productDetail.ProductId = Convert.ToInt32(dgvDatHang.Rows[i].Cells[0].Value.ToString());
                        productDetail.Quantity = Convert.ToInt32(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                        productDetail.UnitPrice = Convert.ToInt32(dgvDatHang.Rows[i].Cells[3].Value.ToString());
                        context.ProductDetails.Add(productDetail);
                        int m = Convert.ToInt32(dgvDatHang.Rows[i].Cells[0].Value.ToString());
                        Product p = context.Products.Where(x => x.id == m).FirstOrDefault();
                        if (p != null)
                        {
                            p.Quantity -= Convert.ToInt32(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                        }
                    }
                }
                context.Orders.Where(x => x.Id.ToString() == txtMaHoaDon.Text).FirstOrDefault().CustomerId = Convert.ToInt32(txtMaKhachHang.Text);
                context.Orders.Where(x => x.Id.ToString() == txtMaHoaDon.Text).FirstOrDefault().Amount = Convert.ToDecimal(txtTongTien.Text);
                context.SaveChanges();
                clear();
                Display();
            }
        }

        public void HienThi(bool b)
        {
            groupHoaDon.Visible = b;

        }

        private void clear()
        {
            dgvDatHang.Rows.Clear();
            txtMaHoaDon.Text = txtNgayTao.Text = txtTongTien.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string search = txtTimKiem.Text;
            List<ProductDTO2> _studentList = new List<ProductDTO2>();
            _studentList = context.Products.Select(x => new ProductDTO2
            {
                id = x.id,
                name = x.Name,
                quantity = x.Quantity.Value,
                productDate = x.ProductDate.Value,
                UnitPrice = x.UnitPrice.Value,
                description = x.Description,
                images = x.Images,
                categoryId = x.CategoryProduct.Name,
                supplierId = x.Supplier.Name,
                DiscountName = x.Discount.Discount1.Value
            }).Where(x => x.name.Contains(search) || x.supplierId.Contains(search)).ToList();
            dgvDanhSachSanPham.DataSource = _studentList;

        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm");

            }
            else if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng");

            }
            else if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }
            else
            {
                int sl = 0;
                double gia = 0;
                double giamgia = 0;
                double sum = 0;

                Product p = context.Products.Where(x => x.id.ToString() == txtMaSanPham.Text).FirstOrDefault();
                p.Quantity = Convert.ToInt32(txtSoLuong.Text);
                dgvDatHang.ColumnCount = 8;
                dgvDatHang.Columns[0].Name = "Mã Sản phẩm";
                dgvDatHang.Columns[1].Name = "Tên sản phẩm";
                dgvDatHang.Columns[2].Name = "số lượng";
                dgvDatHang.Columns[3].Name = "giá";
                dgvDatHang.Columns[4].Name = "Mô Tả";
                dgvDatHang.Columns[5].Name = "Loại";
                dgvDatHang.Columns[6].Name = "Nhà Cung Cấp";
                dgvDatHang.Columns[7].Name = "Mã giảm giá";

                string[] row = new string[]
                {
                   p.id.ToString(),
                   p.Name,
                   p.Quantity.ToString(),
                   p.UnitPrice.ToString(),
                   p.Description,
                   p.CategoryProduct.Name,
                   p.Supplier.Name,
                   p.Discount.Discount1.ToString()
                };
                dgvDatHang.Rows.Add(row);


                for (int i = 0; i < dgvDatHang.Rows.Count - 1; i++)
                {
                    if (dgvDatHang.Rows.Count > 0)
                    {
                        sl = Convert.ToInt32(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                        gia = Convert.ToDouble(dgvDatHang.Rows[i].Cells[3].Value.ToString());
                        giamgia = Convert.ToDouble(dgvDatHang.Rows[i].Cells[7].Value.ToString());

                        sum += (gia * sl) - ((gia * sl) * (giamgia * 0.01));
                    }
                    txtTongTien.Text = sum.ToString();
                }
                HienThi(true);
            }

        }

        private void dgvDanhSachSanPham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachSanPham.SelectedRows)
            {
                txtMaSanPham.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnNhapThongTinKhachHang_Click(object sender, EventArgs e)
        {
            FormQLKhachHang f = new FormQLKhachHang();
            f.ShowDialog();
        }


    }
}
