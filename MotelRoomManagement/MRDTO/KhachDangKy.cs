using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class KhachDangKy
    {
        public int Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CMND { get; set; }
        public string QueQuan { get; set; }
        public string NgheNghiep { get; set; }
        public string MaKhuVuc { get; set; }
        public string MaLoaiPhong { get; set; }

        public KhachDangKy(int id, string ho, string ten, string gioitinh, DateTime ngaysinh, string cmnd, string quequan, string nghenghiep,string makhuvuc, string maloaiphong)
        {
            this.Id = id;
            this.Ho = ho;
            this.Ten = ten;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.CMND = cmnd;
            this.QueQuan = quequan;
            this.NgheNghiep = nghenghiep;
            this.MaKhuVuc = makhuvuc;
            this.MaLoaiPhong = maloaiphong;
        }
    }
}
