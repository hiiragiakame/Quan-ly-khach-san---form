using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class NhanVienKhongTrongNhomBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<NhanVienKhongTrongNhom> GetNhanVienKhongTrongNhom(String _maCongTy, String _maDonVi)
        {
            return db.NhanVienKhongTrongNhoms.Where(t => t.MaDonVi.Equals(_maDonVi) && t.MaCongTy.Equals(_maCongTy) && t.Nhom == false && t.KhoaTaiKhoan == false).ToList();
        }
    }
}
