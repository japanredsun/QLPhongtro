using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using MRDTO;

namespace MRDAO
{
    public class DangNhapDAO
    {
        private DataProvider dp;

        public DangNhapDAO()
        {
            dp = new DataProvider();
        }
        public int Log(string sql, string id, string pass)
        {
            dp.Connect();
            try
            {
                SqlConnection cn = new SqlConnection(@"Server = USER-PC\KDC; Database = QLPhongTro; Integrated Security = true;");
                cn.Open();
                SqlCommand cm = new SqlCommand(sql, cn);
                cm.Parameters.Add(new SqlParameter("@id", id));
                cm.Parameters.Add(new SqlParameter("@pw", pass));
                int x = (int)cm.ExecuteScalar();
                return x;
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
        public List<GhiNho> getGN(string sql)
        {
            List<GhiNho> list = new List<GhiNho>();
            string id, pass; 
            dp.Connect();
            try
            {
                SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                    id = dr.GetString(0);
                    pass = dr.GetString(1);

                    GhiNho gn = new GhiNho(id, pass);
                    list.Add(gn);
                }
                return list;
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
        public int Save(string id, string pass)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@ID", id));
            paras.Add(new SqlParameter("@Pass", pass));
            try
            {
                return (dp.ExecuteNonQuery("saveP", System.Data.CommandType.StoredProcedure, paras));
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
                return (dp.DExecuteNonQuery("Xoa", System.Data.CommandType.StoredProcedure));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
