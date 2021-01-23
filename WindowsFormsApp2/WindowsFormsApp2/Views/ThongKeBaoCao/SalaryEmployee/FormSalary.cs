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

namespace WindowsFormsApp2.Views.ThongKeBaoCao.SalaryEmployee
{
    public partial class FormSalary : Form
    {
        Model1 context = new Model1();
        public FormSalary()
        {
            InitializeComponent();
        }

        private void FormSalary_Load(object sender, EventArgs e)
        {
            List<LuongNhanVien> listReport = new List<LuongNhanVien>();
            List<Employee> list = context.Employees.ToList();
            foreach (Employee i in list)
            {
                LuongNhanVien r = new LuongNhanVien();
                r.name = i.Name;
                r.address = i.Address;
                r.phoneNumber = i.PhoneNumber;
                r.salary = i.Salary.Value;
                listReport.Add(r);
            }
            this.reportViewer1.LocalReport.ReportPath = "LuongReport.rdlc";
            var resource = new ReportDataSource("LuongDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(resource);
            this.reportViewer1.RefreshReport();
        }
    }
}
