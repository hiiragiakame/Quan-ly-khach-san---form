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
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        public frmPhong(int quyen)
        {
            InitializeComponent();
            _quyen = quyen;
        }
        PhongBLL _phong;
        TangBLL _tang;
        LoaiPhongBLL _loaiPhong;
        int _quyen;
        bool _them;
        int _maPhong;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            _phong = new PhongBLL();
            _tang = new TangBLL();
            _loaiPhong = new LoaiPhongBLL();
            loadData();
            loadTang();
            loadLoaiPhong();
            showHideControl(true);
            _enable(false);
        }

        void _enable(bool t)
        {
            txtTen.Enabled = t;
            cboLoaiPhong.Enabled = t;
            cboTang.Enabled = t;
            chkTrangThai.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = String.Empty;
            chkTrangThai.Checked = false;
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
            gcDanhSach.DataSource = _phong.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadTang()
        {
            cboTang.DataSource = _tang.getAll();
            cboTang.ValueMember = "MaTang";
            cboTang.DisplayMember = "TenTang";
        }
        void loadLoaiPhong()
        {
            cboLoaiPhong.DataSource = _loaiPhong.getAll();
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
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
                Phong _p = new Phong();
                _p.TenPhong = txtTen.Text;
                _p.MaLoaiPhong = int.Parse(cboLoaiPhong.SelectedValue.ToString());
                _p.MaTang = int.Parse(cboTang.SelectedValue.ToString());
                _p.TrangThai = chkTrangThai.Checked;
                _p.Disabled = chkDisabled.Checked;
                _phong.add(_p);
            }
            else
            {
                Phong _p = _phong.getItem(_maPhong);
                _p.TenPhong = txtTen.Text;
                _p.MaLoaiPhong = int.Parse(cboLoaiPhong.SelectedValue.ToString());
                _p.MaTang = int.Parse(cboTang.SelectedValue.ToString());
                _p.TrangThai = chkTrangThai.Checked;
                _p.Disabled = chkDisabled.Checked;
                _phong.update(_p);
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
                _phong.delete(_maPhong);
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
                _maPhong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaPhong").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenPhong").ToString();
                cboLoaiPhong.SelectedValue = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaLoaiPhong").ToString());
                cboTang.SelectedValue = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaTang").ToString());
                chkTrangThai.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("TrangThai").ToString());
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }
    }
}