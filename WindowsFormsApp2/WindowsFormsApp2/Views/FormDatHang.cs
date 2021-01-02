﻿using System;
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
                dgvDatHang.Visible = false;
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
            decimal gia = Convert.ToDecimal( dgvDanhSachSanPham.SelectedRows[0].Cells[4].Value.ToString());         
            string mota = dgvDanhSachSanPham.SelectedRows[0].Cells[5].Value.ToString();
            string loai = dgvDanhSachSanPham.SelectedRows[0].Cells[7].Value.ToString();
            string nhaCungCap = dgvDanhSachSanPham.SelectedRows[0].Cells[8].Value.ToString();
            string maGiamGia = dgvDanhSachSanPham.SelectedRows[0].Cells[9].Value.ToString();
            try
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
                    id, name, soluong.ToString(), gia.ToString(), mota,loai,nhaCungCap,maGiamGia
                };
                dgvDatHang.Rows.Add(row);
                using (var context = new QL_BanHangEntities())
                {
                    ProductDetail productDetail = new ProductDetail();
                    productDetail.OrderId = Convert.ToInt32( txtMaHoaDon.Text);
                    productDetail.ProductId = Convert.ToInt32(txtId.Text);
                    productDetail.Quantity = soluong;
                    productDetail.UnitPrice = gia;
                    context.ProductDetails.Add(productDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }          
        }

        
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            /* try
             {*/
            int id = Convert.ToInt32(txtMaHoaDon.Text);
                dgvDatHang.Visible = true;
                string name = "Hóa Đơn";
                txtNgayTao.Text = Convert.ToString(DateTime.Now);
                using (var context = new QL_BanHangEntities())
                {
                    Order order = new Order();
                    {
                        order.Id = id;
                        order.Address = name;
                        order.OrderDate = DateTime.Now;
                        // order.Amount = txtTongTien.Text();
                    }
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
           /* }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
   
        }

        private void dgvDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvDatHang.Rows[dgvDatHang.CurrentRow.Index].Cells[0].Value.ToString());
            using (var context = new QL_BanHangEntities())
            {
                dgvChiTietHoaDon.DataSource = context.ProductDetails.Where(x => x.OrderId == id).Select(
                    x => new { x.Id, x.Quantity, x.UnitPrice, x.OrderId }).ToList();
                //txtTongTien.Text = context.Orders.Where(x => x.Id == id).FirstOrDefault().Amount.ToString(); 
            }
        }

        private void btnLuuDonDathang_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}