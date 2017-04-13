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
    public class KhachTroDAO
    {
        private DataProvider cusDp;

        public KhachTroDAO()
        {
            cusDp = new DataProvider();
        }
        public List<KhachTro> GetKhachTro(String sql)
        {
            List<KhachTro> cusList = new List<KhachTro>();
            string id, firstname, lastname, image, birthday, quequan, job, roomid, notes;
            int cmnd;
            cusDp.Connect();
            try
            {
                SqlDataReader cusDr = cusDp.ExecuteReader(sql);
                while (cusDr.Read())
                {
                    id = cusDr.GetString(0);
                    firstname = cusDr.GetString(1);
                    lastname = cusDr.GetString(2);
                    image = cusDr.GetString(3);
                    birthday = cusDr.GetString(4);
                    cmnd = cusDr.GetInt32(5);
                    quequan = cusDr.GetString(6);
                    job = cusDr.GetString(7);
                    roomid = cusDr.GetString(8);
                    notes = cusDr.GetString(9);

                    KhachTro cus = new KhachTro(id, firstname, lastname, image, birthday, cmnd, quequan, job, roomid, notes);
                    cusList.Add(cus);
                }
                return cusList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cusDp.Disconnect();
            }
        }
    }
}
