namespace DoAN_QuanLyBaiHat.UserConTroller
{
    partial class SongItem
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
            this.lblTenBaiHat = new System.Windows.Forms.Label();
            this.lblTenCaSi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTenBaiHat
            // 
            this.lblTenBaiHat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBaiHat.Location = new System.Drawing.Point(0, 0);
            this.lblTenBaiHat.Name = "lblTenBaiHat";
            this.lblTenBaiHat.Size = new System.Drawing.Size(110, 46);
            this.lblTenBaiHat.TabIndex = 0;
            this.lblTenBaiHat.Text = "label1";
            this.lblTenBaiHat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenBaiHat.Click += new System.EventHandler(this.lblTenBai_Click);
            // 
            // lblTenCaSi
            // 
            this.lblTenCaSi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCaSi.Location = new System.Drawing.Point(0, 55);
            this.lblTenCaSi.Name = "lblTenCaSi";
            this.lblTenCaSi.Size = new System.Drawing.Size(110, 44);
            this.lblTenCaSi.TabIndex = 1;
            this.lblTenCaSi.Text = "label1";
            this.lblTenCaSi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenCaSi.Click += new System.EventHandler(this.lblTenCaSi_Click);
            // 
            // SongItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.lblTenCaSi);
            this.Controls.Add(this.lblTenBaiHat);
            this.Name = "SongItem";
            this.Size = new System.Drawing.Size(110, 100);
            this.Click += new System.EventHandler(this.SongItem_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenBaiHat;
        private System.Windows.Forms.Label lblTenCaSi;
    }
}
