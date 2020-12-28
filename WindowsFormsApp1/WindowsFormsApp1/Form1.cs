using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Customer> customers;
        public Form1()
        {
            InitializeComponent();
            customers = new List<Customer>();
        }

        private Customer getCustomer()
        {
            Customer cus = new Customer();
            cus.Id = txtMa.Text;
            cus.FullName = txtHoTen.Text;
            cus.Address = txtDiaChi.Text;
            cus.PhoneNumber =  txtSDT.Text;

            return cus;
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            Customer cus = getCustomer();
            Customer findCus = customers.SingleOrDefault(p => p.Id == cus.Id);
            if(findCus != null)
            {
                findCus.Id = cus.Id;
                findCus.FullName = cus.FullName;
                findCus.Address = cus.Address;
                findCus.PhoneNumber = cus.PhoneNumber;      
            }
            else
            {
                customers.Add(cus);
            }
            UpdateView();
        }

        private void UpdateView()
        {
            listView1.Items.Clear();
          
            foreach (var customer in customers)
            {
                string[] info = new string[]
                {
                    customer.Id,
                    customer.FullName,
                    customer.Address,
                    customer.PhoneNumber
                };
                ListViewItem listViewItem = new ListViewItem(info);
                listView1.Items.Add(listViewItem);
              
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Customer cus = getCustomer();
            Customer findCus = customers.SingleOrDefault(p => p.Id == cus.Id);
            if (findCus != null)
            {
                customers.Remove(findCus);
            }
            UpdateView();
        }

     
    }

    
}
