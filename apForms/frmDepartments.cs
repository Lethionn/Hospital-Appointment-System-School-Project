using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using seCom = sclDW.seCom;

namespace HospitalApp.apForms
{
    public partial class frmDepartments : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtDeps;
        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmDepartments()
        {
            InitializeComponent();

            mbtDeps = apGlobal.MbtDeps;
            //new seCom.mbTable("select * from tDepartments", 0, "tDepartments", "DPID", "DPID", apGlobal.dbCiData.Connection);
            mbtDeps.Refresh();

            
            gridControl.DataSource = mbtDeps.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.Departments, 0, mbtDeps, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);
            
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtDeps.Update();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}