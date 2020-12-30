using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#pragma warning disable CS0234 // The type or namespace name 'Models' does not exist in the namespace 'WindowsFormsApp2' (are you missing an assembly reference?)
using WindowsFormsApp2.Models;
#pragma warning restore CS0234 // The type or namespace name 'Models' does not exist in the namespace 'WindowsFormsApp2' (are you missing an assembly reference?)

namespace WindowsFormsApp2.Views
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (var context = new QL_BanHangEntities1())
            {
                Employee employee = new Employee();
                employee.UserName = txtUserName.Text;
                employee.Password = txtPassword.Text;
                var id = context.Employees.Where(x => x.UserName == employee.UserName && x.Password == employee.Password);
                foreach(var item in id)
                {                   
                    this.Hide();
                    FormQLKhachHang form = new FormQLKhachHang();
                    form.ShowDialog();
                    this.Close();
                } 
            }
        }
    }
}
