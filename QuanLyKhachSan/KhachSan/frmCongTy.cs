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
    public partial class frmCongTy : DevExpress.XtraEditors.XtraForm
    {
        public frmCongTy()
        {
            InitializeComponent();
        }
        public frmCongTy(int quyen)
        {
            InitializeComponent();
            this._quyen = quyen;
        }
        CongTyBLL congTy;
        bool _them;
        String maCongTy;
        int _quyen;
        private void frmCongTy_Load(object sender, EventArgs e)
        {
            congTy = new CongTyBLL();
            loadData();
            showHideControl(true);
            txtMaCongTy.Enabled = false;
            _enable(false);
        }
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
            txtMaCongTy.Text = String.Empty;
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
        void loadData()
        {
            gcDanhSach.DataSource = congTy.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if(_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = true;
            txtMaCongTy.Enabled = true;
            showHideControl(false);
            _enable(true);
            _reset();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

            _them = false;
            showHideControl(true);
            _enable(false);
            txtMaCongTy.Enabled = false;
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
            txtMaCongTy.Enabled = false;
            showHideControl(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(_them)
            {
                if(congTy.checkMaCongTy(maCongTy) == true)
                {
                    MessageBox.Show("Mã công ty này đã tồn tại.\nVui lòng nhập mã công ty khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CongTy cty = new CongTy();
                cty.MaCongTy = txtMaCongTy.Text;
                cty.TenCongTy = txtTen.Text;
                cty.DienThoai = txtDienThoai.Text;
                cty.Fax = txtFax.Text;
                cty.Email = txtEmail.Text;
                cty.DiaChi = txtEmail.Text;
                cty.Disabled = chkDisabled.Checked;
                congTy.add(cty);
            }
            else
            {
                CongTy cty = congTy.getItem(maCongTy);
                cty.TenCongTy = txtTen.Text;
                cty.DienThoai = txtDienThoai.Text;
                cty.Fax = txtFax.Text;
                cty.Email = txtEmail.Text;
                cty.DiaChi = txtEmail.Text;
                cty.Disabled = chkDisabled.Checked;
                congTy.update(cty);
            }
            _them = false;
            txtMaCongTy.Enabled = false;
            loadData();
            _enable(false);
            showHideControl(true);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.RowCount > 0)
            {
                maCongTy = gvDanhSach.GetFocusedRowCellValue("MaCongTy").ToString();
                txtMaCongTy.Text = gvDanhSach.GetFocusedRowCellValue("MaCongTy").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenCongTy").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DienThoai").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("Fax").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("Disabled").ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?","Thông Báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                congTy.delete(maCongTy);
            }
            loadData();
        }
    }
}