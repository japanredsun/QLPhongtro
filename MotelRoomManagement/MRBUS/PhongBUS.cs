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
        public List<GhiNho> getGN(string sql)
        {
            try
            {
                List<GhiNho> tmp = new DangNhapDAO().getGN(sql);
                return tmp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int Log(string sql, string id, string pass)
        {
            try
            {
                int x = new DangNhapDAO().Log(sql, id, pass);
                return x;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Save(string id, string pass)
        {
            try
            {
                return (new DangNhapDAO().Save(id, pass));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Xoa()
        {
            try
            {
                return (new DangNhapDAO().Xoa());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int themphong(string sql, string maphong, string maloai, string makhu, string tenphong, string day, string trangthai)
        {
            try
            {
                return (new PhongDAO().themphong(sql, maphong, maloai, makhu, tenphong, day, trangthai));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int themloaiphong(string sql, string maloaiphong, string tenloaiphong, double dientich, double gia)
        {
            try
            {
                return (new PhongDAO().themloaiphong(sql, maloaiphong, tenloaiphong, dientich, gia));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataTable GetPhongTrong(string sql)
        {
            try
            {
                DataTable result = new PhongDAO().GetDataPhong(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataTable GetThongTinThuePhong(string sql)
        {
            try
            {
                DataTable result = new PhongDAO().GetDataPhong(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        
    }
}
