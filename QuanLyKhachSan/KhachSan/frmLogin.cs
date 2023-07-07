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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        CongTyBLL _congTy;
        DonViBLL _donVi;
        NhanVienBLL _nhanVien;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _congTy = new CongTyBLL();
            _donVi = new DonViBLL();
            _nhanVien = new NhanVienBLL();
            loadcboCongTy();
        }
        void loadcboCongTy()
        {
            cboCongTy.DataSource = _congTy.getAll();
            cboCongTy.ValueMember = "MaCongTy";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcboDonVi();
        }
        void loadcboDonVi()
        {
            cboDonVi.DataSource = _donVi.getAll(cboCongTy.SelectedValue.ToString());
            cboDonVi.ValueMember = "MaDonVi";
            cboDonVi.DisplayMember = "TenDonVi";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenDangNhap.Text) || String.IsNullOrEmpty(txtMatKhau.Text) || cboCongTy.SelectedValue == null || cboDonVi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NhanVien nv = _nhanVien.GetNhanVien_TuCongTyDonViTenDangNhap(cboCongTy.SelectedValue.ToString(), cboDonVi.SelectedValue.ToString(), txtTenDangNhap.Text, txtMatKhau.Text);
            if(nv==null)
            {
                MessageBox.Show("Sai mật khẩu hoặc chọn sai công ty và đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User.MaCongTy = cboCongTy.SelectedValue.ToString();
            User.MaDonVi = cboDonVi.SelectedValue.ToString();
            User.MaNhanVien = nv.MaNhanVien;
            frmMain f = new frmMain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}