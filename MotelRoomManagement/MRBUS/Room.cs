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
    public class Room
    {
        //hàm get data

        //public DataTable GetData(string maphong)
        //{
        //    DataTable result = new DataTable();
        //    DataProvider dp = new DataProvider();
        //    string strQuery = "Select Ho + ' ' + Ten AS [Họ và tên] From ThongTinKhach ,ThongTinThuePhong Where ThongTinKhach.MaKhachTro = ThongTinThuePhong.MaKhachTro AND ThongTinThuePhong.MaPhong='" + maphong + "'";
        //    result = dp.GetData(strQuery);
        //    return result;

        //}

        //public DataTable GetDataTW()
        //{
        //    DataProvider dp = new DataProvider();
        //    DataTable nodecha = new DataTable();
        //    nodecha = dp.GetData("SELECT * FROM KhuVuc");
        //    return nodecha;
        //}

        //public DataTable GetDataTWChild(string where, string trangthai)
        //{
        //    DataProvider dp = new DataProvider();
        //    DataTable nodecon = new DataTable();
        //    if (trangthai == "NoVacant")
        //    {
        //        nodecon = dp.GetData("SELECT MaPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Đã thuê'");
        //    }
        //    else
        //        nodecon = dp.GetData("SELECT MaPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Trống'");

        //    return nodecon;
        //}

        public DataTable GetData(string maphong)
        {
            try
            {
                DataTable result = new PhongDAO().GetData(maphong);
                return result;
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetDataTW()
        {
            try
            {
                DataTable nodecha = new PhongDAO().GetDataTW();
                return nodecha;
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetDataTWChild(string where, string trangthai)
        {
            try
            {
                DataTable nodecon = new PhongDAO().GetDataTWChild(where, trangthai);
                return nodecon;
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

    }
}
