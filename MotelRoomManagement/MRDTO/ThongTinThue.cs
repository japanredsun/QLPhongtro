using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class ThongTinThue
    {
        public string MaHD { get; set; }
        public string MaKhachTro { get; set; }
        public string MaPhong { get; set; }
        public DateTime NgayThue { get; set; }
        public int TienDatCoc { get; set; }
       

        public ThongTinThue(string mahd,string makhachtro, string maphong, DateTime ngaythue,int tiendatcoc)
        {
            this.MaHD=mahd;
            this.MaKhachTro=makhachtro;
            this.MaPhong=maphong;
            this.NgayThue=ngaythue;
            this.TienDatCoc = tiendatcoc;
        }


    }
}
