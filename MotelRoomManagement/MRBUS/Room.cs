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

        public DataTable GetCBPhong(string makv)
        {
            try
            {
                DataTable result = new PhongDAO().GetCBPhong(makv);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataTable GetDataPhong(string sql)
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
