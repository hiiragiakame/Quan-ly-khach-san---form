using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class KhachHangBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public KhachHang getItem(int maKhachHang)
        {
            return db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == maKhachHang);
        }
        public List<KhachHang> getAll()
        {
            return db.KhachHangs.ToList();
        }
        public List<KhachHang> getAll(int maKhachHang)
        {
            return db.KhachHangs.Where(t => t.MaKhachHang == maKhachHang).ToList();
        }
        public void add(KhachHang kh)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(KhachHang kh)
        {
            KhachHang _kh = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == kh.MaKhachHang);
            _kh.TenKhachHang = kh.TenKhachHang;
            _kh.DienThoai = kh.DienThoai;
            _kh.CCCD = kh.CCCD;
            _kh.Email = kh.Email;
            _kh.DiaChi = kh.DiaChi;
            _kh.Nam = kh.Nam;
            _kh.Disabled = kh.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maKhachHang)
        {
            KhachHang _kh = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == maKhachHang);
            _kh.Disabled = true;
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
