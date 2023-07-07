using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class NhomQuyenBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public NhomQuyen getGroupByNhanVien()
        {
            return db.NhomQuyens.FirstOrDefault(t => t.MaNhanVien == User.MaNhanVien);
        }
        public void add(NhomQuyen nhomQuyen)
        {
            try
            {
                db.NhomQuyens.InsertOnSubmit(nhomQuyen);
                db.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong qua trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void delete(int maNhanVien, int maNhomQuyen)
        {
            var nq = db.NhomQuyens.FirstOrDefault(t => t.MaNhanVien == maNhanVien && t.Nhom == maNhomQuyen);
            if(nq != null)
            {
                try
                {
                    db.NhomQuyens.DeleteOnSubmit(nq);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Có lỗi xảy ra trong qua trình xử lý dữ liệu." + ex.Message);
                }
            }
        }
    }
}
