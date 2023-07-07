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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace KhachSan
{
    public partial class frmPhanQuyenChucNang : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyenChucNang()
        {
            InitializeComponent();
        }
        public int _maNhanVien;
        public String _maCongTy;
        public String _maDonVi;
        NhanVienBLL _nhanVien;
        QuyenBLL _quyen;
        
        private void frmPhanQuyenChucNang_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVienBLL();
            _quyen = new QuyenBLL();
            loadUsers();
            loadTinhNangByNhanVien();
            gvChucNang.RowStyle += GvChucNang_RowStyle;
            gcChucNang.ContextMenuStrip = contextMenuStrip1;
        }

        private void GvChucNang_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle>=0)
            {
                bool isRed = Convert.ToBoolean(gvChucNang.GetRowCellValue(e.RowHandle, gvChucNang.Columns["IsGroup"]));
                if(isRed)
                {
                    e.Appearance.BackColor = Color.DeepSkyBlue;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.Font = new Font("Tahoma", 12, FontStyle.Bold);
                }
            }
        }

        void loadUsers()
        {
            if(_maCongTy == null && _maDonVi == null)
            {
                gcUser.DataSource = _nhanVien.getnhanVienByMaDonVi_TinhNang("CTyNe", "~");
                gvUser.OptionsBehavior.Editable = false;
            }
            else
            {
                gcUser.DataSource = _nhanVien.getnhanVienByMaDonVi_TinhNang(_maCongTy, _maDonVi);
                gvUser.OptionsBehavior.Editable = false;
            }
        }
        void loadTinhNangByNhanVien()
        {
            QuyenTinhNangBLL _quyenTinhNang = new QuyenTinhNangBLL();
            gcChucNang.DataSource = _quyenTinhNang.getTinhNangByNhanVien(_maNhanVien);
            gvChucNang.OptionsBehavior.Editable = false;
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if(int.Parse(gvUser.GetRowCellValue(i,"MaNhanVien").ToString()) == _maNhanVien)
                {
                    gvUser.ClearSelection();
                    gvUser.FocusedRowHandle = i;
                }
            }
        }
        private void gvUser_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name=="Nhom" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.usergroup_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
            if (e.Column.Name == "Nhom" && bool.Parse(e.CellValue.ToString()) == false)
            {
                Image img = Properties.Resources.customer_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void mnKhoaQuyen_Click(object sender, EventArgs e)
        {
            for (int i=0;i<gvChucNang.RowCount;i++)
            {
                if(gvChucNang.IsRowSelected(i))
                {
                    _quyen.update(_maNhanVien, gvChucNang.GetRowCellValue(i, "MaTinhNang").ToString(), 0);
                }
            }
            loadTinhNangByNhanVien();
        }

        private void mnChiXem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvChucNang.RowCount; i++)
            {
                if (gvChucNang.IsRowSelected(i))
                {
                    _quyen.update(_maNhanVien, gvChucNang.GetRowCellValue(i, "MaTinhNang").ToString(), 1);
                }
            }
            loadTinhNangByNhanVien();
        }

        private void mnToanQuyen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvChucNang.RowCount; i++)
            {
                if (gvChucNang.IsRowSelected(i))
                {
                    _quyen.update(_maNhanVien, gvChucNang.GetRowCellValue(i, "MaTinhNang").ToString(), 2);
                }
            }
            loadTinhNangByNhanVien();
        }

        private void gvUser_Click(object sender, EventArgs e)
        {
            _maNhanVien = int.Parse(gvUser.GetFocusedRowCellValue("MaNhanVien").ToString());
            loadTinhNangByNhanVien();
        }
    }
}