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

namespace WindowsFormsApp2.Views
{
    public partial class Form_Nhan_Hang : Form
    {
        Model1 model = new Model1();
        public Form_Nhan_Hang()
        {
            InitializeComponent();
        }

        private void Form_Nhan_Hang_Load(object sender, EventArgs e)
        {
            btn_them.Visible = true;
            btn_luu.Visible = false;
            KhoiTao();
        }



        private void KhoiTao()
        {
            List<PhieuGiaoHang> list_phieugiao = model.PhieuGiaoHangs.ToList();
            List<Supplier> list_nhacc = model.Suppliers.ToList();
            FillDataToCombobox(list_nhacc);
            BindingDataToDataGridViews(list_phieugiao);
            settingForm();
            ReadOnlyAll();
        }

        private void ReadOnlyAll()
        {
            txt_id.ReadOnly = true;
            txt_tensp.ReadOnly = true;
            txt_sl.ReadOnly = true;
            txt_dongia.ReadOnly = true;
            dtpNgayGiao.Enabled = false;
            txt_ghichu.ReadOnly = true;
            cb_nhacc.Enabled = false;

        }


        private void UnReadOnlyAll()
        {
            txt_id.ReadOnly = false;
            txt_tensp.ReadOnly = false;
            txt_sl.ReadOnly = false;
            txt_dongia.ReadOnly = false;
            dtpNgayGiao.Enabled = true;
            txt_ghichu.ReadOnly = false;
            cb_nhacc.Enabled = true;
        }

        private void FillDataToCombobox(List<Supplier> list_nhacc)
        {
            cb_nhacc.DataSource = list_nhacc;

            cb_nhacc.ValueMember = "Id";
            cb_nhacc.DisplayMember = "Name";



        }


        private void settingForm()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            /*dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;*/
        }
        void BindingDataToDataGridViews(List<PhieuGiaoHang> list_phieugiao)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên Sản phẩm");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Đơn giá");
            dt.Columns.Add("Ngày giao");
            dt.Columns.Add("Ghi chú");
            dt.Columns.Add("Mã nhà cung cấp");
            dt.Columns.Add("Tên nhà cung cấp");



            int stt = 1;
            for (int i = 0; i < list_phieugiao.Count; i++, stt++)
            {
                PhieuGiaoHang s = list_phieugiao[i];
                dt.Rows.Add(new String[] { stt.ToString(), s.Id.ToString(), s.TenSanPham, s.SoLuong.ToString(), s.DonGia.ToString(), s.NgayGiao.ToString(), s.GhiChu, s.Supplier.Id.ToString(), s.Supplier.Name });
            }

            dataGridView1.DataSource = dt;

        }




        private void GetDateSelected()
        {
            /*if (*//*dataGridView1.SelectedRows.Count > 0*//*)*/
            if (dataGridView1.SelectedRows.Count > 0)
            {

                txt_id.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_tensp.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_sl.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_dongia.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dtpNgayGiao.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_ghichu.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                /* txt_mancc.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();*/
                //cb_nhacc.SelectedIndex = cb_nhacc.FindStringExact(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                cb_nhacc.SelectedIndex = cb_nhacc.FindStringExact(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());

            }
        }



        private void SetNull()
        {
            txt_id.Text = null;
            txt_tensp.Text = null;
            txt_sl.Text = null;
            txt_dongia.Text = null;
            dtpNgayGiao.Text = null;
            txt_ghichu.Text = null;
            cb_nhacc.Text = null;
        }




        private void btn_them_Click(object sender, EventArgs e)
        {
            UnReadOnlyAll();
            SetNull();
            btn_them.Visible = false;
            btn_sua.Enabled = false;
            btn_luu.Visible = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            UnReadOnlyAll();
            txt_id.ReadOnly = true;
            txt_id.Enabled = true;

            btn_them.Visible = false;
            btn_luu.Visible = true;
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            KhoiTao();
            ReadOnlyAll();
            btn_luu.Enabled = true;
            btn_sua.Enabled = true;

            btn_them.Visible = true;
            btn_luu.Visible = false;

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            GetDateSelected();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            String findString = txt_timkiem.Text.ToLower();
            List<PhieuGiaoHang> list_phieugiao = model.PhieuGiaoHangs.Where(c => (c.TenSanPham.ToLower().Contains(findString)) || (c.Id.ToString().Contains(findString)) || (c.Supplier.Name.Contains(findString))).ToList();
            BindingDataToDataGridViews(list_phieugiao);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            //int cv = Convert.ToInt32(txt_id.Text);
            PhieuGiaoHang get_phieugiao = model.PhieuGiaoHangs.FirstOrDefault(c => c.Id.ToString() == txt_id.Text);
            /*nếu sách là*/
            if (get_phieugiao == null) // nếu  
            {
                PhieuGiaoHang s2 = new PhieuGiaoHang();

                s2.Id = Int32.Parse(txt_id.Text);
                s2.TenSanPham = txt_tensp.Text;
                s2.SoLuong = Int32.Parse(txt_sl.Text);
                s2.DonGia = Convert.ToDecimal(txt_dongia.Text);
                s2.NgayGiao = Convert.ToDateTime(dtpNgayGiao.Text);
                s2.GhiChu = txt_ghichu.Text;
                s2.maNCC = Int32.Parse(cb_nhacc.SelectedValue.ToString());
                model.PhieuGiaoHangs.Add(s2);
                model.SaveChanges();


                btn_them.Visible = true;
                btn_luu.Visible = false;
                SetNull();
            }

            else
            {
                get_phieugiao.TenSanPham = txt_tensp.Text;
                get_phieugiao.SoLuong = Int32.Parse(txt_sl.Text);
                get_phieugiao.DonGia = Convert.ToDecimal(txt_dongia.Text);
                get_phieugiao.NgayGiao = Convert.ToDateTime(dtpNgayGiao.Text);
                get_phieugiao.GhiChu = txt_ghichu.Text;
                get_phieugiao.maNCC = Int32.Parse(cb_nhacc.SelectedValue.ToString());


                model.SaveChanges();
                /*db.SaveChanges();*/

                btn_them.Visible = true;
                btn_luu.Visible = false;

            }
            BindingDataToDataGridViews(model.PhieuGiaoHangs.ToList());
            ReadOnlyAll();
            //btn_sua.Enabled = true;
        }
    }
}
