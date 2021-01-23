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

namespace WindowsFormsApp2.Views
{
    public partial class FormNhaCungCap : Form
    {
        Model1 context = new Model1();
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            Display();

        }

        private void Display()
        {
            List<SupplierDTO> list = new List<SupplierDTO>();
            list = context.Suppliers.Select(x => new SupplierDTO
            {
                id = x.Id,
                name = x.Name,
                address = x.Address,
                phone = x.Phone
            }).ToList();
            dgvDanhSachNhaCC.DataSource = list;
        }

        private void dgvDanhSachNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDanhSachNhaCC.SelectedRows)
                {
                    txtMaNhaCC.Text = row.Cells[0].Value.ToString();
                    txtTenCongTy.Text = row.Cells[1].Value.ToString();
                    txtDiaChi.Text = row.Cells[2].Value.ToString();
                    txtSoDienThoai.Text = row.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier r = context.Suppliers.Where(x => x.Id.ToString() == txtMaNhaCC.Text).FirstOrDefault();
                if (r != null)
                {
                    MessageBox.Show("Không tìm thấy mã phù hợp");
                }
                else
                {
                    Supplier roleDetail = new Supplier();
                    roleDetail.Name = txtTenCongTy.Text.Trim();
                    roleDetail.Address = txtDiaChi.Text.Trim();
                    roleDetail.Phone = txtSoDienThoai.Text.Trim();
                    context.Suppliers.Add(roleDetail);
                    context.SaveChanges();
                    Display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier roleDetail = context.Suppliers.Where(x => x.Id.ToString() == txtMaNhaCC.Text).FirstOrDefault();
                if (roleDetail != null)
                {
                    roleDetail.Name = txtTenCongTy.Text.Trim();
                    roleDetail.Address = txtDiaChi.Text.Trim();
                    roleDetail.Phone = txtSoDienThoai.Text.Trim();
                    context.SaveChanges();
                    Display();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phù hợp");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier roleDetail = context.Suppliers.Where(x => x.Id.ToString() == txtMaNhaCC.Text).FirstOrDefault();
                if (roleDetail != null)
                {
                    context.Suppliers.Remove(roleDetail);
                    context.SaveChanges();
                    Display();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phù hợp");
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
    }
}
