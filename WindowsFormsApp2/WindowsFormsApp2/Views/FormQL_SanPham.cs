﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Models;

namespace WindowsFormsApp2.Views
{
    public partial class FormQL_SanPham : Form
    {
        private Image image;

        public FormQL_SanPham()
        {
            InitializeComponent();
        }
        private void FormQL_SanPham_Load(object sender, EventArgs e)
        {
           try
            {
                    SettingForm();
                    var context = new QL_BanHangEntities();
                    List<Product> products = context.Products.ToList(); 
                    List<CategoryProduct> categoryProducts = context.CategoryProducts.ToList();
                    List<Supplier> suppliers = context.Suppliers.ToList();        
                    FillCategory(categoryProducts);
                    FillSupplier(suppliers);     
                    Display();           
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            
        }

        public void Display()   
        {
            using (QL_BanHangEntities _entity = new QL_BanHangEntities())
            {
                List<ProductDTO2> _studentList = new List<ProductDTO2>();
                _studentList = _entity.Products.Select(x => new ProductDTO2
                {
                    id = x.id,
                    name = x.Name,
                    quantity = x.Quantity.Value,
                    productDate = x.ProductDate.Value,
                    unitPrice = x.UnitPrice.Value,
                    images = x.Images,
                    categoryId = x.CategoryProduct.Name,
                    supplierId = x.Supplier.Name
                }).ToList();
                dgvListSanPham.DataSource = _studentList;
            }
        }
        private void SettingForm()
        {
            dgvListSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FillCategory(List<CategoryProduct> categoryProducts)
        {
            this.cbNhaCungCap.DataSource = categoryProducts;
            this.cbNhaCungCap.ValueMember = "Id";
            this.cbNhaCungCap.DisplayMember = "Name";
        }

        private void FillSupplier(List<Supplier> suppliers)
        {
            this.cbLoai.DataSource = suppliers;
            this.cbLoai.ValueMember = "Id";
            this.cbLoai.DisplayMember = "Name";
        }

        private void BindGrid(List<Product> products)
        {
            dgvListSanPham.Rows.Clear();
            foreach (var item in products)
            {
                int index = dgvListSanPham.Rows.Add();
                dgvListSanPham.Rows[index].Cells[0].Value = item.id;
                dgvListSanPham.Rows[index].Cells[1].Value = item.Name;
                dgvListSanPham.Rows[index].Cells[2].Value = item.Quantity;
                dgvListSanPham.Rows[index].Cells[3].Value = item.ProductDate;
                dgvListSanPham.Rows[index].Cells[4].Value = item.UnitPrice;
                dgvListSanPham.Rows[index].Cells[5].Value = item.Images;
                dgvListSanPham.Rows[index].Cells[6].Value = item.CategoryProduct.Name;
                dgvListSanPham.Rows[index].Cells[7].Value = item.Supplier.Name;
            } 
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                string file = openFileDialog1.FileName;

                if (file != null)
                {
                    image = Image.FromFile(file);
                }
                else
                {
                    MessageBox.Show("File không tồn tại");
                }
                pbPhoto.Image = image;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
                
            
        }
       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new QL_BanHangEntities())
                {
                    MemoryStream stream = new MemoryStream();
                    pbPhoto.Image.Save(stream, ImageFormat.Jpeg);
                    Product productId = context.Products.FirstOrDefault(p => p.id.ToString() == txtId.Text);
                
                if (productId != null)
                    {
                        productId.Name = txtTen.Text;
                        productId.Quantity = Convert.ToInt32(txtSoLuong.Text);
                        productId.ProductDate = Convert.ToDateTime(dtpNgay.Text);
                        productId.UnitPrice = Convert.ToDecimal(txtGia.Text);
                        productId.Images = stream.ToArray();
                        productId.SupplierId = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
                        productId.CategoryId = Convert.ToInt32(cbLoai.SelectedValue.ToString());
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        Product product = new Product();
                        product.Name = txtTen.Text;
                        product.Quantity = Convert.ToInt32(txtSoLuong.Text);
                        product.ProductDate = Convert.ToDateTime(dtpNgay.Text);
                        product.UnitPrice = Convert.ToDecimal(txtGia.Text);
                        product.Images = stream.ToArray();
                        product.SupplierId = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
                        product.CategoryId = Convert.ToInt32(cbLoai.SelectedValue.ToString());
                        context.Products.Add(product);
                        context.SaveChanges();
                        MessageBox.Show("Thếm thành công");
                    }      
                }
                Display();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var context = new QL_BanHangEntities())
            {
                Product productId = context.Products.FirstOrDefault(p => p.id.ToString() == txtId.Text);
                if (productId != null)
                {
                    context.Products.Remove(productId);
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
              Display();      
                
            }
        }

        private void dgvListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
            if (dgvListSanPham.Rows.Count > 0)
            {
                txtId.Text = dgvListSanPham.SelectedRows[0].Cells[0].Value.ToString();
                txtTen.Text = dgvListSanPham.SelectedRows[0].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvListSanPham.SelectedRows[0].Cells[2].Value.ToString();
                dtpNgay.Text = dgvListSanPham.SelectedRows[0].Cells[3].Value.ToString();
                txtGia.Text = dgvListSanPham.SelectedRows[0].Cells[4].Value.ToString();
                // hinh anh
                var context = new QL_BanHangEntities();
                Product product = context.Products.FirstOrDefault(p => p.id.ToString() == txtId.Text);
                MemoryStream stream = new MemoryStream(product.Images.ToArray());
                Image img = Image.FromStream(stream);
                pbPhoto.Image = img;
                cbLoai.SelectedIndex = cbLoai.FindStringExact(dgvListSanPham.SelectedRows[0].Cells[6].Value.ToString());
                cbNhaCungCap.SelectedIndex = cbNhaCungCap.FindStringExact(dgvListSanPham.SelectedRows[0].Cells[7].Value.ToString());
            }
        }
    }
}
