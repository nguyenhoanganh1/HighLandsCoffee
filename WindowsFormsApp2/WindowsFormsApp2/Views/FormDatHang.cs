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
        public FormDatHang()
        {
            InitializeComponent();
        }

        private void FormDatHang_Load(object sender, EventArgs e)
        {
                SettingForm();               
                Display();
                txtNgayTao.Text = Convert.ToString(DateTime.Now);
                txtTongTien.Text = "0";            
        }

        public void Display()
        {
            using (var _entity = new QL_BanHangEntities())
            {
                List<ProductDTO2> _studentList = new List<ProductDTO2>();
                _studentList = _entity.Products.Select(x => new ProductDTO2
                {
                    id = x.id,
                    name = x.Name,
                    quantity = x.Quantity.Value,
                    productDate = x.ProductDate.Value,
                    UnitPrice = (decimal)x.UnitPrice.Value,
                    description = x.Description,
                    images = x.Images,
                    categoryId = x.CategoryProduct.Name,
                    supplierId = x.Supplier.Name,
                    DiscountName = x.Discount.Name
                }).ToList();
                dgvDanhSachSanPham.DataSource = _studentList;
            }
        }
        private void SettingForm()
        {
            dgvDanhSachSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvDanhSachSanPham.SelectedRows[0].Cells[0].Value.ToString();
            var context = new QL_BanHangEntities();
            Product product = context.Products.FirstOrDefault(p => p.id.ToString() ==  txtId.Text);
            MemoryStream stream = new MemoryStream(product.Images.ToArray());
            Image img = Image.FromStream(stream);
            pbPhoto.Image = img;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
        
       
        private void dgvDanhSachSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string id = dgvDanhSachSanPham.SelectedRows[0].Cells[0].Value.ToString();
            string name = dgvDanhSachSanPham.SelectedRows[0].Cells[1].Value.ToString();
            int soluong = 1;
            string gia = dgvDanhSachSanPham.SelectedRows[0].Cells[4].Value.ToString();         
            string mota = dgvDanhSachSanPham.SelectedRows[0].Cells[5].Value.ToString();
            string loai = dgvDanhSachSanPham.SelectedRows[0].Cells[7].Value.ToString();
            string nhaCungCap = dgvDanhSachSanPham.SelectedRows[0].Cells[8].Value.ToString();
            string maGiamGia = dgvDanhSachSanPham.SelectedRows[0].Cells[9].Value.ToString();
            try
            {
                using(var context = new QL_BanHangEntities())
                {
                    Product product = context.Products.Where(p => p.id.ToString() == id).FirstOrDefault();
                    if(product != null)
                    {
                        
                        dgvDatHang.ColumnCount = 9;
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
                            id, name, soluong++.ToString(), gia, mota,loai,nhaCungCap,maGiamGia
                        };
                        dgvDatHang.Rows.Add(row);
                    }
                    else
                    {
                        dgvDatHang.ColumnCount = 9;
                        dgvDatHang.Columns[0].Name = "Mã Sản phẩm";
                        dgvDatHang.Columns[1].Name = "Tên sản phẩm";
                        dgvDatHang.Columns[2].Name = "số lượng";
                        dgvDatHang.Columns[3].Name = "giá";
                        dgvDatHang.Columns[4].Name = "Mô Tả";
                        dgvDatHang.Columns[6].Name = "Loại";
                        dgvDatHang.Columns[7].Name = "Nhà Cung Cấp";
                        dgvDatHang.Columns[8].Name = "Mã giảm giá";
                        string[] row = new string[]
                        {
                            id, name, soluong.ToString(), gia, mota,loai,nhaCungCap,maGiamGia
                        };
                        dgvDatHang.Rows.Add(row);
                    }
                }                              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
