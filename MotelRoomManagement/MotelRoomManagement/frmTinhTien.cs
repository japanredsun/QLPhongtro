using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            cbPhong.SelectedIndex = -1;
        }

        private void cbPhong_DropDown(object sender, EventArgs e)
        {
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "MaPhong";
            cbPhong.DataSource = cb.GetCBPhong(khuvuc);
        }

        //finish combobox

      

    }
}
