using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class TrangThaiBLL
    {
        public bool _value { get; set; }
        public String _display { get; set; }
        public TrangThaiBLL()
        {

        }
        public TrangThaiBLL(bool _val, String _dis)
        {
            this._value = _val;
            this._display = _dis;
        }
        public static List<TrangThaiBLL> getList()
        {
            List<TrangThaiBLL> list = new List<TrangThaiBLL>();
            TrangThaiBLL[] collect = new TrangThaiBLL[2]
            {
                new TrangThaiBLL(false,"Chưa hoàn tất"),
                new TrangThaiBLL(true,"Đã Hoàn tất")
            };
            list.AddRange(collect);
            return list;
        }
    }
}
