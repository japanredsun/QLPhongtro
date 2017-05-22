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
    public partial class SapPhong : UserControl
    {
        string ho, ten, gioitinh, cmnd, quequan, nghenghiep, maphong,ghichu;
        DateTime ngaysinh;
        string makhach;
        //double tiendatcoc;
        public SapPhong()
        {
            InitializeComponent();
        }

        private void radDSDK_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDK.Checked)
            {
                grDSKDK.Enabled = true;
                
            }
            else
                grDSKDK.Enabled = false;
                
        }
        private void rdnTuNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnTuNhap.Checked)
            {
                lbPKC.Visible = false;
                ClearAll();
            }
            else
                lbPKC.Visible = true;
        }

   

        private void SapPhong_Load(object sender, EventArgs e)
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
        private void Load_ListKDK()
        {
            listKDK.Items.Clear();
            string makv = cbKV.SelectedValue.ToString();
            Room data = new Room();
            var khachdk = data.GetDataPhong("SELECT * From ThongTinDangKyPhong Where MaKhuVuc='"+makv+"'");

            for (int i = 0; i < khachdk.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(khachdk.Rows[i][0].ToString());
                if (khachdk.Rows[i][3].ToString() == "Nam") item.ImageIndex = 3; else item.ImageIndex = 2;
                item.SubItems.Add(khachdk.Rows[i][1].ToString() + " " + khachdk.Rows[i][2].ToString());
                listKDK.Items.Add(item);
            }
        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            Load_CBLoaiPhong();
            Load_ListKDK();

        }
       
        private void LoadData_ListPhong()
        {
            string khuvuc = cbKV.SelectedValue.ToString();
            string loaiphong = cbLoaiPhong.SelectedValue.ToString();
            Room data = new Room();
            var phong = data.GetDataPhong("SELECT * FROM Phong WHERE MaLoaiPhong='" + loaiphong + "'AND TrangThai=N'Trống' AND MaKhuVuc='" + khuvuc + "'");

            for (int i = 0; i < phong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(phong.Rows[i][3].ToString());
                item.SubItems.Add(phong.Rows[i][0].ToString());
                item.ImageIndex = 0;
                lvPhong.Items.Add(item);
            }
            
            
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
            string sql = "SELECT MaPhong FROM Phong WHERE TenPhong=N'"+tp+"'AND MaKhuVuc='"+kv+"'";
            var mp = data.GetDataPhong(sql);

            PhongBUS listphong = new PhongBUS();
            string maphong = mp.Rows[0][0].ToString();
            string sql1 = "SELECT p.TenPhong, lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaPhong=N'" + maphong + "'AND p.MaLoaiPhong = lp.MaLoaiPhong";
            var dsphong = listphong.GetThongTinThuePhong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string gia = string.Format("{0:#,##0}",Int32.Parse(dsphong.Rows[0][1].ToString()));
            lbMaPhong.Text = maphong; lbMaPhong.ForeColor = Color.Red;
            lbTenPhong.Text = tenphong; lbTenPhong.ForeColor = Color.Red;
            lbGia.Text = gia + " vnd"; lbGia.ForeColor = Color.Red;
        }


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
            ghichu="1";
            //tiendatcoc = (int)txtTienDatCoc.Text.Trim();

            if (MessageBox.Show("Bạn có muốn lưu?", "Mã khách trọ: " + makhach, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Them vao bang ThongTinKhach               
                KhachThue kt = new KhachThue(makhach, ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep, maphong, ghichu);
                string sqlAddKhachInfo = "INSERT INTO ThongTinKhach(MaKhachTro,Ho,Ten,GioiTinh,NgaySinh,CMND,QueQuan,NgheNghiep,MaPhong,GhiChu) VALUES(@makhach,@ho,@ten,@gioitinh,@ngaysinh,@cmnd,@quequan,@nghenghiep,@maphong,@ghichu)";
                int j = new KhachThueBUS().Insert(sqlAddKhachInfo,kt);

                //Them vao bang ThongTinThuePhong
                //Lay thong tin
                PhongBUS tttp = new PhongBUS();
                string sql = "SELECT * From ThongTinThuePhong";
                int id_tttp = tttp.GetThongTinThuePhong(sql).Rows.Count + 1;
                string idtttp = id_tttp.ToString();
                string select_maphong = lbMaPhong.Text;
                string ngaythue = dtpNgayThue.Text;
                       //INSERT vao bang
                string sqlinsert = "INSERT INTO ThongTinThuePhong(MaHD, MaKhachTro, MaPhong, NgayThue) VALUES(@id, @makhachtro,@maphong,@ngaythue)";
                int i = new ThongTinThuePhongBUS().Insert(sqlinsert, idtttp, makhach, maphong, ngaythue);
                                
                 //Cap nhat trang thai phong
                ThongTinThuePhongBUS update = new ThongTinThuePhongBUS();
                string sqlupdate = "UPDATE Phong SET TrangThai=@trangthai WHERE MaPhong='" + select_maphong + "'";
                update.Update(sqlupdate);
                //Xoa Khach tu DS Dang Ky

                //Refresh Form
                lvPhong.Items.Clear();
                LoadData_ListPhong();
                MessageBox.Show("Đã thêm thành công!");
               

               
            }
        }

        // Nút Clear
        private void ClearAll()
        {
            dtpNgaySinh.Value = DateTime.Today;
            cbGioiTinh.Text = "";
            List<TextBox> tmp = new List<TextBox>();
            tmp.Add(txtCMND); tmp.Add(txtHo); tmp.Add(txtNgheNghiep); tmp.Add(txtQueQuan); tmp.Add(txtTen); tmp.Add(txtTienDatCoc);
            foreach (TextBox txtbox in tmp)
            {
                txtbox.Text = "";
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void listKDK_Click(object sender, EventArgs e)
        {
            ListViewItem item = listKDK.SelectedItems[0];
            string id = item.Text;

            Room data = new Room();
            var khachdk = data.GetDataPhong("SELECT * From ThongTinDangKyPhong Where Id=" + id);

            txtHo.Text = khachdk.Rows[0][1].ToString();
            txtTen.Text = khachdk.Rows[0][2].ToString();
            cbGioiTinh.Text = khachdk.Rows[0][3].ToString();
            dtpNgaySinh.Text = khachdk.Rows[0][4].ToString();
            txtCMND.Text = khachdk.Rows[0][5].ToString();
            txtQueQuan.Text = khachdk.Rows[0][6].ToString();
            txtNgheNghiep.Text = khachdk.Rows[0][7].ToString();

            string maloaiphong = khachdk.Rows[0][9].ToString();
            var tenphong = data.GetDataPhong("SELECT TenLoaiPhong From LoaiPhong Where MaLoaiPhong='"+maloaiphong+"'");
            lbPCK1.Text = tenphong.Rows[0][0].ToString();

           
        }

       

   


      

        
    }
}
