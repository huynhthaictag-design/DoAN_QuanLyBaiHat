using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using DoAN_QuanLyBaiHat.AdminController;

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
            // Tải danh sách ca sĩ ngay khi khởi tạo
            LoadComboBoxCaSi();
        }

        // --- 1. HÀM LOAD DANH SÁCH CA SĨ VÀO COMBOBOX ---
        private void LoadComboBoxCaSi()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Lấy Tên Ca Sĩ để hiển thị
                    string sql = "SELECT TenCS FROM casi";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gán dữ liệu vào ComboBox
                    cbbCaSi.DataSource = dt;
                    cbbCaSi.DisplayMember = "TenCS"; // Hiển thị tên
                    cbbCaSi.ValueMember = "TenCS";   // Giá trị lấy cũng là tên (vì bảng baihat lưu tên)

                    // Mặc định không chọn ai cả
                    cbbCaSi.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ca sĩ: " + ex.Message);
            }
        }

        // --- 2. HÀM NHẬN DỮ LIỆU TỪ FORM CHA ---
        public void SetData(int mode, string id, string ten, string theloai, DateTime ngay, string loi, string duongdan, string album, string casi)
        {
            _flagMode = mode;
            _idBaiHat = id;

            // Đảm bảo load lại danh sách ca sĩ mới nhất mỗi khi mở form
            LoadComboBoxCaSi();

            if (mode == 2) // Chế độ Sửa
            {
                label8.Text = "CHỈNH SỬA BÀI HÁT";
                txtTenBaiHat.Text = ten;
                cbbTheLoai.Text = theloai;
                dtpNgayDang.Value = ngay;
                richLoiNhac.Text = loi;
                txtDuongDan.Text = duongdan;
               

                // Gán giá trị cho ComboBox Ca Sĩ
                cbbCaSi.Text = casi;

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
       
            cbbCaSi.SelectedIndex = -1; // Reset combobox ca sĩ
            cbbTheLoai.SelectedIndex = -1;
            dtpNgayDang.Value = DateTime.Now;
        }

        private void btnChonNhac_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Music Files|*.mp3;*.wav;*.wma|All Files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = open.FileName;
            }
        }

        // --- 3. NÚT LƯU ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (txtTenBaiHat.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên bài hát!");
                txtTenBaiHat.Focus();
                return;
            }

            if (cbbCaSi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn Ca sĩ!");
                cbbCaSi.Focus();
                return;
            }

            // XỬ LÝ FILE NHẠC
            string duongDanLuuDB = txtDuongDan.Text;

            try
            {
                if (File.Exists(txtDuongDan.Text) && Path.IsPathRooted(txtDuongDan.Text))
                {
                    string folderDich = Path.Combine(Application.StartupPath, "MusicData");
                    if (!Directory.Exists(folderDich)) Directory.CreateDirectory(folderDich);

                    string tenFileGoc = Path.GetFileName(txtDuongDan.Text);
                    string tenFileMoi = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + tenFileGoc;
                    string duongDanDich = Path.Combine(folderDich, tenFileMoi);

                    File.Copy(txtDuongDan.Text, duongDanDich, true);
                    duongDanLuuDB = "MusicData\\" + tenFileMoi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi copy nhạc: " + ex.Message);
                return;
            }

            // XỬ LÝ DATABASE
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "";

                    if (_flagMode == 1) // THÊM MỚI
                    {
                        // XÓA chữ "Album" và "@Album" ở dòng này để tránh lỗi khi thêm mới
                        sql = "INSERT INTO BaiHat (Ten_Bai_Hat, The_Loai, Ngay_Dang, Lyrics, DuongDan, CaSi) " +
                              "VALUES (@Ten, @TheLoai, @Ngay, @Loi, @Link, @CaSi)";
                    }
                    else // SỬA (UPDATE) - Đây là phần bạn đang bị lỗi
                    {
                        // XÓA đoạn "Album=@Album," đi
                        // Câu lệnh mới sẽ như sau:
                        sql = "UPDATE BaiHat SET Ten_Bai_Hat=@Ten, The_Loai=@TheLoai, Ngay_Dang=@Ngay, " +
                              "Lyrics=@Loi, DuongDan=@Link, CaSi=@CaSi WHERE Bai_Hat_Id=@Id";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ten", txtTenBaiHat.Text.Trim());
                    cmd.Parameters.AddWithValue("@TheLoai", cbbTheLoai.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayDang.Value);
                    cmd.Parameters.AddWithValue("@Loi", richLoiNhac.Text);
                    cmd.Parameters.AddWithValue("@Link", duongDanLuuDB);
                  

                    // Lấy tên ca sĩ từ ComboBox thay vì TextBox
                    cmd.Parameters.AddWithValue("@CaSi", cbbCaSi.Text);

                    if (_flagMode == 2)
                    {
                        cmd.Parameters.AddWithValue("@Id", _idBaiHat);
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thao tác thành công!");
                    OnLuuThanhCong?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            OnHuy?.Invoke(this, EventArgs.Empty);
        }

        private void UC_ThemBaiHat_Load(object sender, EventArgs e)
        {
            // Có thể gọi LoadComboBoxCaSi() ở đây nếu muốn chắc chắn
        }
    }
}