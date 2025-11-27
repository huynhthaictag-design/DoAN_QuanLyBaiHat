using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DoAN_QuanLyBaiHat.UserControls; // Namespace chứa UC_ThemBaiHat

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1
    {
        // --- HÀM TẢI DỮ LIỆU BÀI HÁT ---
        void LoadBaiHat()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM BaiHat";
                    daBaiHat = new MySqlDataAdapter(sql, conn);

                    ds.Clear();
                    daBaiHat.Fill(ds, "tblBaiHat");
                    dgvBaiHat.DataSource = ds.Tables["tblBaiHat"];

                    // Cấu hình cột hiển thị
                    if (dgvBaiHat.Columns.Contains("ab_Id")) dgvBaiHat.Columns["ab_Id"].Visible = false;
                    if (dgvBaiHat.Columns.Contains("Lyrics")) dgvBaiHat.Columns["Lyrics"].Visible = false;
                    if (dgvBaiHat.Columns.Contains("DuongDan")) dgvBaiHat.Columns["DuongDan"].Visible = false;

                    if (dgvBaiHat.Columns.Contains("Bai_Hat_Id")) dgvBaiHat.Columns["Bai_Hat_Id"].HeaderText = "Mã Bài";
                    if (dgvBaiHat.Columns.Contains("Ten_Bai_Hat"))
                    {
                        dgvBaiHat.Columns["Ten_Bai_Hat"].HeaderText = "Tên Bài Hát";
                        dgvBaiHat.Columns["Ten_Bai_Hat"].Width = 200;
                    }
                    if (dgvBaiHat.Columns.Contains("CaSi")) dgvBaiHat.Columns["CaSi"].HeaderText = "Ca Sĩ";
                    if (dgvBaiHat.Columns.Contains("Album")) dgvBaiHat.Columns["Album"].HeaderText = "Album";
                    if (dgvBaiHat.Columns.Contains("The_Loai")) dgvBaiHat.Columns["The_Loai"].HeaderText = "Thể Loại";
                    if (dgvBaiHat.Columns.Contains("Ngay_Dang")) dgvBaiHat.Columns["Ngay_Dang"].HeaderText = "Ngày Đăng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bài hát: " + ex.Message);
            }
        }

        // --- HIỂN THỊ FORM THÊM/SỬA BÀI HÁT ---
        private void HienThiUC_ThemBaiHat(int mode, DataGridViewRow rowData = null)
        {
            UC_ThemBaiHat uc = new UC_ThemBaiHat();

            if (mode == 1) // Thêm
            {
                uc.SetData(1, "", "", "", DateTime.Now, "", "", "", "");
            }
            else if (mode == 2 && rowData != null) // Sửa
            {
                string id = rowData.Cells["Bai_Hat_Id"].Value.ToString();
                string ten = rowData.Cells["Ten_Bai_Hat"].Value.ToString();
                string tl = rowData.Cells["The_Loai"].Value.ToString();
                string loi = rowData.Cells["Lyrics"].Value.ToString();
                string link = rowData.Cells["DuongDan"].Value.ToString();

                string album = "";
                if (dgvBaiHat.Columns.Contains("Album") && rowData.Cells["Album"].Value != DBNull.Value)
                    album = rowData.Cells["Album"].Value.ToString();

                string casi = "";
                if (dgvBaiHat.Columns.Contains("CaSi") && rowData.Cells["CaSi"].Value != DBNull.Value)
                    casi = rowData.Cells["CaSi"].Value.ToString();

                DateTime ngay = DateTime.Now;
                if (rowData.Cells["Ngay_Dang"].Value != DBNull.Value)
                    ngay = Convert.ToDateTime(rowData.Cells["Ngay_Dang"].Value);

                uc.SetData(2, id, ten, tl, ngay, loi, link, album, casi);
            }

            uc.OnHuy += (s, e) => { DongUserControl(uc); };
            uc.OnLuuThanhCong += (s, e) => { DongUserControl(uc); LoadBaiHat(); };

            tabBaiHat.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- CÁC SỰ KIỆN NÚT BẤM BÀI HÁT ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThiUC_ThemBaiHat(1);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBaiHat.CurrentRow != null)
                HienThiUC_ThemBaiHat(2, dgvBaiHat.CurrentRow);
            else
                MessageBox.Show("Vui lòng chọn bài hát cần sửa!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBaiHat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bài hát cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bài hát này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string id = dgvBaiHat.CurrentRow.Cells["Bai_Hat_Id"].Value.ToString();
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM BaiHat WHERE Bai_Hat_Id = @Id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadBaiHat();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ds == null || ds.Tables["tblBaiHat"] == null) return;
                DataTable dt = ds.Tables["tblBaiHat"];
                string keyword = txtTimKiem.Text.Trim().Replace("'", "''");

                if (string.IsNullOrEmpty(keyword))
                    dt.DefaultView.RowFilter = "";
                else
                    dt.DefaultView.RowFilter = string.Format("Ten_Bai_Hat LIKE '%{0}%' OR CaSi LIKE '%{0}%'", keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}