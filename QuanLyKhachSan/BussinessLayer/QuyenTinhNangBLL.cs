using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class QuyenTinhNangBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<QuyenTinhNang> getTinhNangByNhanVien(int maNhanVien)
        {
            return db.QuyenTinhNangs.Where(t => t.MaNhanVien == maNhanVien).OrderBy(t => t.SapXep).ToList();
        }
    }
}
