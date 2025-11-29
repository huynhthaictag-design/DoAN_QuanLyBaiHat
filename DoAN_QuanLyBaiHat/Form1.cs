using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        MySqlDataAdapter daBaiHat;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            LoadBaiHat();       
            LoadDataCaSi();    
            LoadDataAlbums();  

            LoadTabTaiKhoan();
        }

        private void LoadTabTaiKhoan()
        {
            DoAN_QuanLyBaiHat.AdminController.UC_QuanLyTaiKhoan ucTK = new DoAN_QuanLyBaiHat.AdminController.UC_QuanLyTaiKhoan();
            ucTK.Dock = DockStyle.Fill;
            tabQuanLyTaiKhoan.Controls.Clear();
            tabQuanLyTaiKhoan.Controls.Add(ucTK);
            ucTK.BringToFront();
        }

        private void DongUserControl(UserControl uc)
        {
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

      

        // File: Form1.Albums.cs (hoặc Form1.cs tùy nơi tạo sự kiện)

        private void dgvAlbums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào dòng hợp lệ (không phải tiêu đề)
            if (e.RowIndex >= 0 && dgvAlbums.CurrentRow != null)
            {
                // Lấy ID Album và Tên Album
                string abId = dgvAlbums.CurrentRow.Cells["Ab_Id"].Value.ToString();
                string tenAb = dgvAlbums.CurrentRow.Cells["Ten_Ab"].Value.ToString();

                // Gọi hàm để lấy danh sách bài hát
                LoadBaiHatCuaAlbum(abId, tenAb);
            }
        }

        // Hàm phụ để tải và hiển thị bài hát
        private void LoadBaiHatCuaAlbum(string abId, string tenAlbum)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Lấy tên bài hát thuộc album này
                    string sql = "SELECT Ten_Bai_Hat FROM baihat WHERE ab_Id = @AbId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AbId", abId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    string danhSachBaiHat = "";
                    int dem = 0;

                    while (reader.Read())
                    {
                        dem++;
                        danhSachBaiHat += $"{dem}. {reader["Ten_Bai_Hat"]}\n";
                    }

                    if (dem > 0)
                    {
                        MessageBox.Show($"Danh sách bài hát trong Album '{tenAlbum}':\n\n{danhSachBaiHat}", "Chi tiết Album");
                    }
                    else
                    {
                        MessageBox.Show($"Album '{tenAlbum}' chưa có bài hát nào.", "Chi tiết Album");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bài hát: " + ex.Message);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
                FormDangNhap fdn = new FormDangNhap();
                fdn.ShowDialog();
            this.Show();
            
        }
    }
}