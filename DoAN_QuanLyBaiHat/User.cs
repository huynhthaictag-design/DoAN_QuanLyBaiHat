using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using DoAN_QuanLyBaiHat.UserConTroller;

// QUAN TRỌNG: Thêm thư viện này
using WMPLib;

namespace DoAN_QuanLyBaiHat
{
    public partial class User : Form
    {
        // 1. KHAI BÁO TRÌNH PHÁT NHẠC TẠI ĐÂY
        // (Tự tạo bằng code, không cần kéo thả Designer)
        private WindowsMediaPlayer soundPlayer;

        public User()
        {
            InitializeComponent();

            // 2. KHỞI TẠO NÓ TRONG CONSTRUCTOR
            soundPlayer = new WindowsMediaPlayer();
            // Tắt chế độ tự phát (để an toàn)
            soundPlayer.settings.autoStart = false;
        }

        private void User_Load(object sender, EventArgs e)
        {
            btnBaiHat_Click(null, null);
        }

        private void HienThiGiaoDien(UserControl uc)
        {
            if (pnlBody == null) return;
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(uc);
            uc.BringToFront();
        }

        // ====================================================================
        // MENU BÊN TRÁI
        // ====================================================================

        private void btnBaiHat_Click(object sender, EventArgs e)
        {
            UC_BaiHat uc = new UC_BaiHat();

            // Kết nối sự kiện
            uc.OnPlayMusic += PhatNhac;

            uc.OnStopMusic += () =>
            {
                if (soundPlayer != null)
                {
                    // Kiểm tra trạng thái: 3 là Playing (Đang phát)
                    if (soundPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        // Nếu đang hát thì Tạm Dừng
                        soundPlayer.controls.pause();
                    }
                    else
                    {
                        // Nếu đang dừng thì Hát Tiếp
                        soundPlayer.controls.play();
                    }
                }
            };

            // Tua Nhạc
            uc.OnRewind10s += TuaLai;
            uc.OnFastForward10s += TuaNhanh;

            // Playlist
            uc.OnAddToPlaylist += ThemVaoPlaylist;
            uc.OnRemoveFromPlaylist += XoaKhoiPlaylist;

            HienThiGiaoDien(uc);
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            UC_Albums uc = new UC_Albums();
            HienThiGiaoDien(uc);
        }

        private void btnCaSi_Click(object sender, EventArgs e)
        {
            UC_CaSi uc = new UC_CaSi();
            HienThiGiaoDien(uc);
        }

        private void btnPlayList_Click(object sender, EventArgs e)
        {
            UC_Playlist uc = new UC_Playlist();
            HienThiGiaoDien(uc);
        }

        // ====================================================================
        // XỬ LÝ LOGIC NHẠC (SỬA LẠI DÙNG BIẾN soundPlayer)
        // ====================================================================

        // --- 1. PHÁT NHẠC ---
        private void PhatNhac(string duongDanDB)
        {
            if (string.IsNullOrEmpty(duongDanDB)) return;

            string fullPath = Path.Combine(Application.StartupPath, duongDanDB);

            if (File.Exists(fullPath))
            {
                try
                {
                    // Code mới dùng soundPlayer
                    soundPlayer.URL = fullPath;
                    soundPlayer.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi loa: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại: " + fullPath);
            }
        }

        // --- 2. TUA NHẠC ---
        private void TuaNhanh()
        {
            // Kiểm tra trạng thái đang phát (playing = 3)
            if (soundPlayer != null && soundPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                soundPlayer.controls.currentPosition += 10;
            }
        }

        private void TuaLai()
        {
            if (soundPlayer != null && soundPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                soundPlayer.controls.currentPosition -= 10;
            }
        }

        // --- 3. DATABASE PLAYLIST (Giữ nguyên không đổi) ---
        private void ThemVaoPlaylist(string songId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    int playlistId = GetOrCreatePlaylistId(conn, 1);

                    string checkSql = "SELECT COUNT(*) FROM playlistsong WHERE playlist_id = @PlId AND song_id = @SongId";
                    MySqlCommand cmdCheck = new MySqlCommand(checkSql, conn);
                    cmdCheck.Parameters.AddWithValue("@PlId", playlistId);
                    cmdCheck.Parameters.AddWithValue("@SongId", songId);

                    if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Đã có trong Playlist!");
                        return;
                    }

                    string sql = "INSERT INTO playlistsong (playlist_id, song_id) VALUES (@PlId, @SongId)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PlId", playlistId);
                    cmd.Parameters.AddWithValue("@SongId", songId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void XoaKhoiPlaylist(string songId)
        {
            if (MessageBox.Show("Xóa bài này khỏi Playlist?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    int playlistId = GetOrCreatePlaylistId(conn, 1);

                    string sql = "DELETE FROM playlistsong WHERE playlist_id = @PlId AND song_id = @SongId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PlId", playlistId);
                    cmd.Parameters.AddWithValue("@SongId", songId);

                    if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Đã xóa!");
                    else MessageBox.Show("Không có trong Playlist.");
                }
            }
            catch { }
        }

        private int GetOrCreatePlaylistId(MySqlConnection conn, int userId)
        {
            string getPlSql = "SELECT Pl_Id FROM playlist WHERE user_id = @UserId LIMIT 1";
            MySqlCommand cmdGet = new MySqlCommand(getPlSql, conn);
            cmdGet.Parameters.AddWithValue("@UserId", userId);
            object result = cmdGet.ExecuteScalar();

            if (result != null) return Convert.ToInt32(result);
            else
            {
                string createSql = "INSERT INTO playlist (Ten_Pl, user_id) VALUES ('My Playlist', @UserId); SELECT LAST_INSERT_ID();";
                MySqlCommand cmdCreate = new MySqlCommand(createSql, conn);
                cmdCreate.Parameters.AddWithValue("@UserId", userId);
                return Convert.ToInt32(cmdCreate.ExecuteScalar());
            }
        }

        // Nút Stop chung
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (soundPlayer != null) soundPlayer.controls.stop();
        }
    }
}