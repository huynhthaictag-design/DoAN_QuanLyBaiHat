using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat.UserConTroller
{
    public partial class UC_CaSi : UserControl
    {
        public UC_CaSi()
        {
            InitializeComponent();
        }

        private void UC_CaSi_Load(object sender, EventArgs e)
        {
            // Load danh sách ca sĩ khi mở lên
            // Lưu ý: Tôi đã đổi tên FLP trong Designer thành 'flpDsCaSi' cho đúng nghĩa
            LoadCaSiVaoFLP(flpDsCaSi, "SELECT Cs_Id, TenCS, Image FROM casi");
        }

        // --- HÀM TẠO GIAO DIỆN CA SĨ ĐỘNG ---
        private void LoadCaSiVaoFLP(FlowLayoutPanel flp, string sql)
        {
            if (flp == null) return;

            flp.Controls.Clear();
            flp.WrapContents = true; // Dạng lưới (tự xuống dòng)
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
                        while (reader.Read())
                        {
                            string tenCaSi = reader["TenCS"].ToString();
                            string anhCaSi = reader["Image"]?.ToString() ?? "";
                            // Bạn có thể lấy thêm ID nếu muốn làm chức năng click chi tiết
                            // int idCaSi = Convert.ToInt32(reader["Cs_Id"]); 

                            // --- TẠO THẺ CA SĨ (CARD) ---

                            // 1. Panel bao ngoài
                            Panel pnlCaSi = new Panel();
                            pnlCaSi.Size = new Size(140, 180); // Nhỏ hơn Album một chút
                            pnlCaSi.BackColor = Color.White;
                            pnlCaSi.Cursor = Cursors.Hand;
                            pnlCaSi.Margin = new Padding(15);

                            // 2. Hình ảnh (Cố gắng giả lập khung ảnh dọc hoặc vuông)
                            PictureBox pbAnh = new PictureBox();
                            pbAnh.Size = new Size(120, 120);
                            pbAnh.Location = new Point(10, 10);
                            pbAnh.SizeMode = PictureBoxSizeMode.Zoom; // Zoom để thấy trọn mặt
                            pbAnh.BackColor = Color.LightPink; // Màu nền mặc định cho Ca sĩ

                            if (!string.IsNullOrEmpty(anhCaSi))
                            {
                                string fullPath = Path.Combine(Application.StartupPath, anhCaSi);
                                if (File.Exists(fullPath)) pbAnh.ImageLocation = fullPath;
                            }

                            // 3. Tên Ca Sĩ
                            Label lblTen = new Label();
                            lblTen.Text = tenCaSi;
                            lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            lblTen.ForeColor = Color.DarkSlateBlue;
                            lblTen.Location = new Point(5, 135);
                            lblTen.Size = new Size(130, 40);
                            lblTen.TextAlign = ContentAlignment.TopCenter;
                            lblTen.AutoEllipsis = true;

                            // 4. Sự kiện Click
                            EventHandler SuKienClick = (s, ev) =>
                            {
                                MessageBox.Show("Ca sĩ: " + tenCaSi);
                                // Tại đây bạn có thể gọi FrmChiTietCaSi nếu muốn
                            };

                            pnlCaSi.Click += SuKienClick;
                            pbAnh.Click += SuKienClick;
                            lblTen.Click += SuKienClick;

                            // 5. Add vào FLP
                            pnlCaSi.Controls.Add(pbAnh);
                            pnlCaSi.Controls.Add(lblTen);

                            flp.Controls.Add(pnlCaSi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Ca Sĩ: " + ex.Message);
            }
        }
    }
}