using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DonViBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public DonVi getItem(String maDonVi)
        {
            return db.DonVis.FirstOrDefault(t => t.MaDonVi.Equals(maDonVi));
        }
        public List<DonVi> getAll()
        {
            return db.DonVis.ToList();
        }
        public List<DonVi> getAll(String maCongTy)
        {
            return db.DonVis.Where(t => t.MaCongTy.Equals(maCongTy)).ToList();
        }
        public void add(DonVi dvi)
        {
            try
            {
                db.DonVis.InsertOnSubmit(dvi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void update(DonVi dvi)
        {
            DonVi _dvi = db.DonVis.FirstOrDefault(t => t.MaDonVi.Equals(dvi.MaDonVi));
            _dvi.TenDonVi = dvi.TenDonVi;
            _dvi.DienThoai = dvi.DienThoai;
            _dvi.Fax=dvi.Fax;
            _dvi.Email = dvi.Email;
            _dvi.DiaChi=dvi.DiaChi;
            _dvi.Disabled = dvi.Disabled;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(String maDonVi)
        {
            DonVi _dvi = db.DonVis.FirstOrDefault(t => t.MaDonVi.Equals(maDonVi));
            _dvi.Disabled = true;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public bool checkMaDonVi(String maDonVi)
        {
            return db.DonVis.FirstOrDefault(t => t.MaCongTy.Equals(maDonVi)) == null ? false : true;
        }
    }
}
