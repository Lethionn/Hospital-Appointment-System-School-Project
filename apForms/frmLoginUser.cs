using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using seCom = sclDW.seCom;
using HospitalApp.apClasses;

namespace HospitalApp.apForms
{ 
    public partial class FrmLoginUser : DevExpress.XtraEditors.XtraForm
    {
        private int _LoginID;
        apClasses.CAppUser _User;


        //public int LoginID { get { return _LoginID; } }
        public CAppUser User { get { return _User; } }
        public FrmLoginUser()
        {
            InitializeComponent();
            Text = apGlobal.ApplicationName + " Login";
        }
       

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (sender == btnCancel)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            } 
            else if ( sender == btnOk )
            {

                string tbName="tUsers";
                DataRow r;
               
                seCom.mbTable mbt = new seCom.mbTable("select * from " +tbName+ " where UName=@UName", 0, "", "", "", apGlobal.dbCiData.Connection);
                mbt.SetCommandParams("@UName", edtUserName.Text);
                try { 
                    mbt.Refresh();                     
                }
                catch (Exception E)
                {
                    seCom.DevexUtil.HataGoster("Kullanıcı Doğurulanırken hata oluştu\r\nHata:" + E.Message);
                    return;
                }
                if (mbt.Table== null ||  mbt.Table.Rows.Count < 1)
                {
                    seCom.DevexUtil.HataGoster("Kullanıcı doğrulanmadı!");
                    return;
                }

                r = mbt.Table.Rows[0]; 
                

                string uname = r["UName"].ToString();

                string decPass = r["Passw"].ToString();

                if ( decPass != edtPassword.Text )
                {
                    seCom.DevexUtil.HataGoster("Geçersiz parola!!");
                    return;
                }
                //_LoginID = Convert.ToInt32(r["USID"]);


                _User = new CAppUser(r);// _LoginID, uname, salt, encPwd, decPass,gsg);

                DialogResult = System.Windows.Forms.DialogResult.OK;

            }
        }




        private void edtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnCikis_Click(btnOk, null);

        }

       
        
    }
}
