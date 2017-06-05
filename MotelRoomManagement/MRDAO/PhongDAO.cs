using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using MRDTO;

namespace MRDAO
{
    public class PhongDAO
    {
        private DataProvider dp;

        public PhongDAO()
        {
            dp = new DataProvider();
        }
        public List<Phong> GetPhong(string sql)
        {
            List<Phong> list = new List<Phong>();
            string maphong, maloai, khuvuc, tenphong, day, trangthai;
            dp.Connect();
            try
            {
                SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                    maphong = dr.GetString(0);
                    maloai = dr.GetString(1);
                    khuvuc = dr.GetString(2);
                    tenphong = dr.GetString(3);
                    day = dr.GetString(4);
                    trangthai = dr.GetString(5);

                    Phong pro = new Phong(maphong, maloai, khuvuc, tenphong, day, trangthai);
                    list.Add(pro);
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

        public DataTable GetDataTW()
        {
            DataTable nodecha = new DataTable();
            dp.Connect();
            try
            {
                
                nodecha = dp.GetData("SELECT * FROM KhuVuc");
                return nodecha;
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

        public DataTable GetDataTWChild(string where, string trangthai)
        {
            DataTable nodecon = new DataTable();
            dp.Connect();
            try
            {
                
                if (trangthai == "NoVacant")
                {
                    nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Đã thuê'");
                }
                else
                    nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Trống'");

                return nodecon;
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
        public int themphong(string sql, string maphong, string maloai, string makhu, string tenphong, string day, string trangthai)
        {

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@maphong", maphong));
            paras.Add(new SqlParameter("@maloai", maloai));
            paras.Add(new SqlParameter("@makhu", makhu));
            paras.Add(new SqlParameter("@tenphong", tenphong));
            paras.Add(new SqlParameter("@day", day));
            paras.Add(new SqlParameter("@trangthai", trangthai));
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int themloaiphong(string sql, string maloaiphong, string tenloaiphong, double dientich, double gia)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@maloaiphong", maloaiphong));
            paras.Add(new SqlParameter("@tenloaiphong", tenloaiphong));
            paras.Add(new SqlParameter("@dientich", dientich));
            paras.Add(new SqlParameter("gia", gia));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int themdichvu(string sql, string id, string tendichvu, double gia)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id", id));
            paras.Add(new SqlParameter("@tendichvu", tendichvu));
            paras.Add(new SqlParameter("@gia", gia));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        public DataTable GetCBPhong(string makv)
        {
            DataTable result = new DataTable();
            dp.Connect();
            try
            {
                result = dp.GetData("SELECT MaPhong, TenPhong From Phong Where MaKhuVuc='" + makv + "'AND TrangThai=N'Đã thuê'");
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
        public DataTable GetDataPhong(string sql)
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

        public int XoaLoaiPhong(string sql)
        {
            try
            {
                return dp.DExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
       
    }
}
