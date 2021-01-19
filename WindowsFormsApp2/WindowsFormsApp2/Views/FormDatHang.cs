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

namespace WindowsFormsApp2.Views
{
    public partial class FormDatHang : Form
    {
        Model1 context = new Model1();
        static string[] row;
        public FormDatHang()
        {
            InitializeComponent();
        }

        private void FormDatHang_Load(object sender, EventArgs e)
        {

            SettingForm();
            Display();
            dgvDatHang.Visible = false;

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
                DiscountName = x.Discount.Name
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
                dgvDatHang.Rows.Clear();
                txtTongTien.Text = "0";
                txtNgayTao.Text = Convert.ToString(DateTime.Now);

                int ma = context.Orders.Select(x => x.Id).Max();
                txtMaHoaDon1.Text = (ma + 1).ToString();

                Order orderId = context.Orders.Where(x => x.Id == ma + 1).FirstOrDefault();
                if (orderId != null)
                {
                    MessageBox.Show("Mã đã tồn tại. xin nhập Mã khác " + orderId);
                }
                else
                {

                    dgvDatHang.Visible = true;
                    Order order = new Order();
                    order.Id = ma;
                    order.Address = txtDiaChi.Text;
                    order.OrderDate = DateTime.Now;
                    order.Amount = Convert.ToDecimal(txtTongTien.Text);
                    context.Orders.Add(order);
                    context.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDanhSachSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtMaHoaDon1.Text))
                {
                    MessageBox.Show("Vui lòng tạo hóa đơn");
                }
                else
                {
                    string id = dgvDanhSachSanPham.SelectedRows[0].Cells[0].Value.ToString();
                    string name = dgvDanhSachSanPham.SelectedRows[0].Cells[1].Value.ToString();
                    int soluong = 1;
                    double gia = Convert.ToDouble(dgvDanhSachSanPham.SelectedRows[0].Cells[4].Value);
                    string mota = dgvDanhSachSanPham.SelectedRows[0].Cells[5].Value.ToString();
                    string loai = dgvDanhSachSanPham.SelectedRows[0].Cells[7].Value.ToString();
                    string nhaCungCap = dgvDanhSachSanPham.SelectedRows[0].Cells[8].Value.ToString();
                    string maGiamGia = dgvDanhSachSanPham.SelectedRows[0].Cells[9].Value.ToString();
                    dgvDatHang.ColumnCount = 8;
                    dgvDatHang.Columns[0].Name = "Mã Sản phẩm";
                    dgvDatHang.Columns[1].Name = "Tên sản phẩm";
                    dgvDatHang.Columns[2].Name = "số lượng";
                    dgvDatHang.Columns[3].Name = "giá";
                    dgvDatHang.Columns[4].Name = "Mô Tả";
                    dgvDatHang.Columns[5].Name = "Loại";
                    dgvDatHang.Columns[6].Name = "Nhà Cung Cấp";
                    dgvDatHang.Columns[7].Name = "Mã giảm giá";
                    txtId.Text = id;
                    row = new string[]
                    {
                            id, name, soluong.ToString(), gia.ToString(), mota,loai,nhaCungCap,maGiamGia
                    };
                    dgvDatHang.Rows.Add(row);

                    ProductDetail productDetail = new ProductDetail();
                    productDetail.OrderId = Convert.ToInt32(txtMaHoaDon1.Text);
                    productDetail.ProductId = Convert.ToInt32(txtId.Text);
                    productDetail.Quantity = soluong;
                    productDetail.UnitPrice = gia;
                    context.ProductDetails.Add(productDetail);
                    context.SaveChanges();
                    //Nếu như Id Order và Id Sản phẩm = id order va id sản phẩm thì tính tiền
                    string product = context.ProductDetails.Select(x => x.Product.Discount.Name).FirstOrDefault();
                    if (product.Equals("5"))
                    {
                        double g = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) * 0.05).Value;
                        txtTongTien.Text = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) - g).Value.ToString();
                        Product p = context.Products.Where(x => x.id.ToString() == txtId.Text).FirstOrDefault();
                        if (p != null)
                        {
                            p.Quantity -= soluong;
                            context.SaveChanges();
                        }

                    }
                    else if (product.Equals("10"))
                    {
                        double g = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) * 0.10).Value;
                        txtTongTien.Text = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) - g).Value.ToString();
                        Product p = context.Products.Where(x => x.id.ToString() == txtId.Text).FirstOrDefault();
                        if (p != null)
                        {
                            p.Quantity -= soluong;
                            context.SaveChanges();
                        }
                    }
                    else if (product.Equals("15"))
                    {
                        double g = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) * 0.15).Value;
                        txtTongTien.Text = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) - g).Value.ToString();
                        Product p = context.Products.Where(x => x.id.ToString() == txtId.Text).FirstOrDefault();
                        if (p != null)
                        {
                            p.Quantity -= soluong;
                            context.SaveChanges();
                        }
                    }
                    else if (product.Equals("20"))
                    {
                        double g = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) * 0.20).Value;
                        txtTongTien.Text = context.ProductDetails.Where(x => x.OrderId == productDetail.OrderId).Sum(x => (x.Quantity * x.UnitPrice) - g).Value.ToString();
                        Product p = context.Products.Where(x => x.id.ToString() == txtId.Text).FirstOrDefault();
                        if (p != null)
                        {
                            p.Quantity -= soluong;
                            context.SaveChanges();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Display();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHoaDon1.Text))
            {
                MessageBox.Show("Vui lòng tạo hóa đơn");
            }
            else
            {
                context.Orders.Where(x => x.Id.ToString() == txtMaHoaDon1.Text).FirstOrDefault().Amount = Convert.ToDecimal(txtTongTien.Text);
                context.Orders.Where(x => x.Id.ToString() == txtMaHoaDon1.Text).FirstOrDefault().Address = txtDiaChi.Text;
                context.SaveChanges();

                clear();
                MessageBox.Show("Thanh Toán Thành Công ");
            }
        }
        private void clear()
        {
            dgvDatHang.Rows.Clear();
            txtDiaChi.Text = txtMaHoaDon1.Text = txtNgayTao.Text = txtTongTien.Text = txtId.Text = " ";
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
                DiscountName = x.Discount.Name
            }).Where(x => x.name.Contains(search) || x.supplierId.Contains(search)).ToList();
            dgvDanhSachSanPham.DataSource = _studentList;

        }


    }
}
