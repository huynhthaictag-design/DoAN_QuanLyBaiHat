using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat
{
    public partial class UC_BaiHat : UserControl
    {
        // --- 1. CÁC SỰ KIỆN GỬI TÍN HIỆU RA NGOÀI (Cho Form User biết) ---
        public event Action<string> OnPlayMusic;        // Yêu cầu phát nhạc (kèm link)
        public event Action OnStopMusic;                // Yêu cầu Dừng
        public event Action OnRewind10s;                // Yêu cầu Lùi 10s
        public event Action OnFastForward10s;           // Yêu cầu Xả 10s

        // Sự kiện cho Playlist (Gửi ID bài hát)
        public event Action<string> OnAddToPlaylist;
        public event Action<string> OnRemoveFromPlaylist;

        // Biến lưu bài hát đang được chọn (để biết thêm bài nào vào playlist)
        private string _selectedSongId = "";
        private string _selectedSongName = "";

        public UC_BaiHat()
        {
            InitializeComponent();
        }

        private void UC_BaiHat_Load(object sender, EventArgs e)
        {
            // Load bài hát (Giữ nguyên logic của bạn)
            LoadNhacVaoFLP(flpDsBH, "SELECT Bai_Hat_Id, Ten_Bai_Hat, CaSi, DuongDan FROM baihat");
        }

        // --- HÀM TẠO GIAO DIỆN ĐỘNG ---
        private void LoadNhacVaoFLP(FlowLayoutPanel flp, string sql)
        {
            flp.Controls.Clear();
            flp.WrapContents = true; // Dạng lưới
            flp.AutoScroll = true;

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Lấy thêm ID để xử lý Playlist
                            string id = reader["Bai_Hat_Id"].ToString();
                            string tenBai = reader["Ten_Bai_Hat"].ToString();
                            string caSi = reader["CaSi"]?.ToString() ?? "Chưa rõ";
                            string linkNhac = reader["DuongDan"]?.ToString() ?? "";

                            // --- TẠO THẺ BÀI HÁT ---
                            Panel pnlItem = new Panel();
                            pnlItem.Size = new Size(200, 70);
                            pnlItem.BackColor = Color.WhiteSmoke;
                            pnlItem.Cursor = Cursors.Hand;
                            pnlItem.Margin = new Padding(10);

                            // Ảnh
                            PictureBox pbAnh = new PictureBox();
                            pbAnh.Size = new Size(60, 60);
                            pbAnh.Location = new Point(5, 5);
                            pbAnh.BackColor = Color.Teal;
                            pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;

                            Label lblIcon = new Label();
                            lblIcon.Text = "♫";
                            lblIcon.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                            lblIcon.ForeColor = Color.White;
                            lblIcon.BackColor = Color.Transparent;
                            lblIcon.AutoSize = true;
                            lblIcon.Location = new Point(15, 10);
                            pbAnh.Controls.Add(lblIcon);

                            // Tên bài
                            Label lblTen = new Label();
                            lblTen.Text = tenBai;
                            lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            lblTen.Location = new Point(70, 10);
                            lblTen.Size = new Size(125, 25);
                            lblTen.AutoEllipsis = true;

                            // Ca sĩ
                            Label lblCaSi = new Label();
                            lblCaSi.Text = caSi;
                            lblCaSi.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                            lblCaSi.ForeColor = Color.Gray;
                            lblCaSi.Location = new Point(70, 35);
                            lblCaSi.Size = new Size(125, 20);

                            // --- SỰ KIỆN CLICK (QUAN TRỌNG) ---
                            EventHandler SuKienClick = (s, ev) =>
                            {
                                // 1. Lưu lại bài đang chọn
                                _selectedSongId = id;
                                _selectedSongName = tenBai;

                                // 2. Đổi màu để biết đang chọn (Highlight)
                                ResetMauCacThe(flp);
                                pnlItem.BackColor = Color.LightSkyBlue; // Màu xanh nhạt khi chọn

                                // 3. Phát nhạc
                                OnPlayMusic?.Invoke(linkNhac);
                            };

                            pnlItem.Click += SuKienClick;
                            pbAnh.Click += SuKienClick;
                            lblTen.Click += SuKienClick;
                            lblCaSi.Click += SuKienClick;
                            lblIcon.Click += SuKienClick;

                            pnlItem.Controls.Add(lblTen);
                            pnlItem.Controls.Add(lblCaSi);
                            pnlItem.Controls.Add(pbAnh);

                            flp.Controls.Add(pnlItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Hàm phụ trợ: Reset màu nền các thẻ về trắng (để chỉ 1 thẻ được xanh)
        private void ResetMauCacThe(FlowLayoutPanel flp)
        {
            foreach (Control c in flp.Controls)
            {
                if (c is Panel) c.BackColor = Color.WhiteSmoke;
            }
        }

        // =========================================================
        // XỬ LÝ CÁC NÚT BẤM (GỌI EVENT RA NGOÀI)
        // =========================================================

        private void btnDung_Click(object sender, EventArgs e)
        {
            OnStopMusic?.Invoke(); // Gửi lệnh Dừng
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            OnRewind10s?.Invoke(); // Gửi lệnh Lùi 10s
        }

        private void btnXa_Click(object sender, EventArgs e)
        {
            OnFastForward10s?.Invoke(); // Gửi lệnh Xả 10s
        }

        private void btnThemPlayList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSongId))
            {
                MessageBox.Show("Vui lòng bấm chọn một bài hát trước!");
                return;
            }
            // Gửi ID bài hát ra ngoài để Form User xử lý thêm vào DB
            OnAddToPlaylist?.Invoke(_selectedSongId);
        }

        private void btnXoaPlayList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSongId))
            {
                MessageBox.Show("Vui lòng chọn bài hát cần xóa!");
                return;
            }
            OnRemoveFromPlaylist?.Invoke(_selectedSongId);
        }
    }
}