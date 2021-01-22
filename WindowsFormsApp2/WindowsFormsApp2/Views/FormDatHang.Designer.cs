namespace WindowsFormsApp2.Views
{
    partial class FormDatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupHoaDon = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.txtNgayTao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDatHang = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnNhapThongTinKhachHang = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThemGioHang = new System.Windows.Forms.Button();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupHoaDon.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatHang)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(79, 30);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(310, 20);
            this.txtTimKiem.TabIndex = 12;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mã khách hàng";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.Location = new System.Drawing.Point(20, 158);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(85, 34);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(231, 158);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 34);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã hóa đơn";
            // 
            // groupHoaDon
            // 
            this.groupHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupHoaDon.Controls.Add(this.btnThanhToan);
            this.groupHoaDon.Controls.Add(this.label6);
            this.groupHoaDon.Controls.Add(this.txtTongTien);
            this.groupHoaDon.Controls.Add(this.btnThoat);
            this.groupHoaDon.Controls.Add(this.btnTaoHoaDon);
            this.groupHoaDon.Controls.Add(this.txtNgayTao);
            this.groupHoaDon.Controls.Add(this.label3);
            this.groupHoaDon.Controls.Add(this.txtMaHoaDon);
            this.groupHoaDon.Controls.Add(this.label1);
            this.groupHoaDon.Location = new System.Drawing.Point(413, 241);
            this.groupHoaDon.Name = "groupHoaDon";
            this.groupHoaDon.Size = new System.Drawing.Size(343, 255);
            this.groupHoaDon.TabIndex = 2;
            this.groupHoaDon.TabStop = false;
            this.groupHoaDon.Text = "Hóa Đơn";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tông tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.Location = new System.Drawing.Point(125, 72);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(191, 20);
            this.txtTongTien.TabIndex = 16;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoHoaDon.Location = new System.Drawing.Point(125, 158);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(90, 34);
            this.btnTaoHoaDon.TabIndex = 13;
            this.btnTaoHoaDon.Text = "Tạo Hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayTao.Location = new System.Drawing.Point(125, 42);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.ReadOnly = true;
            this.txtNgayTao.Size = new System.Drawing.Size(191, 20);
            this.txtNgayTao.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày Tạo";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(125, 16);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.ReadOnly = true;
            this.txtMaHoaDon.Size = new System.Drawing.Size(191, 20);
            this.txtMaHoaDon.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvDatHang);
            this.groupBox3.Location = new System.Drawing.Point(12, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 255);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Giỏ hàng";
            // 
            // dgvDatHang
            // 
            this.dgvDatHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatHang.Location = new System.Drawing.Point(17, 19);
            this.dgvDatHang.Name = "dgvDatHang";
            this.dgvDatHang.Size = new System.Drawing.Size(372, 230);
            this.dgvDatHang.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnNhapThongTinKhachHang);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtMaKhachHang);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtSoLuong);
            this.groupBox4.Controls.Add(this.btnThemGioHang);
            this.groupBox4.Controls.Add(this.txtMaSanPham);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(413, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 223);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nhập thông tin giỏ hàng";
            // 
            // btnNhapThongTinKhachHang
            // 
            this.btnNhapThongTinKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhapThongTinKhachHang.Location = new System.Drawing.Point(36, 156);
            this.btnNhapThongTinKhachHang.Name = "btnNhapThongTinKhachHang";
            this.btnNhapThongTinKhachHang.Size = new System.Drawing.Size(102, 34);
            this.btnNhapThongTinKhachHang.TabIndex = 17;
            this.btnNhapThongTinKhachHang.Text = "Nhập khách hàng";
            this.btnNhapThongTinKhachHang.UseVisualStyleBackColor = true;
            this.btnNhapThongTinKhachHang.Click += new System.EventHandler(this.btnNhapThongTinKhachHang_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mã Sản phẩm";
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaKhachHang.Location = new System.Drawing.Point(114, 88);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(191, 20);
            this.txtMaKhachHang.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Location = new System.Drawing.Point(114, 115);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(191, 20);
            this.txtSoLuong.TabIndex = 14;
            // 
            // btnThemGioHang
            // 
            this.btnThemGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemGioHang.Location = new System.Drawing.Point(188, 156);
            this.btnThemGioHang.Name = "btnThemGioHang";
            this.btnThemGioHang.Size = new System.Drawing.Size(117, 34);
            this.btnThemGioHang.TabIndex = 13;
            this.btnThemGioHang.Text = "Thêm vào giỏ hàng";
            this.btnThemGioHang.UseVisualStyleBackColor = true;
            this.btnThemGioHang.Click += new System.EventHandler(this.btnThemGioHang_Click);
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaSanPham.Location = new System.Drawing.Point(114, 59);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(191, 20);
            this.txtMaSanPham.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Mã khách hàng";
            // 
            // dgvDanhSachSanPham
            // 
            this.dgvDanhSachSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSanPham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSanPham.Location = new System.Drawing.Point(17, 59);
            this.dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            this.dgvDanhSachSanPham.Size = new System.Drawing.Size(372, 158);
            this.dgvDanhSachSanPham.TabIndex = 14;
            this.dgvDanhSachSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachSanPham_CellClick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.dgvDanhSachSanPham);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 223);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sach Sản phẩm";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tìm kiếm";
            // 
            // FormDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupHoaDon);
            this.Name = "FormDatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormDatHang_Load);
            this.groupHoaDon.ResumeLayout(false);
            this.groupHoaDon.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatHang)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupHoaDon;
        private System.Windows.Forms.TextBox txtNgayTao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDatHang;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThemGioHang;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.DataGridView dgvDanhSachSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNhapThongTinKhachHang;
    }
}