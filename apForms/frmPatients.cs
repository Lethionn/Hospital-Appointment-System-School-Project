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
    public partial class frmPatients : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtPatients;
        


        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmPatients()
        {
            InitializeComponent();


          


            mbtPatients = new seCom.mbTable("select * from tPatients where CreateDate >= @CreateDate", 0, "tPatients", "RID", "RID", apGlobal.dbCiData.Connection);
            edtCreateDate.EditValue = DateTime.Today.AddDays(-3);

            mbtPatients.SetCommandParams("@CreateDate", edtCreateDate.EditValue);
            
            mbtPatients.Refresh();
            mbtPatients.SetDateFieldParamToGetDateForInsertCommand("CreateDate");


            
            gridControl.DataSource = mbtPatients.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.Patients, 0, mbtPatients, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);


            mbtGirdMan.AddLookUpInfo("Gender", "Gender", "Gender", apGlobal.MbtGender.Table, "ID", "Description");
            mbtGirdMan.AddLookUpInfo("City", "AdrCity", "City", apGlobal.MbtCity.Table, "GID", "Name");

            seCom.Utils.CLookUpInfo lui = mbtGirdMan.AddLookUpInfo("Town", "AdrTown", "Town",apGlobal.MbtTown.Table, "GID", "Name");
            lui.SetFilterForReferencField("AdrCity", "RfCity");


            
            

        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtPatients.SetCommandParams("@CreateDate", edtCreateDate.EditValue);
            mbtPatients.Refresh();
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
                mbtPatients.Update();
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