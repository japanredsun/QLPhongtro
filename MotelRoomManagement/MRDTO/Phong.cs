using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class Phong
    {
        public string maphong { get; set; }
        public string maloai { get; set; }
        public string KhuVuc { get; set; }
        public string tenphong { get; set; }
        public string Day { get; set; }
        public string Trangthai { get; set; }
        public Phong(string maphong, string maloai, string KhuVuc, string tenphong, string Day, string Trangthai)
        {
            this.maphong = maphong;
            this.maloai = maloai;
            this.KhuVuc = KhuVuc;
            this.tenphong = tenphong;
            this.Day = Day;
            this.Trangthai = Trangthai;
        }
    }
}
