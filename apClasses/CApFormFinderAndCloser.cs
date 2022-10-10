using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace HospitalApp.apClasses
{
    public class CApFormFinderAndCloser
    {
        string _Title;
        public Thread thr;
        private bool _Stop = false;
        public CApFormFinderAndCloser(string vTitle)
        {

            _Title = vTitle;
        }

        public void StartFind()
        {
            ThreadStart ts = new ThreadStart(thrFindFormEsk);
            thr = new Thread(ts);
            thr.Start();

        }
        public void StopFindForm()
        {
            _Stop = true;
        }


        private void thrFindForm()
        {
            Form f = null;
            int index = 0;
            while (!_Stop)
            {
                Application.DoEvents();
                Thread.Sleep(5);
                index++;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    

                    Form frm = Application.OpenForms[i];
                   
                    if (Application.OpenForms.Count < 1) continue;
                    try
                    {
                        if (string.IsNullOrEmpty(frm.Text)) continue;

                        if (frm.Text.Contains(_Title))
                        {

                            frm.Close();
                            frm.Dispose();
                            _Stop = true;
                            break;
                        }
                    }
                    catch { }
                }

            }

        }

        private void thrFindFormEsk()
        {
            Form f = null;
            int index = 0;
            while (f == null && index <4000 && !_Stop )
            {
                Application.DoEvents();
                Thread.Sleep(5);
                index++;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    

                    Form frm = Application.OpenForms[i];
                    Thread.Sleep(5);
                    if (frm.IsDisposed) continue;
                    Thread.Sleep(5);
                    if (frm.IsDisposed) continue;
                    if (Application.OpenForms.Count < 1) continue;
                    try
                    {
                        if (string.IsNullOrEmpty(frm.Text)) continue;

                        if (frm.Text.Contains(_Title))
                        {
                            f = Application.OpenForms[i];
                            break;
                        }
                    }
                    catch { }
                }
                
            }
            if ( f!=null && !f.IsDisposed)
            {
                try
                {

                    f.Close();
                } catch (Exception E)
                {

                }

            }

        }



    }
}
