using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;

namespace MRDAO
{
    public class KhachThueDAO
    {
        private DataProvider dp;

        public KhachThueDAO()
        {
            dp = new DataProvider();
        }

        public List<KhachThue> GetKhachThue(string sql)
        {
            List<KhachThue> list = new List<KhachThue>();
            
            string makt, ho, ten, gioitinh, cmnd, quequan, nghenghiep, maphong, ghichu;
            DateTime ngaysinh;
            dp.Connect();
            try 
	            {	        
		            SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        makt = dr.GetString(0);
                        ho = dr.GetString(1);
                        ten = dr.GetString(2);
                        gioitinh = dr.GetString(3);
                        ngaysinh = dr.GetDateTime(5);
                        cmnd = dr.GetString(6);
                        quequan = dr.GetString(7);
                        nghenghiep = dr.GetString(8);
                        maphong = dr.GetString(9);
                        ghichu = dr.GetString(10);

                        KhachThue khach = new KhachThue(makt,ho,ten,gioitinh,ngaysinh,cmnd,quequan,nghenghiep,maphong,ghichu);
                        list.Add(khach);
                    }
                    return list;
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

        

        public DataTable GetData(string maphong)
        {
            try
            {
                DataTable result = new DataTable();
                dp.Connect();
                string strQuery = "Select ThongTinKhach.MaKhachTro AS [Mã khách], Ho + ' ' + Ten AS [Họ và tên], GioiTinh, CONVERT(varchar(10),NgaySinh,103),QueQuan,NgheNghiep From ThongTinKhach ,ThongTinThuePhong Where ThongTinKhach.MaKhachTro = ThongTinThuePhong.MaKhachTro AND ThongTinThuePhong.MaPhong='" + maphong + "'";
                result = dp.GetData(strQuery);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                dp.Disconnect();
            }
            
        }

        public int Insert(string sql, KhachThue kt)
        {

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@makhach", kt.MaKhachTro));
            paras.Add(new SqlParameter("@ho", kt.Ho));
            paras.Add(new SqlParameter("@ten", kt.Ten));
            paras.Add(new SqlParameter("@gioitinh", kt.GioiTinh));
            paras.Add(new SqlParameter("@ngaysinh", kt.NgaySinh));
            paras.Add(new SqlParameter("@cmnd", kt.CMND));
            paras.Add(new SqlParameter("@quequan", kt.QueQuan));
            paras.Add(new SqlParameter("@nghenghiep", kt.NgheNghiep));
            paras.Add(new SqlParameter("@maphong", kt.MaPhong));
            paras.Add(new SqlParameter("@ghichu", kt.GhiChu));
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

       
    }
}
