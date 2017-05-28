using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class PhieuThu
    {
        public double MaPhieu { get; set; }
        public string MaPhong { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayThu { get; set; }  
        public int TienNha { get; set; }
        public int SoKiDien { get; set; }
        public int TienDien { get; set; }
        public int SoKhoiNuoc { get; set; }
        public int TienNuoc { get; set; }
        public int TongTien { get; set; }
        public string TrangThai { get; set; }

        public PhieuThu(double maphieu, string maphong, DateTime ngaylap,DateTime ngaythu, int tiennha, int skdien, int tiendien, int sknuoc, int tiennuoc, int tongtien, string trangthai)
        {
            this.MaPhieu = maphieu;
            this.MaPhong = maphong;
            this.NgayLap = ngaylap;
            this.NgayThu = ngaythu;
            this.TienNha = tiennha;
            this.SoKiDien = skdien;
            this.TienDien = tiendien;
            this.SoKhoiNuoc = sknuoc;
            this.TienNuoc = tiennuoc;
            this.TongTien = tongtien;
            this.TrangThai = trangthai;
        }
    }
}
