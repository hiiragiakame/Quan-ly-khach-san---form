using BussinessLayer;
using DevExpress.Utils.Gesture;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class frmDatPhongTheoDoan : DevExpress.XtraEditors.XtraForm
    {
        public frmDatPhongTheoDoan()
        {
            InitializeComponent();
            DataTable tb = myFunctions.layDuLieu("select p.MaPhong, p.TenPhong, lp.DonGia, p.MaTang, t.TenTang from Phong p, Tang t, LoaiPhong lp where p.MaTang = t.MaTang and p.MaLoaiPhong = lp.MaLoaiPhong and p.TrangThai = 0");
            gcPhong.DataSource = tb;
            gcDatPhong.DataSource = tb.Clone();
        }
        public frmDatPhongTheoDoan(int quyen)
        {
            InitializeComponent();
            DataTable tb = myFunctions.layDuLieu("select p.MaPhong, p.TenPhong, lp.DonGia, p.MaTang, t.TenTang from Phong p, Tang t, LoaiPhong lp where p.MaTang = t.MaTang and p.MaLoaiPhong = lp.MaLoaiPhong and p.TrangThai = 0");
            gcPhong.DataSource = tb;
            gcDatPhong.DataSource = tb.Clone();
            _quyen = quyen;
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        bool _them;
        int _maPhong = 0;
        int _maDatPhong = 0;
        int _rowDatPhong = 0;
        int soNgayO = 0;
        int _quyen;
        String _tenPhong;
        String _maCongTy;
        String _maDonVi;
        List<DatPhong_SanPhamDTO> listDPSP;

        CongTy_DonViBLL _congTyDonVi;
        DatPhongBLL _datphong;
        ChiTietDatPhongBLL _chiTietDatPhong;
        DatPhong_SanPhamBLL _datPhongSanPham;
        
        KhachHangBLL _khachHang;
        SanPhamBLL _sanPham;
        PhongBLL _phong;

        GridHitInfo downHitInfo = null;
        private void frmDatPhongTheoDoan_Load(object sender, EventArgs e)
        {
            _datphong = new DatPhongBLL();
            _chiTietDatPhong = new ChiTietDatPhongBLL();
            _datPhongSanPham = new DatPhong_SanPhamBLL();
            _khachHang = new KhachHangBLL();
            _sanPham = new SanPhamBLL();
            _phong = new PhongBLL();

            listDPSP = new List<DatPhong_SanPhamDTO>();

            dtpTuNgay.Value = myFunctions.layNgayDauCuaThang(DateTime.Now.Year, DateTime.Now.Month);
            dtpDenNgay.Value = DateTime.Now;

            _maCongTy = User.MaCongTy;
            _maDonVi = User.MaDonVi;

            loadKhachHang();
            loadSanPham();
            loadDanhSach();
            cboTrangThai.DataSource = TrangThaiBLL.getList();
            cboTrangThai.ValueMember = "_value";
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.Enabled = false;
            _them = true;
            showHideControl(true);
            _enable(false);
            gvPhong.ExpandAllGroups();
            tabDanhSach.SelectedTabPage = pageDanhSach;
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        void loadDanhSach()
        {
            _datphong = new DatPhongBLL();
            gcDanhSach.DataSource = _datphong.getAll(dtpTuNgay.Value, dtpDenNgay.Value.AddDays(1), _maCongTy, _maDonVi);
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        public void loadKhachHang()
        {
            _khachHang = new KhachHangBLL();
            cboKhachHang.DataSource = _khachHang.getAll();
            cboKhachHang.ValueMember = "MaKhachHang";
            cboKhachHang.DisplayMember = "TenKhachHang";
        }

        void loadSanPham()
        {
            gcSanPham.DataSource = _sanPham.getAll();
            gvSanPham.OptionsBehavior.Editable = false;
        }

        void _enable(bool t)
        {
            cboKhachHang.Enabled = t;
            btnAddNew.Enabled = t;
            dtpNgayDat.Enabled = t;
            dtpNgayTra.Enabled = t;
            cboTrangThai.Enabled = t;
            chkTheoDoan.Enabled = t;
            nupSoNguoi.Enabled = t;
            txtGhiChu.Enabled = t;
            gcPhong.Enabled = t;
            gcSanPham.Enabled = t;
            gcDatPhong.Enabled = t;
            gcSPDV.Enabled = t;
            txtTongTien.Enabled = t;
        }
        void _reset()
        {
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now.AddDays(1);
            nupSoNguoi.Value = 1;
            chkTheoDoan.Checked = true;
            cboTrangThai.SelectedValue = false;
            txtGhiChu.Text = String.Empty;
            txtTongTien.Text = "0";
        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
            btnIn.Visible = t;
        }

        void addReset()
        {
            DataTable tb = myFunctions.layDuLieu("select p.MaPhong, p.TenPhong, lp.DonGia, p.MaTang, t.TenTang from Phong p, Tang t, LoaiPhong lp where p.MaTang = t.MaTang and p.MaLoaiPhong = lp.MaLoaiPhong and p.TrangThai = 0");
            gcPhong.DataSource = tb;
            gcDatPhong.DataSource = tb.Clone();
            gvPhong.ExpandAllGroups();
            gcSPDV.DataSource = _datPhongSanPham.getAllByDatPhong(0);
            txtTongTien.Text = "0";
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
            addReset();
            tabDanhSach.SelectedTabPage = pageChiTiet;
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
            tabDanhSach.SelectedTabPage = pageChiTiet;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            luuData();
            objMain.gControl.Gallery.Groups.Clear();
            objMain.hienThiPhong();
            _them = false;
            loadDanhSach();
            _enable(false);
            showHideControl(true);
            tabDanhSach.SelectedTabPage = pageDanhSach;
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
                dp.TheoDoan = chkTheoDoan.Checked;
                dp.MaKhachHang = int.Parse(cboKhachHang.SelectedValue.ToString());
                dp.SoTien = double.Parse(txtTongTien.Text);
                dp.GhiChu = txtGhiChu.Text;
                dp.Disabled = false;
                dp.MaNhanVien = User.MaNhanVien;
                dp.MaCongTy = _maCongTy;
                dp.MaDonVi = _maDonVi;
                dp.NgayTao = DateTime.Now;
                dp.GhiChu = txtGhiChu.Text;
                var _dp = _datphong.add(dp);
                _maDatPhong = _dp.MaDatPhong;
                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    ctdp = new ChiTietDatPhong();
                    ctdp.MaDatPhong = _dp.MaDatPhong;
                    ctdp.MaPhong = int.Parse(gvDatPhong.GetRowCellValue(i, "MaPhong").ToString());
                    ctdp.SoNgayO = (dtpNgayTra.Value - dtpNgayDat.Value).Days + 1;
                    ctdp.DonGia = int.Parse(gvDatPhong.GetRowCellValue(i, "DonGia").ToString());
                    ctdp.ThanhTien = ctdp.SoNgayO * ctdp.DonGia;
                    ctdp.Ngay = DateTime.Now;
                    var _ctdp = _chiTietDatPhong.add(ctdp);
                    _phong.updateStatus(int.Parse(ctdp.MaPhong.ToString()), true);
                    if (gvSPDV.RowCount > 0)
                    {
                        for (int j = 0; j < gvSPDV.RowCount; j++)
                        {
                            if(ctdp.MaPhong == int.Parse(gvSPDV.GetRowCellValue(j, "MaPhong").ToString()))
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
            else
            {
                DatPhong dp = _datphong.getItem(_maDatPhong);
                ChiTietDatPhong ctdp;
                DatPhong_SanPham dpsp;

                dp.NgayDatPhong = dtpNgayDat.Value;
                dp.NgayTraPhong = dtpNgayTra.Value;
                dp.SoNguoiO = int.Parse(nupSoNguoi.Value.ToString());
                dp.TrangThai = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.MaKhachHang = int.Parse(cboKhachHang.SelectedValue.ToString());
                dp.SoTien = double.Parse(txtTongTien.Text);
                dp.GhiChu = txtGhiChu.Text;
                dp.MaNhanVienCapNhat = User.MaNhanVien;
                dp.NgayCapNhat = DateTime.Now;
                dp.GhiChu = txtGhiChu.Text;
                var _dp = _datphong.update(dp);
                _maDatPhong = _dp.MaDatPhong;
                _chiTietDatPhong.deleteAll(_dp.MaDatPhong);
                _datPhongSanPham.deleteAll(_dp.MaDatPhong);
                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    ctdp = new ChiTietDatPhong();
                    ctdp.MaDatPhong = _dp.MaDatPhong;
                    ctdp.MaPhong = int.Parse(gvDatPhong.GetRowCellValue(i, "MaPhong").ToString());
                    ctdp.SoNgayO = dtpNgayTra.Value.Day - dtpNgayDat.Value.Day;
                    ctdp.DonGia = int.Parse(gvDatPhong.GetRowCellValue(i, "DonGia").ToString());
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
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
            tabDanhSach.SelectedTabPage = pageDanhSach;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_quyen == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_maDatPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần in hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                _datphong.updateStatus(_maDatPhong);
                var listCTDP = _chiTietDatPhong.getAllByDatPhong(_maDatPhong);
                foreach (var item in listCTDP)
                {
                    _phong.updateStatus((int)item.MaPhong, false);
                }
                loadDanhSach();
                frmReport f = new frmReport(_maDatPhong);
                f.ShowDialog();
                objMain.gControl.Gallery.Groups.Clear();
                objMain.hienThiPhong();
            }
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
                _datphong.delete(_maDatPhong);
                var listCTDP = _chiTietDatPhong.getAllByDatPhong(_maDatPhong);
                foreach(var item in listCTDP)
                {
                    _phong.updateStatus((int)item.MaPhong, false);
                }
            }
            loadDanhSach();
            objMain.gControl.Gallery.Groups.Clear();
            objMain.hienThiPhong();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDatPhong_MouseDown(object sender, MouseEventArgs e)
        {
            if(gvDatPhong.GetFocusedRowCellValue("MaPhong") != null)
            {
                _maPhong = int.Parse(gvDatPhong.GetFocusedRowCellValue("MaPhong").ToString());
                _tenPhong = gvDatPhong.GetFocusedRowCellValue("TenPhong").ToString();
            }
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if(e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            {
                downHitInfo = hitInfo;
            }
        }

        private void gvDatPhong_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if(e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X,e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void gvPhong_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void gvPhong_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            {
                downHitInfo = hitInfo;
            }
        }

        private void gcPhong_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                row.Delete();
            }
        }

        private void gcPhong_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void gvPhong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if(!gvPhong.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if(e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = String.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; // Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); // Tăng số thứ tự
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); // Lấy kích  thước của vùng hiển thị text
                    Int32 _Width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvPhong); })); //Tăng kích thước nếu text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1; // Nhân -1 để đánh lại số thứ tự
                e.Info.DisplayText = String.Format("[{0}]", (e.RowHandle * -1));
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvPhong); }));
            }
        }

        private void gvPhong_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            String caption = info.Column.Caption;
            if (info.Column.Caption == String.Empty)
                caption = info.Column.ToString();
            info.GroupText = String.Format("{0}: {1} ({2} phòng trống)", caption, info.GroupValueText, view.GetChildRowCount(e.RowHandle));
        }

        private void gcSanPham_DoubleClick(object sender, EventArgs e)
        {
            if(_maPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvSanPham.GetFocusedRowCellValue("MaSanPham") != null)
            {
                DatPhong_SanPhamDTO sp = new DatPhong_SanPhamDTO();
                sp.MaSanPham = int.Parse(gvSanPham.GetFocusedRowCellValue("MaSanPham").ToString());
                sp.TenSanPham = gvSanPham.GetFocusedRowCellValue("TenSanPham").ToString();
                sp.MaPhong = _maPhong;
                sp.TenPhong = _tenPhong;
                sp.DonGia = float.Parse(gvSanPham.GetFocusedRowCellValue("DonGia").ToString());
                sp.SoLuong = 1;
                sp.ThanhTien = sp.DonGia * sp.SoLuong;
                foreach(var item in listDPSP)
                {
                    if (item.MaSanPham == sp.MaSanPham && item.MaPhong == sp.MaPhong)
                    {
                        item.SoLuong = item.SoLuong + 1;
                        item.ThanhTien = item.SoLuong * item.DonGia;
                        loadDPSP();
                        txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DonGia"].SummaryItem.SummaryValue.ToString()) * soNgayO).ToString("N0");
                        return;
                    }
                }
                listDPSP.Add(sp);
            }
            loadDPSP();
            txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DonGia"].SummaryItem.SummaryValue.ToString()) * soNgayO).ToString("N0");
        }
        void loadDPSP()
        {
            List<DatPhong_SanPhamDTO> list = new List<DatPhong_SanPhamDTO>();
            foreach(var item in listDPSP)
            {
                list.Add(item);
            }
            gcSPDV.DataSource = list;
        }

        private void gvSPDV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName == "SoLuong")
            {
                int sl = int.Parse(e.Value.ToString());
                if(sl != 0)
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
            txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DonGia"].SummaryItem.SummaryValue.ToString()) * soNgayO).ToString("N0");
        }

        private void gvDatPhong_RowCountChanged(object sender, EventArgs e)
        {
            if(gvDatPhong.RowCount < _rowDatPhong && _them == false)
            {
                _phong.updateStatus(_maPhong, false);
                _chiTietDatPhong.delete(_maDatPhong, _maPhong);
                _datPhongSanPham.deleteAllByPhong(_maDatPhong, _maPhong);
                objMain.gControl.Gallery.Groups.Clear();
                objMain.hienThiPhong();
            }
            double t = 0;
            if (gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue == null)
                t = 0;
            else
                t = double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString());
            txtTongTien.Text = (double.Parse(gvDatPhong.Columns["DonGia"].SummaryItem.SummaryValue.ToString()) * soNgayO + t).ToString("N0");
        }

        private void gvDatPhong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                e.Info.ImageIndex = 0;
                e.Info.DisplayText = String.Empty;
            }
            else
            {
                e.Info.ImageIndex = -1; // Không hiển thị hình
                e.Info.DisplayText = (e.RowHandle + 1).ToString(); // Tăng số thứ tự
            }
        }

        private void gvSPDV_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                e.Info.ImageIndex = 0;
                e.Info.DisplayText = String.Empty;
            }
            else
            {
                e.Info.ImageIndex = -1; // Không hiển thị hình
                e.Info.DisplayText = (e.RowHandle + 1).ToString(); // Tăng số thứ tự
            }
        }

        private void gvSanPham_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                e.Info.ImageIndex = 0;
                e.Info.DisplayText = String.Empty;
            }
            else
            {
                e.Info.ImageIndex = -1; // Không hiển thị hình
                e.Info.DisplayText = (e.RowHandle + 1).ToString(); // Tăng số thứ tự
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.KhachHang_DatPhong = "DatPhongTheoDoan";
            f.ShowDialog();
        }
        public void setKhachHang(int maKhachHang)
        {
            var _kh = _khachHang.getItem(maKhachHang);
            cboKhachHang.SelectedValue = _kh.MaKhachHang;
            cboKhachHang.Text = _kh.TenKhachHang;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maDatPhong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaDatPhong").ToString());
                var dp = _datphong.getItem(_maDatPhong);
                cboKhachHang.SelectedValue = dp.MaKhachHang;
                dtpNgayDat.Value = dp.NgayDatPhong.Value;
                dtpNgayTra.Value = dp.NgayTraPhong.Value;
                nupSoNguoi.Value = int.Parse(dp.SoNguoiO.ToString());
                cboTrangThai.SelectedValue = dp.TrangThai;
                txtGhiChu.Text = dp.GhiChu;
                txtTongTien.Text = dp.SoTien.Value.ToString("N0");
                loadDP();
                loadSPDV();
            }
        }

        void loadDP()
        {
            _rowDatPhong = 0;
            gcDatPhong.DataSource = myFunctions.layDuLieu("select p.MaPhong, p.TenPhong, lp.DonGia, p.MaTang, t.TenTang from Phong p, Tang t, LoaiPhong lp, ChiTietDatPhong ctdp where p.MaTang = t.MaTang and p.MaLoaiPhong = lp.MaLoaiPhong and p.MaPhong = ctdp.MaPhong and ctdp.MaDatPhong = " + _maDatPhong);
            _rowDatPhong = gvDatPhong.RowCount;
        }

        void loadSPDV()
        {
            gcSPDV.DataSource = _datPhongSanPham.getAllByDatPhong(_maDatPhong);
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                loadDanhSach();
        }

        private void dtpTuNgay_Leave(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                loadDanhSach();
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maDatPhong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaDatPhong").ToString());
                var dp = _datphong.getItem(_maDatPhong);
                cboKhachHang.SelectedValue = dp.MaKhachHang;
                dtpNgayDat.Value = dp.NgayDatPhong.Value;
                dtpNgayTra.Value = dp.NgayTraPhong.Value;
                nupSoNguoi.Value = int.Parse(dp.SoNguoiO.ToString());
                cboTrangThai.SelectedValue = dp.TrangThai;
                txtGhiChu.Text = dp.GhiChu;
                txtTongTien.Text = dp.SoTien.Value.ToString("N0");
                loadDP();
                loadSPDV();
            }
            tabDanhSach.SelectedTabPage = pageChiTiet;
        }

        private void gvDanhSach_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                e.Info.ImageIndex = 0;
                e.Info.DisplayText = String.Empty;
            }
            else
            {
                e.Info.ImageIndex = -1; // Không hiển thị hình
                e.Info.DisplayText = (e.RowHandle + 1).ToString(); // Tăng số thứ tự
            }
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan time = dtpNgayTra.Value - dtpNgayDat.Value;
            soNgayO = time.Days;
            if (gvDatPhong.Columns["DonGia"].SummaryItem.SummaryValue != null && gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue != null)
                txtTongTien.Text = (double.Parse(gvSPDV.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DonGia"].SummaryItem.SummaryValue.ToString()) * soNgayO).ToString("N0");
        }
    }
}