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
    public partial class frmReportOption : Form
    {
        public frmReportOption()
        {
            InitializeComponent();
        }

        private void btnDSKT_Click(object sender, EventArgs e)
        {
            frmCustomerReport frmCR = new frmCustomerReport();
            frmCR.Show();
        }
    }
}
