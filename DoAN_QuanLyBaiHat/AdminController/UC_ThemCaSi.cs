using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace DoAN_QuanLyBaiHat.AdminController
{
    public partial class UC_ThemCaSi : UserControl
    {
        public event EventHandler OnHuy;
        public event EventHandler OnLuuThanhCong;

        private int _flagMode = 0;
        private string _idCaSi = "";

        public UC_ThemCaSi()
        {
            InitializeComponent();
        }


        // --- 1. HÀM NHẬN DỮ LIỆU (SỬA ĐỔI PHẦN GIỚI TÍNH) ---
        public void SetData(int mode, string id, string ten, string gioitinh, string mota, string image)
        {
            _flagMode = mode;
            _idCaSi = id;

            if (mode == 2) // SỬA
            {
                txtTenCaSi.Text = ten;
                txtMoTa.Text = mota;
                txtDuongDan.Text = image; // Ví dụ: Images_CS\2025...jpg

                // Xử lý giới tính
                if (gioitinh == "Nam") rdoNam.Checked = true;
                else if (gioitinh == "Nữ") rdoNu.Checked = true;
                else { rdoNam.Checked = false; rdoNu.Checked = false; }

                // Xử lý hiển thị ảnh
                if (!string.IsNullOrEmpty(image))
                {
                    // Đường dẫn đầy đủ = Thư mục chạy PM + Đường dẫn trong DB
                    string fullPath = Path.Combine(Application.StartupPath, image);

                    if (File.Exists(fullPath))
                    {
                        pbAnh.ImageLocation = fullPath;
                    }
                    else
                    {
                        pbAnh.Image = null;
                    }
                }
                else
                {
                    pbAnh.Image = null;
                }
            }
            else // THÊM
            {
                XoaTrang();
            }
        }

        private void XoaTrang()
        {
            txtTenCaSi.Clear();
            txtMoTa.Clear();
            // Mặc định chọn Nam khi thêm mới (hoặc bỏ chọn cả 2 tùy bạn)
            rdoNam.Checked = true;
        }

        // --- 2. NÚT LƯU (SỬA ĐỔI CÁCH LẤY GIỚI TÍNH) ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenCaSi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên Ca sĩ!", "Thông báo");
                return;
            }

            // Logic lấy dữ liệu từ Radio Button
            string gioitinh = "";
            if (rdoNam.Checked) gioitinh = "Nam";
            else if (rdoNu.Checked) gioitinh = "Nữ";

            // (Tùy chọn: Kiểm tra nếu chưa chọn giới tính)
            if (gioitinh == "")
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "";

                    // 1. Kiểm tra câu lệnh SQL (Phải có @Img)
                    if (_flagMode == 1) // THÊM
                    {
                        sql = "INSERT INTO casi (TenCS, GioiTinh, Mota, Image) VALUES (@Ten, @GT, @Mota, @Img)";
                    }
                    else // SỬA
                    {
                        sql = "UPDATE casi SET TenCS=@Ten, GioiTinh=@GT, Mota=@Mota, Image=@Img WHERE Cs_Id=@Id";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // 2. Nạp tham số (KIỂM TRA KỸ CÁC DÒNG NÀY)
                    cmd.Parameters.AddWithValue("@Ten", txtTenCaSi.Text);
                    cmd.Parameters.AddWithValue("@GT", gioitinh);
                    cmd.Parameters.AddWithValue("@Mota", txtMoTa.Text);

                    // 👇👇👇 BẠN CÓ THỂ ĐANG THIẾU DÒNG NÀY 👇👇👇
                    cmd.Parameters.AddWithValue("@Img", txtDuongDan.Text);
                    // 👆👆👆 HÃY CHẮC CHẮN NÓ CÓ MẶT 👆👆👆

                    if (_flagMode == 2) cmd.Parameters.AddWithValue("@Id", _idCaSi);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thành công!");

                    OnLuuThanhCong?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            OnHuy?.Invoke(this, EventArgs.Empty);

            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        private void btnChonHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            open.Title = "Chọn ảnh chân dung";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Tạo thư mục "Images_CS" nếu chưa có
                    string folderName = "Images_CS";
                    string folderPath = Path.Combine(Application.StartupPath, folderName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // 2. Tạo tên file mới theo định dạng: yyyyMMdd_HHmmss_CS.jpg
                    string extension = Path.GetExtension(open.FileName); // Lấy đuôi file (.jpg, .png)
                    string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string newFileName = $"{timeStamp}_CS{extension}"; // Ví dụ: 20251128_120543_CS.jpg

                    // 3. Tạo đường dẫn đích đầy đủ
                    string destPath = Path.Combine(folderPath, newFileName);

                    // 4. COPY file từ máy vào thư mục dự án ngay lập tức
                    File.Copy(open.FileName, destPath, true);

                    // 5. Hiển thị ảnh lên PictureBox
                    pbAnh.ImageLocation = destPath;

                    // 6. Gán đường dẫn tương đối vào TextBox để tí nữa lưu Database
                    // Lưu dạng: Images_CS\20251128_120543_CS.jpg
                    txtDuongDan.Text = Path.Combine(folderName, newFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý ảnh: " + ex.Message);
                }
            }
        }

        private void txtTenCaSi_TextChanged(object sender, EventArgs e)
        {
            txtTenCaSi.Focus();
        }
    }
}