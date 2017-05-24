using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class TraPhong
    {
        public int id { get; set; }
        public string MaKhach { get; set; }
        public string MaPhong { get; set; }
        public DateTime NgayThue { get; set; }
        public DateTime NgayTra { get; set; }

        public TraPhong(int id, string makhach, string maphong, DateTime NgayThue, DateTime NgayTra)
        {
            this.id = id;
            this.MaKhach = makhach;
            this.MaPhong = maphong;
            this.NgayThue = NgayThue;
            this.NgayTra = NgayTra;
        }
    }
}
