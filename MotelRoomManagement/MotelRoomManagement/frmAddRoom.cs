using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRDTO;
using MRBUS;

namespace MotelRoomManagement
{
    public partial class frmAddRoom : Form
    {
        public frmAddRoom()
        {
            InitializeComponent();
        }

        private void frmAddRoom_Load(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Phong (MaPhong,MaLoaiPhong,MaKhuVuc,TenPhong,Day,TrangThai) VALUES(@maphong,@maloai,@makhu,@tenphong,@day,@trangthai)";
            string trangthai = "Trống";
            string maphong = txtMaPhong.Text.ToString(),
                    loaiphong = txtLoaiPhong.Text.ToString(),
                    khuvuc = txtKhuVuc.Text.ToString(),
                    tenphong = txtTenPhong.Text.ToString(),
                    day = txtDay.Text.ToString();
            int i = new PhongBUS().themphong(sql, maphong, loaiphong, khuvuc, tenphong, day, trangthai);
            MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
