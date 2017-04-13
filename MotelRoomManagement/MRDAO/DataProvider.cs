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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Data TreeView

        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }

        //Thêm, sửa ,xóa
        public int executeNonQuery(string sql)
        {
            int result = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery();
            return result;
        }

        //Trả về một đối tượng nào đó

        public object exeCuteScalarQuery(string sql)
        {
            object result = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            result = cmd.ExecuteScalar();
            return result;
        }

    }
}
