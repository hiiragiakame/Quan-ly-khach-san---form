using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class PhongDTO
    {
        public int MaPhong { get; set; }
        public String TenPhong { get; set; }
        public bool? TrangThai { get; set; }
        public int MaTang { get; set; }
        public int MaLoaiPhong { get; set; }
        public double DonGia { get; set; }
        public bool Disabled { get; set; }
    }
}
