namespace DoAN_QuanLyBaiHat.AdminController
{
    partial class UC_ThemAlbums
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
            this.dtpNgayDang = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaSi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAlbums = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpNgayDang
            // 
            this.dtpNgayDang.Location = new System.Drawing.Point(195, 212);
            this.dtpNgayDang.Name = "dtpNgayDang";
            this.dtpNgayDang.Size = new System.Drawing.Size(298, 30);
            this.dtpNgayDang.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 90;
            this.label3.Text = "Ngày Đăng";
            // 
            // txtCaSi
            // 
            this.txtCaSi.Location = new System.Drawing.Point(195, 159);
            this.txtCaSi.Name = "txtCaSi";
            this.txtCaSi.Size = new System.Drawing.Size(298, 30);
            this.txtCaSi.TabIndex = 89;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 22);
            this.label7.TabIndex = 88;
            this.label7.Text = "Tên Ca Sĩ";
            // 
            // txtAlbums
            // 
            this.txtAlbums.Location = new System.Drawing.Point(195, 109);
            this.txtAlbums.Name = "txtAlbums";
            this.txtAlbums.Size = new System.Drawing.Size(298, 30);
            this.txtAlbums.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 22);
            this.label6.TabIndex = 86;
            this.label6.Text = "Tên Albums";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(345, 261);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(125, 52);
            this.btnHuy.TabIndex = 84;
            this.btnHuy.Text = "Quay Lại";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(122, 261);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(125, 52);
            this.btnLuu.TabIndex = 85;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // UC_ThemAlbums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpNgayDang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCaSi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAlbums);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_ThemAlbums";
            this.Size = new System.Drawing.Size(577, 423);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayDang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCaSi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAlbums;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}
