using HospitalApp.apForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalApp
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm//Form
    {
        public FrmMain()
        {
            InitializeComponent();
            apGlobal.SetMainForm(this);

            toolStripStatusLabel1.Text = "User Type : " + apGlobal.User.UType.ToString() + "   ";
            toolStripStatusLabel2.Text = apGlobal.User.PersonName + " " + apGlobal.User.PersonSurname;
        }

        private void tsmUsers_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.Users)) return;

            apForms.frmUsers f = new apForms.frmUsers();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmDoctors_Click(object sender, EventArgs e)
        {

            if (!apGlobal.CheckPermition(EModuls.Doctors)) return;

            apForms.frmDoctors f = new apForms.frmDoctors();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmDepartments_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.Departments)) return;

            apForms.frmDepartments f = new apForms.frmDepartments();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmDrSpecalities_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.DrSpecialities)) return;

            apForms.frmSpecialities f = new apForms.frmSpecialities();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmAssistants_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.Assistant)) return;

            apForms.frmAssistants f = new apForms.frmAssistants();
            f.MdiParent = this;
            f.Show();

        }

        private void tsmOperators_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.Operators)) return;

            apForms.frmOperators f = new apForms.frmOperators();
            f.MdiParent = this;
            f.Show();


        }

        private void tsmPatients_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.Patients)) return;

            apForms.frmPatients f = new apForms.frmPatients();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmRegisterPatient_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.RegisterPatients)) return;

            frmRegisterPatient f = new frmRegisterPatient();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmSatientExam_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.PatientExam)) return;
            frmPatientExam f = new frmPatientExam();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmCities_Click(object sender, EventArgs e)
        {
            if (!apGlobal.CheckPermition(EModuls.Cities)) return;
            frmCities f = new frmCities();
            f.MdiParent = this;
            f.Show();
        }
    }
}
