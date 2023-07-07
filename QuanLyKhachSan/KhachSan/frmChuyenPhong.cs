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
    public partial class frmChuyenPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmChuyenPhong()
        {
            InitializeComponent();
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        public int _maPhong;
        PhongBLL _phong;
        ChiTietDatPhongBLL _chiTietDatPhong;
        DatPhong_SanPhamBLL _datPhongSanPham;
        DatPhongBLL _datPhong;
        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            _phong = new PhongBLL();
            _chiTietDatPhong = new ChiTietDatPhongBLL();
            _datPhongSanPham = new DatPhong_SanPhamBLL();_datPhong = new DatPhongBLL();
            var p = _phong.getItemFull(_maPhong);
            lblPhong.Text = p.TenPhong + " - Đơn giá: " + p.DonGia.ToString("N0");
            loadPhongTrong();
        }
        void loadPhongTrong()
        {
            searchChuyenPhong.Properties.DataSource = _phong.getPhongTrongFull();
            searchChuyenPhong.Properties.ValueMember = "MaPhong";
            searchChuyenPhong.Properties.DisplayMember = "TenPhong";
        }

        private void btnChuyenPhong_Click(object sender, EventArgs e)
        {
            if(searchChuyenPhong.EditValue == null || searchChuyenPhong.EditValue.ToString() == String.Empty)
            {
                MessageBox.Show("Vui lòng chọn phòng muốn chuyển đến..", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int tongTien = 0;
            int tongTien2 = 0;
            var phongHienTai = _chiTietDatPhong.getIDDPByPhong(_maPhong);
            var phongChuyenDen = _phong.getItemFull(int.Parse(searchChuyenPhong.EditValue.ToString()));
            List <DatPhong_SanPham> listDPSP = _datPhongSanPham.getAllByPhong((int)phongHienTai.MaDatPhong, phongHienTai.MaChiTietDatPhong);
            foreach(var item in listDPSP)
            {
                item.MaPhong = int.Parse(searchChuyenPhong.EditValue.ToString());
                tongTien = tongTien + int.Parse(item.DonGia.ToString()) * int.Parse(item.SoLuong.ToString());
                _datPhongSanPham.update(item);
            }
            var ctdp = _chiTietDatPhong.getItem((int)phongHienTai.MaDatPhong, _maPhong);
            ctdp.MaPhong = phongChuyenDen.MaPhong;
            ctdp.DonGia = int.Parse(phongChuyenDen.DonGia.ToString());
            ctdp.ThanhTien = ctdp.SoNgayO * int.Parse(phongChuyenDen.DonGia.ToString());
            tongTien2 = int.Parse(ctdp.ThanhTien.ToString());
            _chiTietDatPhong.update(ctdp);
            _phong.updateStatus(_maPhong, false);
            _phong.updateStatus(phongChuyenDen.MaPhong, true);
            var dp = _datPhong.getItem(int.Parse(phongHienTai.MaDatPhong.ToString()));
            dp.SoTien = tongTien + tongTien2;
            _datPhong.update(dp);
            objMain.gControl.Gallery.Groups.Clear();
            objMain.hienThiPhong();
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}