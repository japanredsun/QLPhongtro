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
    public partial class frmHireRoom : Form
    {
        string  ho , ten, gioitinh, cmnd,  ngaysinh, quequan, nghenghiep, maphong;
        string makhach;
        //double tiendatcoc;

        public frmHireRoom()
        {
            InitializeComponent();
        }

        private void frmHireRoom_Load(object sender, EventArgs e)
        {
            //Load danh sach phong trong
            string sql = "SELECT p.MaPhong,p.TenPhong,lp.TenLoaiPhong,lp.DonGia FROM Phong p,LoaiPhong lp WHERE p.TrangThai = N'Trống' AND p.MaLoaiPhong = lp.MaLoaiPhong";
           
            PhongBUS ListPhong = new PhongBUS();
            for (int i = 0; i < ListPhong.GetThongTinThuePhong(sql).Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(ListPhong.GetThongTinThuePhong(sql).Rows[i][0].ToString());
                item.SubItems.Add(ListPhong.GetThongTinThuePhong(sql).Rows[i][1].ToString());
                item.SubItems.Add(ListPhong.GetThongTinThuePhong(sql).Rows[i][2].ToString());
                item.SubItems.Add(ListPhong.GetThongTinThuePhong(sql).Rows[i][3].ToString());

                lstPhongTrong.Items.Add(item);
            }

            //Sinh Ma Khach moi
            ThongTinThuePhongBUS soluongkhach = new ThongTinThuePhongBUS();
            string sql1 = "SELECT * From ThongTinKhach";
            int id_khach = soluongkhach.GetKhach(sql1).Rows.Count + 1;
            makhach = "KT" + id_khach.ToString(); 
            txtMaKhach.Text = makhach;
        }

        //private List<KhachThue> getKhachThue()
        //{
        //    string sql = "SELECT * FROM ThongTinKhach";
        //    List<KhachThue> khach = new KhachThueBUS().GetKhach_List(sql);
        //    return khach;
        //}

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void btSave_Click(object sender, EventArgs e)
        {
            //Lay thong tin bang ThongTinKhach

            makhach = txtMaKhach.Text.ToString();
            ho = txtHo.Text.Trim();
            ten = txtTen.Text.Trim();
            ngaysinh = dtpNgaySinh.Text;
            if (cbGioiTinh.SelectedItem.ToString() == "Nam")
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            cmnd = txtCMND.Text.Trim();
            quequan = txtQueQuan.Text.Trim();
            nghenghiep = txtNgheNghiep.Text.Trim();
            maphong = lbMaPhong.Text.Trim();
            //tiendatcoc = (double)txtTienDatCoc.Text.Trim();
            
            //Them vao bang ThongTinKhach

            string sqlAddKhachInfo = "INSERT INTO ThongTinKhach(MaKhachTro,Ho,Ten,GioiTinh,NgaySinh,CMND,QueQuan,NgheNghiep,MaPhong) VALUES('"+makhach+"',N'"+ho+"',N'"+ten+"',N'"+gioitinh+"','"+ngaysinh+"','"+cmnd+"',N'"+quequan+"',N'"+nghenghiep+"','"+maphong+"')";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sqlAddKhachInfo);

            //Them vao bang ThongTinThuePhong
                //Lay thong tin
            PhongBUS tttp = new PhongBUS();
            string sql ="SELECT * From ThongTinThuePhong";
            int id_tttp = tttp.GetThongTinThuePhong(sql).Rows.Count + 1;
            string idtttp = id_tttp.ToString();
            string select_maphong = lbMaPhong.Text;
            string ngaythue = dtpNgayThue.Text;
                //INSERT vao SQL
            string sqlinsert = "INSERT INTO ThongTinThuePhong(MaHD, MaKhachTro, MaPhong, NgayThue) VALUES(@id, @makhachtro,@maphong,@ngaythue)";
            int i = new ThongTinThuePhongBUS().Insert(sqlinsert, idtttp, makhach, maphong, ngaythue);

             //Cap nhat
            
                //Cap nhat trang thai
            ThongTinThuePhongBUS update = new ThongTinThuePhongBUS();
            string sqlupdate = "UPDATE Phong SET TrangThai=@trangthai WHERE MaPhong='"+select_maphong+"'";
            update.Update(sqlupdate);
                //Refresh Form
            


            MessageBox.Show("Đã thêm thành công!");

            this.Close();
        }


        
        
        private void lstPhongTrong_Click(object sender, EventArgs e)
        {
            //ListViewItem item = new ListViewItem();
            //string maphong = lbMaPhong.Text;
            //string ten = lbTenPhong.Text;
            //string dongia = lbGia.Text;
            PhongBUS listphong = new PhongBUS();
            string maphong = lstPhongTrong.SelectedItems[0].Text;
            string sql1 = "SELECT p.TenPhong, lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaPhong=N'"+maphong+"'AND p.MaLoaiPhong = lp.MaLoaiPhong";
            var dsphong = listphong.GetThongTinThuePhong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string dongia = dsphong.Rows[0][1].ToString();

            lbMaPhong.Text = maphong;
            lbTenPhong.Text = tenphong;
            lbGia.Text = dongia;
            
        }

       
    }
}
