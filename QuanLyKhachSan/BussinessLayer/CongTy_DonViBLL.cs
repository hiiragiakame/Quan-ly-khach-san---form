using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CongTy_DonViBLL
    {
        KhachSanDataContext db = new KhachSanDataContext();
        //public CongTy_DonVi getCongTy_DonVi()
        //{
        //    return db.CongTy_DonVis.FirstOrDefault();
        //}
        String _maCongTy;
        String _maDonVi;
        
        public CongTy_DonViBLL(String maCongTy,String maDonVi)
        {
            this.MaCongTy = maCongTy;
            this.MaDonVi = maDonVi;
        }

        public string MaCongTy { get => _maCongTy; set => _maCongTy = value; }
        public string MaDonVi { get => _maDonVi; set => _maDonVi = value; }
    }
}
