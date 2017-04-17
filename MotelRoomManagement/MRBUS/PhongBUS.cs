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
    public class PhongBUS
    {
        public List<Phong> GetPhong(string sql)
        {
            try
            {
                List<Phong> tmp = new PhongDAO().GetPhong(sql);
                return tmp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
    }
}
