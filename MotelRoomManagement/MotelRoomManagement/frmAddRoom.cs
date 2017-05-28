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
            Load_ComboBox();
        }

        private void Load_ComboBox()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;

            var lp = data.GetDataPhong("SELECT MaLoaiPhong, TenLoaiPhong From LoaiPhong");
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.DataSource = lp;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Phong (MaPhong,MaLoaiPhong,MaKhuVuc,TenPhong,Day,TrangThai) VALUES(@maphong,@maloai,@makhu,@tenphong,@day,@trangthai)";
            string trangthai = "Trống";
            string maphong = txtMaPhong.Text.ToString(),
                    loaiphong = cbLoaiPhong.SelectedValue.ToString(),
                    khuvuc =cbKV.SelectedValue.ToString(),
                    tenphong = txtTenPhong.Text.ToString(),
                    day = txtDay.Text.ToString();
            int i = new PhongBUS().themphong(sql, maphong, loaiphong, khuvuc, tenphong, day, trangthai);
            if (i == 1)
            {
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Không thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO LoaiPhong (MaLoaiPhong,TenLoaiPhong,DienTich,Gia) VALUES(@maloaiphong,@tenloaiphong,@dientich,@gia)";            
            string maloaiphong = txtMLP.Text.ToString(),
                    tenloaiphong = txtTenLP.Text.ToString();
            double dientich = Convert.ToDouble(txtDT.Text),
                    gia = Convert.ToDouble(txtGia.Text);
                    
            int i = new PhongBUS().themloaiphong(sql, maloaiphong, tenloaiphong, dientich, gia);
            if (i == 1)
            {
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Không thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
