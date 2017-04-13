using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class DangNhap
    {
        public string ID { get; set; }
        public string PassWord { get; set; }
        public DangNhap(string ID, string PassWord)
        {
            this.ID = ID;
            this.PassWord = PassWord;
        }
    }
}
