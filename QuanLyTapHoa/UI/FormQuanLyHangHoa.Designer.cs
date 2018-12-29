namespace QuanLyTapHoa.UI
{
    partial class FormQuanLyHangHoa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewDanhSachHangHoa = new System.Windows.Forms.DataGridView();
            this.MaHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHetHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBanLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxTimHangHoa = new System.Windows.Forms.GroupBox();
            this.buttonTim = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelTimLoaiHangHoa = new System.Windows.Forms.Label();
            this.textBoxTimLoaiHangHoa = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelTimTenHangHoa = new System.Windows.Forms.Label();
            this.textBoxTimTenHangHoa = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonDatLai = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonCapNhat = new System.Windows.Forms.Button();
            this.groupBoxThongTinHangHoa = new System.Windows.Forms.GroupBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.textBoxDonGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.textBoxSoLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dateTimePickerHetHan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBoxTenHangHoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTieuDe = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxDaHetHan = new System.Windows.Forms.CheckBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachHangHoa)).BeginInit();
            this.groupBoxTimHangHoa.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxThongTinHangHoa.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewDanhSachHangHoa);
            this.panel1.Location = new System.Drawing.Point(2, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 384);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewDanhSachHangHoa
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDanhSachHangHoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDanhSachHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSachHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHangHoa,
            this.TenHangHoa,
            this.LoaiHangHoa,
            this.NgayHetHang,
            this.SoLuong,
            this.GiaBanLe,
            this.DonViTinh});
            this.dataGridViewDanhSachHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDanhSachHangHoa.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDanhSachHangHoa.Name = "dataGridViewDanhSachHangHoa";
            this.dataGridViewDanhSachHangHoa.Size = new System.Drawing.Size(552, 384);
            this.dataGridViewDanhSachHangHoa.TabIndex = 0;
            // 
            // MaHangHoa
            // 
            this.MaHangHoa.HeaderText = "Mã hàng";
            this.MaHangHoa.Name = "MaHangHoa";
            this.MaHangHoa.ReadOnly = true;
            this.MaHangHoa.Visible = false;
            this.MaHangHoa.Width = 85;
            // 
            // TenHangHoa
            // 
            this.TenHangHoa.HeaderText = "Sản phẩm";
            this.TenHangHoa.Name = "TenHangHoa";
            this.TenHangHoa.ReadOnly = true;
            this.TenHangHoa.Width = 85;
            // 
            // LoaiHangHoa
            // 
            this.LoaiHangHoa.HeaderText = "Loại";
            this.LoaiHangHoa.Name = "LoaiHangHoa";
            this.LoaiHangHoa.ReadOnly = true;
            this.LoaiHangHoa.Width = 85;
            // 
            // NgayHetHang
            // 
            this.NgayHetHang.HeaderText = "Hạn sử dụng";
            this.NgayHetHang.Name = "NgayHetHang";
            this.NgayHetHang.ReadOnly = true;
            this.NgayHetHang.Width = 85;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 84;
            // 
            // GiaBanLe
            // 
            this.GiaBanLe.HeaderText = "Giá bán";
            this.GiaBanLe.Name = "GiaBanLe";
            this.GiaBanLe.ReadOnly = true;
            this.GiaBanLe.Width = 85;
            // 
            // DonViTinh
            // 
            this.DonViTinh.HeaderText = "Đơn vị";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            this.DonViTinh.Width = 85;
            // 
            // groupBoxTimHangHoa
            // 
            this.groupBoxTimHangHoa.Controls.Add(this.panel13);
            this.groupBoxTimHangHoa.Controls.Add(this.buttonTim);
            this.groupBoxTimHangHoa.Controls.Add(this.panel6);
            this.groupBoxTimHangHoa.Controls.Add(this.panel5);
            this.groupBoxTimHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTimHangHoa.Location = new System.Drawing.Point(557, 67);
            this.groupBoxTimHangHoa.Name = "groupBoxTimHangHoa";
            this.groupBoxTimHangHoa.Size = new System.Drawing.Size(323, 117);
            this.groupBoxTimHangHoa.TabIndex = 2;
            this.groupBoxTimHangHoa.TabStop = false;
            this.groupBoxTimHangHoa.Text = "Tìm sản phẩm";
            // 
            // buttonTim
            // 
            this.buttonTim.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.buttonTim.Location = new System.Drawing.Point(185, 84);
            this.buttonTim.Name = "buttonTim";
            this.buttonTim.Size = new System.Drawing.Size(132, 27);
            this.buttonTim.TabIndex = 4;
            this.buttonTim.Text = "Tìm";
            this.buttonTim.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelTimLoaiHangHoa);
            this.panel6.Controls.Add(this.textBoxTimLoaiHangHoa);
            this.panel6.Location = new System.Drawing.Point(6, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(315, 38);
            this.panel6.TabIndex = 3;
            // 
            // labelTimLoaiHangHoa
            // 
            this.labelTimLoaiHangHoa.AutoSize = true;
            this.labelTimLoaiHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimLoaiHangHoa.Location = new System.Drawing.Point(3, 1);
            this.labelTimLoaiHangHoa.Name = "labelTimLoaiHangHoa";
            this.labelTimLoaiHangHoa.Size = new System.Drawing.Size(70, 18);
            this.labelTimLoaiHangHoa.TabIndex = 1;
            this.labelTimLoaiHangHoa.Text = "Loại hàng";
            // 
            // textBoxTimLoaiHangHoa
            // 
            this.textBoxTimLoaiHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimLoaiHangHoa.Location = new System.Drawing.Point(113, 3);
            this.textBoxTimLoaiHangHoa.Name = "textBoxTimLoaiHangHoa";
            this.textBoxTimLoaiHangHoa.Size = new System.Drawing.Size(198, 26);
            this.textBoxTimLoaiHangHoa.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelTimTenHangHoa);
            this.panel5.Controls.Add(this.textBoxTimTenHangHoa);
            this.panel5.Location = new System.Drawing.Point(6, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(315, 27);
            this.panel5.TabIndex = 2;
            // 
            // labelTimTenHangHoa
            // 
            this.labelTimTenHangHoa.AutoSize = true;
            this.labelTimTenHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimTenHangHoa.Location = new System.Drawing.Point(3, 3);
            this.labelTimTenHangHoa.Name = "labelTimTenHangHoa";
            this.labelTimTenHangHoa.Size = new System.Drawing.Size(104, 18);
            this.labelTimTenHangHoa.TabIndex = 1;
            this.labelTimTenHangHoa.Text = "Tên sản phẩm";
            // 
            // textBoxTimTenHangHoa
            // 
            this.textBoxTimTenHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimTenHangHoa.Location = new System.Drawing.Point(113, 0);
            this.textBoxTimTenHangHoa.Name = "textBoxTimTenHangHoa";
            this.textBoxTimTenHangHoa.Size = new System.Drawing.Size(198, 26);
            this.textBoxTimTenHangHoa.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBoxThongTinHangHoa);
            this.panel2.Location = new System.Drawing.Point(557, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 290);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(0, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonDatLai);
            this.panel3.Controls.Add(this.buttonXoa);
            this.panel3.Controls.Add(this.buttonThem);
            this.panel3.Controls.Add(this.buttonCapNhat);
            this.panel3.Location = new System.Drawing.Point(6, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 45);
            this.panel3.TabIndex = 2;
            // 
            // buttonDatLai
            // 
            this.buttonDatLai.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.buttonDatLai.Location = new System.Drawing.Point(234, 0);
            this.buttonDatLai.Name = "buttonDatLai";
            this.buttonDatLai.Size = new System.Drawing.Size(76, 45);
            this.buttonDatLai.TabIndex = 8;
            this.buttonDatLai.Text = "Đặt lại";
            this.buttonDatLai.UseVisualStyleBackColor = true;
            // 
            // buttonXoa
            // 
            this.buttonXoa.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.buttonXoa.Location = new System.Drawing.Point(78, 0);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(76, 45);
            this.buttonXoa.TabIndex = 6;
            this.buttonXoa.Text = "Xóa\r\nsản phẩm";
            this.buttonXoa.UseVisualStyleBackColor = true;
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.buttonThem.Location = new System.Drawing.Point(0, 0);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(76, 45);
            this.buttonThem.TabIndex = 5;
            this.buttonThem.Text = "Thêm\r\nsản phẩm";
            this.buttonThem.UseVisualStyleBackColor = true;
            // 
            // buttonCapNhat
            // 
            this.buttonCapNhat.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.buttonCapNhat.Location = new System.Drawing.Point(156, 0);
            this.buttonCapNhat.Name = "buttonCapNhat";
            this.buttonCapNhat.Size = new System.Drawing.Size(76, 45);
            this.buttonCapNhat.TabIndex = 7;
            this.buttonCapNhat.Text = "Cập nhật\r\nsản phẩm";
            this.buttonCapNhat.UseVisualStyleBackColor = true;
            // 
            // groupBoxThongTinHangHoa
            // 
            this.groupBoxThongTinHangHoa.Controls.Add(this.panel12);
            this.groupBoxThongTinHangHoa.Controls.Add(this.panel11);
            this.groupBoxThongTinHangHoa.Controls.Add(this.panel10);
            this.groupBoxThongTinHangHoa.Controls.Add(this.panel9);
            this.groupBoxThongTinHangHoa.Controls.Add(this.panel8);
            this.groupBoxThongTinHangHoa.Controls.Add(this.panel7);
            this.groupBoxThongTinHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxThongTinHangHoa.Location = new System.Drawing.Point(0, 3);
            this.groupBoxThongTinHangHoa.Name = "groupBoxThongTinHangHoa";
            this.groupBoxThongTinHangHoa.Size = new System.Drawing.Size(323, 213);
            this.groupBoxThongTinHangHoa.TabIndex = 0;
            this.groupBoxThongTinHangHoa.TabStop = false;
            this.groupBoxThongTinHangHoa.Text = "Thông tin sản phẩm";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.textBox2);
            this.panel12.Controls.Add(this.label6);
            this.panel12.Location = new System.Drawing.Point(6, 180);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(315, 27);
            this.panel12.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(113, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 26);
            this.textBox2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Đơn vị tính";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.textBoxDonGia);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Location = new System.Drawing.Point(6, 150);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(314, 26);
            this.panel11.TabIndex = 5;
            // 
            // textBoxDonGia
            // 
            this.textBoxDonGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDonGia.Location = new System.Drawing.Point(113, 0);
            this.textBoxDonGia.Name = "textBoxDonGia";
            this.textBoxDonGia.Size = new System.Drawing.Size(198, 26);
            this.textBoxDonGia.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Đơn giá";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.textBoxSoLuong);
            this.panel10.Controls.Add(this.label4);
            this.panel10.Location = new System.Drawing.Point(6, 117);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(315, 27);
            this.panel10.TabIndex = 5;
            // 
            // textBoxSoLuong
            // 
            this.textBoxSoLuong.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoLuong.Location = new System.Drawing.Point(113, 0);
            this.textBoxSoLuong.Name = "textBoxSoLuong";
            this.textBoxSoLuong.Size = new System.Drawing.Size(198, 26);
            this.textBoxSoLuong.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số lượng";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dateTimePickerHetHan);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Location = new System.Drawing.Point(5, 87);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(315, 26);
            this.panel9.TabIndex = 5;
            // 
            // dateTimePickerHetHan
            // 
            this.dateTimePickerHetHan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHetHan.Location = new System.Drawing.Point(114, 0);
            this.dateTimePickerHetHan.Name = "dateTimePickerHetHan";
            this.dateTimePickerHetHan.Size = new System.Drawing.Size(197, 26);
            this.dateTimePickerHetHan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày hết hạn";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.textBox1);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Location = new System.Drawing.Point(6, 55);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(315, 26);
            this.panel8.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(113, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 26);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại sản phẩm";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.textBoxTenHangHoa);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(6, 23);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(315, 26);
            this.panel7.TabIndex = 3;
            // 
            // textBoxTenHangHoa
            // 
            this.textBoxTenHangHoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenHangHoa.Location = new System.Drawing.Point(113, 0);
            this.textBoxTenHangHoa.Name = "textBoxTenHangHoa";
            this.textBoxTenHangHoa.Size = new System.Drawing.Size(198, 26);
            this.textBoxTenHangHoa.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên sản phẩm";
            // 
            // labelTieuDe
            // 
            this.labelTieuDe.AutoSize = true;
            this.labelTieuDe.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTieuDe.Location = new System.Drawing.Point(269, 6);
            this.labelTieuDe.Name = "labelTieuDe";
            this.labelTieuDe.Size = new System.Drawing.Size(341, 42);
            this.labelTieuDe.TabIndex = 3;
            this.labelTieuDe.Text = "QUẢN LÝ HÀNG HÓA";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelTieuDe);
            this.panel4.Location = new System.Drawing.Point(2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(878, 55);
            this.panel4.TabIndex = 4;
            // 
            // checkBoxDaHetHan
            // 
            this.checkBoxDaHetHan.AutoSize = true;
            this.checkBoxDaHetHan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDaHetHan.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDaHetHan.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDaHetHan.Name = "checkBoxDaHetHan";
            this.checkBoxDaHetHan.Size = new System.Drawing.Size(170, 22);
            this.checkBoxDaHetHan.TabIndex = 5;
            this.checkBoxDaHetHan.Text = "Sản phẩm đã hết hạn";
            this.checkBoxDaHetHan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxDaHetHan.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.checkBoxDaHetHan);
            this.panel13.Location = new System.Drawing.Point(6, 84);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(173, 30);
            this.panel13.TabIndex = 6;
            // 
            // FormQuanLyHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 482);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBoxTimHangHoa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormQuanLyHangHoa";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachHangHoa)).EndInit();
            this.groupBoxTimHangHoa.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBoxThongTinHangHoa.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachHangHoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBoxTimHangHoa;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelTimTenHangHoa;
        private System.Windows.Forms.TextBox textBoxTimTenHangHoa;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelTimLoaiHangHoa;
        private System.Windows.Forms.TextBox textBoxTimLoaiHangHoa;
        private System.Windows.Forms.Button buttonTim;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonCapNhat;
        private System.Windows.Forms.Button buttonDatLai;
        private System.Windows.Forms.GroupBox groupBoxThongTinHangHoa;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHetHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBanLe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.TextBox textBoxTenHangHoa;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox textBoxDonGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox textBoxSoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerHetHan;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelTieuDe;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.CheckBox checkBoxDaHetHan;
    }
}