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
    public partial class frmDanhSachNhom : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhom()
        {
            InitializeComponent();
        }
        public String _maCongTy;
        public String _maDonVi;
        public int _maNhanVien;
        NhomQuyenBLL _nhomQuyen;
        NhanVienTrongNhomBLL _nvTN;

        frmNhanVien objNhanVien = (frmNhanVien)Application.OpenForms["frmNhanVien"];
        private void frmDanhSachNhom_Load(object sender, EventArgs e)
        {
            _nhomQuyen = new NhomQuyenBLL();
            _nvTN = new NhanVienTrongNhomBLL();
            loadNhomQuyen();
        }
        void loadNhomQuyen()
        {
            gcNhom.DataSource = _nvTN.getNhomByDonVi(_maCongTy, _maDonVi);
            gvNhom.OptionsBehavior.Editable = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_nvTN.checkGroupByUser(_maNhanVien, int.Parse(gvNhom.GetFocusedRowCellValue("MaNhanVien").ToString())))
            {
                MessageBox.Show("Nhân viên đã tồn tại trong nhóm.\nVui lòng chọn nhóm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NhomQuyen nq = new NhomQuyen();
            nq.Nhom = int.Parse(gvNhom.GetFocusedRowCellValue("MaNhanVien").ToString());
            nq.MaNhanVien = _maNhanVien;
            _nhomQuyen.add(nq);
            objNhanVien.loadNhomQuyenByNhanVien(_maNhanVien);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}