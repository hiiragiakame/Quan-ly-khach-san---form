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
    public partial class frmPhong_ThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong_ThietBi()
        {
            InitializeComponent();
        }
        public frmPhong_ThietBi(int quyen)
        {
            InitializeComponent();
            _quyen = quyen;
        }
        Phong_ThietBiBLL _phong_ThietBi;
        PhongBLL _phong;
        ThietBiBLL _thietBi;
        bool _them;
        int _maPhong;
        int _maThietBi;
        int _quyen;
        private void frmPhong_ThietBi_Load(object sender, EventArgs e)
        {
            _phong_ThietBi = new Phong_ThietBiBLL();
            _phong = new PhongBLL();
            _thietBi = new ThietBiBLL();
            loadData();
            loadPhong();
            loadThietBi();
            showHideControl(true);
            _enable(false);
        }
        void _enable(bool t)
        {
            cboPhong.Enabled = t;
            cboThietBi.Enabled = t;
            nupSoLuong.Enabled = t;
        }
        void _reset()
        {
            nupSoLuong.Value = 0;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _phong_ThietBi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadPhong()
        {
            cboPhong.DataSource = _phong.getAll();
            cboPhong.ValueMember = "MaPhong";
            cboPhong.DisplayMember = "TenPhong";
        }
        void loadThietBi()
        {
            cboThietBi.DataSource = _thietBi.getAll();
            cboThietBi.ValueMember = "MaThietBi";
            cboThietBi.DisplayMember = "TenThietBi";
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
            cboPhong.Enabled = false;
            cboThietBi.Enabled = false;
            showHideControl(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                Phong_ThietBi _ptb = new Phong_ThietBi();
                _ptb.MaPhong = int.Parse(cboPhong.SelectedValue.ToString());
                _ptb.MaThietBi = int.Parse(cboThietBi.SelectedValue.ToString());
                _ptb.SoLuong = int.Parse(nupSoLuong.Value.ToString());
                _phong_ThietBi.add(_ptb);
            }
            else
            {
                Phong_ThietBi _ptb = _phong_ThietBi.getItem(_maPhong, _maThietBi);
                _ptb.SoLuong = int.Parse(nupSoLuong.Value.ToString());
                _phong_ThietBi.update(_ptb);
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
                _phong_ThietBi.delete(_maPhong, _maThietBi);
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
                _maPhong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaPhong").ToString());
                cboPhong.SelectedValue = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaPhong").ToString());
                cboThietBi.SelectedValue = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaThietBi").ToString());
                nupSoLuong.Value = int.Parse(gvDanhSach.GetFocusedRowCellValue("SoLuong").ToString());
            }
        }
    }
}