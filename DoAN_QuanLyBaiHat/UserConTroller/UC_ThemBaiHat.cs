using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Thư viện MySQL
using System.IO; // Thư viện thao tác File

namespace DoAN_QuanLyBaiHat.UserControls
{
    public partial class UC_ThemBaiHat : UserControl
    {
        // 1. KHAI BÁO SỰ KIỆN (Để giao tiếp với Form Cha)
        public event EventHandler OnHuy;
        public event EventHandler OnLuuThanhCong;

        // Biến lưu trạng thái
        private int _flagMode = 0; // 1: Thêm, 2: Sửa
        private string _idBaiHat = "";

        public UC_ThemBaiHat()
        {
            InitializeComponent();
        }

        // 2. HÀM NHẬN DỮ LIỆU TỪ BÊN NGOÀI (Public Method)
        public void SetData(int mode, string id, string ten, string theloai, DateTime ngay, string loi, string duongdan)
        {
            _flagMode = mode;
            _idBaiHat = id;

            if (mode == 2) // Chế độ Sửa -> Điền dữ liệu cũ
            {
                txtTenBaiHat.Text = ten;
                cbbTheLoai.Text = theloai; // Dùng ComboBox
                dtpNgayDang.Value = ngay;
                richLoiNhac.Text = loi;
                txtDuongDan.Text = duongdan;
            }
            else // Chế độ Thêm -> Xóa trắng
            {
                XoaTrang();
            }
        }

        private void XoaTrang()
        {
            txtTenBaiHat.Clear();
            richLoiNhac.Clear();
            txtDuongDan.Clear();
            cbbTheLoai.SelectedIndex = -1; // Reset ComboBox
            dtpNgayDang.Value = DateTime.Now;
        }

        // 3. NÚT CHỌN NHẠC (Chỉ lấy MP3)
        private void btnChonNhac_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Music (*.mp3)|*.mp3"; // Chỉ lọc file mp3
            openFileDialog.Title = "Chọn file nhạc";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = openFileDialog.FileName;
            }
        }

        // 4. NÚT LƯU (Xử lý Copy nhạc + Lưu Database)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // A. Kiểm tra dữ liệu đầu vào
            if (txtTenBaiHat.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên bài hát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // B. Xử lý Copy nhạc vào thư mục dự án
            string tenFileLuuDB = ""; // Tên file sẽ lưu vào SQL

            try
            {
                // Nếu đường dẫn chứa dấu '\' nghĩa là người dùng vừa chọn file mới từ ổ đĩa
                if (txtDuongDan.Text.Contains("\\"))
                {
                    // Tạo thư mục MusicData nếu chưa có
                    string folderPath = Path.Combine(Application.StartupPath, "MusicData");
                    if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                    // Lấy tên file gốc
                    string sourceFile = txtDuongDan.Text;
                    string fileName = Path.GetFileName(sourceFile);

                    // Tạo đường dẫn đích
                    string destFile = Path.Combine(folderPath, fileName);

                    // Copy file (ghi đè nếu trùng)
                    File.Copy(sourceFile, destFile, true);

                    // Chỉ lấy tên file để lưu
                    tenFileLuuDB = fileName;
                }
                else
                {
                    // Nếu không chọn mới, giữ nguyên tên cũ (khi đang Sửa)
                    tenFileLuuDB = txtDuongDan.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi copy nhạc: " + ex.Message);
                return; // Dừng lại nếu copy lỗi
            }

            // C. Lưu vào Database
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "";

                    if (_flagMode == 1) // Thêm mới
                    {
                        sql = "INSERT INTO BaiHat (Ten_Bai_Hat, The_Loai, Ngay_Dang, Lyrics, DuongDan) VALUES (@Ten, @TheLoai, @Ngay, @Loi, @Link)";
                    }
                    else // Sửa
                    {
                        sql = "UPDATE BaiHat SET Ten_Bai_Hat=@Ten, The_Loai=@TheLoai, Ngay_Dang=@Ngay, Lyrics=@Loi, DuongDan=@Link WHERE Bai_Hat_Id=@Id";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Gán tham số (An toàn, chống SQL Injection)
                    cmd.Parameters.AddWithValue("@Ten", txtTenBaiHat.Text.Trim());
                    cmd.Parameters.AddWithValue("@TheLoai", cbbTheLoai.Text); // Lấy từ ComboBox
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayDang.Value);
                    cmd.Parameters.AddWithValue("@Loi", richLoiNhac.Text);
                    cmd.Parameters.AddWithValue("@Link", tenFileLuuDB); // Lưu tên file ngắn gọn

                    if (_flagMode == 2)
                    {
                        cmd.Parameters.AddWithValue("@Id", _idBaiHat);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thao tác thành công!", "Thông báo");

                    // D. Báo cho Form cha biết để tắt UC đi
                    OnLuuThanhCong?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
            }
        }

        // 5. NÚT QUAY LẠI
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Báo cho Form cha biết để tắt UC đi
            OnHuy?.Invoke(this, EventArgs.Empty);
        }

        // Sự kiện Load (để trống nếu không dùng)
        private void UC_ThemBaiHat_Load(object sender, EventArgs e) { }
    }
}