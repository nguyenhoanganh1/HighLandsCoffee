using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;

namespace WindowsFormsApp2.Views
{
    public partial class FormQuanLyNhanVien : Form
    {
        Model1 context = new Model1();
        public FormQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void FormQuanLyNhanVien_Load(object sender, EventArgs e)
        {

            Binding();
        }

        private void Binding()
        {
            List<EmployeeDTO> em = new List<EmployeeDTO>();
            em = context.Employees.Select(x => new EmployeeDTO
            {
                id = x.Id,
                name = x.Name,
                address = x.Address,
                phoneNumber = x.PhoneNumber,
                salary = x.Salary.Value,
                userName = x.UserName,
                password = x.Password
            }).ToList();
            dgvDanhSachNhanVien.DataSource = em;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Employee employee = context.Employees.Where(x => x.Id.ToString() == txtMaNhanVien.Text).FirstOrDefault();
            if (employee != null)
            {
                MessageBox.Show("Trùng mã! vui lòng nhập lại");
            }
            else
            {
                Employee em = new Employee();
                em.Id = Convert.ToInt32(txtMaNhanVien.Text);
                em.Name = txtHoTen.Text;
                em.Address = txtDiaChi.Text;
                em.PhoneNumber = txtSoDienThoai.Text;
                em.Salary = Convert.ToDecimal(txtLuong.Text);
                em.UserName = txtUsername.Text;
                em.Password = MD5Hash(txtPassword.Text);

                context.Employees.Add(em);
                context.SaveChanges();
                Binding();
            }

        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Employee ee = context.Employees.Where(x => x.Id.ToString() == txtMaNhanVien.Text).FirstOrDefault();
            context.Employees.Remove(ee);
            context.SaveChanges();
            Binding();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Employee em = context.Employees.Where(x => x.Id.ToString() == txtMaNhanVien.Text).FirstOrDefault();
            if (em != null)
            {
                em.Id = Convert.ToInt32(txtMaNhanVien.Text);
                em.Name = txtHoTen.Text;
                em.Address = txtDiaChi.Text;
                em.PhoneNumber = txtSoDienThoai.Text;
                em.Salary = Convert.ToDecimal(txtLuong.Text);
                em.UserName = txtUsername.Text;
                em.Password = MD5Hash(txtPassword.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã đại ka ơi !");
            }
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachNhanVien.SelectedRows)
            {
                if (dgvDanhSachNhanVien.Rows.Count > 0)
                {
                    txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                    txtHoTen.Text = row.Cells[1].Value.ToString();
                    txtDiaChi.Text = row.Cells[2].Value.ToString();
                    txtSoDienThoai.Text = row.Cells[3].Value.ToString();
                    txtLuong.Text = row.Cells[4].Value.ToString();
                    txtUsername.Text = row.Cells[5].Value.ToString();
                    txtPassword.Text = row.Cells[6].Value.ToString();

                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}