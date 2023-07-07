using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class QuyenBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public Quyen getQuyen(int maNhanVien, String maTinhNang)
        {
            return db.Quyens.FirstOrDefault(t => t.MaNhanVien == maNhanVien && t.MaTinhNang.Equals(maTinhNang));
        }
        public void update(int maNhanVien, String maTinhNang, int quyen)
        {
            Quyen q = db.Quyens.FirstOrDefault(t => t.MaNhanVien == maNhanVien && t.MaTinhNang == maTinhNang);
            try
            {
                q.Quyen1 = quyen;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lối khi xử lý dữ liệu: " + ex.Message);
            }
        }
    }
}
