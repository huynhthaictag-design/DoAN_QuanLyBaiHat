using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat.UserConTroller
{
    // 1. Sửa tên class thành UC_Albums cho trùng với tên file
    public partial class UC_Albums : UserControl
    {
        // 2. Sửa Constructor thành UC_Albums
        public UC_Albums()
        {
            InitializeComponent();
        }

        private void UC_Albums_Load(object sender, EventArgs e)
        {
            // Load danh sách Album (đảm bảo bạn đã có flpDsAlbum bên Designer)
            LoadAlbumVaoFLP(flpDsAlbum, "SELECT Ten_Ab, AnhAlbum FROM albums");
        }

        // --- HÀM TẠO GIAO DIỆN ALBUM ---
        private void LoadAlbumVaoFLP(FlowLayoutPanel flp, string sql)
        {
            if (flp == null) return; // Kiểm tra an toàn

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
                            string tenAlbum = reader["Ten_Ab"].ToString();
                            string anhAlbum = reader["AnhAlbum"]?.ToString() ?? "";

                            // --- TẠO THẺ ALBUM ---
                            Panel pnlAlbum = new Panel();
                            pnlAlbum.Size = new Size(160, 200);
                            pnlAlbum.BackColor = Color.White;
                            pnlAlbum.Cursor = Cursors.Hand;
                            pnlAlbum.Margin = new Padding(15);

                            // Ảnh
                            PictureBox pbAnh = new PictureBox();
                            pbAnh.Size = new Size(140, 140);
                            pbAnh.Location = new Point(10, 10);
                            pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                            pbAnh.BackColor = Color.Orange;

                            if (!string.IsNullOrEmpty(anhAlbum))
                            {
                                string fullPath = Path.Combine(Application.StartupPath, anhAlbum);
                                if (File.Exists(fullPath)) pbAnh.ImageLocation = fullPath;
                            }

                            // Tên
                            Label lblTen = new Label();
                            lblTen.Text = tenAlbum;
                            lblTen.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                            lblTen.Location = new Point(5, 155);
                            lblTen.Size = new Size(150, 40);
                            lblTen.TextAlign = ContentAlignment.TopCenter;

                            // Sự kiện Click
                            EventHandler clickEvent = (s, ev) => MessageBox.Show("Album: " + tenAlbum);
                            pnlAlbum.Click += clickEvent;
                            pbAnh.Click += clickEvent;
                            lblTen.Click += clickEvent;

                            pnlAlbum.Controls.Add(pbAnh);
                            pnlAlbum.Controls.Add(lblTen);
                            flp.Controls.Add(pnlAlbum);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Album: " + ex.Message);
            }
        }
    }
}