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
        }

        // --- HÀM HỖ TRỢ DÙNG CHUNG (HELPER) ---
        private void DongUserControl(UserControl uc)
        {
            // Tìm parent của uc để remove chính xác
            if (uc.Parent != null)
            {
                uc.Parent.Controls.Remove(uc);
            }
            uc.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}