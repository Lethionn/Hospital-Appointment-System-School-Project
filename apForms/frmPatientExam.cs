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
    public partial class frmPatientExam : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtAppointments;
        seCom.mbTable mbtDoctor;
        seCom.mbTable mbtDeps;
        seCom.mbTable mbtPatSelect;
        int _DocIorID=-1;


        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmPatientExam()
        {
            InitializeComponent();


            mbtDoctor = new seCom.mbTable("select ID,DRID,DrName+' '+DrSurname as Name,DepartmentId from tDoctors where DRID=" + apGlobal.User.UserId.ToString(), 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtDoctor.Refresh();

            if (mbtDoctor.Table.Rows.Count > 0)
                _DocIorID = (int)mbtDoctor.Table.Rows[0]["ID"];

            mbtDeps = apGlobal.MbtDeps;
            

            mbtPatSelect = new seCom.mbTable("select RID,CitizenId,PName+' ' +PSurname as Name from tPatients", 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtPatSelect.Refresh();


            mbtAppointments = new seCom.mbTable("select * from tAppointments where DoctorID=@DocID and ApDate >= @ADate1 and  ApDate<= @ADate2 ", 0, "", "", "", apGlobal.dbCiData.Connection);

            dtpAppDate1.EditValue = DateTime.Today.Date;
            dtpAppDate2.EditValue = DateTime.Today.AddDays(2);



            mbtAppointments.SetCommandParams("@DocID,@ADate1,@ADate2", new object[] { _DocIorID,  dtpAppDate1.EditValue, dtpAppDate2.EditValue } );
            
            mbtAppointments.Refresh();
            


            
            gridControl.DataSource = mbtAppointments.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.RegisterPatients, 0, mbtAppointments, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);

            mbtGirdMan.AddLookUpInfo("Depertment", "DPID", "Department", mbtDeps.Table, "DPID", "DpName");
            mbtGirdMan.AddLookUpInfo("Status", "StatusID", "Status", apGlobal.MbtAppStatus.Table, "StatusID", "Description");
            mbtGirdMan.AddLookUpInfo("Patient", "PatientID", "Status", mbtPatSelect.Table, "RID", "Name");




            seCom.Utils.CLookUpInfo lui = mbtGirdMan.AddLookUpInfo("Doctor", "DoctorID", "Doctor", mbtDoctor.Table, "ID", "Name");
            lui.SetFilterForReferencField("DPID", "DepartmentId");

            
            
            

        }

        private void QueryPatientsRegister()
        {
            /*
            string query = "select * from tAppointments where (CreateDate >= @CDate1 and  CreateDate<= @CDate2) ";
            mbtAppointments.SetCommandParams("@CDate1,@CDate2", new object[] { dtpCreateDate1.EditValue, dtpCreateDate2.EditValue });


            if (btnCheckAppointmentDate.Checked) 
            {

                query += "AND (ApDate >= @ADate1 and ApDate <=@ADate2 ) ";
                mbtAppointments.SetCommandParams("@ADate1,@ADate2", new object[] { dtpAppDate1.EditValue, dtpAppDate2.EditValue });


            }
            mbtAppointments.SetSelectCommand(query);
            */
            mbtAppointments.SetCommandParams("@DocID,@ADate1,@ADate2", new object[] { _DocIorID, dtpAppDate1.EditValue, dtpAppDate2.EditValue });
            mbtAppointments.Refresh();



        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryPatientsRegister();
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

        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //mbtGirdMan.NewRecord();
            

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