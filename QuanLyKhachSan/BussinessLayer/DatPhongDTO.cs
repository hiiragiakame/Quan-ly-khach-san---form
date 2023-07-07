using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DatPhongDTO
    {
        public int MaDatPhong { get; set; }
        public int MaKhachHang { get; set; }
        public String TenKhachHang { get; set; }
        public DateTime? NgayDatPhong { get; set; }
        public DateTime? NgayTraPhong { get; set; }
        public double? SoTien { get; set; }
        public int? SoNguoiO { get; set; }
        public int? MaNhanVien { get; set; }
        public String MaCongTy { get; set; }
        public String MaDonVi { get; set; }
        public bool? TrangThai { get; set; }
        public bool? TheoDoan { get; set; }
        public bool Disabled { get; set; }
        public String GhiChu { get; set; }
    }
}
