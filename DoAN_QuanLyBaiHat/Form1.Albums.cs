// File: Form1.Albums.cs

using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DoAN_QuanLyBaiHat.AdminController;

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1
    {
        private void LoadDataAlbums()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT a.Ab_Id, a.Ten_Ab, c.TenCS, c.Cs_Id, a.Ngay_Dang 
                   FROM albums a 
                   LEFT JOIN casi c ON a.Cs_Id = c.Cs_Id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                 
                    if (dgvAlbums != null)
                    {
                        dgvAlbums.DataSource = null;
                        dgvAlbums.AutoGenerateColumns = true;

                        dgvAlbums.DataSource = dt; 

                    
                        if (dgvAlbums.Columns.Contains("Ab_Id")) dgvAlbums.Columns["Ab_Id"].HeaderText = "Mã Album";
                        if (dgvAlbums.Columns.Contains("Ten_Ab")) dgvAlbums.Columns["Ten_Ab"].HeaderText = "Tên Album";
                        if (dgvAlbums.Columns.Contains("TenCS")) dgvAlbums.Columns["TenCS"].HeaderText = "Ca Sĩ";
                        if (dgvAlbums.Columns.Contains("Ngay_Dang")) dgvAlbums.Columns["Ngay_Dang"].HeaderText = "Ngày Đăng";
                        if (dgvAlbums.Columns.Contains("Cs_Id"))
                        {
                            dgvAlbums.Columns["Cs_Id"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // --- NÚT THÊM ALBUM (Không thay đổi) ---
        private void btnThemAlbums_Click(object sender, EventArgs e)
        {
            UC_ThemAlbums uc = new UC_ThemAlbums();
            uc.Dock = DockStyle.Fill;


            tabAlbum.AutoScroll = true; 
                                        

            uc.Dock = DockStyle.Top; 

            uc.OnLuuThanhCong += (s, args) => {
                DongUserControl(uc);
                LoadDataAlbums();
            };

            uc.OnHuy += (s, args) => { DongUserControl(uc); };

            tabAlbum.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- NÚT XÓA ALBUM ---
        private void btnXoaAlbums_Click(object sender, EventArgs e)
        {
            // --- SỬA Ở ĐÂY: Đổi dgvCaSi thành dgvAlbums ---
            if (dgvAlbums.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn Album cần xóa!", "Thông báo");
                return;
            }

            // Lấy dữ liệu từ dgvAlbums
            string abId = dgvAlbums.CurrentRow.Cells["Ab_Id"].Value.ToString();
            string tenAb = dgvAlbums.CurrentRow.Cells["Ten_Ab"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa Album '{tenAb}'?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        // Gỡ bài hát khỏi album
                        string sqlUpdate = "UPDATE baihat SET ab_Id = NULL, Album = NULL WHERE ab_Id = @AbId";
                        MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn);
                        cmdUpdate.Parameters.AddWithValue("@AbId", abId);
                        cmdUpdate.ExecuteNonQuery();

                        // Xóa Album
                        string sqlDelete = "DELETE FROM albums WHERE Ab_Id = @AbId";
                        MySqlCommand cmdDelete = new MySqlCommand(sqlDelete, conn);
                        cmdDelete.Parameters.AddWithValue("@AbId", abId);
                        cmdDelete.ExecuteNonQuery();
                    }
                    MessageBox.Show("Đã xóa thành công!");
                    LoadDataAlbums();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        

        private void btnSuaAlbums_Click(object sender, EventArgs e)
        {
            if (dgvAlbums.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn Album cần sửa!");
                return;
            }

            // Lấy dữ liệu từ dòng đang chọn
            DataGridViewRow row = dgvAlbums.CurrentRow;
            string id = row.Cells["Ab_Id"].Value.ToString();
            string ten = row.Cells["Ten_Ab"].Value.ToString();

            // Lấy ID ca sĩ (cột ẩn ta vừa thêm ở Bước 1)
            string idCaSi = "";
            if (row.Cells["Cs_Id"].Value != null) idCaSi = row.Cells["Cs_Id"].Value.ToString();

            DateTime ngay = DateTime.Now;
            if (row.Cells["Ngay_Dang"].Value != DBNull.Value)
                ngay = Convert.ToDateTime(row.Cells["Ngay_Dang"].Value);

            // Vì Grid không hiện đường dẫn ảnh, ta tạm truyền chuỗi rỗng 
            // (hoặc bạn phải query lại DB để lấy link ảnh nếu muốn hiện ảnh cũ)
            string anh = "";

            // Gọi UserControl
            UC_ThemAlbums uc = new UC_ThemAlbums();
            tabAlbum.AutoScroll = true; // Bật thanh cuộn
            uc.Dock = DockStyle.Top;

            // Gọi hàm SetData vừa viết: Mode 2 là Sửa
            uc.SetData(2, id, ten, idCaSi, ngay, anh);

            uc.OnLuuThanhCong += (s, args) => {
                DongUserControl(uc);
                LoadDataAlbums();
            };

            uc.OnHuy += (s, args) => { DongUserControl(uc); };

            tabAlbum.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}