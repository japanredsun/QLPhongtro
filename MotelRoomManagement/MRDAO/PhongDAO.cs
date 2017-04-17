﻿using System;
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
            string id, kind, khuvuc, day, trangthai;
            int phongso;
            dp.Connect();
            try
            {
                SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                    id = dr.GetString(0);
                    kind = dr.GetString(1);
                    khuvuc = dr.GetString(2);
                    day = dr.GetString(3);
                    phongso = dr.GetInt32(4);
                    trangthai = dr.GetString(5);

                    Phong pro = new Phong(id, kind,khuvuc, day, phongso, trangthai);
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
            nodecha = dp.GetData("SELECT * FROM KhuVuc");
            return nodecha;
        }

        public DataTable GetCBPhong(string makv)
        {
            DataTable result = new DataTable();
            dp.Connect();
            result = dp.GetData("SELECT MaPhong, TenPhong From Phong Where MaKhuVuc='"+makv+"'");
            return result;
        }


        public DataTable GetDataTWChild(string where, string trangthai)
        {
            DataTable nodecon = new DataTable();
            dp.Connect();
            if (trangthai == "NoVacant")
            {
                nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Đã thuê'");
            }
            else
                nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Trống'");

            return nodecon;
        }

      
    }
}
