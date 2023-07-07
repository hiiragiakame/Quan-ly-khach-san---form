using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class PhongBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<Phong> getAll()
        {
            return db.Phongs.ToList();
        }
        public Phong getItem(int maPhong)
        {
            return db.Phongs.FirstOrDefault(t => t.MaPhong == maPhong);
        }
        public PhongDTO getItemFull(int maPhong)
        {
            Phong p = db.Phongs.FirstOrDefault(t => t.MaPhong == maPhong);
            PhongDTO phong = new PhongDTO();
            phong.MaPhong = p.MaPhong;
            phong.TenPhong = p.TenPhong;
            phong.TrangThai = p.TrangThai;
            phong.MaTang = p.MaTang;
            phong.MaLoaiPhong = p.MaLoaiPhong;
            LoaiPhong lp = db.LoaiPhongs.FirstOrDefault(t => t.MaLoaiPhong == phong.MaLoaiPhong);
            phong.DonGia = (double)lp.DonGia;
            return phong;
        }
        public List<Phong> getByTang(int maTang)
        {
            return db.Phongs.Where(t => t.MaTang == maTang).ToList();
        }
        public void add(Phong phong)
        {
            try
            {
                db.Phongs.InsertOnSubmit(phong);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(Phong phong)
        {
            Phong _phong = db.Phongs.FirstOrDefault(t => t.MaPhong == phong.MaPhong);
            _phong.TenPhong = phong.TenPhong;
            _phong.TrangThai = phong.TrangThai;
            _phong.MaTang = phong.MaTang;
            _phong.MaLoaiPhong = phong.MaLoaiPhong;
            _phong.Disabled = phong.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maPhong)
        {
            Phong _phong = db.Phongs.FirstOrDefault(t => t.MaPhong == maPhong);
            _phong.Disabled = true;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void updateStatus(int maPhong, bool b)
        {
            Phong _phong = db.Phongs.FirstOrDefault(t => t.MaPhong == maPhong);
            _phong.TrangThai = b;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public bool checkEmpty(int maPhong)
        {
            var p = db.Phongs.FirstOrDefault(t => t.MaPhong == maPhong);
            if (p.TrangThai == true)
                return true;
            return false;
        }
        public List<PhongDTO> getPhongTrongFull()
        {
            List<Phong> list = db.Phongs.Where(t => t.TrangThai == false).ToList();
            List<PhongDTO> lst = new List<PhongDTO>();
            foreach(var item in list)
            {
                PhongDTO phong = new PhongDTO();
                phong.MaPhong = item.MaPhong;
                phong.TenPhong = item.TenPhong;
                phong.TrangThai = item.TrangThai;
                phong.MaTang = item.MaTang;
                phong.MaLoaiPhong = item.MaLoaiPhong;
                LoaiPhong lp = db.LoaiPhongs.FirstOrDefault(t => t.MaLoaiPhong == phong.MaLoaiPhong);
                phong.DonGia = (double)lp.DonGia;
                lst.Add(phong);
            }
            return lst;
        }
    }
}
