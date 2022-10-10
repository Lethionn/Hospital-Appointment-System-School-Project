using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace HospitalApp
{
    public partial class FrmDlgAyar : Form
    {
        sclDW.seCom.cDbConnectionInfo ci;
        
        public FrmDlgAyar(sclDW.seCom.cDbConnectionInfo vCi)
        {
            InitializeComponent();

            ci = vCi;
            

            edtServer.Text = ci.Server;
            edtDB.Text = ci.DBName;
            edtUser.Text = ci.UserName;
            edtPassword.Text = ci.Password;

            /*
            edtFirmaNo.Text = apParams.LogoFirmaNo.ToString();
            edtDonem.Text = apParams.LogoDonemNo.ToString();
            edtIsYeriNo.Text = apParams.LogoIsyeriNo.ToString();
            edtYetkiKod.Text = apParams.YetkiKodu;
            edtSayKodDeger.Text = apParams.SayisalKod;
            //edtCariIlgiliEkTabloAdi.Text = apGlobals.dbCi.CariIlgiliTabloAdi;
            */
 
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edtPassword.Text.Trim() == "")
            {
                if (string.IsNullOrEmpty(ci.Password))
                {
                    MessageBox.Show("Giriş Şifresi belirlenmemiş! Yine de bağlanılmaya çalışılacak.");
                    sclDW.seCom.cDbConnectionInfo gci = new sclDW.seCom.cDbConnectionInfo(ci.ConInfoFileSectionName, edtServer.Text, edtDB.Text, edtUser.Text, edtPassword.Text);
                    if (gci.TestConnection())
                    {
                        MessageBox.Show("Bağlantı Başarılı");

                    }
                    else
                    {
                        MessageBox.Show("Bağlantı Başarısiz olduğu için bağlantı bilgileri kaydedilmedi");
                        return;
                    }
                }
                ci.ReCreateSQLConnection(edtServer.Text, edtDB.Text, edtUser.Text, edtPassword.Text);
            }
            else
            {
                ci.ReCreateSQLConnection(edtServer.Text, edtDB.Text, edtUser.Text, edtPassword.Text);
            }

            ci.SaveToIni();
            //apParams.SetProps(Convert.ToInt32(edtFirmaNo.Text), Convert.ToInt32(edtDonem.Text), Convert.ToInt32(edtIsYeriNo.Text), edtYetkiKod.Text,edtSayKodDeger.Text);
            //apParams.SaveToIni();


            DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sclDW.seCom.cDbConnectionInfo gci = new sclDW.seCom.cDbConnectionInfo(ci.ConInfoFileSectionName, edtServer.Text, edtDB.Text, edtUser.Text, edtPassword.Text);
            
            if (gci.TestConnection())
            {
                MessageBox.Show("Bağlantı başarılı.");
            }
            else
            {
                MessageBox.Show("Bağlantı başarısız.");
            }
        }

        private void btnInitDB_Click(object sender, EventArgs e)
        {
          

            
        }

       
    }
}
