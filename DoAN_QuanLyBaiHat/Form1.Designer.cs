namespace DoAN_QuanLyBaiHat
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBaiHat = new System.Windows.Forms.TabPage();
            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvBaiHat = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.tabControl1.SuspendLayout();
            this.tabBaiHat.SuspendLayout();
            this.pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiHat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBaiHat);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(987, 709);
            this.tabControl1.TabIndex = 1;
            // 
            // tabBaiHat
            // 
            this.tabBaiHat.Controls.Add(this.pnlDanhSach);
            this.tabBaiHat.Location = new System.Drawing.Point(4, 31);
            this.tabBaiHat.Name = "tabBaiHat";
            this.tabBaiHat.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaiHat.Size = new System.Drawing.Size(979, 674);
            this.tabBaiHat.TabIndex = 0;
            this.tabBaiHat.Text = "Quản Lý Bài Hát";
            this.tabBaiHat.UseVisualStyleBackColor = true;
            // 
            // pnlDanhSach
            // 
            this.pnlDanhSach.BackgroundImage = global::DoAN_QuanLyBaiHat.Properties.Resources.Gemini_Generated_Image_3wpmbg3wpmbg3wpm;
            this.pnlDanhSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDanhSach.Controls.Add(this.btnSua);
            this.pnlDanhSach.Controls.Add(this.dgvBaiHat);
            this.pnlDanhSach.Controls.Add(this.btnXoa);
            this.pnlDanhSach.Controls.Add(this.btnThem);
            this.pnlDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhSach.Location = new System.Drawing.Point(3, 3);
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.Size = new System.Drawing.Size(973, 668);
            this.pnlDanhSach.TabIndex = 0;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(770, 183);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(176, 58);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa Bài Hát";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvBaiHat
            // 
            this.dgvBaiHat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaiHat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaiHat.Location = new System.Drawing.Point(-7, 0);
            this.dgvBaiHat.Name = "dgvBaiHat";
            this.dgvBaiHat.RowHeadersWidth = 51;
            this.dgvBaiHat.RowTemplate.Height = 24;
            this.dgvBaiHat.Size = new System.Drawing.Size(744, 674);
            this.dgvBaiHat.TabIndex = 1;
            this.dgvBaiHat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaiHat_CellContentClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(770, 119);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(176, 58);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa Bài Hát";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(770, 55);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(176, 58);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm Bài Hát";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(979, 680);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(979, 680);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(200, 100);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "tabPage4";
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 709);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBaiHat.ResumeLayout(false);
            this.pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiHat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBaiHat;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pnlDanhSach;
        private System.Windows.Forms.DataGridView dgvBaiHat;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}

