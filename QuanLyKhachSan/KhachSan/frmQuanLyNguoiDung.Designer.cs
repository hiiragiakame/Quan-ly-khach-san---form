namespace KhachSan
{
    partial class frmQuanLyNguoiDung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyNguoiDung));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNhomNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.btnUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhat = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhanQuyenChucNang = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnPhanQuyen = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboCongTy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnNhom = new System.Windows.Forms.Panel();
            this.cboDonVi = new System.Windows.Forms.ComboBox();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Disabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaCongTy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nhom = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnNhom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNhomNguoiDung,
            this.btnUser,
            this.btnCapNhat,
            this.btnPhanQuyenChucNang,
            this.btnThoat});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1119, 150);
            // 
            // btnNhomNguoiDung
            // 
            this.btnNhomNguoiDung.Caption = "Nhóm người dùng";
            this.btnNhomNguoiDung.Id = 1;
            this.btnNhomNguoiDung.ImageOptions.Image = global::KhachSan.Properties.Resources.usergroup_16x16;
            this.btnNhomNguoiDung.ImageOptions.LargeImage = global::KhachSan.Properties.Resources.usergroup_32x32;
            this.btnNhomNguoiDung.Name = "btnNhomNguoiDung";
            this.btnNhomNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhomNguoiDung_ItemClick);
            // 
            // btnUser
            // 
            this.btnUser.Caption = "Người dùng";
            this.btnUser.Id = 2;
            this.btnUser.ImageOptions.Image = global::KhachSan.Properties.Resources.customer_16x16;
            this.btnUser.ImageOptions.LargeImage = global::KhachSan.Properties.Resources.customer_32x32;
            this.btnUser.Name = "btnUser";
            this.btnUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUser_ItemClick);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Caption = "Cập nhật thông tin";
            this.btnCapNhat.Id = 3;
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.Image")));
            this.btnCapNhat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.LargeImage")));
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapNhat_ItemClick);
            // 
            // btnPhanQuyenChucNang
            // 
            this.btnPhanQuyenChucNang.Caption = "Phân quyền chức năng";
            this.btnPhanQuyenChucNang.Id = 4;
            this.btnPhanQuyenChucNang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhanQuyenChucNang.ImageOptions.Image")));
            this.btnPhanQuyenChucNang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPhanQuyenChucNang.ImageOptions.LargeImage")));
            this.btnPhanQuyenChucNang.Name = "btnPhanQuyenChucNang";
            this.btnPhanQuyenChucNang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhanQuyenChucNang_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 5;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.Name = "btnThoat";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.btnPhanQuyen,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhomNguoiDung);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUser, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCapNhat, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tài khoản";
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.ItemLinks.Add(this.btnPhanQuyenChucNang);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Text = "Phân quyền";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnThoat);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Thoát";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboCongTy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnNhom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 31);
            this.panel1.TabIndex = 1;
            // 
            // cboCongTy
            // 
            this.cboCongTy.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCongTy.FormattingEnabled = true;
            this.cboCongTy.Location = new System.Drawing.Point(113, -2);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(330, 33);
            this.cboCongTy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "CÔNG TY";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(691, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐƠN VỊ";
            // 
            // pnNhom
            // 
            this.pnNhom.Controls.Add(this.cboDonVi);
            this.pnNhom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnNhom.Location = new System.Drawing.Point(789, 0);
            this.pnNhom.Name = "pnNhom";
            this.pnNhom.Size = new System.Drawing.Size(330, 31);
            this.pnNhom.TabIndex = 0;
            // 
            // cboDonVi
            // 
            this.cboDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDonVi.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDonVi.FormattingEnabled = true;
            this.cboDonVi.Location = new System.Drawing.Point(0, 0);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(330, 33);
            this.cboDonVi.TabIndex = 0;
            // 
            // gcUser
            // 
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(0, 181);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.MenuManager = this.ribbonControl1;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(1119, 432);
            this.gcUser.TabIndex = 2;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Disabled,
            this.MaNhanVien,
            this.TenDangNhap,
            this.TenNhanVien,
            this.MaCongTy,
            this.MaDonVi,
            this.Nhom});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvUser_CustomDrawCell);
            this.gvUser.DoubleClick += new System.EventHandler(this.gvUser_DoubleClick);
            // 
            // Disabled
            // 
            this.Disabled.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Disabled.AppearanceHeader.Options.UseFont = true;
            this.Disabled.Caption = "Disabled";
            this.Disabled.FieldName = "KhoaTaiKhoan";
            this.Disabled.MaxWidth = 50;
            this.Disabled.Name = "Disabled";
            this.Disabled.Visible = true;
            this.Disabled.VisibleIndex = 0;
            this.Disabled.Width = 30;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "Mã Nhân Viên";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TenDangNhap.AppearanceHeader.Options.UseFont = true;
            this.TenDangNhap.Caption = "Tên Đăng Nhập";
            this.TenDangNhap.FieldName = "TenDangNhap";
            this.TenDangNhap.MaxWidth = 150;
            this.TenDangNhap.MinWidth = 100;
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Visible = true;
            this.TenDangNhap.VisibleIndex = 1;
            this.TenDangNhap.Width = 100;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TenNhanVien.AppearanceHeader.Options.UseFont = true;
            this.TenNhanVien.Caption = "Tên Nhân Viên";
            this.TenNhanVien.FieldName = "TenNhanVien";
            this.TenNhanVien.MaxWidth = 200;
            this.TenNhanVien.MinWidth = 150;
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Visible = true;
            this.TenNhanVien.VisibleIndex = 2;
            this.TenNhanVien.Width = 150;
            // 
            // MaCongTy
            // 
            this.MaCongTy.Caption = "Mã Công Ty";
            this.MaCongTy.FieldName = "MaCongTy";
            this.MaCongTy.Name = "MaCongTy";
            // 
            // MaDonVi
            // 
            this.MaDonVi.Caption = "Mã Đơn Vị";
            this.MaDonVi.FieldName = "MaDonVi";
            this.MaDonVi.Name = "MaDonVi";
            // 
            // Nhom
            // 
            this.Nhom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Nhom.AppearanceHeader.Options.UseFont = true;
            this.Nhom.Caption = "Nhóm";
            this.Nhom.FieldName = "Nhom";
            this.Nhom.MaxWidth = 60;
            this.Nhom.MinWidth = 40;
            this.Nhom.Name = "Nhom";
            this.Nhom.Visible = true;
            this.Nhom.VisibleIndex = 3;
            this.Nhom.Width = 60;
            // 
            // frmQuanLyNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 613);
            this.Controls.Add(this.gcUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmQuanLyNguoiDung";
            this.Text = "frmQuanLyNguoiDung";
            this.Load += new System.EventHandler(this.frmQuanLyNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnNhom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnNhomNguoiDung;
        private DevExpress.XtraBars.BarButtonItem btnUser;
        private DevExpress.XtraBars.BarButtonItem btnCapNhat;
        private DevExpress.XtraBars.BarButtonItem btnPhanQuyenChucNang;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup btnPhanQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnNhom;
        private System.Windows.Forms.ComboBox cboDonVi;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn Disabled;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn TenDangNhap;
        private DevExpress.XtraGrid.Columns.GridColumn TenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaCongTy;
        private DevExpress.XtraGrid.Columns.GridColumn MaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn Nhom;
        private System.Windows.Forms.ComboBox cboCongTy;
        private System.Windows.Forms.Label label2;
    }
}