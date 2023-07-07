using BussinessLayer;
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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        int _maDatPhong;
        public frmReport(int mdp)
        {
            InitializeComponent();
            _maDatPhong = mdp;
        }
        private void frmReport_Load(object sender, EventArgs e)
        {
            CrystalReport1 crp = new CrystalReport1();
            crp.SetDataSource(myFunctions.layDuLieu("Exec Phieu_DatPhong " + _maDatPhong));
            crpReport.ReportSource = crp;
        }
    }
}
