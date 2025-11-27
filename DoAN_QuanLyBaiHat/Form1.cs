using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DoAN_QuanLyBaiHat.UserControls;
using DoAN_QuanLyBaiHat.AdminController;

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
            LoadData();
        }

        // --- HÀM TẢI DỮ LIỆU ---
        void LoadData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Vẫn lấy SELECT * để có đủ dữ liệu cho nút Sửa
                    string sql = "SELECT * FROM BaiHat";
                    daBaiHat = new MySqlDataAdapter(sql, conn);

                    ds.Clear();
                    daBaiHat.Fill(ds, "tblBaiHat");
                    dgvBaiHat.DataSource = ds.Tables["tblBaiHat"];

                    // --- CẤU HÌNH CỘT HIỂN THỊ ---

                    // 1. Ẩn các cột không muốn hiện
                    if (dgvBaiHat.Columns.Contains("ab_Id"))
                        dgvBaiHat.Columns["ab_Id"].Visible = false;

                    if (dgvBaiHat.Columns.Contains("Lyrics"))
                        dgvBaiHat.Columns["Lyrics"].Visible = false;

                    if (dgvBaiHat.Columns.Contains("DuongDan"))
                        dgvBaiHat.Columns["DuongDan"].Visible = false;

                    // 2. Đặt tên tiếng Việt cho đẹp
                    if (dgvBaiHat.Columns.Contains("Bai_Hat_Id"))
                        dgvBaiHat.Columns["Bai_Hat_Id"].HeaderText = "Mã Bài";

                    if (dgvBaiHat.Columns.Contains("Ten_Bai_Hat"))
                    {
                        dgvBaiHat.Columns["Ten_Bai_Hat"].HeaderText = "Tên Bài Hát";
                        dgvBaiHat.Columns["Ten_Bai_Hat"].Width = 200; // Chỉnh độ rộng
                    }

                    // 3. Cột CA SĨ (Mới thêm vào)
                    // Lưu ý: Trong Database MySQL bảng BaiHat PHẢI có cột tên là 'CaSi'
                    if (dgvBaiHat.Columns.Contains("CaSi"))
                    {
                        dgvBaiHat.Columns["CaSi"].Visible = true;
                        dgvBaiHat.Columns["CaSi"].HeaderText = "Ca Sĩ";
                    }

                    if (dgvBaiHat.Columns.Contains("Album"))
                    {
                        dgvBaiHat.Columns["Album"].HeaderText = "Album";
                    }

                    if (dgvBaiHat.Columns.Contains("The_Loai"))
                        dgvBaiHat.Columns["The_Loai"].HeaderText = "Thể Loại";

                    if (dgvBaiHat.Columns.Contains("Ngay_Dang"))
                        dgvBaiHat.Columns["Ngay_Dang"].HeaderText = "Ngày Đăng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- HÀM HIỂN THỊ USER CONTROL ---
        private void HienThiUC_ThemBaiHat(int mode, DataGridViewRow rowData = null)
        {

            UC_ThemBaiHat uc = new UC_ThemBaiHat();


            // --- TRUYỀN DỮ LIỆU ---
            if (mode == 1) // Thêm
            {
                // Truyền chuỗi rỗng cho các tham số mới (album, casi)
                uc.SetData(1, "", "", "", DateTime.Now, "", "", "", "");
            }
            else if (mode == 2 && rowData != null) // Sửa
            {
                // Lấy dữ liệu an toàn (tránh lỗi null)
                string id = rowData.Cells["Bai_Hat_Id"].Value.ToString();
                string ten = rowData.Cells["Ten_Bai_Hat"].Value.ToString();
                string tl = rowData.Cells["The_Loai"].Value.ToString();
                string loi = rowData.Cells["Lyrics"].Value.ToString();
                string link = rowData.Cells["DuongDan"].Value.ToString();

                // Lấy Album và Ca sĩ (Kiểm tra xem cột có tồn tại không để tránh lỗi)
                string album = "";
                if (dgvBaiHat.Columns.Contains("Album") && rowData.Cells["Album"].Value != DBNull.Value)
                    album = rowData.Cells["Album"].Value.ToString();

                string casi = "";
                if (dgvBaiHat.Columns.Contains("CaSi") && rowData.Cells["CaSi"].Value != DBNull.Value)
                    casi = rowData.Cells["CaSi"].Value.ToString();

                DateTime ngay = DateTime.Now;
                if (rowData.Cells["Ngay_Dang"].Value != DBNull.Value)
                    ngay = Convert.ToDateTime(rowData.Cells["Ngay_Dang"].Value);

                // Truyền đủ 9 tham số sang UC
                uc.SetData(2, id, ten, tl, ngay, loi, link, album, casi);
            }

            // --- (Phần sự kiện OnHuy, OnLuuThanhCong giữ nguyên như cũ) ---
            uc.OnHuy += (s, e) => { DongUserControl(uc); };
            uc.OnLuuThanhCong += (s, e) => { DongUserControl(uc); LoadData(); };

            tabBaiHat.Controls.Add(uc);
            uc.BringToFront();
        }
        // --- HÀM HỖ TRỢ ĐÓNG UC (CHO GỌN CODE) ---
        private void DongUserControl(UserControl uc)
        {
            tabBaiHat.Controls.Remove(uc); // Gỡ khỏi giao diện
            uc.Dispose();                  // Giải phóng bộ nhớ
        }

        // --- CÁC NÚT BẤM ---

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

        // --- XỬ LÝ XÓA (NÊN DÙNG SQL TRỰC TIẾP) ---
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
                    // Lấy ID cần xóa
                    string id = dgvBaiHat.CurrentRow.Cells["Bai_Hat_Id"].Value.ToString();

                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM BaiHat WHERE Bai_Hat_Id = @Id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Load lại data
                    LoadData();
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
                // 1. Kiểm tra xem DataSet và Bảng dữ liệu có tồn tại không
                if (ds == null || ds.Tables["tblBaiHat"] == null) return;

                // 2. Lấy dữ liệu từ bảng đang hiển thị
                DataTable dt = ds.Tables["tblBaiHat"];

                // 3. Lấy từ khóa người dùng nhập và xử lý ký tự đặc biệt (')
                // Ký tự ' có thể gây lỗi cú pháp SQL/Filter nên cần thay bằng ''
                string keyword = txtTimKiem.Text.Trim().Replace("'", "''");

                // 4. Thực hiện lọc dữ liệu (RowFilter)
                if (string.IsNullOrEmpty(keyword))
                {
                    // Nếu ô tìm kiếm rỗng, xóa bộ lọc để hiện tất cả
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    // Lọc theo Tên Bài Hát HOẶC Tên Ca Sĩ
                    // Cú pháp: TênCột LIKE '%tukhoa%'
                    string filter = string.Format("Ten_Bai_Hat LIKE '%{0}%' OR CaSi LIKE '%{0}%'", keyword);

                    // Nếu bạn muốn tìm cả Thể loại thì thêm đoạn này vào filter trên:
                    // OR The_Loai LIKE '%{0}%'

                    dt.DefaultView.RowFilter = filter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnThemAlbums_Click(object sender, EventArgs e)
        {
            // Tương tự, bạn có thể áp dụng cách làm trên cho UC Albums
            UC_ThemAlbums uc = new UC_ThemAlbums();
            uc.Dock = DockStyle.Fill;
            tabAlbums.Controls.Add(uc);
            uc.BringToFront();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}