namespace DoAN_QuanLyBaiHat.AdminController
{
    partial class UC_ThemAlbums
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenAlbum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbCaSi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayPhatHanh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.clbBaiHat = new System.Windows.Forms.CheckedListBox();
            this.pbAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelTitle.Location = new System.Drawing.Point(320, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(245, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "THÊM ALBUM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(50, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Album:";
            // 
            // txtTenAlbum
            // 
            this.txtTenAlbum.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTenAlbum.Location = new System.Drawing.Point(180, 87);
            this.txtTenAlbum.Name = "txtTenAlbum";
            this.txtTenAlbum.Size = new System.Drawing.Size(300, 30);
            this.txtTenAlbum.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(50, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ca Sĩ:";
            // 
            // cbbCaSi
            // 
            this.cbbCaSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCaSi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbbCaSi.FormattingEnabled = true;
            this.cbbCaSi.Location = new System.Drawing.Point(180, 137);
            this.cbbCaSi.Name = "cbbCaSi";
            this.cbbCaSi.Size = new System.Drawing.Size(300, 30);
            this.cbbCaSi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label4.Location = new System.Drawing.Point(50, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ngày Đăng:";
            // 
            // dtpNgayPhatHanh
            // 
            this.dtpNgayPhatHanh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpNgayPhatHanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayPhatHanh.Location = new System.Drawing.Point(180, 187);
            this.dtpNgayPhatHanh.Name = "dtpNgayPhatHanh";
            this.dtpNgayPhatHanh.Size = new System.Drawing.Size(300, 30);
            this.dtpNgayPhatHanh.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(50, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chọn bài hát thêm vào Album (Tích chọn):";
            // 
            // clbBaiHat
            // 
            this.clbBaiHat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.clbBaiHat.FormattingEnabled = true;
            this.clbBaiHat.Location = new System.Drawing.Point(54, 270);
            this.clbBaiHat.Name = "clbBaiHat";
            this.clbBaiHat.Size = new System.Drawing.Size(426, 204);
            this.clbBaiHat.TabIndex = 8;
            // 
            // pbAnh
            // 
            this.pbAnh.BackColor = System.Drawing.Color.Gainsboro;
            this.pbAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAnh.Location = new System.Drawing.Point(550, 87);
            this.pbAnh.Name = "pbAnh";
            this.pbAnh.Size = new System.Drawing.Size(200, 200);
            this.pbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnh.TabIndex = 9;
            this.pbAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnChonAnh.Location = new System.Drawing.Point(550, 300);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(200, 40);
            this.btnChonAnh.TabIndex = 10;
            this.btnChonAnh.Text = "Chọn Ảnh Bìa...";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(250, 500);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(130, 50);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "LƯU";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(420, 500);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(130, 50);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "QUAY LẠI";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // UC_ThemAlbums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.pbAnh);
            this.Controls.Add(this.clbBaiHat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNgayPhatHanh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbCaSi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenAlbum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_ThemAlbums";
            this.Size = new System.Drawing.Size(1000, 793);
            this.Load += new System.EventHandler(this.UC_ThemAlbums_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenAlbum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbCaSi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayPhatHanh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbBaiHat;
        private System.Windows.Forms.PictureBox pbAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}