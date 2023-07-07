using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SanPhamBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<SanPham> getAll()
        {
            return db.SanPhams.ToList();
        }
        public SanPham getItem(int maSanPham)
        {
            return db.SanPhams.FirstOrDefault(t => t.MaSanPham == maSanPham);
        }
        public void add(SanPham SanPham)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(SanPham);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(SanPham SanPham)
        {
            SanPham _SanPham = db.SanPhams.FirstOrDefault(t => t.MaSanPham == SanPham.MaSanPham);
            _SanPham.TenSanPham = SanPham.TenSanPham;
            _SanPham.DonGia = SanPham.DonGia;
            _SanPham.Disabled = SanPham.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maSanPham)
        {
            SanPham _SanPham = db.SanPhams.FirstOrDefault(t => t.MaSanPham == maSanPham);
            _SanPham.Disabled = true;
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
