namespace DoAN_QuanLyBaiHat.UserControls
{
    partial class UC_ThemBaiHat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlNhapLieu = new System.Windows.Forms.Panel();
            this.cbbTheLoai = new System.Windows.Forms.ComboBox();
            this.btnChonNhac = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richLoiNhac = new System.Windows.Forms.RichTextBox();
            this.dtpNgayDang = new System.Windows.Forms.DateTimePicker();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.txtTenBaiHat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlNhapLieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNhapLieu
            // 
            this.pnlNhapLieu.Controls.Add(this.cbbTheLoai);
            this.pnlNhapLieu.Controls.Add(this.btnChonNhac);
            this.pnlNhapLieu.Controls.Add(this.label5);
            this.pnlNhapLieu.Controls.Add(this.richLoiNhac);
            this.pnlNhapLieu.Controls.Add(this.dtpNgayDang);
            this.pnlNhapLieu.Controls.Add(this.txtDuongDan);
            this.pnlNhapLieu.Controls.Add(this.txtTenBaiHat);
            this.pnlNhapLieu.Controls.Add(this.label4);
            this.pnlNhapLieu.Controls.Add(this.label3);
            this.pnlNhapLieu.Controls.Add(this.label2);
            this.pnlNhapLieu.Controls.Add(this.label1);
            this.pnlNhapLieu.Controls.Add(this.btnHuy);
            this.pnlNhapLieu.Controls.Add(this.btnLuu);
            this.pnlNhapLieu.Location = new System.Drawing.Point(0, 3);
            this.pnlNhapLieu.Name = "pnlNhapLieu";
            this.pnlNhapLieu.Size = new System.Drawing.Size(983, 677);
            this.pnlNhapLieu.TabIndex = 3;
            // 
            // cbbTheLoai
            // 
            this.cbbTheLoai.FormattingEnabled = true;
            this.cbbTheLoai.Items.AddRange(new object[] {
            "Buồn ",
            "Vui",
            "Hạnh Phúc"});
            this.cbbTheLoai.Location = new System.Drawing.Point(257, 152);
            this.cbbTheLoai.Name = "cbbTheLoai";
            this.cbbTheLoai.Size = new System.Drawing.Size(121, 30);
            this.cbbTheLoai.TabIndex = 20;
            // 
            // btnChonNhac
            // 
            this.btnChonNhac.Location = new System.Drawing.Point(735, 126);
            this.btnChonNhac.Name = "btnChonNhac";
            this.btnChonNhac.Size = new System.Drawing.Size(75, 23);
            this.btnChonNhac.TabIndex = 19;
            this.btnChonNhac.Text = "Chọn";
            this.btnChonNhac.UseVisualStyleBackColor = true;
            this.btnChonNhac.Click += new System.EventHandler(this.btnChonNhac_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "File Nhạc";
            // 
            // richLoiNhac
            // 
            this.richLoiNhac.Location = new System.Drawing.Point(239, 252);
            this.richLoiNhac.Name = "richLoiNhac";
            this.richLoiNhac.Size = new System.Drawing.Size(370, 96);
            this.richLoiNhac.TabIndex = 17;
            this.richLoiNhac.Text = "";
            // 
            // dtpNgayDang
            // 
            this.dtpNgayDang.Location = new System.Drawing.Point(257, 196);
            this.dtpNgayDang.Name = "dtpNgayDang";
            this.dtpNgayDang.Size = new System.Drawing.Size(200, 30);
            this.dtpNgayDang.TabIndex = 16;
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(620, 123);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(100, 30);
            this.txtDuongDan.TabIndex = 14;
            // 
            // txtTenBaiHat
            // 
            this.txtTenBaiHat.Location = new System.Drawing.Point(257, 118);
            this.txtTenBaiHat.Name = "txtTenBaiHat";
            this.txtTenBaiHat.Size = new System.Drawing.Size(100, 30);
            this.txtTenBaiHat.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lời Nhạc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngày Đăng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Thể Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên Bài Hát";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(501, 506);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(125, 52);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Quay Lại";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(176, 506);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(125, 52);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // UC_ThemBaiHat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNhapLieu);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "UC_ThemBaiHat";
            this.Size = new System.Drawing.Size(983, 677);
            this.Load += new System.EventHandler(this.UC_ThemBaiHat_Load);
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNhapLieu;
        private System.Windows.Forms.ComboBox cbbTheLoai;
        private System.Windows.Forms.Button btnChonNhac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richLoiNhac;
        private System.Windows.Forms.DateTimePicker dtpNgayDang;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.TextBox txtTenBaiHat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}
