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
    public partial class frmDatPhongDon : DevExpress.XtraEditors.XtraForm
    {
        public frmDatPhongDon()
        {
            InitializeComponent();
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        public bool _them;
        public int _maPhong;
        int _maDatPhong = 0;
        int songayO = 0;
        String _maCongTy;
        String _maDonVi;
        double _tongTien = 0;
        DatPhongBLL _datPhong;
        ChiTietDatPhongBLL _chiTietDatPhong;
        DatPhong_SanPhamBLL _datPhongSanPham;
        PhongBLL _phong;
        PhongDTO _phongHienTai;
        KhachHangBLL _khachHang;
        SanPhamBLL _sanPham;
        List<DatPhong_SanPhamDTO> listDPSP;
        CongTy_DonViBLL _congTyDonVi;

        private void frmDatPhongDon_Load(object sender, EventArgs e)
        {
            _datPhong = new DatPhongBLL();
            _chiTietDatPhong = new ChiTietDatPhongBLL();
            _datPhongSanPham = new DatPhong_SanPhamBLL();
            _phong = new PhongBLL();
            _sanPham = new SanPhamBLL();
            listDPSP = new List<DatPhong_SanPhamDTO>();
            _phongHienTai = _phong.getItemFull(_maPhong);
            lblPhong.Text = _phongHienTai.TenPhong + " - Đơn giá: " + _phongHienTai.DonGia.ToString("N0") + " VNĐ";
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now.AddDays(1);
            cboTrangThai.DataSource = TrangThaiBLL.getList();
            cboTrangThai.ValueMember = "_value";
            cboTrangThai.DisplayMember = "_display";
            nupSoNguoi.Value = 1;
            _maCongTy = User.MaCongTy;
            _maDonVi = User.MaDonVi;
            loadKhachHang();
            loadSanPham();
            var ctdp = _chiTietDatPhong.getIDDPByPhong(_maPhong);
            TimeSpan time = dtpNgayTra.Value - dtpNgayDat.Value;
            txtTongTien.Text = (_phongHienTai.DonGia * time.Days).ToString("N0");
            if (!_them && ctdp != null)
            {
                _maDatPhong = (int)ctdp.MaDatPhong;
                var dp = _datPhong.getItem(_maDatPhong);
                searchKhachHang.EditValue = dp.MaKhachHang;
                dtpNgayDat.Value = dp.NgayDatPhong.Value;
                dtpNgayTra.Value = dp.NgayTraPhong.Value;
                cboTrangThai.SelectedValue = dp.TrangThai;
                nupSoNguoi.Value = (decimal)dp.SoNguoiO;
                txtGhiChu.Text = dp.GhiChu;
                txtTongTien.Text = dp.SoTien.Value.ToString("N0");
            }
            cboTrangThai.Enabled = false;
            loadSPDV();
        }
        void loadSPDV()
        {
            gcSPDV.DataSource = _datPhongSanPham.getAllByDatPhong(_maDatPhong);
            listDPSP = _datPhongSanPham.getAllByDatPhong(_maDatPhong);
        }

        void loadSanPham()
        {
            gcSanPham.DataSource = _sanPham.getAll();
            gvSanPham.OptionsBehavior.Editable = false;
        }

        public void loadKhachHang()
        {
            _khachHang = new KhachHangBLL();
            searchKhachHang.Properties.DataSource = _khachHang.getAll();
            searchKhachHang.Properties.ValueMember = "MaKhachHang";
            searchKhachHang.Properties.DisplayMember = "TenKhachHang";
        }

        public void setKhachHang(int maKhachHang)
        {
            searchKhachHang.EditValue = maKhachHang;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(searchKhachHang.EditValue == null || searchKhachHang.EditValue.ToString() == String.Empty)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            luuData();
            _tongTien = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + _phong.getItemFull(_maPhong).DonGia * songayO);
            var dp = _datPhong.getItem(int.Parse(_maDatPhong.ToString()));
            dp.SoTien = _tongTien;
            _datPhong.update(dp);
            objMain.gControl.Gallery.Groups.Clear();
            objMain.hienThiPhong();
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!_them)
            {
                luuData();
                _tongTien = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + _phong.getItemFull(_maPhong).DonGia * songayO);
                var dp = _datPhong.getItem(int.Parse(_maDatPhong.ToString()));
                dp.SoTien = _tongTien;
                if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _datPhong.update(dp);
                    _datPhong.updateStatus(_maDatPhong);
                    _phong.updateStatus(_maPhong, false);
                    frmReport f = new frmReport(_maDatPhong);
                    f.ShowDialog();
                    cboTrangThai.SelectedValue = true;
                    objMain.gControl.Gallery.Groups.Clear();
                    objMain.hienThiPhong();
                    this.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void layKhachHang(int _maKhachHang)
        {
            _khachHang = new KhachHangBLL();
            var kh = _khachHang.getItem(_maKhachHang);
            searchKhachHang.EditValue = kh.MaKhachHang;
            searchKhachHang.Text = kh.TenKhachHang;
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.KhachHang_DatPhong = "DatPhongDon";
            f.ShowDialog();
        }

        void loadDPSP()
        {
            List<DatPhong_SanPhamDTO> list = new List<DatPhong_SanPhamDTO>();
            foreach (var item in listDPSP)
            {
                list.Add(item);
            }
            gcSPDV.DataSource = list;
        }

        private void gvSPDV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SoLuong")
            {
                int sl = int.Parse(e.Value.ToString());
                if (sl != 0)
                {
                    double gia = double.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "DonGia").ToString());
                    gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "ThanhTien", sl * gia);
                }
                else
                {
                    gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "ThanhTien", 0);
                }
            }
            gvSPDV.UpdateTotalSummary();
            txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + _phong.getItemFull(_maPhong).DonGia * songayO).ToString("N0");
        }

        private void gvSPDV_HiddenEditor(object sender, EventArgs e)
        {
            gvSPDV.UpdateCurrentRow();
        }
        void luuData()
        {
            if (_them)
            {
                DatPhong dp = new DatPhong();
                ChiTietDatPhong ctdp;
                DatPhong_SanPham dpsp;

                dp.NgayDatPhong = dtpNgayDat.Value;
                dp.NgayTraPhong = dtpNgayTra.Value;
                dp.SoNguoiO = int.Parse(nupSoNguoi.Value.ToString());
                dp.TrangThai = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.TheoDoan = false;
                dp.MaKhachHang = int.Parse(searchKhachHang.EditValue.ToString());
                dp.SoTien = double.Parse(txtTongTien.Text);
                dp.GhiChu = txtGhiChu.Text;
                dp.Disabled = false;
                dp.MaNhanVien = User.MaNhanVien;
                dp.MaCongTy = _maCongTy;
                dp.MaDonVi = _maDonVi;
                dp.NgayTao = DateTime.Now;
                var _dp = _datPhong.add(dp);
                _maDatPhong = _dp.MaDatPhong;
                ctdp = new ChiTietDatPhong();
                ctdp.MaDatPhong = _dp.MaDatPhong;
                ctdp.MaPhong = _maPhong;
                ctdp.SoNgayO = songayO;
                ctdp.DonGia = int.Parse(_phongHienTai.DonGia.ToString());
                ctdp.ThanhTien = ctdp.SoNgayO * ctdp.DonGia;
                ctdp.Ngay = DateTime.Now;
                var _ctdp = _chiTietDatPhong.add(ctdp);
                _phong.updateStatus(int.Parse(ctdp.MaPhong.ToString()), true);
                if (gvSPDV.RowCount > 0)
                {
                    for (int j = 0; j < gvSPDV.RowCount; j++)
                    {
                        if (ctdp.MaPhong == int.Parse(gvSPDV.GetRowCellValue(j, "MaPhong").ToString()))
                        {
                            dpsp = new DatPhong_SanPham();
                            dpsp.MaDatPhong = _dp.MaDatPhong;
                            dpsp.MaChiTietDatPhong = _ctdp.MaChiTietDatPhong;
                            dpsp.MaPhong = int.Parse(gvSPDV.GetRowCellValue(j, "MaPhong").ToString());
                            dpsp.MaSanPham = int.Parse(gvSPDV.GetRowCellValue(j, "MaSanPham").ToString());
                            dpsp.SoLuong = int.Parse(gvSPDV.GetRowCellValue(j, "SoLuong").ToString());
                            dpsp.DonGia = int.Parse(gvSPDV.GetRowCellValue(j, "DonGia").ToString());
                            dpsp.ThanhTien = dpsp.SoLuong * dpsp.DonGia;
                            dpsp.Ngay = DateTime.Now;
                            _datPhongSanPham.add(dpsp);
                        }
                    }
                }
            }
            else
            {
                DatPhong dp = _datPhong.getItem(_maDatPhong);
                ChiTietDatPhong ctdp;
                DatPhong_SanPham dpsp;

                dp.NgayDatPhong = dtpNgayDat.Value;
                dp.NgayTraPhong = dtpNgayTra.Value;
                dp.SoNguoiO = int.Parse(nupSoNguoi.Value.ToString());
                dp.TrangThai = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.MaKhachHang = int.Parse(searchKhachHang.EditValue.ToString());
                dp.SoTien = double.Parse(txtTongTien.Text);
                dp.GhiChu = txtGhiChu.Text;
                dp.MaNhanVienCapNhat = User.MaNhanVien;
                dp.NgayCapNhat = DateTime.Now;
                var _dp = _datPhong.update(dp);
                _maDatPhong = _dp.MaDatPhong;
                _chiTietDatPhong.deleteAll(_dp.MaDatPhong);
                _datPhongSanPham.deleteAll(_dp.MaDatPhong);
                ctdp = new ChiTietDatPhong();
                ctdp.MaDatPhong = _dp.MaDatPhong;
                ctdp.MaPhong = _maPhong;
                ctdp.SoNgayO = dtpNgayTra.Value.Day - dtpNgayDat.Value.Day;
                ctdp.DonGia = int.Parse(_phongHienTai.DonGia.ToString());
                ctdp.ThanhTien = ctdp.SoNgayO * ctdp.DonGia;
                ctdp.Ngay = DateTime.Now;
                var _ctdp = _chiTietDatPhong.add(ctdp);
                _phong.updateStatus(int.Parse(ctdp.MaPhong.ToString()), true);
                if (gvSPDV.RowCount > 0)
                {
                    for (int j = 0; j < gvSPDV.RowCount; j++)
                    {
                        if (ctdp.MaPhong == int.Parse(gvSPDV.GetRowCellValue(j, "MaPhong").ToString()))
                        {
                            dpsp = new DatPhong_SanPham();
                            dpsp.MaDatPhong = _dp.MaDatPhong;
                            dpsp.MaChiTietDatPhong = _ctdp.MaChiTietDatPhong;
                            dpsp.MaPhong = int.Parse(gvSPDV.GetRowCellValue(j, "MaPhong").ToString());
                            dpsp.MaSanPham = int.Parse(gvSPDV.GetRowCellValue(j, "MaSanPham").ToString());
                            dpsp.SoLuong = int.Parse(gvSPDV.GetRowCellValue(j, "SoLuong").ToString());
                            dpsp.DonGia = int.Parse(gvSPDV.GetRowCellValue(j, "DonGia").ToString());
                            dpsp.ThanhTien = dpsp.SoLuong * dpsp.DonGia;
                            dpsp.Ngay = DateTime.Now;
                            _datPhongSanPham.add(dpsp);
                        }
                    }
                }
            }
        }

        private void gvSanPham_DoubleClick(object sender, EventArgs e)
        {
            if (_maPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bool.Parse(cboTrangThai.SelectedValue.ToString()) == true)
            {
                MessageBox.Show("Phiếu đã hoàn tất không được chỉnh sửa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvSanPham.GetFocusedRowCellValue("MaSanPham") != null)
            {
                DatPhong_SanPhamDTO sp = new DatPhong_SanPhamDTO();
                sp.MaSanPham = int.Parse(gvSanPham.GetFocusedRowCellValue("MaSanPham").ToString());
                sp.TenSanPham = gvSanPham.GetFocusedRowCellValue("TenSanPham").ToString();
                sp.MaPhong = _maPhong;
                sp.TenPhong = _phongHienTai.TenPhong;
                sp.DonGia = float.Parse(gvSanPham.GetFocusedRowCellValue("DonGia").ToString());
                sp.SoLuong = 1;
                sp.ThanhTien = sp.DonGia * sp.SoLuong;
                foreach (var item in listDPSP)
                {
                    if (item.MaSanPham == sp.MaSanPham && item.MaPhong == sp.MaPhong)
                    {
                        item.SoLuong = item.SoLuong + 1;
                        item.ThanhTien = item.SoLuong * item.DonGia;
                        loadDPSP();
                        txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + _phong.getItemFull(_maPhong).DonGia * songayO).ToString("N0");
                        return;
                    }
                }
                listDPSP.Add(sp);
            }
            loadDPSP();
            txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + _phong.getItemFull(_maPhong).DonGia * songayO).ToString("N0");
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            
            TimeSpan time = dtpNgayTra.Value - dtpNgayDat.Value;
            songayO = time.Days;
            if(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue != null)
                txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + _phong.getItemFull(_maPhong).DonGia * songayO).ToString("N0");
        }
    }
}