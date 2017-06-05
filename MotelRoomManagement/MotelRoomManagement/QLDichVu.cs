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
using System.Collections;

namespace MotelRoomManagement
{
    public partial class QLDichVu : Form
    {
        string id;
        int request;
        public QLDichVu()
        {
            InitializeComponent();
        }

        private void QLDichVu_Load(object sender, EventArgs e)
        {
            Load_datagrid();
        }

        private void Load_datagrid()
        {
            dgvQLDV.Rows.Clear();

            dgvQLDV.ColumnCount = 3;
            dgvQLDV.Columns[0].Name = "Mã dịch vụ";
            dgvQLDV.Columns[1].Name = "Tên dịch vụ";
            dgvQLDV.Columns[2].Name = "Đơn giá";

            string sql = "SELECT * From DichVu";
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                row.Add(dsphong.Rows[i][2].ToString());
                dgvQLDV.Rows.Add(row.ToArray());
            }

        }

        private void dgvQLDV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLDV.SelectedCells.Count > 0)
            {
                int index = dgvQLDV.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dgvQLDV.Rows[index];
                id = Convert.ToString(selectedrow.Cells["Mã dịch vụ"].Value);

                var data = new Room().GetDataPhong("SELECT * From DichVu WHERE Id='" + id + "'");
                txtID.Text = data.Rows[0][0].ToString();
                txtTDV.Text = data.Rows[0][1].ToString();
                txtDG.Text = data.Rows[0][2].ToString();
            }
        }

        private void disable_textbox()
        {
            txtID.Enabled = false; txtDG.Enabled = false; txtTDV.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            request = 1;
            txtID.Text = ""; txtTDV.Text = ""; txtDG.Text = "";
            txtID.Enabled = true; txtTDV.Enabled = true; txtDG.Enabled = true;
            btnLuu.Visible = true; btnHuy.Visible = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            request = 2;
            txtID.Enabled = true; txtTDV.Enabled = true; txtDG.Enabled = true;
            btnLuu.Visible = true; btnHuy.Visible = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dịch vụ: " + txtTDV.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE From DichVu WHERE Id='" + id + "'";
                int i = new PhongBUS().XoaLoaiPhong(sql);

                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_datagrid();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (request)
            {
                case 1:
                    {

                        //Them Loai Phong
                        string sql = "INSERT INTO DichVu (Id,TenDichVu,Gia) VALUES(@id,@tendichvu,@gia)";
                        string tendichvu = txtTDV.Text;
                        double gia = Convert.ToDouble(txtDG.Text);
                        int i = new PhongBUS().themdichvu(sql, id, tendichvu, gia);
                        MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Visible = false; btnHuy.Visible = false;
                        btnSua.Enabled = true; btnXoa.Enabled = true;
                        disable_textbox();
                        Load_datagrid();

                    }
                    break;
                case 2:
                    {

                        //SuaLoaiPhong

                        string sql = "UPDATE DichVu SET Id=@id, TenDichVu=@tendichvu,Gia=@gia WHERE Id='" + id + "'";
                        string ma = txtID.Text,
                            tendichvu = txtTDV.Text;
                        double gia = Convert.ToDouble(txtDG.Text);
                        int i = new PhongBUS().themdichvu(sql, ma, tendichvu, gia);
                        MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Visible = false; btnHuy.Visible = false;
                        btnThem.Enabled = true; btnXoa.Enabled = true;
                        disable_textbox();
                        Load_datagrid();

                    }
                    break;

                default:
                    break;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_datagrid();
            btnLuu.Visible = false; btnHuy.Visible = false;
            txtID.Enabled = false; txtTDV.Enabled = false; txtDG.Enabled = false;
            btnSua.Enabled = true; btnXoa.Enabled = true; btnThem.Enabled = true;
        }
      
    }
}
