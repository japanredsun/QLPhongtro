using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class ThemNguoi : UserControl
    {
        string ho, ten, gioitinh, cmnd, quequan, nghenghiep, maphong, ghichu;
        DateTime ngaysinh;
        string makhach;
        int tiendatcoc;

        public ThemNguoi()
        {
            InitializeComponent();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void ThemNguoi_Load(object sender, EventArgs e)
        {
            Load_CBKV();
            Load_CBLoaiPhong();
        }

        private void Load_CBKV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;
        }
        private void Load_CBLoaiPhong()
        {
            LoaiPhongBUS data = new LoaiPhongBUS();
            var loaiphong = data.GetLoaiPhongDA();
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.DataSource = loaiphong;
        }

        private void LoadData_ListPhong()
        {
            string khuvuc = cbKV.SelectedValue.ToString();
            string loaiphong = cbLoaiPhong.SelectedValue.ToString();
            Room data = new Room();
            var phong = data.GetDataPhong("SELECT * FROM Phong WHERE MaLoaiPhong='" + loaiphong + "'AND TrangThai=N'Đã thuê' AND MaKhuVuc='" + khuvuc + "'");

            for (int i = 0; i < phong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(phong.Rows[i][3].ToString());
                item.SubItems.Add(phong.Rows[i][0].ToString());
                item.ImageIndex = 0;
                lvPhong.Items.Add(item);
            }


        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            Load_CBLoaiPhong();
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            LoadData_ListPhong();
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            Room data = new Room();
            string kv = cbKV.SelectedValue.ToString();
            string tp = lvPhong.SelectedItems[0].Text;
            string sql = "SELECT MaPhong FROM Phong WHERE TenPhong=N'" + tp + "'AND MaKhuVuc='" + kv + "'";
            var mp = data.GetDataPhong(sql);

            PhongBUS listphong = new PhongBUS();
            string maphong = mp.Rows[0][0].ToString();
            string sql1 = "SELECT p.TenPhong, lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaPhong=N'" + maphong + "'AND p.MaLoaiPhong = lp.MaLoaiPhong";
            var dsphong = listphong.GetThongTinThuePhong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string gia = string.Format("{0:#,##0}", Int32.Parse(dsphong.Rows[0][1].ToString()));
            lbMaPhong.Text = maphong; lbMaPhong.ForeColor = Color.Red;
            lbTenPhong.Text = tenphong; lbTenPhong.ForeColor = Color.Red;
            lbGia.Text = gia + " vnd"; lbGia.ForeColor = Color.Red;

            Load_ListKhach(maphong);
            
        }   
        //Load ListView Khach thue 
        private void Load_ListKhach(string maphong)
        {
            KhachThueBUS khach = new KhachThueBUS();
            var listkhach = khach.GetKhach(maphong);
            lvKhachThue.Items.Clear();
            for (int i = 0; i < listkhach.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(listkhach.Rows[i][0].ToString());
                if (listkhach.Rows[i][2].ToString() == "Nam") item.ImageIndex = 3; else item.ImageIndex = 2;
                item.SubItems.Add(listkhach.Rows[i][1].ToString());
                item.SubItems.Add(listkhach.Rows[i][3].ToString());
                item.SubItems.Add(listkhach.Rows[i][5].ToString());
                lvKhachThue.Items.Add(item);
            }
            lbSoNguoi.Text = listkhach.Rows.Count.ToString();
        }

        //Clear Textbox
        private void ClearAll()
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtCMND.Text = "";
            txtNgheNghiep.Text = "";
            txtQueQuan.Text = "";
            txtTienDatCoc.Text = "";
            cbGioiTinh.Text = "";
            dtpNgaySinh.Value = DateTime.Today;
        }

        //Nút Clear
        private void buttonX2_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        //Nút Lưu
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Sinh Ma Khach moi
            ThongTinThuePhongBUS data = new ThongTinThuePhongBUS();
            makhach = data.newID();

            //Lay thong tin bang ThongTinKhach
            ho = txtHo.Text.Trim();
            ten = txtTen.Text.Trim();
            ngaysinh = dtpNgaySinh.Value;
            if (cbGioiTinh.SelectedItem.ToString() == "Nam")
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            cmnd = txtCMND.Text.Trim();
            quequan = txtQueQuan.Text.Trim();
            nghenghiep = txtNgheNghiep.Text.Trim();
            maphong = lbMaPhong.Text.Trim();
            ghichu = "1";
            tiendatcoc = Convert.ToInt32(txtTienDatCoc.Text);

            //Lay thong tin ThongTinThuePhong
            string idtttp = new ThongTinThuePhongBUS().newID_tttp().ToString();
            string select_maphong = lbMaPhong.Text;
            DateTime ngaythue = dtpNgayThue.Value;

            if (MessageBox.Show("Bạn có muốn lưu?", "Mã khách trọ: " + makhach, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Them vao bang ThongTinKhach               
                KhachThue kt = new KhachThue(makhach, ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep, maphong, ghichu);
                string sqlAddKhachInfo = "INSERT INTO ThongTinKhach(MaKhachTro,Ho,Ten,GioiTinh,NgaySinh,CMND,QueQuan,NgheNghiep,MaPhong,GhiChu) VALUES(@makhach,@ho,@ten,@gioitinh,@ngaysinh,@cmnd,@quequan,@nghenghiep,@maphong,@ghichu)";
                int j = new KhachThueBUS().Insert(sqlAddKhachInfo, kt);

                //Them vao bang ThongTinThuePhong             
                ThongTinThue ttp = new ThongTinThue(idtttp,makhach,maphong,ngaythue,tiendatcoc);
                string sqlinsert = "INSERT INTO ThongTinThuePhong(MaHD, MaKhachTro, MaPhong, NgayThue,TienDatCoc) VALUES(@id, @makhachtro,@maphong,@ngaythue,@tiendatcoc)";
                int i = new ThongTinThuePhongBUS().Insert(sqlinsert, ttp);

                //Cap nhat trang thai phong
                ThongTinThuePhongBUS update = new ThongTinThuePhongBUS();
                string sqlupdate = "UPDATE Phong SET TrangThai=@trangthai WHERE MaPhong='" + select_maphong + "'";
                update.Update(sqlupdate);

                //Refresh Form
                lvPhong.Items.Clear();
                LoadData_ListPhong();
                ClearAll();
                Load_ListKhach(maphong);
                MessageBox.Show("Đã thêm thành công!");      
            }
        }


    }
}
