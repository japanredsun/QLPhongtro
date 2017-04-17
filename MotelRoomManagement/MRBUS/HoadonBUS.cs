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
    public class HoadonBUS
    {
        public DataTable GetInfo(string khuvuc)
        {
            try
            {
                DataTable dsHoaDon = new HoadonDAO().GetInfo(khuvuc);
                return dsHoaDon;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}

