using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ChiTietDatPhongBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<ChiTietDatPhong> getAll()
        {
            return db.ChiTietDatPhongs.ToList();
        }

        public List<ChiTietDatPhong> getAllByDatPhong(int maDatPhong)
        {
            return db.ChiTietDatPhongs.Where(t => t.MaDatPhong == maDatPhong).ToList();
        }
        public ChiTietDatPhong getIDDPByPhong(int maPhong)
        {
            return db.ChiTietDatPhongs.OrderByDescending(t => t.Ngay).FirstOrDefault(y => y.MaPhong == maPhong);
        }
        public ChiTietDatPhong getItem(int maChiTietDatPhong)
        {
            return db.ChiTietDatPhongs.FirstOrDefault(t => t.MaChiTietDatPhong == maChiTietDatPhong);
        }
        public ChiTietDatPhong getItem(int maDatPhong, int maPhong)
        {
            return db.ChiTietDatPhongs.FirstOrDefault(t => t.MaDatPhong == maDatPhong && t.MaPhong == maPhong);
        }
        public ChiTietDatPhong add(ChiTietDatPhong ChiTietDatPhong)
        {
            try
            {
                db.ChiTietDatPhongs.InsertOnSubmit(ChiTietDatPhong);
                db.SubmitChanges();
                return ChiTietDatPhong;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(ChiTietDatPhong ChiTietDatPhong)
        {
            ChiTietDatPhong _ChiTietDatPhong = db.ChiTietDatPhongs.FirstOrDefault(t => t.MaChiTietDatPhong == ChiTietDatPhong.MaChiTietDatPhong);
            _ChiTietDatPhong.MaDatPhong = ChiTietDatPhong.MaDatPhong;
            _ChiTietDatPhong.MaPhong = ChiTietDatPhong.MaPhong;
            _ChiTietDatPhong.MaChiTietDatPhong = ChiTietDatPhong.MaChiTietDatPhong;
            _ChiTietDatPhong.Ngay = ChiTietDatPhong.Ngay;
            _ChiTietDatPhong.DonGia = ChiTietDatPhong.DonGia;
            _ChiTietDatPhong.SoNgayO = ChiTietDatPhong.SoNgayO;
            _ChiTietDatPhong.ThanhTien = ChiTietDatPhong.ThanhTien;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maDatPhong, int maPhong)
        {
            ChiTietDatPhong _ChiTietDatPhong = db.ChiTietDatPhongs.FirstOrDefault(t => t.MaDatPhong == maDatPhong && t.MaPhong == maPhong);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void deleteAll(int maDatPhong)
        {
            List<ChiTietDatPhong> listDP = db.ChiTietDatPhongs.Where(t => t.MaDatPhong == maDatPhong).ToList();
            try
            {
                db.ChiTietDatPhongs.DeleteAllOnSubmit(listDP);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
    }
}
