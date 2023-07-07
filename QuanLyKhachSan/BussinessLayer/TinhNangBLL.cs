using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class TinhNangBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        public List<TinhNang> getParent()
        {
            return db.TinhNangs.Where(t => t.IsGroup == true && t.Menu == true).OrderBy(y => y.SapXep).ToList();
        }
        public List<TinhNang> getChild(String parent)
        {
            return db.TinhNangs.Where(t => t.IsGroup == false && t.Menu == true && t.Parent == parent).OrderBy(y => y.SapXep).ToList();
        }
    }
}
