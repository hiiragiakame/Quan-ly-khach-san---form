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
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        public frmSanPham(int quyen)
        {
            InitializeComponent();
            _quyen = quyen;
        }
        SanPhamBLL _sanPham;
        bool _them;
        int _maSanPham;
        int _quyen;
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            _sanPham = new SanPhamBLL();
            loadData();
            showHideControl(true);
            _enable(false);
        }
        void _enable(bool t)
        {
            txtTen.Enabled = t;
            nupDonGia.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = String.Empty;
            nupDonGia.Value = 0;
            chkDisabled.Checked = false;

        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _sanPham.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = true;
            showHideControl(false);
            _enable(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = false;
            _enable(true);
            showHideControl(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                SanPham _sp = new SanPham();
                _sp.TenSanPham = txtTen.Text;
                _sp.DonGia = float.Parse(nupDonGia.Value.ToString());
                _sp.Disabled = chkDisabled.Checked;
                _sanPham.add(_sp);
            }
            else
            {
                SanPham _sp = _sanPham.getItem(_maSanPham);
                _sp.TenSanPham = txtTen.Text;
                _sp.DonGia = float.Parse(nupDonGia.Value.ToString());
                _sp.Disabled = chkDisabled.Checked;
                _sanPham.update(_sp);
            }
            _them = false;
            loadData();
            _enable(false);
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _sanPham.delete(_maSanPham);
            }
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maSanPham = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaSanPham").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenSanPham").ToString();
                nupDonGia.Value = int.Parse(gvDanhSach.GetFocusedRowCellValue("DonGia").ToString());
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }
    }
}