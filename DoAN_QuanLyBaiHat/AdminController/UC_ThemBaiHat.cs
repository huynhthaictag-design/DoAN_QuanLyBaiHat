using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using DoAN_QuanLyBaiHat.AdminController; // Để dùng DatabaseConnection

namespace DoAN_QuanLyBaiHat.UserControls
{
    public partial class UC_ThemBaiHat : UserControl
    {
        public event EventHandler OnHuy;
        public event EventHandler OnLuuThanhCong;

        private int _flagMode = 0;
        private string _idBaiHat = "";

        public UC_ThemBaiHat()
        {
            InitializeComponent();
        }

        // --- 1. SỬA HÀM NÀY ĐỂ NHẬN ĐỦ 9 THAM SỐ (KHẮC PHỤC LỖI CS1501) ---
        public void SetData(int mode, string id, string ten, string theloai, DateTime ngay, string loi, string duongdan, string album, string casi)
        {
            _flagMode = mode;
            _idBaiHat = id;

            if (mode == 2) // Chế độ Sửa
            {
                label8.Text = "CHỈNH SỬA BÀI HÁT";
                txtTenBaiHat.Text = ten;
                cbbTheLoai.Text = theloai;
                dtpNgayDang.Value = ngay;
                richLoiNhac.Text = loi;
                txtDuongDan.Text = duongdan;

                // Điền thêm 2 cái mới
                txtAlbums.Text = album;
                txtCaSi.Text = casi;

                btnLuu.Text = "Cập Nhật";
            }
            else // Chế độ Thêm
            {
                label8.Text = "THÊM BÀI HÁT";
                XoaTrang();
                btnLuu.Text = "Thêm Mới";
            }
        }

        private void XoaTrang()
        {
            txtTenBaiHat.Clear();
            richLoiNhac.Clear();
            txtDuongDan.Clear();
            // Xóa trắng 2 ô mới
            txtAlbums.Clear();
            txtCaSi.Clear();
            cbbTheLoai.SelectedIndex = -1;
            dtpNgayDang.Value = DateTime.Now;
        }

        private void btnChonNhac_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // Thêm các định dạng nhạc khác cho đầy đủ
            open.Filter = "Music Files|*.mp3;*.wav;*.wma|All Files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = open.FileName;
            }
        }

        // --- NÚT LƯU ĐÃ ĐƯỢC NÂNG CẤP ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (txtTenBaiHat.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên bài hát!");
                txtTenBaiHat.Focus();
                return;
            }

            // 2. XỬ LÝ FILE NHẠC (COPY VÀ TẠO ĐƯỜNG DẪN)
            string duongDanLuuDB = txtDuongDan.Text; // Mặc định lấy giá trị hiện tại trong ô textbox

            try
            {
                // Kiểm tra: Nếu đường dẫn trong TextBox là file từ ổ cứng (C:\...) thì mới thực hiện Copy.
                // Nếu là đường dẫn cũ (MusicData\...) thì bỏ qua bước này.
                if (File.Exists(txtDuongDan.Text) && Path.IsPathRooted(txtDuongDan.Text))
                {
                    // a. Tạo thư mục chứa nhạc nếu chưa có
                    string folderDich = Path.Combine(Application.StartupPath, "MusicData");
                    if (!Directory.Exists(folderDich))
                    {
                        Directory.CreateDirectory(folderDich);
                    }

                    // b. Tạo tên file duy nhất (Tránh trùng lặp)
                    // Ví dụ: 20231127_105012_EmCuaNgayHomQua.mp3
                    string tenFileGoc = Path.GetFileName(txtDuongDan.Text);
                    string tenFileMoi = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + tenFileGoc;

                    // c. Đường dẫn đích để copy file vào
                    string duongDanDich = Path.Combine(folderDich, tenFileMoi);

                    // d. Thực hiện Copy
                    File.Copy(txtDuongDan.Text, duongDanDich, true);

                    // e. Cập nhật chuỗi để lưu vào Database (Lưu đường dẫn tương đối)
                    duongDanLuuDB = "MusicData\\" + tenFileMoi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi copy nhạc: " + ex.Message);
                return; // Dừng lại nếu copy lỗi
            }

            // 3. XỬ LÝ DATABASE
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "";

                    if (_flagMode == 1) // THÊM MỚI
                    {
                        sql = "INSERT INTO BaiHat (Ten_Bai_Hat, The_Loai, Ngay_Dang, Lyrics, DuongDan, Album, CaSi) " +
                              "VALUES (@Ten, @TheLoai, @Ngay, @Loi, @Link, @Album, @CaSi)";
                    }
                    else // SỬA (UPDATE)
                    {
                        sql = "UPDATE BaiHat SET Ten_Bai_Hat=@Ten, The_Loai=@TheLoai, Ngay_Dang=@Ngay, " +
                              "Lyrics=@Loi, DuongDan=@Link, Album=@Album, CaSi=@CaSi WHERE Bai_Hat_Id=@Id";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Gán các tham số
                    cmd.Parameters.AddWithValue("@Ten", txtTenBaiHat.Text.Trim());
                    cmd.Parameters.AddWithValue("@TheLoai", cbbTheLoai.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayDang.Value);
                    cmd.Parameters.AddWithValue("@Loi", richLoiNhac.Text);

                    // Quan trọng: Lưu đường dẫn đã xử lý ở trên
                    cmd.Parameters.AddWithValue("@Link", duongDanLuuDB);

                    cmd.Parameters.AddWithValue("@Album", txtAlbums.Text);
                    cmd.Parameters.AddWithValue("@CaSi", txtCaSi.Text);

                    if (_flagMode == 2) // Nếu là sửa thì cần ID
                    {
                        cmd.Parameters.AddWithValue("@Id", _idBaiHat);
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thao tác thành công!");

                    // Gọi sự kiện để Form cha biết mà load lại dữ liệu
                    OnLuuThanhCong?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message + "\n(Kiểm tra lại xem đã chạy lệnh SQL thêm cột Album/CaSi chưa?)");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            OnHuy?.Invoke(this, EventArgs.Empty);
        }
    }
}