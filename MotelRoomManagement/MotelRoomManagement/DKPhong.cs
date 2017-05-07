using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class DKPhong : UserControl
    {
        string ho, ten, ngaysinh, gioitinh, cmnd, quequan, nghenghiep, makhuvuc, maloaiphong;

        public DKPhong()
        {
            InitializeComponent();
        }

        private void DKPhong_Load(object sender, EventArgs e)
        {
            LoadKV();

        }
        private void LoadKV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKhuVuc.DisplayMember = "TenKhuVuc";
            cbKhuVuc.ValueMember = "MaKhuVuc";
            cbKhuVuc.DataSource = kv;
            

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            ThongTinDKBUS ttdk = new ThongTinDKBUS();
            string sql = "SELECT * FROM ThongTinDangKyPhong";
            int id = ttdk.GetThongTinDK(sql).Rows.Count + 1;
            ho = txtHo.Text;
            ten = txtTen.Text;
            ngaysinh = dtiNgaySinh.Text;
            if (cbGioiTinh.SelectedItem.ToString() == "Nam")
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            cmnd = txtCmnd.Text;
            quequan = txtQuequan.Text;
            nghenghiep = txtNghenghiep.Text;
            makhuvuc = cbKhuVuc.SelectedValue.ToString();

            string sqlInsert = "INSERT INTO ThongTinDangKyPhong(Id,Ho,Ten,GioiTinh,NgaySinh,CMND,QueQuan,NgheNghiep,MaKhuVuc,MaLoaiPhong) VALUES(@id,@ho,@ten,@gioitinh,@ngaysinh,@cmnd,@quequan,@nghenghiep,@makhuvuc,@maloaiphong)";
            int i = new ThongTinDKBUS().Insert(sqlInsert ,id , ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep, makhuvuc, maloaiphong);

            MessageBox.Show("Đã thêm thành công!");

        }

        private void cbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLoaiPhong.Items.Clear();
            string makv = cbKhuVuc.SelectedValue.ToString();

            string sql = "SELECT lp.MaLoaiPhong, lp.TenLoaiPhong, lp.DienTichPhong, lp.DonGia, p.TrangThai FROM LoaiPhong lp, Phong p WHERE p.MaKhuVuc = N'" + makv + "' AND p.TrangThai = N'Trống' AND p.MaLoaiPhong = lp.MaLoaiPhong";
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][0].ToString());
                item.SubItems.Add(loaiphong.Rows[i][1].ToString());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString());
                item.SubItems.Add(loaiphong.Rows[i][3].ToString());

                lstLoaiPhong.Items.Add(item);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            

        }

        private void lstLoaiPhong_Click(object sender, EventArgs e)
        {
            maloaiphong = lstLoaiPhong.SelectedItems[0].Text;
        }

        
    }
}
