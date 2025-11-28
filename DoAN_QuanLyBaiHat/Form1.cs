using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat
{
    // Từ khóa "partial" rất quan trọng
    public partial class Form1 : Form
    {
        // Các biến dùng chung cho cả BaiHat và CaSi
        DataSet ds = new DataSet();
        MySqlDataAdapter daBaiHat;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBaiHat();     // Hàm này nằm ở file Form1.BaiHat.cs
            LoadDataCaSi();   // Hàm này nằm ở file Form1.CaSi.cs
            LoadTabTaiKhoan();
           
        }
        private void LoadTabTaiKhoan()
        {
            DoAN_QuanLyBaiHat.AdminController.UC_QuanLyTaiKhoan ucTK = new DoAN_QuanLyBaiHat.AdminController.UC_QuanLyTaiKhoan();

            // Cài đặt lấp đầy
            ucTK.Dock = DockStyle.Fill;

            // Xóa cái cũ đi trước khi thêm cái mới (Tránh bị chồng)
            tabQuanLyTaiKhoan.Controls.Clear();

            // Thêm vào Tab
            tabQuanLyTaiKhoan.Controls.Add(ucTK);

            // Đưa lên trên cùng cho chắc chắn
            ucTK.BringToFront();
        }

        // --- HÀM HỖ TRỢ DÙNG CHUNG (HELPER) ---
        private void DongUserControl(UserControl uc)
        {
            if (uc.Parent != null)
            {
                uc.Parent.Controls.Remove(uc); // Gỡ bỏ khỏi giao diện
            }
            uc.Dispose(); // Giải phóng bộ nhớ
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void VeManHinhChinh()
        {
     
            for (int i = tabBaiHat.Controls.Count - 1; i >= 0; i--)
            {
    
                if (tabBaiHat.Controls[i] is UserControl)
                {
             
                    tabBaiHat.Controls.RemoveAt(i);
                }
            }

           
            dgvBaiHat.Visible = true;
            LoadBaiHat();
        }
    }
}