using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MRDAO;
using MRDTO;

namespace MRBUS
{
    public class PhieuThuBUS
    {
        public int Insert(string sql, PhieuThu pt)
        {
            try
            {
                return new PhieuThuDAO().Insert(sql, pt);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
        public double newID()
        {
            var table = new PhongDAO().GetDataPhong("SELECT * From PhieuThu");
            table.PrimaryKey = new DataColumn[] { table.Columns["MaPT"] };
            double id_pt = table.Rows.Count + 1;            
            return id_pt;
        }
        public int XNDongTien(string id)
        {
            try
            {
                return (new PhieuThuDAO().XNDongTien(id));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
