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
    public partial class FormDangNhap : Form
    {
        public static string tenNhanVien;
        public event ChungThucTaiKhoan chungThucTaiKhoan;
        public delegate void ChungThucTaiKhoan(object sender);
        Model1 context = new Model1();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraInput())
            {
                string userName = txtUserName.Text;
                string password = MD5Hash(txtPassword.Text);
                Employee employee = context.Employees.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

                if (employee != null)
                {
                    chungThucTaiKhoan(employee);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng thông tin");
                    return;
                }
            }
        }

        private string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private bool KiemTraInput()
        {

            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin");
                return false;
            }
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
