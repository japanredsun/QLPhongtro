using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;

namespace MRDAO
{
    public class ThongTinDKDAO
    {
        DataProvider dp;
        public ThongTinDKDAO()
        {
            dp = new DataProvider();
        }

        public int Insert(string sql, KhachDangKy kdk)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id",kdk.Id));
            paras.Add(new SqlParameter("@ho",kdk.Ho));
            paras.Add(new SqlParameter("@ten",kdk.Ten));
            paras.Add(new SqlParameter("@gioitinh",kdk.GioiTinh));
            paras.Add(new SqlParameter("@ngaysinh",kdk.NgaySinh));
            paras.Add(new SqlParameter("@cmnd",kdk.CMND));
            paras.Add(new SqlParameter("@quequan",kdk.QueQuan));
            paras.Add(new SqlParameter("@nghenghiep",kdk.NgheNghiep));
            paras.Add(new SqlParameter("@makhuvuc", kdk.MaKhuVuc));
            paras.Add(new SqlParameter("@maloaiphong", kdk.MaLoaiPhong));

            try
            {
                return(dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

        ////public List<KhachDangKy> GetThongTinDK(string sql)
        ////{
        ////    List<KhachDangKy> list = new List<KhachDangKy>();
        ////    string ho, ten, gioitinh, cmnd, quequan, nghenghiep;
        ////    int id;
        ////    DateTime ngaysinh;
        ////    dp.Connect();
        ////    try
        ////    {
        ////        SqlDataReader dr = dp.ExecuteReader(sql);
        ////        while (dr.Read())
        ////        {
        ////            id = dr.GetInt32(0);
        ////            ho = dr.GetString(1);
        ////            ten = dr.GetString(2);
        ////            gioitinh = dr.GetString(3);
        ////            ngaysinh = dr.GetDateTime(4);
        ////            cmnd = dr.GetString(5);
        ////            quequan = dr.GetString(7);
        ////            nghenghiep = dr.GetString(7);

        ////            KhachDangKy khachdk = new KhachDangKy(id, ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep);
        ////            list.Add(khachdk);
        ////        }
        ////        return list;
        ////    }
        ////    catch (Exception)
        ////    {

        ////        throw;
        ////    }
        ////    finally
        ////    {
        ////        dp.Disconnect();
        ////    }

            public DataTable GetDataThongTinDK(string sql)
            {
                DataTable dt = new DataTable();
                dp.Connect();
                try
                {
                    dt = dp.GetData(sql);
                    return dt;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    dp.Disconnect();
                }
            }
        }
}
