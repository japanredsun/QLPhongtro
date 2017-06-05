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
    public class DangNhapBUS
    {
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
        public int ChangePass(string id, string newPass)
        {
            try
            {
                return (new DangNhapDAO().ChangePass(id, newPass));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int ThemTK(string sql, DangNhap dn)
        {
            try
            {
                return (new DangNhapDAO().ThemTK(sql, dn));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
