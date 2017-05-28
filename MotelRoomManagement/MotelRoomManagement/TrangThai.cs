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
    public partial class TrangThai : UserControl
    {
        public TrangThai()
        {
            InitializeComponent();
        }

   

        private void TrangThai_Load(object sender, EventArgs e)
        {
            Load_Data_TreeView1();
            Load_Data_TreeView2();
            Load_CB_KV();
        }

        public void Load_CB_KV()
        {   
            //Load ComboBox Khu Vuc
            Room _CbData = new Room();
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DataSource = _CbData.GetDataTW();
            

        }
        //Load du lieu
        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Room _CbData = new Room();
            string makv = cbKV.SelectedValue.ToString();
            var phongtrong = _CbData.GetDataTWChild(makv, "Vacant");
            var phongdathue = _CbData.GetDataTWChild(makv, "NoVacant");
            numTrong.Text = phongtrong.Rows.Count.ToString();
            numRent.Text = phongdathue.Rows.Count.ToString();
        }

        private void Load_Data_TreeView1()
        {
            Room _TW = new Room();
            treeView1.ImageList = TwImgList;
            for (int i = 0; i < _TW.GetDataTW().Rows.Count; i++)
            {
                string item_TenKV = _TW.GetDataTW().Rows[i][1].ToString();
                string item_MaKV = _TW.GetDataTW().Rows[i][0].ToString();
                TreeNode nodecha = treeView1.Nodes.Add(item_TenKV);
                treeView1.Nodes[i].Tag = "1";
                nodecha.ImageIndex = 0;
                for (int j = 0; j < _TW.GetDataTWChild(item_MaKV, "NoVacant").Rows.Count; j++)
                {
                    TreeNode nodecon = treeView1.Nodes[i].Nodes.Add(_TW.GetDataTWChild(item_MaKV, "NoVacant").Rows[j][1].ToString());
                    treeView1.Nodes[i].Nodes[j].Tag = "2";
                    treeView1.Nodes[i].Nodes[j].Name = _TW.GetDataTWChild(item_MaKV, "NoVacant").Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }


            } 
        }

        private void Load_Data_TreeView2()
        {
            Room _TW2 = new Room();
            treeView2.ImageList = TwImgList;
            for (int i = 0; i < _TW2.GetDataTW().Rows.Count; i++)
            {
                string item_MaKV = _TW2.GetDataTW().Rows[i][0].ToString();
                string item_TenKV = _TW2.GetDataTW().Rows[i][1].ToString();

                TreeNode nodecha = treeView2.Nodes.Add(item_TenKV);
                treeView2.Nodes[i].Tag = "1";
                nodecha.ImageIndex = 0;
                for (int j = 0; j < _TW2.GetDataTWChild(item_MaKV, "Vacant").Rows.Count; j++)
                {
                    TreeNode nodecon = treeView2.Nodes[i].Nodes.Add(_TW2.GetDataTWChild(item_MaKV, "Vacant").Rows[j][1].ToString());
                    treeView2.Nodes[i].Nodes[j].Tag = "2";
                    treeView2.Nodes[i].Nodes[j].Name = _TW2.GetDataTWChild(item_MaKV, "Vacant").Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }

            } 
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            listKhach.Items.Clear();
            TreeNode theNode = this.treeView1.SelectedNode;
            KhachThueBUS _ListKT = new KhachThueBUS();
            if (theNode.Tag.ToString() == "2")
            {
                panel2.Visible = false;
                string node = theNode.Name.ToString();
                var list_khach = _ListKT.GetKhach(node);

                for (int i = 0; i < list_khach.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(list_khach.Rows[i][0].ToString());
                    if (list_khach.Rows[i][2].ToString() == "Nam") item.ImageIndex = 3; else item.ImageIndex = 2;
                    item.SubItems.Add(list_khach.Rows[i][1].ToString());
                    item.SubItems.Add(list_khach.Rows[i][3].ToString());
                    item.SubItems.Add(list_khach.Rows[i][4].ToString());
                    item.SubItems.Add(list_khach.Rows[i][5].ToString());
                    listKhach.Items.Add(item);
                }
            }      
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listKhach.Items.Clear();

            Room p = new Room();
            TreeNode theNode = this.treeView2.SelectedNode;
            string dkphong = theNode.Name.ToString();
            var ttp = p.GetDataPhong("SELECT TenLoaiPhong, DienTichPhong, DonGia FROM LoaiPhong lp, Phong p WHERE p.MaLoaiPhong=lp.MaLoaiPhong AND p.MaPhong='"+dkphong+"'");
              if (theNode.Tag.ToString() == "2")
            {
                label1.Text = dkphong;
                lbLoaiPhong.Text = ttp.Rows[0][0].ToString();
                lbDienTich.Text = ttp.Rows[0][1].ToString();
                lbgia.Text = ttp.Rows[0][2].ToString();
                panel2.Visible = true;
            }
        }

        private void listKhach_Click(object sender, EventArgs e)
        {
            ListViewItem item = listKhach.SelectedItems[0];
            string id = item.Text;
            frmInformation frmInfo = new frmInformation(id);
            frmInfo.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            listKhach.Items.Clear();
            Load_Data_TreeView1();
            Load_Data_TreeView2();
            panel2.Visible = false;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {

        }

        


        
    }
}
