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
    public partial class TraPhong : UserControl
    {
        private int tiendatcoc;
        public TraPhong()
        {
            InitializeComponent();
        }

        private void lvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TraPhong_Load(object sender, EventArgs e)
        {
            Load_KV();
            
        }

        public void Load_KV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;
        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_listPhong();
        }
        private void Load_listPhong()
        {
            lvPhong.Items.Clear();
            string makv = cbKV.SelectedValue.ToString();
            Room data = new Room();
            var sql = data.GetDataPhong("SELECT * FROM Phong WHERE MaKhuVuc='" + makv + "' AND TrangThai=N'Đã thuê'");
            for (int i = 0; i < sql.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(sql.Rows[i][0].ToString());
                item.SubItems.Add(sql.Rows[i][3].ToString());
                item.SubItems.Add(sql.Rows[i][1].ToString());
                item.SubItems.Add(sql.Rows[i][4].ToString());
                lvPhong.Items.Add(item);
            }
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            lvKhach.Items.Clear();
            ListViewItem a =lvPhong.SelectedItems[0];
            string map = a.Text;
            string id;
            //string map = lvPhong.SelectedItems[0].ToString().TrimEnd();
            string sqll = "SELECT * FROM ThongTinKhach WHERE MaPhong= '" + map + "'";
            KhachThueBUS data = new KhachThueBUS();
            DataTable sql = data.GetKhachTheoMaPhong(sqll);
            for (int i = 0; i < sql.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(sql.Rows[i][0].ToString());
                item.SubItems.Add(sql.Rows[i][1].ToString() + " " + sql.Rows[i][2].ToString());
                item.SubItems.Add(sql.Rows[i][3].ToString());
                lvKhach.Items.Add(item);
            }


            id = sql.Rows[0][0].ToString();
            load_khach_dau(id);
           
        }



        private void load_khach_dau(string id)
        {
            KhachThueBUS kt = new KhachThueBUS();
            var sqlkt = kt.GetKhachTheoMaPhong("SELECT * FROM ThongTinKhach WHERE MaKhachTro='" + id + "'");
            lbHoTen.Text = sqlkt.Rows[0][1] + " " + sqlkt.Rows[0][2];
            dtNgaySinh.Text = sqlkt.Rows[0][5].ToString();
            lbGioiTinh.Text = sqlkt.Rows[0][3].ToString();
            lbCMND.Text = sqlkt.Rows[0][6].ToString();
            lbQueQuan.Text = sqlkt.Rows[0][7].ToString();
            lbNgheNghiep.Text = sqlkt.Rows[0][8].ToString();
            lbMaKhach.Text = sqlkt.Rows[0][0].ToString();

            ThongTinThuePhongBUS ttt = new ThongTinThuePhongBUS();
            var sqlttt = ttt.GetKhach("SELECT * FROM ThongTinThuePhong WHERE MaKhachTro='" + id + "'");
            lbPhong.Text = sqlttt.Rows[0][2].ToString();
            dtNgayThue.Text = sqlttt.Rows[0][3].ToString();            
            tiendatcoc = Convert.ToInt32(sqlttt.Rows[0][4].ToString());
            lbTienDatCoc.Text = string.Format("{0:#,##0}", tiendatcoc);
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {

            string maphong = lbPhong.Text;
            ThongTinThuePhongBUS ttt = new ThongTinThuePhongBUS();

            //Id
            int id = new ThongTinThuePhongBUS().newID_traphong();

            DateTime ngaythue, ngaytra;
            string makhach = lbMaKhach.Text;
            ngaythue = dtNgayThue.Value;
            ngaytra = dtNgayTraPhong.Value;
            string str_tdc = string.Format("{0:#,##0}",tiendatcoc);

            //Them vao bang TraPhong
            ThongTinThuePhongBUS tttTraphong = new ThongTinThuePhongBUS();
            MRDTO.TraPhong tp = new MRDTO.TraPhong(id,makhach,maphong,ngaythue,ngaytra);

            if (MessageBox.Show("Ngày thuê: "+ dtNgayThue.Text.ToString() + "\nTiền đặt cọc: "+str_tdc+" vnd", "Xác nhận trả phòng: " + maphong, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlinsert = "INSERT INTO TraPhong(Id,MaPhong,MaKhachTro,NgayThue,NgayTraPhong) VALUES(@id,@maphong,@makhach,@ngaythue,@ngaytra)";
                int insert = tttTraphong.Insert_Tra_phong(sqlinsert, tp);

                //Xoa ben ThongTinThue
                var sqlttt = ttt.Delete("DELETE FROM ThongTinThuePhong WHERE MaPhong=@maphong", maphong);

                //Xoa khach thuoc phong vua tra
                var xoakhachthue = ttt.Delete("DELETE FROM ThongTinKhach WHERE MaPhong=@maphong", maphong);

                //Sua trang thai
                var update = ttt.Update_TraPhong("UPDATE Phong SET TrangThai=@trangthai WHERE MaPhong='" + maphong + "'");
                MessageBox.Show("Đã trả phòng");

                //Refresh
                Load_listPhong();
                ClearAll();
                lvKhach.Items.Clear();
            }
        }

        //ClearAll
        private void ClearAll()
        {
            dtNgaySinh.Value = DateTime.Today;
            lbHoTen.Text = "";
            lbCMND.Text = "";
            lbGioiTinh.Text = "";
            lbNgheNghiep.Text = "";
            lbPhong.Text = "";
            lbQueQuan.Text = "";
            lbTienDatCoc.Text="";
        }

        private void lvKhach_Click(object sender, EventArgs e)
        {
            ListViewItem a = lvKhach.SelectedItems[0];
            string makhach = a.Text;
            load_khach_dau(makhach);
        }
    }
}
