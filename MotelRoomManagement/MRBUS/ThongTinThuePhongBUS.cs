using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MRDTO;
using MRDAO;
namespace MRBUS
{
    public class ThongTinThuePhongBUS
    {
        public int Insert(string sql, string tttp, string khachtro, string maphong, string ngaythue)
        {
            try
            {
                return new ThongTinThuePhongDAO().Insert(sql, tttp, khachtro, maphong, ngaythue);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetKhach(string sql)
        {
            try 
	            {	        
		              DataTable result = new DataTable();
                       result = new PhongDAO().GetDataPhong(sql);
                        return result;
	            }
	            catch (SqlException ex)
	            {
		
		            throw ex;
	            }
                    }
    }
}
