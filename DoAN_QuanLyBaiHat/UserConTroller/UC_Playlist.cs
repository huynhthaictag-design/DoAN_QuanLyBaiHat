using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat.UserConTroller
{
    public partial class UC_Playlist : UserControl
    {
        public UC_Playlist()
        {
            InitializeComponent();
        }

        private void UC_Playlist_Load(object sender, EventArgs e)
        {
            // Load danh sách Playlist của User (Giả sử User ID = 1)
            // Nếu muốn chính xác theo User đăng nhập, bạn cần truyền ID User vào đây
            LoadPlaylistVaoFLP(flpDsPlaylist, "SELECT Pl_Id, Ten_Pl FROM playlist WHERE user_id = 1");
        }

        // --- HÀM TẠO GIAO DIỆN PLAYLIST ĐỘNG ---
        private void LoadPlaylistVaoFLP(FlowLayoutPanel flp, string sql)
        {
            if (flp == null) return;

            flp.Controls.Clear();
            flp.WrapContents = true; // Dạng lưới
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.LeftToRight;

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Kiểm tra nếu không có dữ liệu
                        if (!reader.HasRows)
                        {
                            Label lblTrong = new Label();
                            lblTrong.Text = "Bạn chưa có Playlist nào.\nHãy vào mục Bài Hát để thêm nhé!";
                            lblTrong.AutoSize = true;
                            lblTrong.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                            lblTrong.ForeColor = Color.Gray;
                            lblTrong.Padding = new Padding(20);
                            flp.Controls.Add(lblTrong);
                            return;
                        }

                        while (reader.Read())
                        {
                            string idPlaylist = reader["Pl_Id"].ToString();
                            string tenPlaylist = reader["Ten_Pl"].ToString();

                            // --- TẠO CARD PLAYLIST ---

                            // 1. Panel bao ngoài
                            Panel pnlPl = new Panel();
                            pnlPl.Size = new Size(160, 200);
                            pnlPl.BackColor = Color.White;
                            pnlPl.Cursor = Cursors.Hand;
                            pnlPl.Margin = new Padding(15);

                            // 2. Hình ảnh (Icon tự vẽ)
                            PictureBox pbAnh = new PictureBox();
                            pbAnh.Size = new Size(140, 140);
                            pbAnh.Location = new Point(10, 10);
                            pbAnh.BackColor = Color.RoyalBlue; // Màu xanh hoàng gia
                            pbAnh.SizeMode = PictureBoxSizeMode.CenterImage;

                            // Vẽ chữ cái đầu của tên Playlist lên ảnh
                            Label lblIcon = new Label();
                            string kyTuDau = tenPlaylist.Length > 0 ? tenPlaylist.Substring(0, 1).ToUpper() : "P";
                            lblIcon.Text = kyTuDau;
                            lblIcon.Font = new Font("Segoe UI", 50, FontStyle.Bold);
                            lblIcon.ForeColor = Color.White;
                            lblIcon.AutoSize = true;
                            lblIcon.BackColor = Color.Transparent;
                            // Căn giữa tương đối
                            lblIcon.Location = new Point(35, 25);
                            pbAnh.Controls.Add(lblIcon);

                            // 3. Tên Playlist
                            Label lblTen = new Label();
                            lblTen.Text = tenPlaylist;
                            lblTen.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                            lblTen.ForeColor = Color.MidnightBlue;
                            lblTen.Location = new Point(5, 155);
                            lblTen.Size = new Size(150, 40);
                            lblTen.TextAlign = ContentAlignment.TopCenter;
                            lblTen.AutoEllipsis = true;

                            // 4. Sự kiện Click
                            EventHandler SuKienClick = (s, ev) =>
                            {
                                MessageBox.Show("Đang mở Playlist: " + tenPlaylist + "\n(ID: " + idPlaylist + ")");
                                // TODO: Sau này bạn có thể code mở danh sách bài hát chi tiết tại đây
                            };

                            pnlPl.Click += SuKienClick;
                            pbAnh.Click += SuKienClick;
                            lblTen.Click += SuKienClick;
                            lblIcon.Click += SuKienClick;

                            pnlPl.Controls.Add(pbAnh);
                            pnlPl.Controls.Add(lblTen);

                            flp.Controls.Add(pnlPl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Playlist: " + ex.Message);
            }
        }
    }
}