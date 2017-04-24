using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using MRBUS;
using MRDTO;
namespace MotelRoomManagement
{
    public partial class frmTinhTien : Form
    {
        Room cb = new Room();
        string khuvuc;
     
        public frmTinhTien()
        {
            InitializeComponent();
        }

        private void frmTinhTien_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Load_Data()
        {
            //Combo Box Khu Vuc: 
            cbKhuVuc.DisplayMember = "TenKhuVuc";
            cbKhuVuc.ValueMember = "MaKhuVuc";
            cbKhuVuc.DataSource = cb.GetDataTW();
        }

        private void cbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Combo Box Phong: 
            khuvuc = cbKhuVuc.SelectedValue.ToString();
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "MaPhong";
            cbPhong.DataSource = cb.GetCBPhong(khuvuc);
            
        }

       

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //Load Thong Tin Phong Thue
            string maphong = cbPhong.SelectedValue.ToString();
            string sql = "SELECT p.MaPhong, TenPhong, NgayThue From Phong p , ThongTinThuePhong tp Where p.MaPhong='" + maphong + "'AND TrangThai=N'Đã thuê' AND p.MaPhong=tp.MaPhong";
            var phong = cb.GetDataPhong(sql);

            txtMaPhong.Text = maphong;
            txtTenPhong.Text = phong.Rows[0][1].ToString();
            string ngay= phong.Rows[0][2].ToString() ;
            //DateTime dt = DateTime.ParseExact(ngay, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //string s = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            //txtNgayThue.Text = s;
            dtNgayThue.Text = ngay;

            //Load Thong Tin Chu Thue
            string sqlkhach = "SELECT tp.MaKhachTro, Ho +' '+ Ten AS HoTen FROM ThongTinThuePhong tp, ThongTinKhach ttk WHERE tp.MaKhachTro = ttk.MaKhachTro AND tp.MaPhong='"+maphong+"'";
            var khach = cb.GetDataPhong(sqlkhach);

            //combobox Ten Chu Thue
            txtSoluong.Text = khach.Rows.Count.ToString();
            cbMaKhachThue.DisplayMember = "HoTen";
            cbMaKhachThue.ValueMember = "MaKhachTro";
            cbMaKhachThue.DataSource = khach ;

        }

        private void cbMaKhachThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load chi tiet thong tin khach
            string makhach = cbMaKhachThue.SelectedValue.ToString();
            string sql = "SELECT CMND, NgheNghiep, QueQuan FROM ThongTinKhach WHERE MaKhachTro='"+makhach+"'";
            var thongtinkhach = cb.GetDataPhong(sql);

            txtCMND.Text = thongtinkhach.Rows[0][0].ToString();
            txtNN.Text = thongtinkhach.Rows[0][1].ToString();
            txtNS.Text = thongtinkhach.Rows[0][2].ToString();

        }

     

        //finish combobox

        private void rdSoNguoi_CheckedChanged(object sender, EventArgs e)
        {
            pSoNguoi.Visible = true;
        }

        private void rdNuoc_CheckedChanged(object sender, EventArgs e)
        {
            pSoNguoi.Visible = false;
        }

    }
}
