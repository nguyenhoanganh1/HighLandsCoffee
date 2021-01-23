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
    public partial class FormPhanQuyen : Form
    {
        Model1 context = new Model1();
        public FormPhanQuyen()
        {
            InitializeComponent();
        }

        private void FormPhanQuyen_Load(object sender, EventArgs e)
        {
            List<Employee> employees = context.Employees.ToList();
            List<Role> roles = context.Roles.ToList();
            BindingRole(roles);
            BindingNhanVien(employees);
            Display();
        }

        private void BindingRole(List<Role> roles)
        {
            cbTenQuyen.DataSource = roles;
            this.cbTenQuyen.DisplayMember = "NameRole";
            this.cbTenQuyen.ValueMember = "id";
        }

        private void BindingNhanVien(List<Employee> employees)
        {
            cbTenNhanVien.DataSource = employees;
            this.cbTenNhanVien.DisplayMember = "Name";
            this.cbTenNhanVien.ValueMember = "Id";
        }

        private void Display()
        {
            List<RoleDetailDTO> list = new List<RoleDetailDTO>();
            list = context.RoleDetails.Select(x => new RoleDetailDTO
            {
                id = x.Id,
                nameAction = x.NameAction,
                nameEmployee = x.Employee.Name,
                nameRole = x.Role.NameRole
            }).ToList();
            dgvDanhSachQuyen.DataSource = list;
        }

        private void dgvDanhSachQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachQuyen.SelectedRows)
            {
                if (dgvDanhSachQuyen.Rows.Count > 0)
                {
                    txtMaChiTiet.Text = row.Cells[0].Value.ToString();
                    txtTenChiTiet.Text = row.Cells[1].Value.ToString();
                    cbTenNhanVien.SelectedIndex = cbTenNhanVien.FindStringExact(row.Cells[2].Value.ToString());
                    cbTenQuyen.SelectedIndex = cbTenQuyen.FindStringExact(row.Cells[3].Value.ToString());
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            RoleDetail r = context.RoleDetails.Where(x => x.Id.ToString() == txtMaChiTiet.Text).FirstOrDefault();
            if (r != null)
            {
                context.RoleDetails.Remove(r);
                context.SaveChanges();
                Display();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã phù hợp");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            RoleDetail r = context.RoleDetails.Where(x => x.Id.ToString() == txtMaChiTiet.Text).FirstOrDefault();
            if (r != null)
            {
                r.NameAction = txtTenChiTiet.Text;
                r.IdEmployee = Convert.ToInt32(cbTenNhanVien.SelectedValue.ToString());
                r.IdRole = Convert.ToInt32(cbTenQuyen.SelectedValue.ToString());
                context.SaveChanges();
                Display();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã phù hợp");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            RoleDetail r = context.RoleDetails.Where(x => x.Id.ToString() == txtMaChiTiet.Text).FirstOrDefault();
            if (r != null)
            {
                MessageBox.Show("Không tìm thấy mã phù hợp");
            }
            else
            {
                RoleDetail roleDetail = new RoleDetail();
                roleDetail.NameAction = txtTenChiTiet.Text;
                roleDetail.IdEmployee = Convert.ToInt32(cbTenNhanVien.SelectedValue.ToString());
                roleDetail.IdRole = Convert.ToInt32(cbTenQuyen.SelectedValue.ToString());
                context.RoleDetails.Add(roleDetail);
                context.SaveChanges();
                Display();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}