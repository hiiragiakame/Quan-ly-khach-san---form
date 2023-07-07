using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DatPhong_SanPhamBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<DatPhong_SanPhamDTO> getAllByDatPhong(int _maDatPhong)
        {
            var list = db.DatPhong_SanPhams.Where(t => t.MaDatPhong == _maDatPhong).ToList();
            List<DatPhong_SanPhamDTO> listDPSP = new List<DatPhong_SanPhamDTO>();
            DatPhong_SanPhamDTO sp;
            foreach(var item in list)
            {
                sp = new DatPhong_SanPhamDTO();
                sp.MaChiTietSanPham = item.MaChiTietSanPham;
                sp.MaDatPhong = item.MaDatPhong;
                sp.MaPhong = item.MaPhong;
                var p = db.Phongs.FirstOrDefault(t => t.MaPhong == item.MaPhong);
                sp.TenPhong = p.TenPhong;
                sp.MaSanPham = item.MaSanPham;
                var s = db.SanPhams.FirstOrDefault(t => t.MaSanPham == item.MaSanPham);
                sp.TenSanPham = s.TenSanPham;
                sp.SoLuong = item.SoLuong;
                sp.DonGia = item.DonGia;
                sp.ThanhTien = item.ThanhTien;
                listDPSP.Add(sp);
            }
            return listDPSP;
        }
        public List<DatPhong_SanPham> getAllByPhong(int _maDatPhong, int _maChiTietDatPhong)
        {
            return db.DatPhong_SanPhams.Where(t => t.MaDatPhong == _maDatPhong && t.MaChiTietDatPhong == _maChiTietDatPhong).ToList();
        }
        public void add(DatPhong_SanPham dpsp)
        {
            try
            {
                db.DatPhong_SanPhams.InsertOnSubmit(dpsp);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(DatPhong_SanPham dpsp)
        {
            DatPhong_SanPham sp = db.DatPhong_SanPhams.FirstOrDefault(t => t.MaChiTietSanPham == dpsp.MaChiTietSanPham);
            sp.MaDatPhong = dpsp.MaDatPhong;
            sp.MaPhong = dpsp.MaPhong;
            sp.SoLuong = dpsp.SoLuong;
            sp.Ngay = dpsp.Ngay;
            sp.DonGia = dpsp.DonGia;
            sp.ThanhTien = dpsp.ThanhTien;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void deleteAll( int maDatPhong)
        {
            List<DatPhong_SanPham> listDPSP = db.DatPhong_SanPhams.Where(t => t.MaDatPhong == maDatPhong).ToList();
            try
            {
                db.DatPhong_SanPhams.DeleteAllOnSubmit(listDPSP);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void deleteAllByPhong(int maDatPhong, int maPhong)
        {
            List<DatPhong_SanPham> listDPSP = db.DatPhong_SanPhams.Where(t => t.MaDatPhong == maDatPhong && t.MaPhong == maPhong).ToList();
            try
            {
                db.DatPhong_SanPhams.DeleteAllOnSubmit(listDPSP);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
    }
}
