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
    public partial class frmDoctors : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtUsers;
        seCom.mbTable mbtDoctors;
        seCom.mbTable mbtDeps;
        seCom.mbTable mbtSpecs;

        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmDoctors()
        {
            InitializeComponent();

            string _hata = "";
            mbtUsers = new seCom.mbTable("select * from tUsers where UType="+((int)apClasses.EUserType.Doctor).ToString(), 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtUsers.Refresh();
            //mbtUsers.AddNewRow("USID,UName,Passw,UType", new object[] { 0, "New", "Test", 1 },out _hata);

            mbtDeps = apGlobal.MbtDeps; //; new seCom.mbTable("select * from tDepartments ", 0, "", "", "", apGlobal.dbCiData.Connection);
            

            mbtSpecs = new seCom.mbTable("select * from tDrSpecialities ", 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtSpecs.Refresh();



            mbtDoctors = new seCom.mbTable("select * from tDoctors", 0, "tDoctors", "ID", "ID", apGlobal.dbCiData.Connection);
            mbtDoctors.Refresh();


            //dgmUser = new seCom.DevExGridMan(apGlobal.ApplicationID, (int)EModuls.Users, 0, gridControl, apGlobal.dbCiData.Connection, seCom.DevExGridMan.eSaveTarget.ToFile);
            gridControl.DataSource = mbtDoctors.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.Doctors, 0, mbtDoctors, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);
            mbtGirdMan.AddLookUpInfo("User", "DRID","UName",     mbtUsers.Table, "USID", "UName");
            mbtGirdMan.AddLookUpInfo("Department", "DepartmentId", "Department", mbtDeps.Table, "DPID", "DpName");
            mbtGirdMan.AddLookUpInfo("Speciality", "Speciality", "Speciality", mbtSpecs.Table, "SPID", "SpecName");



            //BindingList<Customer> dataSource = GetDataSource();
            //gridControl.DataSource = dataSource;
            //bsiRecordsCount.Caption = "RECORDS : " + tbUsers.
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtDoctors.Refresh();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtGirdMan.NewRecord();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtGirdMan.EditRecord();
        }

        private void bbiUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtDoctors.Update();
        }
    }
}