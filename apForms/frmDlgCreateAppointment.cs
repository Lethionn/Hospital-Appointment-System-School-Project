using DevExpress.XtraEditors;
using sclDW.seCom.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using seCom = sclDW.seCom;

namespace HospitalApp.apForms
{
    public partial class frmDlgCreateAppointment : DevExpress.XtraEditors.XtraForm
    {
        seCom.mbTable mbtPatSelect;
        seCom.mbTable mbtPatInsert;

        


        seCom.mbTable _imbDep;
        seCom.mbTable _imbDoctors;
        seCom.mbTable _imbApp;

        seCom.Utils.CProcInfo ProcInfo;
        //seCom.Utils.

        seCom.Utils.CLookUpInfoList luListForNewPatient;
        private DataRow _RowFoundPatient;



        public frmDlgCreateAppointment(seCom.mbTable vmbDep, seCom.mbTable vmbtPationSelect, seCom.mbTable vmbDoctors,seCom.mbTable vmbApp)
        {
            InitializeComponent();
            _imbDoctors = vmbDoctors;
            _imbDep = vmbDep;
            _imbApp = vmbApp;
            mbtPatSelect = vmbtPationSelect;

            

            ProcInfo = new seCom.Utils.CProcInfo(apGlobal.dbCiData.Connection, "sp_MakeAppointment");

            

          


            
            SetLue(leCitizen, mbtPatSelect, "CitizenId", "RID");
            SetLue(lueDep, _imbDep, "DpName", "DPID");
           // SetLue(lueDoctor, _imbDoctors, "Name", "DRID");
            seCom.DevexUtil.SetLookUpEdit(lueDoctor, _imbDoctors.Table, "ID", "Name", "ID:15,Name:60");


            InitForNewPatient();



            mbtPatInsert = new seCom.mbTable("select * from tPatients where CreateDate > GetDate() ", 0, "tPatients", "RID", "RID", apGlobal.dbCiData.Connection);
            mbtPatInsert.Refresh();
            mbtPatInsert.SetDateFieldParamToGetDateForInsertCommand("CreateDate");


            lueDep.Properties.DataSource = _imbDep.Table;


            SetCitizenTextCollection();

            
           
        }

        private void InitForNewPatient()
        {

            luListForNewPatient = new CLookUpInfoList();

            luListForNewPatient.AddNew("Gender", "Gender", "Gender", apGlobal.MbtGender.Table, "ID", "Description");
            luListForNewPatient.AddNew("City", "AdrCity", "City", apGlobal.MbtCity.Table, "GID", "Name");


            seCom.Utils.CLookUpInfo lui = new CLookUpInfo("Town", "AdrTown", "Town", apGlobal.MbtTown.Table, "GID", "Name");
            lui.SetFilterForReferencField("AdrCity", "RfCity");
            luListForNewPatient.AddNew(lui);



        }

        private void SetCitizenTextCollection()
        {

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.AddRange(seCom.cSqlDBA.GetFieldAsList(mbtPatSelect.Table, "CitizenId").ToArray());


            edtCitizenId.MaskBox.AutoCompleteCustomSource = col;
            edtCitizenId.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            edtCitizenId.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


        }

        private void SetLue(LookUpEdit lue,seCom.mbTable mbt,string vDispMem, string vValMem)
        {
            lue.Properties.DataSource = mbt.Table;
            lue.Properties.DisplayMember = vDispMem;
            lue.Properties.ValueMember = vValMem;



        }

        private void textEdit1_Leave(object sender, EventArgs e)
        {
            DataRow rFind = mbtPatSelect.GetRow("CitizenId", edtCitizenId.EditValue);
            if (rFind == null)
            {
                string vhata = "";
                //seCom.DevexUtil.UyariGoster("There is no citizen matched with number you entered.\nA Dialog will be opened to enter new citisen");
                seCom.DevexUtil.UyariGoster("Girdiğiniz numara için bir hasta kayıtlı değildir.\nYeni Hasta kaydı için bir Dialog açılacak");

                seCom.DevEx.FrmKayitDynDxForMBT f = new seCom.DevEx.FrmKayitDynDxForMBT(mbtPatInsert, seCom.eKayitTip.Yeni, null, "", "CitizenId,PName,PSurname,AdrCity,AdrTown,Gender", "CitizenId");
                f.SetLookupInfoList(luListForNewPatient);
                f.SetDefaultValue("CitizenId", edtCitizenId.EditValue);
                if (f.ShowDialog()==DialogResult.OK )
                {
                    DataRow rn = f.ActiveRow;

                    DataRow ra =mbtPatSelect.AddNewRow("RID,CitizenId,Name", new object[] { rn["RID"], rn["CitizenId"], rn["PName"].ToString() + ' ' + rn["PSurname"] },out vhata);
                    ra.AcceptChanges();
                    rFind = ra;

                    edtName.EditValue = rFind["Name"].ToString();
                    _RowFoundPatient = rFind;

                }
            } 
            else
            {
                _RowFoundPatient = rFind;
                edtName.EditValue = rFind["Name"].ToString();

            }
            


        }

        private void lueDep_EditValueChanged(object sender, EventArgs e)
        {
            lueDoctor.EditValue = null;
            
            lueDoctor.Properties.DataSource = seCom.cSqlDBA.FilterTable(_imbDoctors.Table, "DepartmentId=" + lueDep.EditValue.ToString());
        }


        public DataRow GetRecordedDataRow()
        {
            if (ProcInfo.ResultTable != null && ProcInfo.ResultTable.Rows.Count > 0)
                return ProcInfo.ResultTable.Rows[0];
            else
                return null;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_RowFoundPatient == null )
            {
                seCom.DevexUtil.UyariGoster("Seçilmiş bir hasta yok");
                return;
            }
            if (lueDep.EditValue == null || lueDoctor.EditValue == null)
            {
                seCom.DevexUtil.UyariGoster("Doktor ya da depertman seçili değil");
                return;
            }

            ProcInfo.Exec("@APPBY,@DPID,@DRID,@PatientID,@Complaint", new object[] { apGlobal.User.UserId, lueDep.EditValue, lueDoctor.EditValue, _RowFoundPatient["RID"], mEdtComplaint.Text });
            if (ProcInfo.CommandSuccessFul)
            {
                DialogResult = DialogResult.OK;
            } else
            {
                seCom.DevexUtil.HataGoster("Hata:\n"+ProcInfo.Hata);
                return;

            }


            

            

        }

    }
}
