using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MRDAO
{
    public class DataProvider
    {
        string cnStr = "";
        SqlConnection cn;

        public DataProvider()
        {
            cnStr = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            cn = new SqlConnection(cnStr);
        }
        public void Connect()
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
                cn.Close();
        }
        public SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //public void ExecuteScalar(string sql)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}
        public int ExecuteNonQuery(string sql, CommandType type, List<SqlParameter> paras)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                if (paras != null)
                {
                    foreach (SqlParameter para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        public int DExecuteNonQuery(string sql, CommandType type)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
