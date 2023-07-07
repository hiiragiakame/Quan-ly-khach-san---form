using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Phong_ThietBiBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<Phong_ThietBiDTO> getAll()
        {
            List<Phong_ThietBiDTO> list = new List<Phong_ThietBiDTO>();
            List<Phong_ThietBi> listptd = db.Phong_ThietBis.ToList();
            foreach(var item in listptd)
            {
                Phong_ThietBiDTO p = new Phong_ThietBiDTO();
                p.MaPhong = item.MaPhong;
                p.MaThietBi = item.MaThietBi;
                p.TenPhong = item.Phong.TenPhong;
                p.TenThietBi = item.ThietBi.TenThietBi;
                p.SoLuong = (int)item.SoLuong;
                list.Add(p);
            }
            return list;
        }
        public Phong_ThietBi getItem(int maPhong, int maThietBi)
        {
            return db.Phong_ThietBis.FirstOrDefault(t => t.MaPhong == maPhong && t.MaThietBi == maThietBi);
        }
        public void add(Phong_ThietBi t)
        {
            try
            {
                db.Phong_ThietBis.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(Phong_ThietBi t)
        {
            Phong_ThietBi _t = db.Phong_ThietBis.FirstOrDefault(x => x.MaPhong == t.MaPhong && x.MaThietBi == t.MaThietBi);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maPhong, int maThietBi)
        {
            Phong_ThietBi _t = db.Phong_ThietBis.FirstOrDefault(t => t.MaPhong == maPhong && t.MaThietBi == maThietBi);
            db.Phong_ThietBis.DeleteOnSubmit(_t);
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
