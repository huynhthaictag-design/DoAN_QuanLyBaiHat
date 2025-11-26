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
            this.tabAlbums = new System.Windows.Forms.TabControl();
            this.tabBaiHat = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSuaAlbums = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnXoaAlbums = new System.Windows.Forms.Button();
            this.btnThemAlbums = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSuaCaSi = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnXoaCaSi = new System.Windows.Forms.Button();
            this.btnThemCaSi = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvBaiHat = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabAlbums.SuspendLayout();
            this.tabBaiHat.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiHat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAlbums
            // 
            this.tabAlbums.Controls.Add(this.tabBaiHat);
            this.tabAlbums.Controls.Add(this.tabPage2);
            this.tabAlbums.Controls.Add(this.tabPage3);
            this.tabAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAlbums.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAlbums.Location = new System.Drawing.Point(0, 0);
            this.tabAlbums.Name = "tabAlbums";
            this.tabAlbums.SelectedIndex = 0;
            this.tabAlbums.Size = new System.Drawing.Size(1161, 709);
            this.tabAlbums.TabIndex = 1;
            // 
            // tabBaiHat
            // 
            this.tabBaiHat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tabBaiHat.Controls.Add(this.label4);
            this.tabBaiHat.Controls.Add(this.txtTimKiem);
            this.tabBaiHat.Controls.Add(this.label1);
            this.tabBaiHat.Controls.Add(this.btnSua);
            this.tabBaiHat.Controls.Add(this.dgvBaiHat);
            this.tabBaiHat.Controls.Add(this.btnXoa);
            this.tabBaiHat.Controls.Add(this.btnThem);
            this.tabBaiHat.Location = new System.Drawing.Point(4, 31);
            this.tabBaiHat.Name = "tabBaiHat";
            this.tabBaiHat.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaiHat.Size = new System.Drawing.Size(1153, 674);
            this.tabBaiHat.TabIndex = 0;
            this.tabBaiHat.Text = "Quản Lý Bài Hát";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSuaAlbums);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.btnXoaAlbums);
            this.tabPage2.Controls.Add(this.btnThemAlbums);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1153, 674);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản Lí Albums";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Algerian", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(928, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 428);
            this.label2.TabIndex = 6;
            this.label2.Text = "NGUYỄN ĐẠT \r\nTÀI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSuaAlbums
            // 
            this.btnSuaAlbums.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaAlbums.Location = new System.Drawing.Point(950, 180);
            this.btnSuaAlbums.Name = "btnSuaAlbums";
            this.btnSuaAlbums.Size = new System.Drawing.Size(176, 58);
            this.btnSuaAlbums.TabIndex = 2;
            this.btnSuaAlbums.Text = "Sửa Albums";
            this.btnSuaAlbums.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(922, 677);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnXoaAlbums
            // 
            this.btnXoaAlbums.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaAlbums.Location = new System.Drawing.Point(950, 116);
            this.btnXoaAlbums.Name = "btnXoaAlbums";
            this.btnXoaAlbums.Size = new System.Drawing.Size(176, 58);
            this.btnXoaAlbums.TabIndex = 3;
            this.btnXoaAlbums.Text = "Xóa Albums";
            this.btnXoaAlbums.UseVisualStyleBackColor = true;
            // 
            // btnThemAlbums
            // 
            this.btnThemAlbums.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemAlbums.Location = new System.Drawing.Point(950, 52);
            this.btnThemAlbums.Name = "btnThemAlbums";
            this.btnThemAlbums.Size = new System.Drawing.Size(176, 58);
            this.btnThemAlbums.TabIndex = 4;
            this.btnThemAlbums.Text = "Thêm Albums";
            this.btnThemAlbums.UseVisualStyleBackColor = true;
            this.btnThemAlbums.Click += new System.EventHandler(this.btnThemAlbums_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnSuaCaSi);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Controls.Add(this.btnXoaCaSi);
            this.tabPage3.Controls.Add(this.btnThemCaSi);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1153, 674);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Quản Lí Ca Sĩ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Algerian", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(928, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 428);
            this.label3.TabIndex = 7;
            this.label3.Text = "PHAN \r\nHỮU \r\nTRỌNG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSuaCaSi
            // 
            this.btnSuaCaSi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCaSi.Location = new System.Drawing.Point(952, 180);
            this.btnSuaCaSi.Name = "btnSuaCaSi";
            this.btnSuaCaSi.Size = new System.Drawing.Size(176, 58);
            this.btnSuaCaSi.TabIndex = 2;
            this.btnSuaCaSi.Text = "Sửa Ca Sĩ";
            this.btnSuaCaSi.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(922, 674);
            this.dataGridView2.TabIndex = 5;
            // 
            // btnXoaCaSi
            // 
            this.btnXoaCaSi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCaSi.Location = new System.Drawing.Point(952, 116);
            this.btnXoaCaSi.Name = "btnXoaCaSi";
            this.btnXoaCaSi.Size = new System.Drawing.Size(176, 58);
            this.btnXoaCaSi.TabIndex = 3;
            this.btnXoaCaSi.Text = "Xóa Ca Sĩ";
            this.btnXoaCaSi.UseVisualStyleBackColor = true;
            // 
            // btnThemCaSi
            // 
            this.btnThemCaSi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCaSi.Location = new System.Drawing.Point(952, 52);
            this.btnThemCaSi.Name = "btnThemCaSi";
            this.btnThemCaSi.Size = new System.Drawing.Size(176, 58);
            this.btnThemCaSi.TabIndex = 4;
            this.btnThemCaSi.Text = "Thêm Ca Sĩ";
            this.btnThemCaSi.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Algerian", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(924, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 351);
            this.label1.TabIndex = 7;
            this.label1.Text = "HUỲNH DUY THÁI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(947, 171);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(176, 58);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa Bài Hát";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvBaiHat
            // 
            this.dgvBaiHat.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaiHat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaiHat.Location = new System.Drawing.Point(0, 0);
            this.dgvBaiHat.Name = "dgvBaiHat";
            this.dgvBaiHat.RowHeadersWidth = 51;
            this.dgvBaiHat.RowTemplate.Height = 24;
            this.dgvBaiHat.Size = new System.Drawing.Size(918, 674);
            this.dgvBaiHat.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(947, 107);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(176, 58);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa Bài Hát";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(947, 43);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(176, 58);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm Bài Hát";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(932, 284);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(213, 30);
            this.txtTimKiem.TabIndex = 8;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(942, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tìm kiếm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1161, 709);
            this.Controls.Add(this.tabAlbums);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabAlbums.ResumeLayout(false);
            this.tabBaiHat.ResumeLayout(false);
            this.tabBaiHat.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiHat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabAlbums;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Button btnSuaAlbums;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnXoaAlbums;
        private System.Windows.Forms.Button btnThemAlbums;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabBaiHat;
        private System.Windows.Forms.Button btnSuaCaSi;
        private System.Windows.Forms.Button btnXoaCaSi;
        private System.Windows.Forms.Button btnThemCaSi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvBaiHat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label4;
    }
}

