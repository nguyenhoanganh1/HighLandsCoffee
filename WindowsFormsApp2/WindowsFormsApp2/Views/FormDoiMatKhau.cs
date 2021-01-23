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
    public partial class FormDoiMatKhau : Form
    {
        Model1 context = new Model1();
        public static int maNhanVien;
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            Employee em = context.Employees.Where(x => x.Id.ToString().Equals(maNhanVien.ToString())).FirstOrDefault();
            txtMaNhanVien.Text = maNhanVien.ToString();
            txtHoTen.Text = em.Name;
            txtDiaChi.Text = em.Address;
            txtSDT.Text = em.PhoneNumber;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Employee em = context.Employees.Where(x => x.Id.ToString().Equals(maNhanVien.ToString())).FirstOrDefault();
            em.Name = txtHoTen.Text;
            em.Address = txtDiaChi.Text;
            em.PhoneNumber = txtSDT.Text;
            em.Password = MD5Hash(txtMatKhauMoi.Text);
            context.SaveChanges();
            MessageBox.Show("Sửa thông tin thành công");
        }
    }
}
