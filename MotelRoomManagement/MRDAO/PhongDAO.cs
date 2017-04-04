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
        public List<Phong> GetPhong(String sql)
        {
            List<Phong> list = new List<Phong>();
            string id, kind, day, trangthai;
            int phongso;
            dp.Connect();
            try
            {
                SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                    id = dr.GetString(0);
                    kind = dr.GetString(1);
                    day = dr.GetString(2);
                    phongso = dr.GetInt32(3);
                    trangthai = dr.GetString(4);

                    Phong pro = new Phong(id, kind, day, phongso, trangthai);
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
    }
}
