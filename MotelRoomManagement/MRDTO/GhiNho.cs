using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class GhiNho
    {
        public string ID { get; set; }
        public string pass { get; set; }
        public int aa { get; set; }
        public GhiNho(string ID, string pass, int aa)
        {
            this.ID = ID;
            this.pass = pass;
            this.aa = aa;
        }
    }
}
