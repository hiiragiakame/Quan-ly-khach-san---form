using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class NhanVienBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public NhanVien getItem(int maNhanVien)
        {
            return db.NhanViens.FirstOrDefault(t => t.MaNhanVien.Equals(maNhanVien));
        }
        public List<NhanVien> getAll()
        {
            return db.NhanViens.ToList();
        }
        public List<NhanVien> getnhanVienByMaDonVi(String maCongTy, String maDonVi)
        {
            return db.NhanViens.Where(t => t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi)).ToList();
        }
        public List<NhanVien> getnhanVienByMaDonVi_TinhNang(String maCongTy, String maDonVi)
        {
            return db.NhanViens.Where(t => t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi) && t.KhoaTaiKhoan == false).OrderByDescending(t => t.Nhom).ToList();
        }
        public NhanVien getNhanVienHienTai()
        {
            return db.NhanViens.FirstOrDefault(t => t.MaNhanVien == User.MaNhanVien);
        }
        public void add(NhanVien nv)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(NhanVien nv)
        {
            NhanVien _nv = db.NhanViens.FirstOrDefault(t => t.MaNhanVien.Equals(nv.MaNhanVien));
            _nv.TenNhanVien = nv.TenNhanVien;
            _nv.MatKhau = nv.MatKhau;
            _nv.MaCongTy = nv.MaCongTy;
            _nv.MaDonVi = nv.MaDonVi;
            _nv.Nhom = nv.Nhom;
            _nv.KhoaTaiKhoan = nv.KhoaTaiKhoan;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(String maNhanVien)
        {
            NhanVien _nv = db.NhanViens.FirstOrDefault(t => t.MaNhanVien.Equals(maNhanVien));
            _nv.KhoaTaiKhoan = true;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public bool kiemtraTenDangNhapDaTonTaiChua(String maCongTy, String maDonVi, String tenDangNhap)
        {
            var nv = db.NhanViens.FirstOrDefault(t => t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi) && t.TenDangNhap.Equals(tenDangNhap));
            return nv != null ? true : false;
        }
        public NhanVien GetNhanVien_TuCongTyDonViTenDangNhap(String maCongTy, String maDonVi, String tenDangNhap, String matKhau)
        {
            return db.NhanViens.FirstOrDefault(t => t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi) && t.TenDangNhap.Equals(tenDangNhap) && t.MatKhau.Equals(matKhau));
        }
    }
}
