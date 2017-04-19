﻿using System;
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