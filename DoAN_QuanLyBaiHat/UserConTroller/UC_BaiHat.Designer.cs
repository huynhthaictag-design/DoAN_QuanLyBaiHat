namespace DoAN_QuanLyBaiHat
{
    partial class UC_BaiHat
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
            this.label1 = new System.Windows.Forms.Label();
            this.flpDsBH = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXa = new System.Windows.Forms.Button();
            this.btnDung = new System.Windows.Forms.Button();
            this.btnLui = new System.Windows.Forms.Button();
            this.btnThemPlayList = new System.Windows.Forms.Button();
            this.btnXoaPlayList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Bài Hát";
            // 
            // flpDsBH
            // 
            this.flpDsBH.AutoScroll = true;
            this.flpDsBH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpDsBH.Location = new System.Drawing.Point(3, 51);
            this.flpDsBH.Name = "flpDsBH";
            this.flpDsBH.Size = new System.Drawing.Size(964, 489);
            this.flpDsBH.TabIndex = 1;
            // 
            // btnXa
            // 
            this.btnXa.Location = new System.Drawing.Point(545, 548);
            this.btnXa.Name = "btnXa";
            this.btnXa.Size = new System.Drawing.Size(108, 54);
            this.btnXa.TabIndex = 10;
            this.btnXa.Text = ">>";
            this.btnXa.UseVisualStyleBackColor = true;
            this.btnXa.Click += new System.EventHandler(this.btnXa_Click);
            // 
            // btnDung
            // 
            this.btnDung.Location = new System.Drawing.Point(431, 548);
            this.btnDung.Name = "btnDung";
            this.btnDung.Size = new System.Drawing.Size(108, 54);
            this.btnDung.TabIndex = 9;
            this.btnDung.Text = "⏯";
            this.btnDung.UseVisualStyleBackColor = true;
            this.btnDung.Click += new System.EventHandler(this.btnDung_Click);
            // 
            // btnLui
            // 
            this.btnLui.Location = new System.Drawing.Point(317, 548);
            this.btnLui.Name = "btnLui";
            this.btnLui.Size = new System.Drawing.Size(108, 54);
            this.btnLui.TabIndex = 8;
            this.btnLui.Text = "<<";
            this.btnLui.UseVisualStyleBackColor = true;
            this.btnLui.Click += new System.EventHandler(this.btnLui_Click);
            // 
            // btnThemPlayList
            // 
            this.btnThemPlayList.Location = new System.Drawing.Point(659, 558);
            this.btnThemPlayList.Name = "btnThemPlayList";
            this.btnThemPlayList.Size = new System.Drawing.Size(151, 35);
            this.btnThemPlayList.TabIndex = 11;
            this.btnThemPlayList.Text = "+ Thêm PlayList";
            this.btnThemPlayList.UseVisualStyleBackColor = true;
            this.btnThemPlayList.Click += new System.EventHandler(this.btnThemPlayList_Click);
            // 
            // btnXoaPlayList
            // 
            this.btnXoaPlayList.Location = new System.Drawing.Point(160, 558);
            this.btnXoaPlayList.Name = "btnXoaPlayList";
            this.btnXoaPlayList.Size = new System.Drawing.Size(151, 35);
            this.btnXoaPlayList.TabIndex = 12;
            this.btnXoaPlayList.Text = "- Xóa PlayList";
            this.btnXoaPlayList.UseVisualStyleBackColor = true;
            this.btnXoaPlayList.Click += new System.EventHandler(this.btnXoaPlayList_Click);
            // 
            // UC_BaiHat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnXoaPlayList);
            this.Controls.Add(this.btnThemPlayList);
            this.Controls.Add(this.btnXa);
            this.Controls.Add(this.btnDung);
            this.Controls.Add(this.btnLui);
            this.Controls.Add(this.flpDsBH);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_BaiHat";
            this.Size = new System.Drawing.Size(970, 615);
            this.Load += new System.EventHandler(this.UC_BaiHat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpDsBH;
        private System.Windows.Forms.Button btnXa;
        private System.Windows.Forms.Button btnDung;
        private System.Windows.Forms.Button btnLui;
        private System.Windows.Forms.Button btnThemPlayList;
        private System.Windows.Forms.Button btnXoaPlayList;
    }
}
