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
        string ten;
        DateTime ngaythue;
        double tiendatcoc;

        public frmHireRoom()
        {
            InitializeComponent();
        }

        private void frmHireRoom_Load(object sender, EventArgs e)
        {
            
        }

        private List<KhachThue> getKhachThue()
        {
            string sql = "SELECT * FROM ThongTinKhach";
            List<KhachThue> khach = new KhachThueBUS().GetKhach_List(sql);
            return khach;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstPhongTrong_Click(object sender, EventArgs e)
        {
            if (lstPhongTrong.SelectedItems.Count > 0)
            {
                ListViewItem phong = lstPhongTrong.SelectedItems[0];
                

            }
        }
    }
}
