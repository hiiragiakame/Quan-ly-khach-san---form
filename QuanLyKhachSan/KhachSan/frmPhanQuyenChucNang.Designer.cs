namespace KhachSan
{
    partial class frmPhanQuyenChucNang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyenChucNang));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Nhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChucNang = new DevExpress.XtraGrid.GridControl();
            this.gvChucNang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaTinhNang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnKhoaQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnChiXem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnToanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcUser);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcChucNang);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(822, 437);
            this.splitContainerControl1.SplitterPosition = 321;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gcUser
            // 
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(0, 0);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(321, 437);
            this.gcUser.TabIndex = 0;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Nhom,
            this.TenDangNhap,
            this.TenNhanVien,
            this.MaNhanVien});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowGroupPanel = false;
            this.gvUser.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvUser_CustomDrawCell);
            this.gvUser.Click += new System.EventHandler(this.gvUser_Click);
            // 
            // Nhom
            // 
            this.Nhom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Nhom.AppearanceHeader.Options.UseFont = true;
            this.Nhom.Caption = "Nhóm";
            this.Nhom.FieldName = "Nhom";
            this.Nhom.MaxWidth = 80;
            this.Nhom.MinWidth = 50;
            this.Nhom.Name = "Nhom";
            this.Nhom.Visible = true;
            this.Nhom.VisibleIndex = 0;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TenDangNhap.AppearanceHeader.Options.UseFont = true;
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
            this.TenNhanVien.Caption = "gridColumn3";
            this.TenNhanVien.FieldName = "TenNhanVien";
            this.TenNhanVien.MaxWidth = 150;
            this.TenNhanVien.MinWidth = 100;
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Visible = true;
            this.TenNhanVien.VisibleIndex = 2;
            this.TenNhanVien.Width = 100;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.Caption = "Mã Nhân Viên";
            this.MaNhanVien.FieldName = "MaNhanVien";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // gcChucNang
            // 
            this.gcChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChucNang.Location = new System.Drawing.Point(0, 0);
            this.gcChucNang.MainView = this.gvChucNang;
            this.gcChucNang.Name = "gcChucNang";
            this.gcChucNang.Size = new System.Drawing.Size(491, 437);
            this.gcChucNang.TabIndex = 1;
            this.gcChucNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChucNang});
            // 
            // gvChucNang
            // 
            this.gvChucNang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaTinhNang,
            this.Description,
            this.Quyen,
            this.IsGroup});
            this.gvChucNang.GridControl = this.gcChucNang;
            this.gvChucNang.Name = "gvChucNang";
            this.gvChucNang.OptionsSelection.MultiSelect = true;
            // 
            // MaTinhNang
            // 
            this.MaTinhNang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.MaTinhNang.AppearanceHeader.Options.UseFont = true;
            this.MaTinhNang.Caption = "Mã Tính Năng";
            this.MaTinhNang.FieldName = "MaTinhNang";
            this.MaTinhNang.MaxWidth = 20;
            this.MaTinhNang.MinWidth = 10;
            this.MaTinhNang.Name = "MaTinhNang";
            this.MaTinhNang.Visible = true;
            this.MaTinhNang.VisibleIndex = 0;
            this.MaTinhNang.Width = 20;
            // 
            // Description
            // 
            this.Description.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Description.AppearanceHeader.Options.UseFont = true;
            this.Description.Caption = "Chức Năng";
            this.Description.FieldName = "Decription";
            this.Description.MaxWidth = 250;
            this.Description.MinWidth = 200;
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 1;
            this.Description.Width = 242;
            // 
            // Quyen
            // 
            this.Quyen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Quyen.AppearanceHeader.Options.UseFont = true;
            this.Quyen.Caption = "Quyền";
            this.Quyen.FieldName = "Quyen";
            this.Quyen.MaxWidth = 150;
            this.Quyen.MinWidth = 100;
            this.Quyen.Name = "Quyen";
            this.Quyen.Visible = true;
            this.Quyen.VisibleIndex = 2;
            this.Quyen.Width = 129;
            // 
            // IsGroup
            // 
            this.IsGroup.Caption = "IsGroup";
            this.IsGroup.FieldName = "IsGroup";
            this.IsGroup.Name = "IsGroup";
            this.IsGroup.Visible = true;
            this.IsGroup.VisibleIndex = 3;
            // 
            // mnKhoaQuyen
            // 
            this.mnKhoaQuyen.Image = ((System.Drawing.Image)(resources.GetObject("mnKhoaQuyen.Image")));
            this.mnKhoaQuyen.Name = "mnKhoaQuyen";
            this.mnKhoaQuyen.Size = new System.Drawing.Size(137, 22);
            this.mnKhoaQuyen.Text = "Khoá quyền";
            this.mnKhoaQuyen.Click += new System.EventHandler(this.mnKhoaQuyen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // mnChiXem
            // 
            this.mnChiXem.Image = global::KhachSan.Properties.Resources.tsbSearch;
            this.mnChiXem.Name = "mnChiXem";
            this.mnChiXem.Size = new System.Drawing.Size(137, 22);
            this.mnChiXem.Text = "Chỉ xem";
            this.mnChiXem.Click += new System.EventHandler(this.mnChiXem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // mnToanQuyen
            // 
            this.mnToanQuyen.Image = global::KhachSan.Properties.Resources.button_ok;
            this.mnToanQuyen.Name = "mnToanQuyen";
            this.mnToanQuyen.Size = new System.Drawing.Size(137, 22);
            this.mnToanQuyen.Text = "Toàn quyền";
            this.mnToanQuyen.Click += new System.EventHandler(this.mnToanQuyen_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnKhoaQuyen,
            this.toolStripSeparator1,
            this.mnChiXem,
            this.toolStripSeparator2,
            this.mnToanQuyen});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 82);
            // 
            // frmPhanQuyenChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 437);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmPhanQuyenChucNang";
            this.Text = "Phân quyền chức năng";
            this.Load += new System.EventHandler(this.frmPhanQuyenChucNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn Nhom;
        private DevExpress.XtraGrid.Columns.GridColumn TenDangNhap;
        private DevExpress.XtraGrid.Columns.GridColumn TenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhanVien;
        private DevExpress.XtraGrid.GridControl gcChucNang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn MaTinhNang;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn Quyen;
        private DevExpress.XtraGrid.Columns.GridColumn IsGroup;
        private System.Windows.Forms.ToolStripMenuItem mnKhoaQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnChiXem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnToanQuyen;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}