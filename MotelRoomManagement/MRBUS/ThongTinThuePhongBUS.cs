﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MRDTO;
using MRDAO;
namespace MRBUS
{
    public class ThongTinThuePhongBUS
    {
        public int Insert(string sql, string tttp, string khachtro, string maphong, string ngaythue)
        {
            try
            {
                return new ThongTinThuePhongDAO().Insert(sql, tttp, khachtro, maphong, ngaythue);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }

        public DataTable GetKhach(string sql)
        {
            try 
	            {	        
		              DataTable result = new DataTable();
                       result = new PhongDAO().GetDataPhong(sql);
                        return result;
	            }
	            catch (SqlException ex)
	            {
		
		            throw ex;
	            }
                    }
        public int Update(string sql)
        {
            try
            {
                return new ThongTinThuePhongDAO().Update(sql, "Đã thuê");
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public string newID()
        {
            var table = new PhongDAO().GetDataPhong("SELECT * From ThongTinKhach");
            table.PrimaryKey = new DataColumn[] { table.Columns["MaKhachTro"] };
            int id_khach = table.Rows.Count + 1;
            string idkhach = "KT" + id_khach.ToString("000");
            for (int i = 1; i < table.Rows.Count; i++)
            {
                if (table.Rows.Find("KT"+i.ToString("000")) == null)
                    return ("KT" + i.ToString("000"));
            }
            return idkhach;
        }
    }

   
}
