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
    public partial class frmLoaiPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        public frmLoaiPhong(int quyen)
        {
            InitializeComponent();
            this._quyen = quyen;
        }
        LoaiPhongBLL _loaiPhong;
        int _quyen;
        bool _them;
        int _maLoaiPhong;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            _loaiPhong = new LoaiPhongBLL();
            loadData();
            showHideControl(true);
            _enable(false);
        }
        void _enable(bool t)
        {
            txtTen.Enabled = t;
            nupDonGia.Enabled = t;
            nupSoNguoi.Enabled = t;
            nupSoGiuong.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = String.Empty;
            nupDonGia.Text = String.Empty;
            nupSoNguoi.Value = 1;
            nupSoGiuong.Value = 1;
            chkDisabled.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _loaiPhong.getAll();
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
                LoaiPhong _lp = new LoaiPhong();
                _lp.TenLoaiPhong = txtTen.Text;
                _lp.DonGia = float.Parse(nupDonGia.Value.ToString());
                _lp.SoNguoi = int.Parse(nupSoNguoi.Value.ToString());
                _lp.SoGiuong = int.Parse(nupSoNguoi.Value.ToString());
                _lp.Disabled = chkDisabled.Checked;
                _loaiPhong.add(_lp);
            }
            else
            {
                LoaiPhong _lp = _loaiPhong.getItem(_maLoaiPhong);
                _lp.TenLoaiPhong = txtTen.Text;
                _lp.DonGia = float.Parse(nupDonGia.Value.ToString());
                _lp.SoNguoi = int.Parse(nupSoNguoi.Value.ToString());
                _lp.SoGiuong = int.Parse(nupSoGiuong.Value.ToString());
                _lp.Disabled = chkDisabled.Checked;
                _loaiPhong.update(_lp);
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
                _loaiPhong.delete(_maLoaiPhong);
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
                _maLoaiPhong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaLoaiPhong").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenLoaiPhong").ToString();
                nupDonGia.Value = decimal.Parse(gvDanhSach.GetFocusedRowCellValue("DonGia").ToString());
                nupSoNguoi.Value = decimal.Parse(gvDanhSach.GetFocusedRowCellValue("SoNguoi").ToString());
                nupSoGiuong.Value = decimal.Parse(gvDanhSach.GetFocusedRowCellValue("SoGiuong").ToString());
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }
    }
}