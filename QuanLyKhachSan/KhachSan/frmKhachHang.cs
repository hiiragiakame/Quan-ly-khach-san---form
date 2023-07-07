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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public frmKhachHang(int quyen)
        {
            InitializeComponent();
            this._quyen = quyen;
        }
        frmDatPhongTheoDoan objDP = (frmDatPhongTheoDoan) Application.OpenForms["frmDatPhongTheoDoan"];
        frmDatPhongDon objDPDon = (frmDatPhongDon)Application.OpenForms["frmDatPhongDon"];
        KhachHangBLL _khachhang;
        int _quyen;
        bool _them;
        int _maKhachHang;
        public String KhachHang_DatPhong;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            _khachhang = new KhachHangBLL();
            loadData();
            showHideControl(true);
            _enable(false);
        }
        void _enable(bool t)
        {
            txtTen.Enabled = t;
            txtDienThoai.Enabled = t;
            txtCCCD.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            chkNam.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = String.Empty;
            txtDienThoai.Text = String.Empty;
            txtCCCD.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
            chkNam.Checked = false;
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
            gcDanhSach.DataSource = _khachhang.getAll();
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
                KhachHang _kh = new KhachHang();
                _kh.TenKhachHang = txtTen.Text;
                _kh.CCCD = txtCCCD.Text;
                _kh.DienThoai = txtDienThoai.Text;
                _kh.Email = txtEmail.Text;
                _kh.DiaChi = txtDiaChi.Text;
                _kh.Nam = chkNam.Checked;
                _kh.Disabled = chkDisabled.Checked;
                _khachhang.add(_kh);
            }
            else
            {
                KhachHang _kh = _khachhang.getItem(_maKhachHang);
                _kh.TenKhachHang = txtTen.Text;
                _kh.CCCD = txtCCCD.Text;
                _kh.DienThoai = txtDienThoai.Text;
                _kh.Email = txtEmail.Text;
                _kh.DiaChi = txtDiaChi.Text;
                _kh.Nam = chkNam.Checked;
                _kh.Disabled = chkDisabled.Checked;
                _khachhang.update(_kh);
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
                _khachhang.delete(_maKhachHang);
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
                _maKhachHang = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaKhachHang").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenKhachHang").ToString();
                txtCCCD.Text = gvDanhSach.GetFocusedRowCellValue("CCCD").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DienThoai").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                chkNam.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Nam").ToString());
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if(gvDanhSach.GetFocusedRowCellValue("MaKhachHang") != null)
            {
                if (String.IsNullOrEmpty(KhachHang_DatPhong))
                    return;
                if (KhachHang_DatPhong.Equals("DatPhongDon"))
                {
                    objDPDon.loadKhachHang();
                    objDPDon.setKhachHang(int.Parse(gvDanhSach.GetFocusedRowCellValue("MaKhachHang").ToString()));
                }
                else
                {
                    objDP.loadKhachHang();
                    objDP.setKhachHang(int.Parse(gvDanhSach.GetFocusedRowCellValue("MaKhachHang").ToString()));
                }
                this.Close();
            }
        }
    }
}