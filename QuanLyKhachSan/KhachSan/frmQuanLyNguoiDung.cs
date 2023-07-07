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
    public partial class frmQuanLyNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }
        public frmQuanLyNguoiDung(int quyen)
        {
            InitializeComponent();
            this._quyen = quyen;
        }
        CongTyBLL _congTy;
        DonViBLL _donVi;
        NhanVienBLL _nhanVien;
        String _maCongTy;
        String _maDonVi;
        int _quyen;
        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            _congTy = new CongTyBLL();
            _donVi = new DonViBLL();
            _nhanVien = new NhanVienBLL();
            loadcboCongTy();
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            cboDonVi.SelectedIndexChanged += CboDonVi_SelectedIndexChanged;
        }
        void loadcboCongTy()
        {
            cboCongTy.DataSource = _congTy.getAll();
            cboCongTy.ValueMember = "MaCongTy";
            cboCongTy.DisplayMember = "TenCongTy";
            
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maCongTy = cboCongTy.SelectedValue.ToString();
            loadcboDonVi();
        }

        void loadcboDonVi()
        {
            cboDonVi.DataSource = _donVi.getAll(_maCongTy);
            cboDonVi.ValueMember = "MaDonVi";
            cboDonVi.DisplayMember = "TenDonVi";
            
        }

        private void CboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maDonVi = cboDonVi.SelectedValue.ToString();
            loadUser(_maCongTy,_maDonVi);
        }

        public void loadUser(String maCongTy, String maDonVi)
        {
            _nhanVien = new NhanVienBLL();
            gcUser.DataSource = _nhanVien.getnhanVienByMaDonVi(maCongTy, maDonVi);
            gvUser.OptionsBehavior.Editable = false;
        }

        private void btnNhomNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboCongTy.SelectedValue == null || cboDonVi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn công ty và và đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmNhomNguoiDung f = new frmNhomNguoiDung();
            f._them = true;
            f._maCongTy = _maCongTy;
            f._maDonVi = _maDonVi;
            f.ShowDialog();
        }

        private void gvUser_DoubleClick(object sender, EventArgs e)
        {
            if(gvUser.RowCount > 0 && gvUser.GetFocusedRowCellValue("Nhom").Equals(true))
            {
                frmNhomNguoiDung f = new frmNhomNguoiDung();
                f._them = false;
                f._maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
                f.ShowDialog();
            }
            else
            {
                frmNhanVien f = new frmNhanVien();
                f._them = false;
                f._maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
                f.ShowDialog();
            }
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvUser.RowCount <=0 )
            {
                MessageBox.Show("Vui lòng chọn nhân viên hoặc nhóm quyền trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvUser.GetFocusedRowCellValue("Nhom").Equals(true))
            {
                frmNhomNguoiDung f = new frmNhomNguoiDung();
                f._them = false;
                f._maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
                f.ShowDialog();
            }
            else
            {
                frmNhanVien f = new frmNhanVien();
                f._them = false;
                f._maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
                f.ShowDialog();
            }
        }

        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboCongTy.SelectedValue == null || cboDonVi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn công ty và và đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmNhanVien f = new frmNhanVien();
            f._them = true;
            f._maCongTy = _maCongTy;
            f._maDonVi = _maDonVi;
            f._maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
            f.ShowDialog();
        }

        private void gvUser_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name =="Nhom" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.usergroup_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
            if (e.Column.Name == "Nhom" && bool.Parse(e.CellValue.ToString()) == false)
            {
                Image img = Properties.Resources.customer_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void btnPhanQuyenChucNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvUser.RowCount > 0)
            {
                frmPhanQuyenChucNang f = new frmPhanQuyenChucNang();
                f._maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
                f._maCongTy = _maCongTy;
                f._maDonVi = _maDonVi;
                f.ShowDialog();
            }
        }
    }
}