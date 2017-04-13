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
    class KhachTroBUS
    {
        public List<KhachTro> GetKhachTro(string sql)
        {
            try
            {
                List<KhachTro> tmp = new List<KhachTro>();
                return tmp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
