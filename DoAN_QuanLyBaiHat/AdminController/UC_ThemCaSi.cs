using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Thư viện xử lý file
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Thư viện MySQL
using DoAN_QuanLyBaiHat; // Namespace chứa DatabaseConnection

namespace DoAN_QuanLyBaiHat.AdminController
{
    public partial class UC_ThemCaSi : UserControl
    {
        // --- KHAI BÁO BIẾN ---
        public int flagMode = 1; // 1: Thêm, 2: Sửa
        public string idCaSi = ""; // Lưu ID khi đang ở chế độ Sửa

        // Sự kiện để báo cho Form cha biết (để load lại danh sách)
        public event EventHandler OnLuuThanhCong;

        public UC_ThemCaSi()
        {
            InitializeComponent();

        }

        // --- 1. XỬ LÝ NÚT CHỌN ẢNH ---
        private void btnChonHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            open.Title = "Chọn ảnh ca sĩ";

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbAnh.ImageLocation = open.FileName;
                pbAnh.Tag = open.FileName; // Lưu đường dẫn gốc
            }
        }

        // --- 2. XỬ LÝ NÚT LƯU (ĐÃ XÓA TAIKHOAN_ID) ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // A. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenCaSi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ca sĩ!");
                txtTenCaSi.Focus();
                return;
            }

            string duongDanLuuDB = "";

            // B. XỬ LÝ FILE ẢNH
            if (pbAnh.Tag != null)
            {
                string duongDanHienTai = pbAnh.Tag.ToString();

                // TRƯỜNG HỢP 1: Ảnh MỚI (chưa có trong thư mục Images_CS)
                if (!duongDanHienTai.Contains("Images_CS"))
                {
                    try
                    {
                        string folderAnh = Path.Combine(Application.StartupPath, "Images_CS");
                        if (!Directory.Exists(folderAnh)) Directory.CreateDirectory(folderAnh);

                        string extension = Path.GetExtension(duongDanHienTai);
                        string tenFileMoi = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_CS" + extension;
                        string duongDanDich = Path.Combine(folderAnh, tenFileMoi);

                        File.Copy(duongDanHienTai, duongDanDich, true);
                        duongDanLuuDB = "Images_CS\\" + tenFileMoi;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi copy ảnh: " + ex.Message);
                        return;
                    }
                }
                // TRƯỜNG HỢP 2: Ảnh CŨ (đã có sẵn)
                else
                {
                    int index = duongDanHienTai.IndexOf("Images_CS");
                    if (index >= 0) duongDanLuuDB = duongDanHienTai.Substring(index);
                }
            }

            // C. LƯU VÀO DATABASE
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    // Lấy giá trị giới tính
                    string gioiTinh = cbGioiTinh.Text;
                    if (string.IsNullOrEmpty(gioiTinh)) gioiTinh = "Nam";

                    if (flagMode == 1) // --- THÊM MỚI ---
                    {
                        // Đã xóa TaiKhoan_Id
                        sql = "INSERT INTO casi (TenCS, GioiTinh, Image, Mota) VALUES (@Ten, @GioiTinh, @HinhAnh, @Mota)";
                        lblTieuDe.Text = "THÊM CA SĨ";
                        cmd.Parameters.AddWithValue("@Ten", txtTenCaSi.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@HinhAnh", duongDanLuuDB);
                        cmd.Parameters.AddWithValue("@Mota", txtMoTa.Text.Trim());
                    }
                    else // --- SỬA ---
                    {
                        // Đã xóa TaiKhoan_Id
                        sql = "UPDATE casi SET TenCS=@Ten, GioiTinh=@GioiTinh, Image=@HinhAnh, Mota=@Mota WHERE Cs_Id=@Id";
                        lblTieuDe.Text = "SỬA CA SĨ";
                        cmd.Parameters.AddWithValue("@Ten", txtTenCaSi.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@HinhAnh", duongDanLuuDB);
                        cmd.Parameters.AddWithValue("@Mota", txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", idCaSi);
                    }

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thao tác thành công!");

                    OnLuuThanhCong?.Invoke(this, EventArgs.Empty);

                    if (flagMode == 1) RefreshForm();
                    else btnHuy_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
            }
        }

        // --- 3. XỬ LÝ NÚT HỦY ---
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (this.Parent != null) this.Parent.Controls.Remove(this);
        }

        // --- 4. HÀM NHẬN DỮ LIỆU TỪ FORM CHA ---
        public void SetData(int mode, string id, string ten, string gioitinh, string mota, string duongDanAnhDB)
        {
            this.flagMode = mode;
            this.idCaSi = id;

            txtTenCaSi.Text = ten;
            txtMoTa.Text = mota;

            if (!string.IsNullOrEmpty(gioitinh))
            {
                cbGioiTinh.SelectedItem = gioitinh;
                if (cbGioiTinh.SelectedIndex < 0) cbGioiTinh.Text = gioitinh;
            }

            if (!string.IsNullOrEmpty(duongDanAnhDB))
            {
                string fullPath = Path.Combine(Application.StartupPath, duongDanAnhDB);
                if (File.Exists(fullPath))
                {
                    pbAnh.ImageLocation = fullPath;
                    pbAnh.Tag = fullPath;
                }
                else
                {
                    pbAnh.Image = null;
                    pbAnh.Tag = null;
                }
            }
            else
            {
                pbAnh.Image = null;
                pbAnh.Tag = null;
            }
        }

        // --- 5. HÀM XÓA TRẮNG FORM ---
        private void RefreshForm()
        {
            txtTenCaSi.Text = "";
            cbGioiTinh.SelectedIndex = 0;
            pbAnh.Image = null;
            pbAnh.Tag = null;
            txtMoTa.Text = "";
            txtTenCaSi.Focus();
        }
    }
}