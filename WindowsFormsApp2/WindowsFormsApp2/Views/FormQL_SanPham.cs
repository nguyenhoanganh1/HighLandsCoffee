using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Views
{
    public partial class FormQL_SanPham : Form
    {
        private Image image;

        public FormQL_SanPham()
        {
            InitializeComponent();
        }

        private void btnMoFile_Click(object sender, EventArgs e)
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
            pictureBox1.Image = image;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream,ImageFormat.Jpeg);
            using (var context = new QL_BanHangEntities())
            {
                Product product = new Product();
                product.images = stream.ToArray();
            }
        }
    }
}
