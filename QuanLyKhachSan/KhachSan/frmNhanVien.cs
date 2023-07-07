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
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
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
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _nhomQuyen = new NhomQuyenBLL();
            if (!_them)
            {
                var nv1 = _nhanVien.getItem(_maNhanVien);
                txtTenDangNhap.Text = nv1.TenDangNhap;
                txttenNhanVien.Text = nv1.TenNhanVien;
                chkKhoaTaiKhoan.Checked = nv1.KhoaTaiKhoan.Value;
                _maCongTy = nv1.MaCongTy;
                _maDonVi = nv1.MaDonVi;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.Text = nv1.MatKhau;
                txtXacNhanMatKhau.Text = nv1.MatKhau;
                loadNhomQuyenByNhanVien(_maNhanVien);
            }
            else
            {
                txttenNhanVien.Text = String.Empty;
                txtTenDangNhap.Text = String.Empty;
                txtMatKhau.Text = String.Empty;
                txtXacNhanMatKhau.Text = String.Empty;
                chkKhoaTaiKhoan.Checked = false;
            }
        }
        public void loadNhomQuyenByNhanVien(int maNhanVien)
        {
            _nvTN = new NhanVienTrongNhomBLL();
            gcThanhVien.DataSource = _nvTN.getNhomQuyenByNhanVien(_maCongTy, _maDonVi, maNhanVien);
            gvThanhVien.OptionsBehavior.Editable = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDangNhap.SelectAll();
                txtTenDangNhap.Focus();
                return;
            }
            if (!txtMatKhau.Text.Equals(txtXacNhanMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDangNhap.SelectAll();
                txtTenDangNhap.Focus();
                return;
            }
            luuData();
        }
        void luuData()
        {
            if (_them)
            {
                bool ktNhanVien = _nhanVien.kiemtraTenDangNhapDaTonTaiChua(_maCongTy, _maDonVi, txtTenDangNhap.Text.Trim());
                if (ktNhanVien)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.\nVui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenDangNhap.SelectAll();
                    txtTenDangNhap.Focus();
                    return;
                }
                nv = new NhanVien();
                nv.TenDangNhap = txtTenDangNhap.Text.Trim();
                nv.TenNhanVien = txttenNhanVien.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.Nhom = false;
                nv.KhoaTaiKhoan = false;
                nv.MaCongTy = _maCongTy;
                nv.MaDonVi = _maDonVi;
                _nhanVien.add(nv);
            }
            else
            {
                nv = _nhanVien.getItem(_maNhanVien);
                nv.TenNhanVien = txttenNhanVien.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.Nhom = false;
                nv.KhoaTaiKhoan = chkKhoaTaiKhoan.Checked;
                nv.MaCongTy = _maCongTy;
                nv.MaDonVi = _maDonVi;
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
            frmDanhSachNhom f = new frmDanhSachNhom();
            f._maNhanVien = _maNhanVien;
            f._maCongTy = _maCongTy;
            f._maDonVi = _maDonVi;
            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _nhomQuyen.delete(_maNhanVien, int.Parse(gvThanhVien.GetFocusedRowCellValue("MaNhanVien").ToString()));
            loadNhomQuyenByNhanVien(_maNhanVien);
        }
    }
}