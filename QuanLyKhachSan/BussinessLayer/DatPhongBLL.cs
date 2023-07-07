using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DatPhongBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<DatPhong> getAll()
        {
            return db.DatPhongs.ToList();
        }
        public List<DatPhongDTO> getAll(DateTime ngayBatDau, DateTime ngayKetThuc, String maCongTy, String maDonVi)
        {
            var listDP = db.DatPhongs.Where(t => t.NgayDatPhong >= ngayBatDau && t.NgayDatPhong < ngayKetThuc && t.MaCongTy.Equals(maCongTy) && t.MaDonVi.Equals(maDonVi) && t.TrangThai == false).ToList();
            List<DatPhongDTO> list = new List<DatPhongDTO>();
            DatPhongDTO dp;
            foreach(var item in listDP)
            {
                dp = new DatPhongDTO();
                dp.MaDatPhong = item.MaDatPhong;
                dp.MaKhachHang = int.Parse(item.MaKhachHang.ToString());
                dp.TenKhachHang = item.KhachHang.TenKhachHang;
                dp.MaNhanVien = item.MaNhanVien;
                dp.NgayDatPhong = item.NgayDatPhong;
                dp.NgayTraPhong = item.NgayTraPhong;
                dp.MaCongTy = item.MaCongTy;
                dp.MaDonVi = item.MaDonVi;
                dp.SoNguoiO = item.SoNguoiO;
                dp.SoTien = item.SoTien;
                dp.TrangThai = item.TrangThai;
                dp.TheoDoan = item.TheoDoan;
                dp.GhiChu = item.GhiChu;
                list.Add(dp);
            }
            return list;
        }
        public DatPhong getItem(int maDatPhong)
        {
            return db.DatPhongs.FirstOrDefault(t => t.MaDatPhong == maDatPhong);
        }
        public DatPhong add(DatPhong DatPhong)
        {
            try
            {
                db.DatPhongs.InsertOnSubmit(DatPhong);
                db.SubmitChanges();
                return DatPhong;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void updateStatus(int maDatPhong)
        {
            DatPhong _DatPhong = db.DatPhongs.FirstOrDefault(t => t.MaDatPhong == maDatPhong);
            _DatPhong.TrangThai = true;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public DatPhong update(DatPhong DatPhong)
        {
            DatPhong _DatPhong = db.DatPhongs.FirstOrDefault(t => t.MaDatPhong == DatPhong.MaDatPhong);
            _DatPhong.MaKhachHang = DatPhong.MaKhachHang;
            _DatPhong.MaCongTy = DatPhong.MaCongTy;
            _DatPhong.MaDonVi = DatPhong.MaDonVi;
            _DatPhong.NgayDatPhong = DatPhong.NgayDatPhong;
            _DatPhong.NgayTraPhong = DatPhong.NgayTraPhong;
            _DatPhong.SoNguoiO = DatPhong.SoNguoiO;
            _DatPhong.SoTien = DatPhong.SoTien;
            _DatPhong.MaNhanVien = DatPhong.MaNhanVien;
            _DatPhong.Disabled = DatPhong.Disabled;
            _DatPhong.TheoDoan = DatPhong.TheoDoan;
            _DatPhong.GhiChu = DatPhong.GhiChu;
            _DatPhong.NgayTao = DatPhong.NgayTao;
            try
            {
                db.SubmitChanges();
                return DatPhong;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maDatPhong)
        {
            DatPhong _DatPhong = db.DatPhongs.FirstOrDefault(t => t.MaDatPhong == maDatPhong);
            _DatPhong.Disabled = true;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
    }
}
