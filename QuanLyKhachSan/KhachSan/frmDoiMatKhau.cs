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
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        NhanVienBLL _nhanVien;
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            NhanVien nv = _nhanVien.getNhanVienHienTai();
            if (txtMatKhauCu.Text.Equals(nv.MatKhau))
            {
                if(txtMatKhauMoi.Text.Equals(txtXacNhanMatKhau.Text))
                {
                    nv.MatKhau = txtMatKhauMoi.Text;
                    _nhanVien.update(nv);
                    MessageBox.Show("Thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                    MessageBox.Show("Xác nhận mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Mật khẩu cũ không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
        }
    }
}