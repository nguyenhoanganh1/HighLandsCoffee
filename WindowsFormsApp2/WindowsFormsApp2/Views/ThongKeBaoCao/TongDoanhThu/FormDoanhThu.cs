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

namespace WindowsFormsApp2.Views.ThongKeBaoCao.cac
{
    public partial class FormDoanhThu : Form
    {
        Model1 context = new Model1();
        public FormDoanhThu()
        {
            InitializeComponent();
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {

            List<DoanhThu> listReport = new List<DoanhThu>();
            List<ProductDetail> list = context.ProductDetails.Where(x => x.Order.OrderDate > dtpFrom.Value && x.Order.OrderDate < dtpTo.Value).ToList();
            if (list.Count > 0)
            {
                foreach (ProductDetail i in list)
                {
                    DoanhThu r = new DoanhThu();
                    r.Id = i.Id;
                    r.OrderId = i.OrderId.Value;
                    r.ProductId = i.ProductId.Value;
                    r.Quantity = i.Quantity.Value;
                    r.UnitPrice = i.UnitPrice.Value;
                    listReport.Add(r);
                }
                this.reportViewer1.LocalReport.ReportPath = "ReportDoanhTHu.rdlc";
                var resource = new ReportDataSource("DoanhThuDataSet", listReport);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(resource);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                BaoCaoDoanhThu();
            }
            this.reportViewer1.RefreshReport();
        }


        public void BaoCaoDoanhThu()
        {
            List<DoanhThu> listReport = new List<DoanhThu>();
            List<ProductDetail> list = context.ProductDetails.ToList();
            foreach (ProductDetail i in list)
            {
                DoanhThu r = new DoanhThu();
                r.Id = i.Id;
                r.OrderId = i.OrderId.Value;
                r.ProductId = i.ProductId.Value;
                r.Quantity = i.Quantity.Value;
                r.UnitPrice = i.UnitPrice.Value;
                listReport.Add(r);
            }
            this.reportViewer1.LocalReport.ReportPath = "ReportDoanhTHu.rdlc";
            var resource = new ReportDataSource("DoanhThuDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(resource);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
