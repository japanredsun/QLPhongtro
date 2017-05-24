using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;
namespace MRDAO
{
    public class ThongTinThuePhongDAO
    {
        DataProvider dp;
        public ThongTinThuePhongDAO()
        {
            dp = new DataProvider();
        }

        public int Insert_Tra_phong(string sql, TraPhong tp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id", tp.id));
            paras.Add(new SqlParameter("@makhach", tp.MaKhach));
            paras.Add(new SqlParameter("@maphong", tp.MaPhong));
            paras.Add(new SqlParameter("@ngaythue", tp.NgayThue));
            paras.Add(new SqlParameter("@ngaytra", tp.NgayTra));
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Insert(string sql, ThongTinThue ttp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id", ttp.MaHD));
            paras.Add(new SqlParameter("@makhachtro", ttp.MaKhachTro));
            paras.Add(new SqlParameter("@maphong", ttp.MaPhong));
            paras.Add(new SqlParameter("@ngaythue", ttp.NgayThue));
            paras.Add(new SqlParameter("@tiendatcoc", ttp.TienDatCoc));
            try
            {
                return(dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Delete(string sql, string maphong)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@maphong", maphong));
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        
        public int Update(string sql, string trangthai)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@trangthai",trangthai));
            try
	    {	        
		    return(dp.IExecuteNonQuery(sql,System.Data.CommandType.Text,paras));
	    }
	    catch (SqlException ex)
	    {
		
		    throw ex;
	    }
            }
    }
}
