using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seCom = sclDW.seCom;
using System.Windows.Forms;
using HospitalApp.apClasses;
using sclDW.seCom;
using System.Data;

namespace HospitalApp
{
    #region Moduls

    public enum EModuls
    {
        Users = 1,
        Doctors=2,
        Assistant = 3,
        Operators=4,
        Departments=5,
        DrSpecialities=6,
        Patients=7,
        RegisterPatients=8,
        PatientExam=9,
        Cities=10
        

    }
    
    #endregion


    public class apGlobal
    {


        private static string _ApplicationName = "HospitalAp";
        
        private static seCom.DModul.CDMUser _LoginUser;
        
        private static int _ApplicationID = 202001;
        private static FrmMain _MainForm;
        private static seCom.cDbConnectionInfo _dbCiData;
        
        private static apClasses.CApFormFinderAndCloser _FormCloser;

        
        private static TreeNode _MenuNodRoot;
        private static apClasses.CAppUser _User;

        private static seCom.mbTable _mbtUserTypes;

        private static seCom.mbTable _mbtDeps;
        private static seCom.mbTable _mbtCity;
        private static seCom.mbTable _mbtTown;
        private static seCom.mbTable _mbtGender;
        private static seCom.mbTable _mbtAppStatus;

        private static DataTable _tbModuls;

        #region prop


        public static FrmMain MainForm { get { return _MainForm; } }
        public static seCom.cDbConnectionInfo dbCiData { get { return _dbCiData; } }
        

        public static CAppUser User { get { return _User; } }

        public static mbTable MbtUserTypes { get => _mbtUserTypes; }
        public static int ApplicationID { get => _ApplicationID; }
        public static mbTable MbtCity { get => _mbtCity;  }
        public static mbTable MbtTown { get => _mbtTown;  }
        public static string ApplicationName { get => _ApplicationName;  }
        public static DataTable TbModuls { get => _tbModuls; }
        public static mbTable MbtGender { get => _mbtGender; }
        public static mbTable MbtAppStatus { get => _mbtAppStatus; }
        public static mbTable MbtDeps { get => _mbtDeps; }


        #endregion

        public static bool Init()
        {
            _FormCloser = new apClasses.CApFormFinderAndCloser("About Dev");
            _FormCloser.StartFind();

            //_MenuNodRoot = new TreeNode("Menu");
            //dbCi = new seCom.cDbConnectionInfo(".", "portalOresis", "sa", "selcuk");
            _dbCiData = new seCom.cDbConnectionInfo("dbHospitalAp", ".", "dbHospitalAp", "sa", "selcuk", ApplicationName);
            dbCiData.LoadFromIni();



            if (!dbCiData.TestConnection())
            {
                MessageBox.Show("Bağlantı başarısız. Lütfen Veritabanı bağlantı ayarlarınızı kontrol ediniz");

                FrmDlgAyar f = new FrmDlgAyar(dbCiData);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    bool ret = dbCiData.TestConnection();


                    if (!ret) return false;
                }
                else
                {

                    return false;
                }

            }

             _tbModuls = seCom.seAction.CreateTableForEnum(typeof(EModuls));




            //seCom.DModul.DMGlobalInterface.Init(typeof(apGlobal), _MainForm, _ApplicationName, ApplicationID, _ApplicationName, seCom.DModul.eModulInfoSource.Database, dbCiData, dbCiModulSet, dbCiReportSet);
            //seCom.DMGlobalInterface.

            dbCiData.Connection.Open();

            /*
            apForms.FrmLoginUser fLogin = new apForms.FrmLoginUser();
            if (fLogin.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            
            _User = fLogin.User;
            */
           _User = GetUser("seroglu");
           // _User = GetUser("ihvangunas");
         
            LoadBaseTables();
         

            return true;
            
        }

        public static void StopFormCloser()
        {
            _FormCloser.StopFindForm();
        }

        public static void SetMainForm(FrmMain vMain)
        {
            _MainForm = vMain;
            seCom.DModul.DMGlobalInterface.SetMainForm(_MainForm);
        }

        public static bool CheckPermition(EModuls vModul)
        {
            DataRow r = seCom.cSqlDBA.GetRowFromDB("select * from tPermitions where UTYPE=" + ((int)User.UType).ToString() + " and ModulID=" + ((int)vModul).ToString(),dbCiData.Connection );
            if (r == null)
            {
                seCom.DevexUtil.UyariGoster("You have no permition to open this module");
                return false;
            }

            return true;
        }

        public static void LoadBaseTables()
        {
            _mbtUserTypes = new seCom.mbTable("select * from tUserType",0, "", "", "", dbCiData.Connection);
            _mbtUserTypes.Refresh();

            _mbtCity = new seCom.mbTable("select * from tCity", 0, "", "", "", dbCiData.Connection);
            _mbtCity.Refresh();

            _mbtTown = new seCom.mbTable("select * from tTown", 0, "", "", "", dbCiData.Connection);
            _mbtTown.Refresh();

            _mbtGender = new seCom.mbTable("select * from tGender ", 0, "", "", "", apGlobal.dbCiData.Connection);
            _mbtGender.Refresh();

            _mbtAppStatus = new seCom.mbTable("select * from tAppStatus ", 0, "", "", "", apGlobal.dbCiData.Connection);
            _mbtAppStatus.Refresh();

            _mbtDeps = new seCom.mbTable("select * from tDepartments", 0, "", "", "", apGlobal.dbCiData.Connection);
            _mbtDeps.Refresh();


            //select id, yer, db_name,db_server,db_username,server_group, db_password, sinema_adi from servers ", _iDbPortal.Connection);
            //_tbServerGroups = seCom.cSqlDBA.GetTable("select id,group_adi from server_groups", _dbCiPortRep.Connection);
            //_tbServers = seCom.cSqlDBA.GetTable("sp_mb_GetServersForMyBiletAPMConnections", _dbCiPortRep.Connection);
            //_tbTestServer = (new DataView(_tbServers, "id=100", "", DataViewRowState.CurrentRows)).ToTable();

        }

        public static apClasses.CAppUser GetUser(string vUserName)
        {
            DataRow r = seCom.cSqlDBA.GetRowFromDB("select * from tUsers where UName='" + vUserName + "'", dbCiData.Connection);
            apClasses.CAppUser u = new CAppUser(r);
            DataRow rp;
            switch (u.UType)
            {
                case EUserType.Doctor:
                    rp = seCom.cSqlDBA.GetRowFromDB("select * from tDoctors where DRID=" + u.UserId.ToString(), dbCiData.Connection);
                    u.SetInterestPerson(rp["DrName"].ToString(), rp["DrSurname"].ToString(), (int)rp["ID"]);
                    break;
                case EUserType.Assistant:
                    rp = seCom.cSqlDBA.GetRowFromDB("select * from tAsistants where ASID=" + u.UserId.ToString(), dbCiData.Connection);
                    u.SetInterestPerson(rp["AsName"].ToString(), rp["AsSurname"].ToString(), (int)rp["ID"]);
                    break;
                case EUserType.Operator:
                    rp = seCom.cSqlDBA.GetRowFromDB("select * from tOperators where OPID=" + u.UserId.ToString(), dbCiData.Connection);
                    u.SetInterestPerson(rp["OpName"].ToString(), rp["OpSurname"].ToString(), (int)rp["ID"]);
                    break;

            }


            return u;
        }


    }
}
