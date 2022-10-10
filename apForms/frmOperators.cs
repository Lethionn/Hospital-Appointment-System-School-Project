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
    public partial class frmOperators : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtUsers;
        seCom.mbTable mbtOpr;
        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmOperators()
        {
            InitializeComponent();


            mbtUsers = new seCom.mbTable("select * from tUsers where UType="+ ((int)apClasses.EUserType.Operator).ToString(), 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtUsers.Refresh();

            

            mbtOpr = new seCom.mbTable("select * from tOperators", 0, "tOperators", "ID", "ID", apGlobal.dbCiData.Connection);
            mbtOpr.Refresh();

            
            gridControl.DataSource = mbtOpr.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.Operators, 0, mbtOpr, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);


            mbtGirdMan.AddLookUpInfo("User", "OPID", "UName", mbtUsers.Table, "USID", "UName");
            
            
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtOpr.Refresh();
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
                mbtOpr.Update();
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