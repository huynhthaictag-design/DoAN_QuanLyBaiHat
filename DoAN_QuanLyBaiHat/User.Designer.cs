namespace DoAN_QuanLyBaiHat
{
    partial class User
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnBaiHat = new System.Windows.Forms.Button();
            this.btnAlbums = new System.Windows.Forms.Button();
            this.btnCaSi = new System.Windows.Forms.Button();
            this.btnPlayList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlBody.Location = new System.Drawing.Point(208, 51);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(970, 615);
            this.pnlBody.TabIndex = 0;
            // 
            // btnBaiHat
            // 
            this.btnBaiHat.Location = new System.Drawing.Point(11, 32);
            this.btnBaiHat.Name = "btnBaiHat";
            this.btnBaiHat.Size = new System.Drawing.Size(176, 58);
            this.btnBaiHat.TabIndex = 1;
            this.btnBaiHat.Text = "Bài Hát";
            this.btnBaiHat.UseVisualStyleBackColor = true;
            this.btnBaiHat.Click += new System.EventHandler(this.btnBaiHat_Click);
            // 
            // btnAlbums
            // 
            this.btnAlbums.Location = new System.Drawing.Point(11, 96);
            this.btnAlbums.Name = "btnAlbums";
            this.btnAlbums.Size = new System.Drawing.Size(176, 58);
            this.btnAlbums.TabIndex = 2;
            this.btnAlbums.Text = "Albums";
            this.btnAlbums.UseVisualStyleBackColor = true;
            this.btnAlbums.Click += new System.EventHandler(this.btnAlbums_Click);
            // 
            // btnCaSi
            // 
            this.btnCaSi.Location = new System.Drawing.Point(11, 160);
            this.btnCaSi.Name = "btnCaSi";
            this.btnCaSi.Size = new System.Drawing.Size(176, 58);
            this.btnCaSi.TabIndex = 3;
            this.btnCaSi.Text = "Ca Sĩ";
            this.btnCaSi.UseVisualStyleBackColor = true;
            this.btnCaSi.Click += new System.EventHandler(this.btnCaSi_Click);
            // 
            // btnPlayList
            // 
            this.btnPlayList.Location = new System.Drawing.Point(11, 224);
            this.btnPlayList.Name = "btnPlayList";
            this.btnPlayList.Size = new System.Drawing.Size(176, 58);
            this.btnPlayList.TabIndex = 4;
            this.btnPlayList.Text = "PlayList của tôi";
            this.btnPlayList.UseVisualStyleBackColor = true;
            this.btnPlayList.Click += new System.EventHandler(this.btnPlayList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.groupBox1.Controls.Add(this.btnBaiHat);
            this.groupBox1.Controls.Add(this.btnPlayList);
            this.groupBox1.Controls.Add(this.btnAlbums);
            this.groupBox1.Controls.Add(this.btnCaSi);
            this.groupBox1.Location = new System.Drawing.Point(3, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 306);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1187, 676);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "User";
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnBaiHat;
        private System.Windows.Forms.Button btnAlbums;
        private System.Windows.Forms.Button btnCaSi;
        private System.Windows.Forms.Button btnPlayList;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}