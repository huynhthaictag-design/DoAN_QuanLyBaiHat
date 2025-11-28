using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DoAN_QuanLyBaiHat.AdminController;

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1
    {
        // --- HÀM TẢI DANH SÁCH CA SĨ (ĐÃ FIX LỖI CRASH GIAO DIỆN) ---
        void LoadDataCaSi()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Lấy dữ liệu từ CSDL
                    string sql = "SELECT Cs_Id, TenCS, GioiTinh, Mota, Image FROM casi";
                    MySqlDataAdapter daCaSi = new MySqlDataAdapter(sql, conn);

                    // Chuẩn bị DataSet
                    if (ds == null) ds = new DataSet();
                    if (ds.Tables.Contains("tblCaSi")) ds.Tables["tblCaSi"].Clear();

                    // Đổ dữ liệu
                    daCaSi.Fill(ds, "tblCaSi");

                    // Gán dữ liệu vào lưới
                    dgvCaSi.DataSource = null; // Reset để tránh lỗi
                    dgvCaSi.DataSource = ds.Tables["tblCaSi"];

                    // --- PHẦN TRANG TRÍ GIAO DIỆN (Được bọc Try-Catch riêng) ---
                    // Mục đích: Nếu Tab đang ẩn mà chỉnh Width bị lỗi thì bỏ qua, không làm crash app
                    try
                    {
                        if (dgvCaSi.Columns.Count > 0)
                        {
                            if (dgvCaSi.Columns.Contains("Cs_Id"))
                            {
                                dgvCaSi.Columns["Cs_Id"].HeaderText = "Mã CS";
                                dgvCaSi.Columns["Cs_Id"].Width = 80;
                            }
                            if (dgvCaSi.Columns.Contains("TenCS"))
                            {
                                dgvCaSi.Columns["TenCS"].HeaderText = "Tên Ca Sĩ";
                                dgvCaSi.Columns["TenCS"].Width = 200;
                                dgvCaSi.Columns["TenCS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                            if (dgvCaSi.Columns.Contains("GioiTinh"))
                            {
                                dgvCaSi.Columns["GioiTinh"].HeaderText = "Giới Tính";
                                dgvCaSi.Columns["GioiTinh"].Width = 100;
                            }
                            if (dgvCaSi.Columns.Contains("Mota"))
                            {
                                dgvCaSi.Columns["Mota"].HeaderText = "Thông Tin / Mô Tả";
                            }
                            if (dgvCaSi.Columns.Contains("Image"))
                            {
                                dgvCaSi.Columns["Image"].Visible = false;
                            }
                        }
                    }
                    catch
                    {
                        // Nếu lỗi chỉnh giao diện thì bỏ qua, miễn là có dữ liệu hiện lên là được
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ca sĩ: " + ex.Message);
            }
        }

        // --- CÁC HÀM SỰ KIỆN GIỮ NGUYÊN ---
        private void HienThiUC_ThemCaSi(int mode, DataGridViewRow rowData = null)
        {
            UC_ThemCaSi ucCs = new UC_ThemCaSi();
            ucCs.Dock = DockStyle.Fill;

            if (mode == 1) // THÊM
            {
                ucCs.SetData(1, "", "", "", "", "");
            }
            else if (mode == 2 && rowData != null) // SỬA
            {
                // Sử dụng ?.ToString() để tránh lỗi null
                string id = rowData.Cells["Cs_Id"].Value?.ToString() ?? "";
                string ten = rowData.Cells["TenCS"].Value?.ToString() ?? "";

                string gioitinh = "";
                if (dgvCaSi.Columns.Contains("GioiTinh") && rowData.Cells["GioiTinh"].Value != DBNull.Value)
                    gioitinh = rowData.Cells["GioiTinh"].Value?.ToString();

                string mota = "";
                if (dgvCaSi.Columns.Contains("Mota") && rowData.Cells["Mota"].Value != DBNull.Value)
                    mota = rowData.Cells["Mota"].Value?.ToString();

                string hinhanh = "";
                if (dgvCaSi.Columns.Contains("Image") && rowData.Cells["Image"].Value != DBNull.Value)
                    hinhanh = rowData.Cells["Image"].Value?.ToString();

                ucCs.SetData(2, id, ten, gioitinh, mota, hinhanh);
            }

            ucCs.OnLuuThanhCong += (s, e) => {
                if (tabCaSi.Controls.Contains(ucCs)) tabCaSi.Controls.Remove(ucCs);
                LoadDataCaSi();
            };

            tabCaSi.Controls.Add(ucCs);
            ucCs.BringToFront();
        }

        private void btnThemCaSi_Click(object sender, EventArgs e) => HienThiUC_ThemCaSi(1);

        private void btnSuaCaSi_Click(object sender, EventArgs e)
        {
            if (dgvCaSi.CurrentRow != null) HienThiUC_ThemCaSi(2, dgvCaSi.CurrentRow);
            else MessageBox.Show("Vui lòng chọn ca sĩ để sửa!");
        }

        private void btnXoaCaSi_Click(object sender, EventArgs e)
        {
            if (dgvCaSi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca sĩ cần xóa!");
                return;
            }

            // Lấy ID và Tên để xử lý
            string id = dgvCaSi.CurrentRow.Cells["Cs_Id"].Value.ToString();
            string tenCS = dgvCaSi.CurrentRow.Cells["TenCS"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa ca sĩ '{tenCS}'?\n\nLƯU Ý: Tất cả Album của ca sĩ này cũng sẽ bị xóa!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        MySqlTransaction tran = conn.BeginTransaction(); // Dùng transaction để an toàn

                        try
                        {
                            // BƯỚC 1: Xóa (hoặc set NULL) các Album thuộc về Ca sĩ này
                            // (Vì bảng albums có cột Cs_Id là khóa ngoại)
                            string sqlDeleteAlbum = "DELETE FROM albums WHERE Cs_Id = @Id";
                            MySqlCommand cmdAlbum = new MySqlCommand(sqlDeleteAlbum, conn, tran);
                            cmdAlbum.Parameters.AddWithValue("@Id", id);
                            cmdAlbum.ExecuteNonQuery();

                            // BƯỚC 2: Cập nhật Bài hát (Nếu bài hát lưu Tên ca sĩ dạng text)
                            // Nếu bảng BaiHat lưu Cs_Id thì dùng ID, nếu lưu TenCS thì dùng tên
                            string sqlUpdateBaiHat = "UPDATE baihat SET CaSi = NULL WHERE CaSi = @TenCS";
                            MySqlCommand cmdBaiHat = new MySqlCommand(sqlUpdateBaiHat, conn, tran);
                            cmdBaiHat.Parameters.AddWithValue("@TenCS", tenCS);
                            cmdBaiHat.ExecuteNonQuery();

                            // BƯỚC 3: Xóa Ca sĩ
                            string sqlDeleteCaSi = "DELETE FROM casi WHERE Cs_Id = @Id";
                            MySqlCommand cmdCaSi = new MySqlCommand(sqlDeleteCaSi, conn, tran);
                            cmdCaSi.Parameters.AddWithValue("@Id", id);
                            cmdCaSi.ExecuteNonQuery();

                            tran.Commit(); // Chốt giao dịch

                            MessageBox.Show("Xóa thành công!");
                            LoadDataCaSi(); // Tải lại danh sách
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback(); // Nếu lỗi thì hoàn tác
                            MessageBox.Show("Lỗi Database: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }
    }
}