using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CongTyBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public CongTy getItem(String maCongTy)
        {
            return db.CongTies.FirstOrDefault(t => t.MaCongTy.Equals(maCongTy));
        }
        public List<CongTy> getAll()
        {
            return db.CongTies.ToList();
        }
        public void add(CongTy cty)
        {
            try
            {
                db.CongTies.InsertOnSubmit(cty);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(CongTy cty)
        {
            CongTy _cty = db.CongTies.FirstOrDefault(t => t.MaCongTy.Equals(cty.MaCongTy));
            _cty.TenCongTy = cty.TenCongTy;
            _cty.DienThoai = cty.DienThoai;
            _cty.Fax = cty.Fax;
            _cty.Email = cty.Email;
            _cty.DiaChi = cty.DiaChi;
            _cty.Disabled = cty.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(String maCongTy)
        {
            CongTy cty = db.CongTies.FirstOrDefault(t => (t.MaCongTy.Equals(maCongTy)));
            cty.Disabled = true;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public bool checkMaCongTy(String maCongTy)
        {
            return db.CongTies.FirstOrDefault(t => t.MaCongTy.Equals(maCongTy)) == null ? false : true;
        }
    }
}
