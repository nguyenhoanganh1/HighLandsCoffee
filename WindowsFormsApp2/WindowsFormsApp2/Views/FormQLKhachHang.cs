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
#pragma warning disable CS0234 // The type or namespace name 'Models' does not exist in the namespace 'WindowsFormsApp2' (are you missing an assembly reference?)
using WindowsFormsApp2.Models;
#pragma warning restore CS0234 // The type or namespace name 'Models' does not exist in the namespace 'WindowsFormsApp2' (are you missing an assembly reference?)

namespace WindowsFormsApp2
{
    public partial class FormQLKhachHang : Form
    {
        Model1 context = new Model1();
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
            SettingForm();

            List<CustomerDTO> _customerList = new List<CustomerDTO>();
            _customerList = context.Customers.Select(x => new CustomerDTO
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.Phone
            }).ToList();
            dataGridView1.DataSource = _customerList;

        }

        private void SettingForm()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "" && txtAddress.Text != "" && txtPhoneNumber.Text != "")
            {
                Customer cus = new Customer();
                cus.Name = txtName.Text;
                cus.Email = txtAddress.Text;
                cus.Phone = txtPhoneNumber.Text;
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
        // THƯ VIỆN HÓA
#pragma warning disable CS0246 // The type or namespace name 'Customer' could not be found (are you missing a using directive or an assembly reference?)
        public bool SaveStudentDetails(Customer cus)
#pragma warning restore CS0246 // The type or namespace name 'Customer' could not be found (are you missing a using directive or an assembly reference?)
        {
            bool result = false;

            context.Customers.Add(cus);
            context.SaveChanges();
            result = true;

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
                    context.Customers.Add(cus);
                }
                else
                {
                    context.Entry(cus).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            Display();
            Clear();

        }
        private Customer GetCustomer()
        {
            Customer cus = new Customer();
            cus.Id = Convert.ToInt32(txtId.Text);
            cus.Name = txtName.Text;
            cus.Email = txtAddress.Text;
            cus.Phone = txtPhoneNumber.Text;
            return cus;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" && txtAddress.Text == "" && txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng muốn xóa");
            }
            else
            {
                int id = Convert.ToInt32(txtId.Text);
                Customer cus = context.Customers.Find(id);
                DialogResult dr = MessageBox.Show("Xác nhận xóa?", "Bạn Có muốn xóa không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    context.Customers.Remove(cus);
                    context.SaveChanges();
                }
            }
            Display();
            Clear();



        }


    }
}
