using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotelRoomManagement
{
    public partial class frmDSPhongReport : Form
    {
        public frmDSPhongReport()
        {
            InitializeComponent();
        }

        private void frmDSPhongReport_Load(object sender, EventArgs e)
        {
            this.phongTableAdapter1.Fill(this.dSPhong.Phong);
            this.reportViewer1.RefreshReport();
        }
    }
}
