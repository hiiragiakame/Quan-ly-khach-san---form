using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ThietBiBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<ThietBi> getAll()
        {
            return db.ThietBis.ToList();
        }
        public ThietBi getItem(int maThietBi)
        {
            return db.ThietBis.FirstOrDefault(t => t.MaThietBi == maThietBi);
        }
        public List<ThietBi> getAll(int maThietBi)
        {
            return db.ThietBis.Where(t => t.MaThietBi == maThietBi).ToList();
        }
        public void add(ThietBi t)
        {
            try
            {
                db.ThietBis.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(ThietBi t)
        {
            ThietBi _t = db.ThietBis.FirstOrDefault(x => x.MaThietBi == t.MaThietBi);
            _t.Disabled = t.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maThietBi)
        {
            ThietBi _t = db.ThietBis.FirstOrDefault(t => t.MaThietBi == maThietBi);
            _t.Disabled = true;
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
