using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HospitalApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (!apGlobal.Init())
            {
                MessageBox.Show("Başlangıç işlemleri başarısız");
                return;
            }

            Application.Run(new FrmMain());
        }
    }
}
