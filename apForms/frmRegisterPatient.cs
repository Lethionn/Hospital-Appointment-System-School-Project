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
    public partial class frmRegisterPatient : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtAppointments;
        seCom.mbTable mbtDoctors;
        seCom.mbTable mbtDeps;
        seCom.mbTable mbtPatSelect;



        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;
        public frmRegisterPatient()
        {
            InitializeComponent();


            mbtDoctors = new seCom.mbTable("select ID,DRID,DrName+' '+DrSurname as Name,DepartmentId from tDoctors ", 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtDoctors.Refresh();

            mbtDeps = apGlobal.MbtDeps;// new seCom.mbTable("select * from tDepartments", 0, "", "", "", apGlobal.dbCiData.Connection);
         

            mbtPatSelect = new seCom.mbTable("select RID,CitizenId,PName+' ' +PSurname as Name from tPatients", 0, "", "", "", apGlobal.dbCiData.Connection);
            mbtPatSelect.Refresh();


            mbtAppointments = new seCom.mbTable("select * from tAppointments where CreateDate >= @CDate1 and  CreateDate<= @CDate2 ", 0, "tAppointments", "APID", "APID", apGlobal.dbCiData.Connection);
            dtpCreateDate1.EditValue = DateTime.Today.AddDays(-1);
            dtpCreateDate2.EditValue = DateTime.Today.AddDays(1);


            dtpAppDate1.EditValue = DateTime.Today;
            dtpAppDate2.EditValue = DateTime.Today;



            mbtAppointments.SetCommandParams("@CDate1,@CDate2", new object[] { dtpCreateDate1.EditValue, dtpCreateDate2.EditValue } );
            
            mbtAppointments.Refresh();
            mbtAppointments.SetDateFieldParamToGetDateForInsertCommand("CreateDate");


            
            gridControl.DataSource = mbtAppointments.Table;
            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.RegisterPatients, 0, mbtAppointments, gridControl, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);

            mbtGirdMan.AddLookUpInfo("Depertment", "DPID", "Department", mbtDeps.Table, "DPID", "DpName");
            mbtGirdMan.AddLookUpInfo("Status", "StatusID", "Status", apGlobal.MbtAppStatus.Table, "StatusID", "Description");
            mbtGirdMan.AddLookUpInfo("Patient", "PatientID", "Status", mbtPatSelect.Table, "RID", "Name");




            seCom.Utils.CLookUpInfo lui = mbtGirdMan.AddLookUpInfo("Doctor", "DoctorID", "Doctor", mbtDoctors.Table, "ID", "Name");
            lui.SetFilterForReferencField("DPID", "DepartmentId");

            
            
            

        }

        private void QueryPatientsRegister()
        {

            string query = "select * from tAppointments where (CreateDate >= @CDate1 and  CreateDate<= @CDate2) ";
            mbtAppointments.SetCommandParams("@CDate1,@CDate2", new object[] { dtpCreateDate1.EditValue, dtpCreateDate2.EditValue });


            if (btnCheckAppointmentDate.Checked) 
            {

                query += "AND (ApDate >= @ADate1 and ApDate <=@ADate2 ) ";
                mbtAppointments.SetCommandParams("@ADate1,@ADate2", new object[] { dtpAppDate1.EditValue, dtpAppDate2.EditValue });


            }
            mbtAppointments.SetSelectCommand(query);

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
            try
            {
                mbtAppointments.Update();
            } catch (Exception E)
            {
                seCom.DevexUtil.UyariGoster(E.Message);

            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //mbtGirdMan.NewRecord();
            frmDlgCreateAppointment f = new frmDlgCreateAppointment(mbtDeps,mbtPatSelect, mbtDoctors,mbtAppointments);
            if (f.ShowDialog() == DialogResult.OK )
            {
                DataRow nr = f.GetRecordedDataRow();
                DataRow ar;
                if (nr !=null)
                {
                    ar = mbtAppointments.AddNewRowByOtherSameRow(nr,"");
                    ar.AcceptChanges();

                }



            }

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