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
            khuvuc = cbKhuVuc.SelectedValue.ToString();
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "MaPhong";
            cbPhong.DataSource = cb.GetCBPhong(khuvuc);
            
        }

       

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maphong = cbPhong.SelectedValue.ToString();
            string sql = "SELECT p.MaPhong, TenPhong, NgayThue From Phong p , ThongTinThuePhong tp Where p.MaPhong='" + maphong + "'AND TrangThai=N'Đã thuê'";
            var phong = cb.GetDataPhong(sql);

            txtMaPhong.Text = maphong;
            txtTenPhong.Text = phong.Rows[0][1].ToString();
            string ngay = phong.Rows[0][2].ToString();
            DateTime dt = DateTime.ParseExact(ngay, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            string s = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtNgayThue.Text = s;
        }

        //finish combobox

    

    }
}
