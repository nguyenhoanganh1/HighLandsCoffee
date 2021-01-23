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
    public partial class FormQuenMatKhau : Form
    {
        Model1 context = new Model1();
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Employee em = context.Employees.Where(x => x.UserName.Equals(txtUsername.Text)).FirstOrDefault();
            if (em != null)
            {
                if (em.PhoneNumber.Equals(txtSDT.Text))
                {
                    if (txtMauKhauMoi.Text.Equals(txtXacNhanMK.Text))
                    {
                        em.Password = MD5Hash(txtMauKhauMoi.Text);
                        context.SaveChanges();
                        MessageBox.Show("Đổi mật khẩu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu");
                    }
                }
                else
                {
                    MessageBox.Show("Sai số điện thoại");
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập");
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


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
