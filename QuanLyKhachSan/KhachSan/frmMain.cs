using BussinessLayer;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KhachSan
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        TinhNangBLL tinhNang;
        TangBLL tang;
        PhongBLL phong;
        GalleryItem item = null;
        NhomQuyenBLL nhomQuyen = new NhomQuyenBLL();
        QuyenBLL quyen;
        private void Form1_Load(object sender, EventArgs e)
        {
            tinhNang = new TinhNangBLL();
            tang = new TangBLL();
            phong = new PhongBLL();
            nhomQuyen = new NhomQuyenBLL();
            quyen = new QuyenBLL();
            leftMenu();
            hienThiPhong();
        }
        void leftMenu()
        {
            int i = 0;
            var _lsparent = tinhNang.getParent();
            foreach(var item in _lsparent)
            {
                NavBarGroup navGroup = new NavBarGroup(item.Decription);
                navGroup.Tag = item.MaTinhNang;
                navGroup.Name = item.MaTinhNang;
                navGroup.ImageOptions.LargeImageIndex = i++;
                navMain.Groups.Add(navGroup);

                var _lsChild = tinhNang.getChild(item.MaTinhNang);
                foreach(var citem in _lsChild)
                {
                    NavBarItem navItem = new NavBarItem(citem.Decription);
                    navItem.Tag = citem.MaTinhNang;
                    navItem.Name = citem.MaTinhNang;
                    navItem.ImageOptions.SmallImageIndex = 0;
                    navGroup.ItemLinks.Add(navItem);
                }
                navMain.Groups[navGroup.Name].Expanded = true;
            }
        }
        public void hienThiPhong()
        {
            tang = new TangBLL();
            phong = new PhongBLL();
            var lsTang = tang.getAll();
            gControl.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64, 64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;
            foreach(var item in lsTang)
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = item.TenTang;
                galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
                List<Phong> lsPhong = phong.getByTang(item.MaTang);
                foreach(var p in lsPhong)
                {
                    var gcItem = new GalleryItem();
                    gcItem.Caption = p.TenPhong;
                    gcItem.Value = p.MaPhong;
                    if(p.TrangThai == true)
                        gcItem.ImageOptions.Image = imageList3.Images[1];
                    else
                        gcItem.ImageOptions.Image = imageList3.Images[0];
                    galleryItem.Items.Add(gcItem);
                }
                gControl.Gallery.Groups.Add(galleryItem);
            }
        }

        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            String maTinhNang = e.Link.Item.Tag.ToString();
            var _group = nhomQuyen.getGroupByNhanVien();
            var _quyenNV = quyen.getQuyen(User.MaNhanVien, maTinhNang);
            if(_group != null)
            {
                var _groupRight = quyen.getQuyen(_group.Nhom, maTinhNang);
                if(_quyenNV.Quyen1 < _groupRight.Quyen1)
                    _quyenNV.Quyen1 = _groupRight.Quyen1;
            }
            if (_quyenNV.Quyen1 == 0 && !maTinhNang.Equals("DoiMK"))
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                switch (maTinhNang)
                {
                    case "CongTy":
                        {
                            frmCongTy f = new frmCongTy(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "DonVi":
                        {
                            frmDonVi f = new frmDonVi(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "KhachHang":
                        {
                            frmKhachHang f = new frmKhachHang(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "Tang":
                        {
                            frmTang f = new frmTang(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "LoaiPhong":
                        {
                            frmLoaiPhong f = new frmLoaiPhong(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "Phong":
                        {
                            frmPhong f = new frmPhong(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "SanPham":
                        {
                            frmSanPham f = new frmSanPham(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "ThietBi":
                        {
                            frmThietBi f = new frmThietBi(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "Phong_ThietBi":
                        {
                            frmPhong_ThietBi f = new frmPhong_ThietBi(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "DatPhongTD":
                        {
                            frmDatPhongTheoDoan f = new frmDatPhongTheoDoan(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                    case "DoiMK":
                        {
                            frmDoiMatKhau f = new frmDoiMatKhau();
                            f.ShowDialog();
                            break;
                        }
                    case "QuanLyNguoiDung":
                        {
                            frmQuanLyNguoiDung f = new frmQuanLyNguoiDung(_quyenNV.Quyen1.Value);
                            f.ShowDialog();
                            break;
                        }
                }
            }
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            Point point = gControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = gControl.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _group = nhomQuyen.getGroupByNhanVien();
            var _quyenNV = quyen.getQuyen(User.MaNhanVien, "DatPhongTD");
            if (_group != null)
            {
                var _groupRight = quyen.getQuyen(_group.Nhom, "DatPhongTD");
                if (_quyenNV.Quyen1 < _groupRight.Quyen1)
                    _quyenNV.Quyen1 = _groupRight.Quyen1;
            }
            if (_quyenNV.Quyen1 == 0)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng đã được đặt\nVui lòng chọn phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon f = new frmDatPhongDon();
            f._maPhong = int.Parse(item.Value.ToString());
            f._them = true;
            f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSanPhamDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _group = nhomQuyen.getGroupByNhanVien();
            var _quyenNV = quyen.getQuyen(User.MaNhanVien, "DatPhongTD");
            if (_group != null)
            {
                var _groupRight = quyen.getQuyen(_group.Nhom, "DatPhongTD");
                if (_quyenNV.Quyen1 < _groupRight.Quyen1)
                    _quyenNV.Quyen1 = _groupRight.Quyen1;
            }
            if (_quyenNV.Quyen1 == 0)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt nên không thể cập nhật sản phẩm - dịch vụ\nVui lòng chọn phòng đã được đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon f = new frmDatPhongDon();
            f._maPhong = int.Parse(item.Value.ToString());
            f._them = false;
            f.ShowDialog();
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _group = nhomQuyen.getGroupByNhanVien();
            var _quyenNV = quyen.getQuyen(User.MaNhanVien, "DatPhongTD");
            if (_group != null)
            {
                var _groupRight = quyen.getQuyen(_group.Nhom, "DatPhongTD");
                if (_quyenNV.Quyen1 < _groupRight.Quyen1)
                    _quyenNV.Quyen1 = _groupRight.Quyen1;
            }
            if (_quyenNV.Quyen1 == 0)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt nên không thể thanh toán\nVui lòng chọn phòng đã đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon f = new frmDatPhongDon();
            f._maPhong = int.Parse(item.Value.ToString());
            f._them = false;
            f.ShowDialog();
        }

        private void btnChuyenPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _group = nhomQuyen.getGroupByNhanVien();
            var _quyenNV = quyen.getQuyen(User.MaNhanVien, "DatPhongTD");
            if (_group != null)
            {
                var _groupRight = quyen.getQuyen(_group.Nhom, "DatPhongTD");
                if (_quyenNV.Quyen1 < _groupRight.Quyen1)
                    _quyenNV.Quyen1 = _groupRight.Quyen1;
            }
            if (_quyenNV.Quyen1 == 0)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa đặt nên không thể chuyển phòng\nVui lòng chọn phòng đã đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmChuyenPhong f = new frmChuyenPhong();
            f._maPhong = int.Parse(item.Value.ToString());
            
            f.ShowDialog();
        }
    }
}
