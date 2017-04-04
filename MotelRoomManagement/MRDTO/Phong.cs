using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class Phong
    {
        public String ID { get; set; }
        public String Kind { get; set; }
        public String Day { get; set; }
        public int Phongso { get; set; }
        public String Trangthai { get; set; }
        public Phong(String ID, String Kind, String Day, int Phongso, String Trangthai)
        {
            this.ID = ID;
            this.Kind = Kind;
            this.Day = Day;
            this.Phongso = Phongso;
            this.Trangthai = Trangthai;
        }
    }
}
