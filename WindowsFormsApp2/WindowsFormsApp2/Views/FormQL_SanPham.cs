using Microsoft.Exchange.WebServices.Data;
using System;
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
        Model1 context = new Model1();
        private Image image;

        public static int userId { get; set; }
        public FormQL_SanPham()
        {
            InitializeComponent();
        }
        private void FormQL_SanPham_Load(object sender, EventArgs e)
        {
            try
            {
                CaiDatQuyen();
                SettingForm();

                List<CategoryProduct> categoryProducts = context.CategoryProducts.ToList();
                List<Supplier> suppliers = context.Suppliers.ToList();
                List<Discount> discounts = context.Discounts.ToList();
                FillDiscount(discounts);
                FillCategory(categoryProducts);
                FillSupplier(suppliers);



                Display();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void CaiDatQuyen()
        {

            //if (DanhSachQuyen.Contains("user"))
            {
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnMoFile.Enabled = true;
            }



        }

        private void FillDiscount(List<Discount> discounts)
        {
            this.cbGiamGia.DataSource = discounts;
            this.cbGiamGia.ValueMember = "Id";
            this.cbGiamGia.DisplayMember = "Discount1";
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
            dgvListSanPham.DataSource = _studentList;

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
            /*try
            {*/

            MemoryStream stream = new MemoryStream();
            pbPhoto.Image.Save(stream, ImageFormat.Jpeg);
            Product productId = context.Products.FirstOrDefault(p => p.id.ToString() == txtId.Text);
            if (productId != null)
            {
                productId.Name = txtTen.Text;
                productId.Quantity = Convert.ToInt32(txtSoLuong.Text);
                productId.ProductDate = Convert.ToDateTime(dtpNgay.Text);
                productId.UnitPrice = Convert.ToDouble(txtGia.Text);
                productId.Description = txtMoTa.Text;
                productId.Images = stream.ToArray();
                productId.SupplierId = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
                productId.CategoryId = Convert.ToInt32(cbLoai.SelectedValue.ToString());
                productId.DiscountId = Convert.ToInt32(cbGiamGia.SelectedValue.ToString());
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa không?", "Nhấn Yes Để Sửa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    context.SaveChanges();
                }
            }
            else
            {
                Product product = new Product();
                product.Name = txtTen.Text;
                product.Quantity = Convert.ToInt32(txtSoLuong.Text);
                product.ProductDate = Convert.ToDateTime(dtpNgay.Text);
                product.UnitPrice = Convert.ToDouble(txtGia.Text);
                product.Description = txtMoTa.Text;
                product.Images = stream.ToArray();
                product.SupplierId = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
                product.CategoryId = Convert.ToInt32(cbLoai.SelectedValue.ToString());
                product.DiscountId = Convert.ToInt32(cbGiamGia.SelectedValue.ToString());
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Thêm sản phẩm thành công");
            }

            Display();
            /*  }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }*/
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                Product productId = context.Products.Where(p => p.id.ToString() == txtId.Text).FirstOrDefault();
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
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvListSanPham.Rows.Count > 0)
                {
                    txtId.Text = dgvListSanPham.SelectedRows[0].Cells[0].Value.ToString();
                    txtTen.Text = dgvListSanPham.SelectedRows[0].Cells[1].Value.ToString();
                    txtSoLuong.Text = dgvListSanPham.SelectedRows[0].Cells[2].Value.ToString();
                    dtpNgay.Text = dgvListSanPham.SelectedRows[0].Cells[3].Value.ToString();
                    txtGia.Text = dgvListSanPham.SelectedRows[0].Cells[4].Value.ToString();
                    txtMoTa.Text = dgvListSanPham.SelectedRows[0].Cells[5].Value.ToString();
                    // hinh anh
                    Product product = context.Products.FirstOrDefault(p => p.id.ToString() == txtId.Text);
                    MemoryStream stream = new MemoryStream(product.Images.ToArray());
                    Image img = Image.FromStream(stream);
                    pbPhoto.Image = img;
                    cbLoai.SelectedIndex = cbLoai.FindStringExact(dgvListSanPham.SelectedRows[0].Cells[7].Value.ToString());
                    cbNhaCungCap.SelectedIndex = cbNhaCungCap.FindStringExact(dgvListSanPham.SelectedRows[0].Cells[8].Value.ToString());
                    cbGiamGia.SelectedIndex = cbGiamGia.FindStringExact(dgvListSanPham.SelectedRows[0].Cells[9].Value.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
