using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class KhachTro
    {
        public String ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Image { get; set; }
        public String Birthday { get; set; }
        public int CMND { get; set; }
        public String QueQuan { get; set; }
        public String Job { get; set; }
        public String RoomID { get; set; }
        public String Notes { get; set; }
        public KhachTro(String ID, String FirstName, String LastName, String Image, String Birthday, int CMND, String QueQuan, String Job, String RoomID, String Notes)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Image = Image;
            this.Birthday = Birthday;
            this.CMND = CMND;
            this.QueQuan = QueQuan;
            this.Job = Job;
            this.RoomID = RoomID;
            this.Notes = Notes;
        }
    }
}
