using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Dùng thư viện MySQL

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1 : Form
    {
        // Khai báo biến toàn cục (Giống mẫu PDF của bạn)
        DataSet ds = new DataSet();
        MySqlDataAdapter daBaiHat;

        // Trạng thái hành động: 1=Thêm, 2=Sửa, 0=Không làm gì
        int flagMode = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // --- 1. HÀM CHUYỂN ĐỔI GIAO DIỆN (QUAN TRỌNG NHẤT) ---
        // true = Hiện khung nhập (ẩn lưới), false = Hiện lưới (ẩn khung nhập)
        void HienKhungNhap(bool hien)
        {
            pnlNhapLieu.Visible = hien;   // Panel nhập liệu
            pnlDanhSach.Visible = !hien;  // Panel danh sách (Ngược lại)

            // Nếu hiện khung nhập thì xóa trắng các ô
            if (hien)
            {
               txtTenBaiHat.Clear();
                richLoiNhac.Clear();
                dtpNgayDang.Value = DateTime.Now;
                txtDuongDan.Clear();
            }
        }

        // --- 2. LOAD FORM VÀ DỮ LIỆU ---
        private void Form1_Load(object sender, EventArgs e)
        {
            HienKhungNhap(false); // Mặc định hiện danh sách
            LoadData();
        }

        void LoadData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Lấy dữ liệu (Giống mẫu PDF)
                    string sql = "SELECT * FROM BaiHat";
                    daBaiHat = new MySqlDataAdapter(sql, conn);

                    // Tự động tạo lệnh Insert/Update/Delete (Thay thế cho đoạn code InsertCommand dài dòng)
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(daBaiHat);

                    ds.Clear();
                    daBaiHat.Fill(ds, "tblBaiHat");
                    dgvBaiHat.DataSource = ds.Tables["tblBaiHat"];
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- 3. CÁC NÚT Ở MÀN HÌNH DANH SÁCH ---

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagMode = 1; // Đánh dấu là đang THÊM
            HienKhungNhap(true); // <--- Ẩn lưới, hiện khung nhập
            txtTenBaiHat.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBaiHat.CurrentRow == null) return;

            flagMode = 2; // Đánh dấu là đang SỬA

            // Đổ dữ liệu cũ lên ô nhập trước khi hiện
            DataGridViewRow row = dgvBaiHat.CurrentRow;
            txtTenBaiHat.Text = row.Cells["Ten_Bai_Hat"].Value.ToString();
            cbbTheLoai.Text = row.Cells["The_Loai"].Value.ToString();
            richLoiNhac.Text = row.Cells["Lyrics"].Value.ToString();
            // ... (các trường khác)

            HienKhungNhap(true); // <--- Ẩn lưới, hiện khung nhập
        }

        // --- 4. CÁC NÚT Ở MÀN HÌNH NHẬP LIỆU (Panel Nhập) ---

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra tên bài hát
            if (txtTenBaiHat.Text == "") { MessageBox.Show("Nhập tên bài hát!"); return; }

            // --- XỬ LÝ COPY NHẠC (PHẦN MỚI) ---
            string tenFileLuuDB = ""; // Biến này để lưu vào CSDL

            try
            {
                // a. Nếu người dùng ĐANG CHỌN file mới (Đường dẫn chứa dấu '\')
                if (txtDuongDan.Text.Contains("\\"))
                {
                    // Tạo thư mục MusicData nếu chưa có
                    string folderPath = System.IO.Path.Combine(Application.StartupPath, "MusicData");
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    // Lấy tên file gốc (ví dụ: "LacTroi.mp3")
                    string sourcePath = txtDuongDan.Text;
                    string fileName = System.IO.Path.GetFileName(sourcePath);

                    // Tạo đường dẫn đích để copy đến
                    string destPath = System.IO.Path.Combine(folderPath, fileName);

                    // COPY FILE (ghi đè nếu trùng tên)
                    System.IO.File.Copy(sourcePath, destPath, true);

                    // Gán tên file để tí nữa lưu vào DB
                    tenFileLuuDB = fileName;
                }
                else
                {
                    // b. Nếu KHÔNG chọn nhạc mới (đang sửa thông tin khác), giữ nguyên tên cũ
                    tenFileLuuDB = txtDuongDan.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi copy nhạc: " + ex.Message);
                return; // Dừng lại nếu copy lỗi
            }

            // --- LƯU VÀO DATABASE (CODE CŨ ĐÃ NÂNG CẤP) ---
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "";

                    if (flagMode == 1) // THÊM
                        sql = "INSERT INTO BaiHat (Ten_Bai_Hat, The_Loai, Ngay_Dang, Lyrics, DuongDan) VALUES (@Ten, @TheLoai, @Ngay, @Loi, @Link)";
                    else // SỬA
                        sql = "UPDATE BaiHat SET Ten_Bai_Hat=@Ten, The_Loai=@TheLoai, Ngay_Dang=@Ngay, Lyrics=@Loi, DuongDan=@Link WHERE Bai_Hat_Id=@Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Gán tham số
                    cmd.Parameters.AddWithValue("@Ten", txtTenBaiHat.Text);
                    cmd.Parameters.AddWithValue("@TheLoai", cbbTheLoai.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayDang.Value);
                    cmd.Parameters.AddWithValue("@Loi", richLoiNhac.Text);

                    // QUAN TRỌNG: Chỉ lưu TÊN FILE ngắn gọn
                    cmd.Parameters.AddWithValue("@Link", tenFileLuuDB);

                    if (flagMode == 2) // Nếu sửa thì cần ID
                        cmd.Parameters.AddWithValue("@Id", dgvBaiHat.CurrentRow.Cells["Bai_Hat_Id"].Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu và đồng bộ nhạc thành công!");

                    // Tải lại dữ liệu
                    LoadData();
                    HienKhungNhap(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.RejectChanges(); // Hủy bỏ thay đổi tạm
            HienKhungNhap(false); // <--- Quay về màn hình danh sách
        }

        // Hàm phụ trợ để gán dữ liệu cho gọn code
        void GanDuLieu(DataRow row)
        {
            row["Ten_Bai_Hat"] = txtTenBaiHat.Text;
            row["The_Loai"] = cbbTheLoai.Text;
            row["Ngay_Dang"] = dtpNgayDang.Value;
            row["Lyrics"] = richLoiNhac.Text;
            row["DuongDan"] = txtDuongDan.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn dòng nào chưa
            if (dgvBaiHat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bài hát cần xóa!");
                return;
            }

            // 2. Hỏi xác nhận người dùng (Tránh xóa nhầm)
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa bài hát này không?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // 3. Xóa dòng đang chọn khỏi DataSet (Bộ nhớ tạm)
                    // Lưu ý: Khi xóa trên DataGridView, nó sẽ đánh dấu dòng đó là Deleted trong DataTable
                    dgvBaiHat.Rows.RemoveAt(dgvBaiHat.CurrentRow.Index);

                    // 4. Cập nhật thay đổi xuống Database thật
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        daBaiHat.SelectCommand.Connection = conn; // Kết nối mới
                        MySqlCommandBuilder builder = new MySqlCommandBuilder(daBaiHat);

                        daBaiHat.Update(ds, "tblBaiHat"); // Thực thi lệnh DELETE trong SQL

                        MessageBox.Show("Xóa thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    // Nếu lỗi, tải lại dữ liệu để hoàn tác thao tác xóa ảo trên lưới
                    ds.RejectChanges();
                }
            }
        }

        private void btnChonNhac_Click(object sender, EventArgs e)
        {
            
            // 1. Khởi tạo hộp thoại mở file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 2. Thiết lập bộ lọc CHỈ LẤY MP3 (Quan trọng)
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            openFileDialog.Title = "Chọn một file nhạc";

            // 3. Hiển thị hộp thoại và kiểm tra nếu người dùng bấm OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 4. Lấy đường dẫn file và gán vào TextBox
                txtDuongDan.Text = openFileDialog.FileName;
            }
        
    }

        private void pnlNhapLieu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvBaiHat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBaiHat.Rows[e.RowIndex];

                // Đổ dữ liệu text lên ô nhập
                txtTenBaiHat.Text = row.Cells["Ten_Bai_Hat"].Value.ToString();
                cbbTheLoai.Text = row.Cells["The_Loai"].Value.ToString();
                richLoiNhac.Text = row.Cells["Lyrics"].Value.ToString();

                if (row.Cells["Ngay_Dang"].Value != DBNull.Value)
                    dtpNgayDang.Value = Convert.ToDateTime(row.Cells["Ngay_Dang"].Value);

                // --- XỬ LÝ ĐƯỜNG DẪN NHẠC ---
                string tenFile = row.Cells["DuongDan"].Value.ToString();

                // Tái tạo đường dẫn đầy đủ
                string fullPath = System.IO.Path.Combine(Application.StartupPath, "MusicData", tenFile);

                // Hiển thị tên file lên textbox (chỉ tên ngắn cho đẹp)
                txtDuongDan.Text = tenFile;

                // Kiểm tra file có tồn tại không rồi mới phát (để tránh lỗi)
                if (System.IO.File.Exists(fullPath))
                {
                    // Code phát nhạc của bạn (Ví dụ dùng Windows Media Player)
                    // axWindowsMediaPlayer1.URL = fullPath;
                }
            
        }
    }

   

        private void txtTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}