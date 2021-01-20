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

namespace WindowsFormsApp2.Views.DanhThuReport
{
    public partial class DoanhThuReportForm : Form
    {
        Model1 context = new Model1();
        public DoanhThuReportForm()
        {
            InitializeComponent();
        }

        private void DoanhThuReportForm_Load(object sender, EventArgs e)
        {
            List<ProductDetailsReport> listReport = new List<ProductDetailsReport>();
            List<ProductDetail> list = context.ProductDetails.ToList();
            foreach (ProductDetail i in list)
            {
                ProductDetailsReport r = new ProductDetailsReport();
                r.tenLoai = i.Product.CategoryProduct.Name;
                r.quantity = i.Quantity.Value;
                r.unitPrice = i.UnitPrice.Value;

                listReport.Add(r);
            }
            this.reportViewer1.LocalReport.ReportPath = "DoanhThuReport.rdlc";
            var resource = new ReportDataSource("DoanhThuDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(resource);
            this.reportViewer1.RefreshReport();

        }
    }
}
