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
    public class ThongTinDKBUS
    {
        public int Insert(string sql, int id, string ho, string ten, string gioitinh, string ngaysinh, string cmnd, string quequan, string nghenghiep, string makhuvuc, string maloaiphong)
        {
            try
            {
                return new ThongTinDKDAO().Insert(sql, id, ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep, makhuvuc, maloaiphong);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
        public DataTable GetThongTinDK(string sql)
        {
            try
            {
                DataTable result = new ThongTinDKDAO().GetDataThongTinDK(sql);
                return result;
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
    }
}
