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
    public partial class frmThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmThietBi(int quyen)
        {
            InitializeComponent();
            _quyen = quyen;
        }
        ThietBiBLL _thietBi;
        bool _them;
        int _maThietBi;
        int _quyen;
        private void frmThietBi_Load(object sender, EventArgs e)
        {
            _thietBi = new ThietBiBLL();
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
            nupDonGia.Text = String.Empty;
            chkDisabled.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _thietBi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
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
                ThietBi _lp = new ThietBi();
                _lp.TenThietBi = txtTen.Text;
                _lp.DonGia = float.Parse(nupDonGia.Value.ToString());
                _lp.Disabled = chkDisabled.Checked;
                _thietBi.add(_lp);
            }
            else
            {
                ThietBi _lp = _thietBi.getItem(_maThietBi);
                _lp.TenThietBi = txtTen.Text;
                _lp.DonGia = float.Parse(nupDonGia.Value.ToString());
                _lp.Disabled = chkDisabled.Checked;
                _thietBi.update(_lp);
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
                _thietBi.delete(_maThietBi);
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
                _maThietBi = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaThietBi").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenThietBi").ToString();
                nupDonGia.Value = decimal.Parse(gvDanhSach.GetFocusedRowCellValue("DonGia").ToString());
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }
    }
}