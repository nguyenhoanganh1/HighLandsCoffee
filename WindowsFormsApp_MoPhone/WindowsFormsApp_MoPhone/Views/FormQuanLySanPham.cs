﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp_MoPhone.EnityDTO;
using WindowsFormsApp_MoPhone.Models;


namespace WindowsFormsApp_MoPhone.Views
{
    public partial class FormQuanLySanPham : Form
    {
        Models.QL_BanHangEntities model = new Models.QL_BanHangEntities();
        private Image image;

        public FormQuanLySanPham()
        {
            InitializeComponent();
        }

        private void FormQuanLySanPham_Load(object sender, EventArgs e)
        {
           /* try
            {*/
                SettingForm();
                using (var context = new QL_BanHangEntities())
                {
                    {
                        
                        List<CategoryProduct> categoryProducts = model.CategoryProducts.ToList();
                        List<Supplier> suppliers = model.Suppliers.ToList();
                        FillCategory(categoryProducts);
                        FillSupplier(suppliers);
                    }
                }

                Display();
           /* }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }

        private void Display()
        {
            using (var _entity = new QL_BanHangEntities())
            {
                List<ProductDTO> list = new List<ProductDTO>();
                list = model.Products.Select(x => new ProductDTO
                {
                    id = x.id,
                    name = x.Name,
                    quantity = x.Quantity.Value,
                    productDate = x.ProductDate.Value,
                    unitPrice = x.UnitPrice,
                    description = x.Description,
                    images = x.Images,
                    categoryName = x.CategoryProduct.Name,
                    supplierName = x.Supplier.Name,
                    
                }).ToList();
                dgvListSanPham.DataSource = list;
            }
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

        private void SettingForm()
        {
            dgvListSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                     MemoryStream stream = new MemoryStream();
                    pbPhoto.Image.Save(stream, ImageFormat.Jpeg);
                using (QL_BanHangEntities context = new QL_BanHangEntities())
                {

                Product productId = model.Products.FirstOrDefault(x => x.id.ToString() == txtId.Text);

                    if (productId != null)
                    {
                        productId.Name = txtTen.Text;
                        productId.Quantity = Convert.ToInt32(txtSoLuong.Text);
                        productId.ProductDate = Convert.ToDateTime( txtNgay.Text);
                       // productId.UnitPrice = Convert.ToDecimal(txtGia.Text);
                        productId.Images = stream.ToArray();
                        productId.SupplierId = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
                        productId.CategoryId = Convert.ToInt32(cbLoai.SelectedValue.ToString());
                        model.SaveChanges();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        Product product = new Product();
                        
                        product.Name = txtTen.Text;
                        product.Quantity = Convert.ToInt32(txtSoLuong.Text);
                        product.ProductDate = Convert.ToDateTime(txtNgay.Text);
                       // product.UnitPrice = Convert.ToDecimal(txtGia.Text);
                        product.Images = stream.ToArray();
                        product.SupplierId = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
                        product.CategoryId = Convert.ToInt32(cbLoai.SelectedValue.ToString());
                        model.Products.Add(product);
                        model.SaveChanges();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
                Product productId = model.Products.FirstOrDefault(p => p.id.ToString() == txtId.Text);
                if (productId != null)
                {
                    model.Products.Remove(productId);
                    model.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
                Display();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           // Product productId = model.Products.FirstOrDefault(x => x.id.ToString() == txtId.Text);
            if (dgvListSanPham.Rows.Count > 0)
              {
                    foreach (DataGridViewRow row in dgvListSanPham.SelectedRows) // foreach datagridview selected rows values  
                    {
                    txtId.Text = row.Cells[0].Value.ToString();
                    txtTen.Text = row.Cells[1].Value.ToString();
                    txtSoLuong.Text = row.Cells[2].Value.ToString();
                    txtNgay.Text = row.Cells[3].Value.ToString();
                    //txtGia.Text = dgvListSanPham.SelectedRows[0].Cells[5].Value.ToString();
                    //txtMoTa.Text = dgvListSanPham.SelectedRows[0].Cells[5].Value.ToString(); 
                    /*MemoryStream stream = new MemoryStream(productId.Images.ToArray());
                    Image img = Image.FromStream(stream);
                    pbPhoto.Image = img;*/
                    cbLoai.SelectedIndex = cbLoai.FindStringExact(row.Cells[6].Value.ToString());
                    cbNhaCungCap.SelectedIndex = cbNhaCungCap.FindStringExact(row.Cells[7].Value.ToString());
                }
               
              }
              else
              {
                   MessageBox.Show("Không có dữ liệu");
              }           
        }
    }
}
