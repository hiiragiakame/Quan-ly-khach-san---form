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
using BussinessLayer;

namespace KhachSan
{
    public partial class frmDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmDonVi()
        {
            InitializeComponent();
        }
        public frmDonVi(int quyen)
        {
            InitializeComponent();
            this._quyen = quyen;
        }
        int _quyen;
        DonViBLL _donVi;
        CongTyBLL _congTy;
        bool _them;
        String _maDonVi;
        void _enable(bool t)
        {
            txtTen.Enabled = t;
            txtDienThoai.Enabled = t;
            txtFax.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtMa.Text = String.Empty;
            txtTen.Text = String.Empty;
            txtDienThoai.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
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
        void loadCongTy()
        {
            cboCongTy.DataSource = _congTy.getAll();
            cboCongTy.ValueMember = "MaCongTy";
            cboCongTy.DisplayMember = "TenCongTy";
        }
        void loadData()
        {
            gcDanhSach.DataSource = _donVi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadDonViByCongTy()
        {
            gcDanhSach.DataSource = _donVi.getAll(cboCongTy.SelectedValue.ToString());
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
            txtMa.Enabled = true;
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
            txtMa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                if (_donVi.checkMaDonVi(_maDonVi) == true)
                {
                    MessageBox.Show("Mã đơn vị này đã tồn tại.\nVui lòng nhập mã đơn vị khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DonVi dvi = new DonVi();
                dvi.MaCongTy = cboCongTy.SelectedValue.ToString();
                dvi.MaDonVi = txtMa.Text;
                dvi.TenDonVi = txtTen.Text;
                dvi.DienThoai = txtDienThoai.Text;
                dvi.Fax = txtFax.Text;
                dvi.Email = txtEmail.Text;
                dvi.DiaChi = txtEmail.Text;
                dvi.Disabled = chkDisabled.Checked;
                _donVi.add(dvi);
            }
            else
            {
                DonVi dvi = _donVi.getItem(_maDonVi);
                dvi.MaCongTy = cboCongTy.SelectedValue.ToString();
                dvi.TenDonVi = txtTen.Text;
                dvi.DienThoai = txtDienThoai.Text;
                dvi.Fax = txtFax.Text;
                dvi.Email = txtEmail.Text;
                dvi.DiaChi = txtEmail.Text;
                dvi.Disabled = chkDisabled.Checked;
                _donVi.update(dvi);
            }
            _them = false;
            txtMa.Enabled = false;
            loadDonViByCongTy();
            _enable(false);
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
            txtMa.Enabled = false;
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
                _donVi.delete(_maDonVi);
            }
            loadDonViByCongTy();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDonVi_Load(object sender, EventArgs e)
        {
            _donVi = new DonViBLL();
            _congTy = new CongTyBLL();
            loadCongTy();
            showHideControl(true);
            _enable(false);
            txtMa.Enabled = false;
            loadDonViByCongTy();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maDonVi = gvDanhSach.GetFocusedRowCellValue("MaDonVi").ToString();
                cboCongTy.SelectedValue = gvDanhSach.GetFocusedRowCellValue("MaCongTy");
                txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MaDonVi").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenDonVi").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DienThoai").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("Fax").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonViByCongTy();
        }

        private void cboCongTy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}