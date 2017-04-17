using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using MRDTO;
using MRBUS;

namespace MotelRoomManagement
{
    public partial class frmRoomManagement : Form
    {
        public frmRoomManagement()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmRoomManagement_Load(object sender, EventArgs e)
        {
            //string sql = "SELECT * FROM LoaiPhong";
            ////List<LoaiPhong> tmp = new LoaiPhongBUS().GetLoaiPhong(sql);
            //DataTable dt = new DataTable();
            //string cn = "Server = USER-PC\\SQL2008; Database = QLPhongTro; Integrated Security = true";
            //SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            //da.Fill(dt);
            
            LoaiPhongBUS _Data = new LoaiPhongBUS();
            DataTable da =  _Data.GetLoaiPhongDA();
            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "TenLoaiPhong";
            comboBox1.ValueMember = "MaLoaiPhong";
            
            string loaiphong = "1";
            LoaiPhongBUS dsphong = new LoaiPhongBUS();
            for (int i = 0; i < dsphong.GetLoaiPhongDA(loaiphong).Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][0].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][2].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][3].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][4].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][5].ToString());
                listView1.Items.Add(item);

            }
            //comboBox1.DataBindings.Add("Text", tmp, "MaLoaiPhong");
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string loaiphong = comboBox1.SelectedValue.ToString();
            LoaiPhongBUS dsphong = new LoaiPhongBUS();
            for (int i = 0; i < dsphong.GetLoaiPhongDA(loaiphong).Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][0].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][2].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][3].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][4].ToString());
                item.SubItems.Add(dsphong.GetLoaiPhongDA(loaiphong).Rows[i][5].ToString());
                listView1.Items.Add(item);   
            }
        }

        

        //private List<LoaiPhong> getLoaiPhong()
        //{
        //    string sql = "SELECT * FROM LoaiPhong";
        //    List<LoaiPhong> tmp = new LoaiPhongBUS().GetLoaiPhong(sql);
        //    return tmp;
        //}
    }
}
