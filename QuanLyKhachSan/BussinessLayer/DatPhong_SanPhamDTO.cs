using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DatPhong_SanPhamDTO
    {
        public int MaChiTietSanPham { get; set; }
        public int? MaSanPham { get; set; }
        public String TenSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public double? ThanhTien { get; set; }
        public int? MaPhong { get; set; }
        public String TenPhong { get; set; }
        public int? MaDatPhong { get; set; }
    }
}
