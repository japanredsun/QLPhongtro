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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetPhong();
        }
        private List<Phong> GetPhong()
        {
            string sql = "SELECT * FROM Phong";
            List<Phong> tmp = new PhongBUS().GetPhong(sql);
            return tmp;
        }
    }
}
