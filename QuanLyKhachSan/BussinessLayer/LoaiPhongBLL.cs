using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class LoaiPhongBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<LoaiPhong> getAll()
        {
            return db.LoaiPhongs.ToList();
        }
        public LoaiPhong getItem(int maLoaiPhong)
        {
            return db.LoaiPhongs.FirstOrDefault(t => t.MaLoaiPhong == maLoaiPhong);
        }
        public List<LoaiPhong> getAll(int maLoaiPhong)
        {
            return db.LoaiPhongs.Where(t => t.MaLoaiPhong == maLoaiPhong).ToList();
        }
        public void add(LoaiPhong t)
        {
            try
            {
                db.LoaiPhongs.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(LoaiPhong t)
        {
            LoaiPhong _loaiPhong = db.LoaiPhongs.FirstOrDefault(x => x.MaLoaiPhong == t.MaLoaiPhong);
            _loaiPhong.Disabled = t.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maLoaiPhong)
        {
            LoaiPhong _loaiPhong = db.LoaiPhongs.FirstOrDefault(t => t.MaLoaiPhong == maLoaiPhong);
            _loaiPhong.Disabled = true;
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
