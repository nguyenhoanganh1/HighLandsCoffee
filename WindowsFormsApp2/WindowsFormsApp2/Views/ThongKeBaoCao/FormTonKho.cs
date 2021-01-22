using Microsoft.Reporting.WinForms;
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
using WindowsFormsApp2.Views.ThongKeBaoCao.TonKho;

namespace WindowsFormsApp2.Views.ThongKeBaoCao
{
    public partial class FormTonKho : Form
    {
        Model1 context = new Model1();
        public FormTonKho()
        {
            InitializeComponent();
        }

        private void FormTonKho_Load(object sender, EventArgs e)
        {
            List<SanPhamTonKho> listReport = new List<SanPhamTonKho>();
            List<Product> list = context.Products.ToList();
            foreach (Product i in list)
            {
                SanPhamTonKho r = new SanPhamTonKho();
                r.id = i.id;
                r.Name = i.Name;
                r.ProductDate = i.ProductDate.Value;
                r.Quantity = i.Quantity.Value;
                r.UnitPrice = i.UnitPrice;

                listReport.Add(r);
            }
            this.reportViewer1.LocalReport.ReportPath = "TonKhoReport.rdlc";
            var resource = new ReportDataSource("TonKhoDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(resource);
            this.reportViewer1.RefreshReport();

        }
    }
}
