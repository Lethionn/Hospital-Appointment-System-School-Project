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
    public partial class frmSpecialities : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtSpecs;
        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmSpecialities()
        {
            InitializeComponent();

            mbtSpecs = new seCom.mbTable("select * from tDrSpecialities", 0, "tDrSpecialities", "SPID", "SPID", apGlobal.dbCiData.Connection);
            mbtSpecs.Refresh();

            
            gridControl.DataSource = mbtSpecs.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.DrSpecialities, 0, mbtSpecs, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);
            
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtSpecs.Refresh();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            mbtGirdMan.DeleteRecord();
            

        }

        private void bbiUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtSpecs.Update();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtGirdMan.NewRecord();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtGirdMan.EditRecord();
        }
    }
}