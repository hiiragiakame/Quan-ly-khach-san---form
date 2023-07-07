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
    public partial class frmNhomNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmNhomNguoiDung()
        {
            InitializeComponent();
        }
        frmQuanLyNguoiDung objQuanLyNguoiDung = (frmQuanLyNguoiDung)Application.OpenForms["frmQuanLyNguoiDung"];
        public String _maCongTy;
        public String _maDonVi;
        public int _maNhanVien;
        public String _tenDangNhap;
        public String _tenNhanVien;
        public bool _them;
        NhanVienBLL _nhanVien;
        NhanVien nv;
        NhomQuyenBLL _nhomQuyen;
        NhanVienTrongNhomBLL _nvTN;
        private void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _nhomQuyen = new NhomQuyenBLL();
            if (!_them)
            {
                var nv1 = _nhanVien.getItem(_maNhanVien);
                txtMoTa.Text = nv1.TenNhanVien;
                _maCongTy = nv1.MaCongTy;
                _maDonVi = nv1.MaDonVi;
                txtTenNhom.ReadOnly = true;
                loadNhanVienTrongNhom(_maNhanVien);
            }
            else
            {
                txtMoTa.Text = String.Empty;
                txtTenNhom.Text = String.Empty;
            }
        }
        public void loadNhanVienTrongNhom(int maNhom)
        {
            _nvTN = new NhanVienTrongNhomBLL();
            gcThanhVien.DataSource = _nvTN.getNhanVienTrongNhom(_maCongTy, _maDonVi, maNhom);
            gvThanhVien.OptionsBehavior.Editable = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNhom.Text.Trim() == String.Empty && _them)
            {
                MessageBox.Show("Vui lòng nhập tên nhóm không dấu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhom.SelectAll();
                txtTenNhom.Focus();
                return;
            }
            luuData();
        }
        void luuData()
        {
            if(_them)
            {
                bool ktNhanVien = _nhanVien.kiemtraTenDangNhapDaTonTaiChua(_maCongTy, _maDonVi, txtTenNhom.Text.Trim());
                if(ktNhanVien)
                {
                    MessageBox.Show("Nhóm đã tồn tại.\nVui lòng kiểm tra lại.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtTenNhom.SelectAll();
                    txtTenNhom.Focus();
                    return;
                }
                nv = new NhanVien();
                nv.TenDangNhap = txtTenNhom.Text.Trim();
                nv.TenNhanVien = txtMoTa.Text;
                nv.Nhom = true;
                nv.KhoaTaiKhoan = false;
                nv.MaCongTy = _maCongTy;
                nv.MaDonVi = _maDonVi;
                _nhanVien.add(nv);
            }
            else
            {
                nv = _nhanVien.getItem(_maNhanVien);
                nv.TenNhanVien = txtMoTa.Text;
                _nhanVien.update(nv);
            }
            objQuanLyNguoiDung.loadUser(_maCongTy, _maDonVi);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThanhVienNhom f = new frmThanhVienNhom();
            f._maNhomQuyen = _maNhanVien;
            f._maCongTy = _maCongTy;
            f._maDonVi = _maDonVi;
            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(gvThanhVien.GetFocusedRowCellValue("MaNhanVien") != null)
            {
                _nhomQuyen.delete(int.Parse(gvThanhVien.GetFocusedRowCellValue("MaNhanVien").ToString()), _maNhanVien);
                loadNhanVienTrongNhom(_maNhanVien);
            }
        }
    }
}