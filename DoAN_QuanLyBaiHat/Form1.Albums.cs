using System;
using System.Windows.Forms;
using DoAN_QuanLyBaiHat.AdminController; // Namespace chứa UC_ThemAlbums

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1
    {
        private void btnThemAlbums_Click(object sender, EventArgs e)
        {
            UC_ThemAlbums uc = new UC_ThemAlbums();
            uc.Dock = DockStyle.Fill;
            tabAlbum.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}