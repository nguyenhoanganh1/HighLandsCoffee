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
    public partial class FormKhuyenMai : Form
    {
        Model1 context = new Model1();
        public FormKhuyenMai()
        {
            InitializeComponent();
        }

        private void FormKhuyenMai_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void Display()
        {
            List<DiscountDTO> list = new List<DiscountDTO>();
            list = context.Discounts.Select(x => new DiscountDTO
            {
                id = x.Id,
                soPhanTram = x.Discount1.Value,
                DateStart = x.DateStart.Value,
                DateeEnd = x.DateeEnd.Value
            }).ToList();
            dgvDanhSachGiamGia.DataSource = list;
        }

        private void dgvDanhSachGiamGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachGiamGia.SelectedRows)
            {
                txtMaGiamGia.Text = row.Cells[0].Value.ToString();
                txtSoPhanTram.Text = row.Cells[1].Value.ToString();
                dtpFrom.Text = row.Cells[2].Value.ToString();
                dtpTo.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Discount r = context.Discounts.Where(x => x.Id.ToString() == txtMaGiamGia.Text).FirstOrDefault();
                if (r != null)
                {
                    MessageBox.Show("Không tìm thấy mã phù hợp");
                }
                else
                {
                    Discount roleDetail = new Discount();
                    roleDetail.Discount1 = Convert.ToInt32(txtSoPhanTram.Text.ToString());
                    roleDetail.DateStart = dtpFrom.Value;
                    roleDetail.DateeEnd = dtpTo.Value;
                    context.Discounts.Add(roleDetail);
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
                Discount roleDetail = context.Discounts.Where(x => x.Id.ToString() == txtMaGiamGia.Text).FirstOrDefault();
                if (roleDetail != null)
                {
                    roleDetail.Discount1 = Convert.ToInt32(txtSoPhanTram.Text.ToString());
                    roleDetail.DateStart = dtpFrom.Value;
                    roleDetail.DateeEnd = dtpTo.Value;
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
                Discount roleDetail = context.Discounts.Where(x => x.Id.ToString() == txtMaGiamGia.Text).FirstOrDefault();
                if (roleDetail != null)
                {
                    context.Discounts.Remove(roleDetail);
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
