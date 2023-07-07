using BussinessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhachSan
{
    public partial class frmThanhVienNhom : DevExpress.XtraEditors.XtraForm
    {
        public frmThanhVienNhom()
        {
            InitializeComponent();
        }
        public String _maCongTy;
        public String _maDonVi;
        public int _maNhomQuyen;
        NhomQuyenBLL _nhomQuyen;
        NhanVienKhongTrongNhomBLL _nvKTN;

        frmNhomNguoiDung objNhomNguoiDung = (frmNhomNguoiDung)Application.OpenForms["frmNhomNguoiDung"];
        private void frmThanhVienNhom_Load(object sender, EventArgs e)
        {
            _nhomQuyen = new NhomQuyenBLL();
            _nvKTN = new NhanVienKhongTrongNhomBLL();
            loadNhanVienKhongTrongNhom();
        }
        void loadNhanVienKhongTrongNhom()
        {
            gcThanhVien.DataSource = _nvKTN.GetNhanVienKhongTrongNhom(_maCongTy, _maDonVi);
            gvThanhVien.OptionsBehavior.Editable = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhomQuyen nq = new NhomQuyen();
            nq.Nhom = _maNhomQuyen;
            nq.MaNhanVien = int.Parse(gvThanhVien.GetFocusedRowCellValue("MaNhanVien").ToString());
            _nhomQuyen.add(nq);
            loadNhanVienKhongTrongNhom();
            objNhomNguoiDung.loadNhanVienTrongNhom(_maNhomQuyen);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}