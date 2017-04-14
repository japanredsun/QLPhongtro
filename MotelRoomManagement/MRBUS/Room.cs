using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MRDAO;
using MRDTO;


namespace MRBUS
{
    public class Room
    {
        //hàm get data

        public DataTable GetData()
        {
            DataTable result = new DataTable();
            DataProvider dp = new DataProvider();
            string strQuery = "SELECT Ho +' '+ Ten AS [Họ và Tên]  FROM ThongTinKhach";
            result = dp.GetData(strQuery);
            return result;

        }

        public DataTable GetDataTW()
        {
            DataProvider dp = new DataProvider();
            DataTable nodecha = new DataTable();
            nodecha = dp.GetData("SELECT * FROM KhuVuc");
            return nodecha;
        }

        public DataTable GetDataTWChild(string where, string trangthai)
        {
            DataProvider dp = new DataProvider();
            DataTable nodecon = new DataTable();
            if (trangthai == "NoVacant")
            {
                nodecon = dp.GetData("SELECT MaPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Đã thuê'");
            }
            else
                nodecon = dp.GetData("SELECT MaPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Trống'");

            return nodecon;
        }

    }
}
