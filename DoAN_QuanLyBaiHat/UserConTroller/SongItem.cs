using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAN_QuanLyBaiHat.UserConTroller
{
    public partial class SongItem : UserControl
    {
        public SongItem()
        {
            InitializeComponent();
        }
        // Hàm để gán dữ liệu từ bên ngoài vào
        public void SetData(string tenBaiHat, string tenCaSi)
        {
            lblTenBaiHat.Text = tenBaiHat;
            lblTenCaSi.Text = tenCaSi;
        }

        // Sự kiện khi click vào bài hát (để phát nhạc)
        private void SongItem_Click(object sender, EventArgs e)
        {
            // Xử lý phát nhạc ở đây
            MessageBox.Show("Đang phát: " + lblTenBaiHat.Text);
        }

        // Gán sự kiện Click cho cả hình và chữ để người dùng bấm đâu cũng ăn
        private void lblTenBai_Click(object sender, EventArgs e) { 
            SongItem_Click(sender, e); }

        private void lblTenCaSi_Click(object sender, EventArgs e)
        {
            SongItem_Click(sender, e);
        }
    }
}
