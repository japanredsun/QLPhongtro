﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class LoaiPhong
    {
        public string MaloaiPhong { get; set; }
        public string TenloaiPhong { get; set; }
        public float DienTichPhong { get; set; }
        public float DonGia { get; set; }
        public string GhiChu { get; set; }
        public LoaiPhong(string MaLoaiPhong, string TenLoaiPhong, float DienTichPhong, float DonGia, string GhiChu)
        {
            this.MaloaiPhong = MaloaiPhong;
            this.TenloaiPhong = TenloaiPhong;
            this.DienTichPhong = DienTichPhong;
            this.DonGia = DonGia;
            this.GhiChu = GhiChu;
        }
    }
}
