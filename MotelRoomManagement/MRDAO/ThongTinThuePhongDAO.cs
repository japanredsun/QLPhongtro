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

        public int Insert_Tra_phong(string sql, int id, string maphong, string makhach, string ngaythue, string ngaytra)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id", id));
            paras.Add(new SqlParameter("@makhach", makhach));
            paras.Add(new SqlParameter("@maphong", maphong));
            paras.Add(new SqlParameter("@ngaythue", ngaythue));
            paras.Add(new SqlParameter("@ngaytra", ngaytra));
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Insert(string sql, string tttp, string khachtro, string maphong, string ngaythue)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id", tttp));
            paras.Add(new SqlParameter("@makhachtro", khachtro));
            paras.Add(new SqlParameter("@maphong", maphong));
            paras.Add(new SqlParameter("@ngaythue", ngaythue));
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
