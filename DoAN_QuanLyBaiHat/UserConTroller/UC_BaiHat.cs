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
        // 1. Tạo sự kiện để báo ra bên ngoài (Form User) biết là cần phát bài nào
        public event Action<string> OnPlayMusic;

        public UC_BaiHat()
        {
            InitializeComponent();
        }

        private void UC_BaiHat_Load(object sender, EventArgs e)
        {
            LoadNhacVaoFLP(flpDsBH, "SELECT Ten_Bai_Hat, CaSi, DuongDan FROM baihat LIMIT 10");
        }
        // --- HÀM TẠO GIAO DIỆN ĐỘNG (KHÔNG CẦN UC_ITEM) ---
        private void LoadNhacVaoFLP(FlowLayoutPanel flp, string sql)
        {
            // Xóa sạch cái cũ đi
            flp.Controls.Clear();

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
                            string tenBai = reader["Ten_Bai_Hat"].ToString();
                            string caSi = reader["CaSi"]?.ToString() ?? "Chưa rõ";
                            string linkNhac = reader["DuongDan"]?.ToString() ?? "";

                            // --- BẮT ĐẦU TẠO GIAO DIỆN BẰNG CODE ---

                            // 1. Tạo cái khung chứa (Panel) - Thay thế cho UC_Item
                            Panel pnlItem = new Panel();
                            pnlItem.Size = new Size(200, 70); // Kích thước thẻ
                            pnlItem.BackColor = Color.WhiteSmoke;
                            pnlItem.Cursor = Cursors.Hand;
                            pnlItem.Margin = new Padding(10); // Khoảng cách giữa các thẻ

                            // 2. Tạo hình ảnh (PictureBox)
                            PictureBox pbAnh = new PictureBox();
                            pbAnh.Size = new Size(60, 60);
                            pbAnh.Location = new Point(5, 5);
                            pbAnh.BackColor = Color.Teal; // Màu nền giả lập ảnh bìa
                            pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;

                            // (Mẹo: Vẽ chữ nốt nhạc lên PictureBox cho đẹp)
                            Label lblIcon = new Label();
                            lblIcon.Text = "♫";
                            lblIcon.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                            lblIcon.ForeColor = Color.White;
                            lblIcon.BackColor = Color.Transparent;
                            lblIcon.AutoSize = true;
                            lblIcon.Location = new Point(15, 10);
                            pbAnh.Controls.Add(lblIcon); // Nhét icon vào trong khung ảnh

                            // 3. Tạo Label Tên Bài Hát
                            Label lblTen = new Label();
                            lblTen.Text = tenBai;
                            lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            lblTen.Location = new Point(70, 10);
                            lblTen.Size = new Size(125, 25); // Giới hạn chiều rộng để không bị tràn
                            lblTen.AutoEllipsis = true; // Tên dài quá thì hiện dấu ...

                            // 4. Tạo Label Ca Sĩ
                            Label lblCaSi = new Label();
                            lblCaSi.Text = caSi;
                            lblCaSi.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                            lblCaSi.ForeColor = Color.Gray;
                            lblCaSi.Location = new Point(70, 35);
                            lblCaSi.Size = new Size(125, 20);

                            // 5. Quan Trọng: Gắn sự kiện CLICK cho tất cả
                            // Để bấm vào chỗ nào cũng phát nhạc
                            EventHandler SuKienClick = (s, ev) =>
                            {
                                // Bắn tín hiệu ra ngoài kèm link nhạc
                                OnPlayMusic?.Invoke(linkNhac);
                            };

                            pnlItem.Click += SuKienClick;
                            pbAnh.Click += SuKienClick;
                            lblTen.Click += SuKienClick;
                            lblCaSi.Click += SuKienClick;
                            lblIcon.Click += SuKienClick;

                            // 6. Thêm các control con vào Panel
                            pnlItem.Controls.Add(lblTen);
                            pnlItem.Controls.Add(lblCaSi);
                            pnlItem.Controls.Add(pbAnh);

                            // 7. Cuối cùng: Thêm Panel vào FlowLayoutPanel
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
    }
}