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
    public partial class frmAssistants : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtUsers;
        seCom.mbTable mbtDeps;
        seCom.mbTable mbtAss;
        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmAssistants()
        {
            InitializeComponent();

            mbtUsers = new seCom.mbTable("select * from tUsers where UType="+ ((int)apClasses.EUserType.Assistant).ToString(), 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtUsers.Refresh();

            mbtDeps = new seCom.mbTable("select * from tDepartments ", 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtDeps.Refresh();

            mbtAss = new seCom.mbTable("select * from tAsistants", 0, "tAsistants", "ID", "ID", apGlobal.dbCiData.Connection);
            mbtAss.Refresh();

            
            gridControl.DataSource = mbtAss.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.Assistant, 0, mbtAss, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);


            mbtGirdMan.AddLookUpInfo("User", "ASID", "UName", mbtUsers.Table, "USID", "UName");
            mbtGirdMan.AddLookUpInfo("Department", "DepartmentId", "Department", mbtDeps.Table, "DPID", "DpName");

            

        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtAss.Refresh();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                mbtGirdMan.DeleteRecord();
            }catch (Exception E)
            {
                seCom.DevexUtil.UyariGoster(E.Message);
            }
            

        }

        private void bbiUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                mbtAss.Update();
            } catch (Exception E)
            {
                seCom.DevexUtil.UyariGoster(E.Message);

            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtGirdMan.NewRecord();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtGirdMan.EditRecord();
        }

        private void frmAssistants_Load(object sender, EventArgs e)
        {

        }
    }
}