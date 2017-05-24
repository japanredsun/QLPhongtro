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
            lbNgayHienTai.Text = DateTime.Today.ToString();
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


                //id = sql.Rows[i][0].ToString();
                //load_khach_dau(id);
                //load_thong_tin_thue(id);
            }


            id = sql.Rows[0][0].ToString();
            load_khach_dau(id);
            load_thong_tin_thue(id);
        }

        private void load_khach_dau(string id)
        {
            KhachThueBUS kt = new KhachThueBUS();
            var sqlkt = kt.GetKhachTheoMaPhong("SELECT * FROM ThongTinKhach WHERE MaKhachTro='" + id + "'");
            lbHoTen.Text = sqlkt.Rows[0][1] + " " + sqlkt.Rows[0][2];
            lbNgaySinh.Text = sqlkt.Rows[0][5].ToString();
            lbGioiTinh.Text = sqlkt.Rows[0][3].ToString();
            lbCMND.Text = sqlkt.Rows[0][6].ToString();
            lbQueQuan.Text = sqlkt.Rows[0][7].ToString();
            lbNgheNghiep.Text = sqlkt.Rows[0][8].ToString();
        }

        private void load_thong_tin_thue(string id)
        {
            ThongTinThuePhongBUS ttt = new ThongTinThuePhongBUS();
            var sqlttt = ttt.GetKhach("SELECT * FROM ThongTinThuePhong WHERE MaKhachTro='" + id + "'");
            lbPhong.Text = sqlttt.Rows[0][2].ToString();
            lbNgaythue.Text = sqlttt.Rows[0][3].ToString();
            lbTienDatCoc.Text = sqlttt.Rows[0][4].ToString();

        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvPhong.SelectedItems[0];
            string maphong = item.Text;
            ThongTinThuePhongBUS ttt = new ThongTinThuePhongBUS();

            //Id
            ThongTinDKBUS ttdk = new ThongTinDKBUS();
            var table = ttdk.GetThongTinDK("SELECT * FROM TraPhong");
            table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };
            int id, k;
            for (k = 1; k < table.Rows.Count; k++)
            {
                if (table.Rows.Find(k) == null)
                {
                    break;
                }
            }
            id = k;

            string ngaythue, ngaytra;

            ListViewItem ab = lvKhach.SelectedItems[0];
            string makhach = item.Text;

            //NgayThue
            //var sql = ttt.GetKhach("SELECT NgayThue FROM ThongTinThuePhong WHERE MaKhachTro='" + lvKhach.SelectedItems[0] + "'");
            //for(int i =0;i<sql.Rows.Count;i++)
            //{
                 
            //}
            ngaythue = lbNgaythue.Text;
            ngaytra = lbNgayHienTai.Text;
            //Them vao bang TraPhong
            ThongTinThuePhongBUS tttTraphong = new ThongTinThuePhongBUS();
            var sqlTraphong = tttTraphong.Insert_Tra_phong("INSERT INTO TraPhong(Id,MaPhong,MaKhachTro,NgayThue,NgayTraPhong) VALUES(@id,@maphong,@makhach,@ngaythue,@ngaytra)", id, maphong, makhach, ngaythue, ngaytra);
            //Xoa ben ThongTinThue
            var sqlttt = ttt.Delete("DELETE FROM ThongTinThuePhong WHERE MaPhong=@maphong", maphong);
            //Sua trang thai
            var update = ttt.Update_TraPhong("UPDATE Phong SET TrangThai=@trangthai WHERE MaPhong='" + maphong + "'");
            MessageBox.Show("Đã trả phòng");
        }
    }
}
