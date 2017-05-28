using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MRDTO;

namespace MRDAO
{
    public class PhieuThuDAO
    {
        private DataProvider dp;
        public PhieuThuDAO()
        {
            dp = new DataProvider();
        }

        public int Insert(string sql, PhieuThu pt)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@mapt", pt.MaPhieu));
            paras.Add(new SqlParameter("@maphong", pt.MaPhong));
            paras.Add(new SqlParameter("@ngaylap", pt.NgayLap));           
            paras.Add(new SqlParameter("@tiennha", pt.TienNha));
            paras.Add(new SqlParameter("@skdien", pt.SoKiDien));
            paras.Add(new SqlParameter("@tiendien", pt.TienDien));
            paras.Add(new SqlParameter("@sknuoc", pt.SoKhoiNuoc));
            paras.Add(new SqlParameter("@tiennuoc", pt.TienNuoc));
            paras.Add(new SqlParameter("@tongtien", pt.TongTien));
            paras.Add(new SqlParameter("@trangthai", pt.TrangThai));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int XNDongTien(string sql,string id)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@ID", id));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
