using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class NhanVienTrongNhomBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<NhanVienTrongNhom> getNhanVienTrongNhom(String maCongTy, String maDonVi, int maNhom)
        {
            return db.NhanVienTrongNhoms.Where(t => t.MaDonVi.Equals(maDonVi) && t.MaCongTy.Equals(maCongTy) && t.Nhom == false && t.KhoaTaiKhoan == false && t.MaNhom == maNhom).ToList();
        }
        public List<NhanVien> getNhomQuyenByNhanVien(String maCongTy, String maDonVi, int maNhanVien)
        {
            List<NhanVien> lstNhom = new List<NhanVien>();
            List<NhanVienTrongNhom> lst = db.NhanVienTrongNhoms.Where(t => t.MaNhanVien == maNhanVien && t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi)).ToList();
            NhanVien user;
            foreach(var item in lst)
            { 
                user = new NhanVien();
                user = db.NhanViens.FirstOrDefault(t => t.MaNhanVien == item.MaNhom);
                lstNhom.Add(user);
            }
            return lstNhom;
        }
        public List<NhanVien> getNhomByDonVi(String maCongTy, String maDonVi)
        {
            return db.NhanViens.Where(t => t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi) && t.Nhom == true).ToList();
        }
        public bool checkGroupByUser(int maNhanVien, int maNhomQuyen)
        {
            return db.NhomQuyens.FirstOrDefault(t => t.MaNhanVien == maNhanVien && t.Nhom == maNhomQuyen) == null ? false : true;
        }
        public List<NhanVien> getNhomQuyenByNhanVien_NotIn(String maCongTy, String maDonVi, int maNhanVien)
        {
            List<NhanVien> lstNhom = new List<NhanVien>();
            List<NhanVien> lstAllGroup = db.NhanViens.Where(t => t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi) && t.Nhom == true).ToList();
            List<NhanVienTrongNhom> lst = db.NhanVienTrongNhoms.Where(t => t.MaNhanVien == maNhanVien && t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi)).ToList();
            NhanVien user;
            foreach (var item in lst)
            {
                user = new NhanVien();
                user = db.NhanViens.FirstOrDefault(t => t.MaNhanVien == item.MaNhom);
                lstNhom.Add(user);
            }
            return lstNhom;
        }
    }
}
