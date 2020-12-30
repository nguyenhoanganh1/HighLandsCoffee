using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;

namespace WindowsFormsApp2
{
    public partial class FormQLKhachHang : Form
    {
        public FormQLKhachHang()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()   // Display Method is a common method to bind the Student details in datagridview after save,update and delete operation perform.
        {
            using (QL_BanHangEntities _entity = new QL_BanHangEntities())
            {
                List<CustomerDTO> _customerList = new List<CustomerDTO>();
                _customerList = _entity.Customers.Select(x => new CustomerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = (int) x.Phone                   
                }).ToList();
                dataGridView1.DataSource = _customerList;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (QL_BanHangEntities _entity = new QL_BanHangEntities())
            {
                if (txtName.Text != "" && txtAddress.Text != "" && txtPhoneNumber.Text != "")
                {                 
                    Customer cus = new Customer();                   
                    cus.Name = txtName.Text;                  
                    cus.Address = txtAddress.Text;
                    cus.Phone = Convert.ToInt32(txtPhoneNumber.Text);               
                    SaveStudentDetails(cus);                     
                    Display();
                    Clear();                     
                    MessageBox.Show("Thêm Thành Công");    
                }   
                else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
            }

        }
        // THƯ VIỆN HÓA
        public bool SaveStudentDetails(Customer cus)   
        {
            bool result = false;
            using (QL_BanHangEntities _entity = new QL_BanHangEntities())
            {
                _entity.Customers.Add(cus);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public void Clear()
        {
            txtId.Text = txtName.Text = txtAddress.Text = txtPhoneNumber.Text = "";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     

        private void btnSua_Click(object sender, EventArgs e)
        {
         
                using (QL_BanHangEntities _entity = new QL_BanHangEntities())
                {
                  
                    if (txtName.Text == "" && txtAddress.Text == "" && txtPhoneNumber.Text == "")
                    {
                        MessageBox.Show("Vui lòng chọn dòng muốn sửa");
                    }
                    else
                    {
                        Customer cus = GetCustomer();
                        if (cus.Id == null)
                        {
                             cus.Id = Convert.ToInt32(txtId.Text);
                             _entity.Customers.Add(cus);
                         }
                        else
                        {
                             _entity.Entry(cus).State = EntityState.Modified;
                             _entity.SaveChanges();
                        }
                    }    
                    Display();
                    Clear();
                }
            
           

        }
        private Customer GetCustomer()
        {
            Customer cus = new Customer();
                cus.Id = Convert.ToInt32(txtId.Text);
                cus.Name = txtName.Text;
                cus.Address = txtAddress.Text;
                cus.Phone = Convert.ToInt32(txtPhoneNumber.Text);
                return cus;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (QL_BanHangEntities _entity = new QL_BanHangEntities())
            {
                if (txtName.Text == "" && txtAddress.Text == "" && txtPhoneNumber.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn dòng muốn xóa");
                }
                else
                {
                    int id = Convert.ToInt32(txtId.Text);
                    Customer cus = _entity.Customers.Find(id);
                    DialogResult dr = MessageBox.Show("Xác nhận xóa?", "Bạn Có muốn xóa không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        _entity.Customers.Remove(cus);
                        _entity.SaveChanges();
                    }
                } 
                Display();
                Clear();

            }
           
        }

       
    }
}
