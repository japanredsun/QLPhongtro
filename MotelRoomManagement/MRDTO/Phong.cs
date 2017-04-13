using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class Phong
    {
        public string ID { get; set; }
        public string Kind { get; set; }
        public string KhuVuc { get; set; }
        public string Day { get; set; }
        public int Phongso { get; set; }
        public string Trangthai { get; set; }
        public Phong(string ID, string Kind,string KhuVuc, string Day, int Phongso, string Trangthai)
        {
            this.ID = ID;
            this.Kind = Kind;
            this.KhuVuc = KhuVuc;
            this.Day = Day;
            this.Phongso = Phongso;
            this.Trangthai = Trangthai;
        }
    }
}
