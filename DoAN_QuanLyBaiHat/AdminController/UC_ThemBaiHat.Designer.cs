namespace DoAN_QuanLyBaiHat.UserControls
{
    partial class UC_ThemBaiHat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenBaiHat = new System.Windows.Forms.TextBox();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.dtpNgayDang = new System.Windows.Forms.DateTimePicker();
            this.richLoiNhac = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChonNhac = new System.Windows.Forms.Button();
            this.cbbTheLoai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlbums = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCaSi = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(439, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 37);
            this.label8.TabIndex = 147;
            this.label8.Text = "THÊM BÀI HÁT\r\n";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(436, 572);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(127, 52);
            this.btnLuu.TabIndex = 130;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuayLai.Location = new System.Drawing.Point(659, 572);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(127, 52);
            this.btnQuayLai.TabIndex = 129;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(345, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 33);
            this.label1.TabIndex = 134;
            this.label1.Text = "Tên Bài Hát";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(345, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 33);
            this.label2.TabIndex = 133;
            this.label2.Text = "Thể Loại";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(345, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 33);
            this.label3.TabIndex = 132;
            this.label3.Text = "Ngày Đăng";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(345, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 33);
            this.label4.TabIndex = 131;
            this.label4.Text = "Lời Nhạc";
            // 
            // txtTenBaiHat
            // 
            this.txtTenBaiHat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenBaiHat.Location = new System.Drawing.Point(509, 111);
            this.txtTenBaiHat.Name = "txtTenBaiHat";
            this.txtTenBaiHat.Size = new System.Drawing.Size(300, 30);
            this.txtTenBaiHat.TabIndex = 136;
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuongDan.Location = new System.Drawing.Point(509, 284);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(204, 30);
            this.txtDuongDan.TabIndex = 135;
            // 
            // dtpNgayDang
            // 
            this.dtpNgayDang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayDang.Location = new System.Drawing.Point(509, 228);
            this.dtpNgayDang.Name = "dtpNgayDang";
            this.dtpNgayDang.Size = new System.Drawing.Size(300, 30);
            this.dtpNgayDang.TabIndex = 137;
            // 
            // richLoiNhac
            // 
            this.richLoiNhac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richLoiNhac.Location = new System.Drawing.Point(509, 339);
            this.richLoiNhac.Name = "richLoiNhac";
            this.richLoiNhac.Size = new System.Drawing.Size(300, 114);
            this.richLoiNhac.TabIndex = 138;
            this.richLoiNhac.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(345, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 33);
            this.label5.TabIndex = 139;
            this.label5.Text = "File Nhạc";
            // 
            // btnChonNhac
            // 
            this.btnChonNhac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonNhac.Location = new System.Drawing.Point(717, 273);
            this.btnChonNhac.Name = "btnChonNhac";
            this.btnChonNhac.Size = new System.Drawing.Size(92, 50);
            this.btnChonNhac.TabIndex = 140;
            this.btnChonNhac.Text = "Chọn";
            this.btnChonNhac.UseVisualStyleBackColor = true;
            this.btnChonNhac.Click += new System.EventHandler(this.btnChonNhac_Click);
            // 
            // cbbTheLoai
            // 
            this.cbbTheLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTheLoai.FormattingEnabled = true;
            this.cbbTheLoai.Items.AddRange(new object[] {
            "Ballad",
            "Pop",
            "Rap/Hip-hop",
            "EDM ",
            "Nhạc Truyền thống và Dân ca",
            "Nhạc Indie/Underground",
            "Nhạc K-pop"});
            this.cbbTheLoai.Location = new System.Drawing.Point(509, 169);
            this.cbbTheLoai.Name = "cbbTheLoai";
            this.cbbTheLoai.Size = new System.Drawing.Size(300, 30);
            this.cbbTheLoai.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(345, 471);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 33);
            this.label6.TabIndex = 142;
            this.label6.Text = "Tên Albums";
            // 
            // txtAlbums
            // 
            this.txtAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlbums.Location = new System.Drawing.Point(509, 475);
            this.txtAlbums.Name = "txtAlbums";
            this.txtAlbums.Size = new System.Drawing.Size(300, 30);
            this.txtAlbums.TabIndex = 143;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(345, 521);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 33);
            this.label7.TabIndex = 144;
            this.label7.Text = "Tên Ca Sĩ";
            // 
            // txtCaSi
            // 
            this.txtCaSi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaSi.Location = new System.Drawing.Point(509, 525);
            this.txtCaSi.Name = "txtCaSi";
            this.txtCaSi.Size = new System.Drawing.Size(300, 30);
            this.txtCaSi.TabIndex = 145;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(180, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 619);
            this.panel1.TabIndex = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(165, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 648);
            this.panel2.TabIndex = 152;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(75, 75);
            this.panel3.TabIndex = 153;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Location = new System.Drawing.Point(84, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(75, 75);
            this.panel4.TabIndex = 154;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Location = new System.Drawing.Point(84, 246);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(75, 75);
            this.panel5.TabIndex = 156;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Location = new System.Drawing.Point(3, 165);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(75, 75);
            this.panel6.TabIndex = 155;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel7.Location = new System.Drawing.Point(84, 571);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(75, 75);
            this.panel7.TabIndex = 160;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Location = new System.Drawing.Point(84, 409);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(75, 75);
            this.panel8.TabIndex = 158;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel9.Location = new System.Drawing.Point(3, 490);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(75, 75);
            this.panel9.TabIndex = 159;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel10.Location = new System.Drawing.Point(3, 328);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(75, 75);
            this.panel10.TabIndex = 157;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel11.Location = new System.Drawing.Point(1077, 571);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(75, 75);
            this.panel11.TabIndex = 168;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel12.Location = new System.Drawing.Point(1077, 246);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(75, 75);
            this.panel12.TabIndex = 164;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel13.Location = new System.Drawing.Point(1077, 409);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(75, 75);
            this.panel13.TabIndex = 166;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel14.Location = new System.Drawing.Point(1077, 84);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(75, 75);
            this.panel14.TabIndex = 162;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel15.Location = new System.Drawing.Point(996, 490);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(75, 75);
            this.panel15.TabIndex = 167;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel16.Location = new System.Drawing.Point(996, 165);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(75, 75);
            this.panel16.TabIndex = 163;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel17.Location = new System.Drawing.Point(996, 328);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(75, 75);
            this.panel17.TabIndex = 165;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel18.Location = new System.Drawing.Point(996, 3);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(75, 75);
            this.panel18.TabIndex = 161;
            // 
            // UC_ThemBaiHat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCaSi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAlbums);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbTheLoai);
            this.Controls.Add(this.btnChonNhac);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richLoiNhac);
            this.Controls.Add(this.dtpNgayDang);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.txtTenBaiHat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "UC_ThemBaiHat";
            this.Size = new System.Drawing.Size(1155, 674);
            this.Load += new System.EventHandler(this.UC_ThemBaiHat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenBaiHat;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.DateTimePicker dtpNgayDang;
        private System.Windows.Forms.RichTextBox richLoiNhac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChonNhac;
        private System.Windows.Forms.ComboBox cbbTheLoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlbums;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCaSi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
    }
}