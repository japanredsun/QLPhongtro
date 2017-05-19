using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;
using MRDAO;

namespace MRBUS
{
    public class KhachThueBUS
    {
        public List<KhachThue> GetKhach_List(string sql)
        {
            try
            {
                List<KhachThue> result = new KhachThueDAO().GetKhachThue(sql);
                return result;
            }
            catch (SqlException ex)
            {
                
                throw ex ;
            }
        }


        public DataTable GetKhach(string maphong)
        {
            try
            {
                DataTable result = new KhachThueDAO().GetData(maphong);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Insert(string sql, string makhach, string ho, string ten, string gioitinh, string ngaysinh, string cmnd, string quequan, string nghenghiep, string maphong,string ghichu)
        {
            try
            {
                return new KhachThueDAO().Insert(sql, makhach, ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep, maphong,ghichu);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        
    }
}
