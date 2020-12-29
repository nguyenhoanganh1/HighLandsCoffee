using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Views
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap form = new FormDangNhap();
            form.ShowDialog();
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox();
            for (int i = 0; i < 5; i++)
            {
                pictureBox.Image = Image.FromFile("C:/Users/Admin/Desktop/my webside/images/icons8-search-50.png");
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

       
    }
}
