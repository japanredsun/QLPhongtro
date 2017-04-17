using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;

namespace MRDAO
{
    public class HoadonDAO
    {
        private DataProvider dp;

        public HoadonDAO()
        {
            dp = new DataProvider();
        }

        public DataTable GetInfo(string khuvuc)
        {
            DataTable result = new DataTable();
            dp.Connect();
            string strQuery = "SELECT MaHD,p.Day,p.TenPhong From ThongTinThuePhong tp, Phong p Where tp.MaPhong=p.MaPhong AND p.MaKhuVuc='" + khuvuc + "'";
            result = dp.GetData(strQuery);
            return result;
        }
    }
}
