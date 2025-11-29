using System;
using System.IO;
using System.Windows.Forms;
using DoAN_QuanLyBaiHat.UserConTroller;
using WMPLib; // <--- QUAN TRỌNG: Phải có dòng này thì mới dùng được Media Player

namespace DoAN_QuanLyBaiHat
{
    public partial class User : Form
    {
        // Tạo máy phát nhạc
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public User()
        {
            InitializeComponent();
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- NÚT BÀI HÁT ---
        private void btnBaiHat_Click(object sender, EventArgs e)
        {
            UC_BaiHat uC_BaiHat = new UC_BaiHat();

            // Đăng ký sự kiện: Khi UC_BaiHat bắn tín hiệu -> Chạy hàm PhatNhac
            uC_BaiHat.OnPlayMusic += PhatNhac;

            AddUserControl(uC_BaiHat);
        }

        // --- HÀM XỬ LÝ PHÁT NHẠC ---
        private void PhatNhac(string linkNhac)
        {
            try
            {
                // 1. Tạo đường dẫn đầy đủ
                // Nếu trong DB lưu "MusicData\baihat.mp3" -> Cần ghép với thư mục chạy
                string fullPath = Path.Combine(Application.StartupPath, linkNhac);

                // 2. DEBUG: Hiện thông báo để xem đường dẫn có đúng không (Sau khi chạy ngon thì xóa dòng này đi)
                // MessageBox.Show("Đang tìm file tại: " + fullPath);

                // 3. Kiểm tra file có tồn tại không
                if (File.Exists(fullPath))
                {
                    player.URL = fullPath; // Nạp file
                    player.controls.play(); // Phát nhạc
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy file nhạc!\nĐường dẫn: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Media Player: " + ex.Message);
            }
        }

        // --- CÁC NÚT KHÁC (GIỮ NGUYÊN) ---
        private void btnCaSi_Click(object sender, EventArgs e)
        {
            UC_CaSi uC_CaSi = new UC_CaSi();
            AddUserControl(uC_CaSi);
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            UC_Albums uC_Albums = new UC_Albums();
            AddUserControl(uC_Albums);
        }

        private void btnPlayList_Click(object sender, EventArgs e)
        {
        }

        private void User_Load(object sender, EventArgs e)
        {
        }
    }
}