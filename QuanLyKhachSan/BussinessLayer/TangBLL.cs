using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class TangBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<Tang> getAll()
        {
            return db.Tangs.ToList();
        }
        public Tang getItem(int maTang)
        {
            return db.Tangs.FirstOrDefault(t => t.MaTang == maTang);
        }
        public List<Tang> getAll(int maTang)
        {
            return db.Tangs.Where(t => t.MaTang == maTang).ToList();
        }
        public void add(Tang t)
        {
            try
            {
                db.Tangs.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(Tang t)
        {
            Tang _t = db.Tangs.FirstOrDefault(x => x.MaTang == t.MaTang);
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
        public void delete(int maTang)
        {
            Tang _t = db.Tangs.FirstOrDefault(t => t.MaTang == maTang);
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
