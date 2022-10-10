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
    public partial class frmCities : DevExpress.XtraEditors.XtraForm
    {
        seCom.mbTable mbtCity;
        seCom.mbTable mbtTown;

        seCom.DevEx.CDxMBTGridMan gmCity;
        seCom.DevEx.CDxMBTGridMan gmTown;

        DataRow _ActiveCityRow;

        public frmCities()
        {
            InitializeComponent();

            mbtCity = new seCom.mbTable("select * from tCity ", 0, "tCity", "GID", "GID", apGlobal.dbCiData.Connection);
            mbtCity.Refresh();
            



            mbtTown = new seCom.mbTable("select * from tTown ", 0, "tTown", "GID", "GID", apGlobal.dbCiData.Connection);
            mbtTown.Refresh();
            

            gmCity= new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID, (int)EModuls.Cities, 0, mbtCity, grdCities, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, false, false, false);
            gmTown= new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID, (int)EModuls.Cities, 1, mbtCity, grdTowns, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, false, false, false);

            


            grdCities.DataSource = mbtCity.Table;
            grdTowns.DataSource = mbtTown.Table;


            //mbtGManUsers = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID, (int)EModuls.Permitions, 0, mbtUsers, grdUser, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, false, false, false);
            //mbtGManUsers.AddLookUpInfo("UserType", "UType", "UserType", apGlobal.MbtUserTypes.Table, "ID", "Description");



        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (mbtTown == null) return;
            DataRow r = seCom.DevexUtil.GetGridActiveRow(grdCities);
            _ActiveCityRow = r;
            if (r == null) return;
            seCom.DevexUtil.GetMainView(grdTowns).ViewCaption = r["Name"].ToString();
            DataView v = seCom.cSqlDBA.FilterTable(mbtTown.Table, "RfCity=" + r["GID"].ToString());
            grdTowns.DataSource = v;
        }

        private void tsbUpdateCity_Click(object sender, EventArgs e)
        {
            mbtCity.Update();
        }

        private void tsbUpdateTown_Click(object sender, EventArgs e)
        {
            mbtTown.Update();
        }

        private void gridView3_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (_ActiveCityRow == null) 
            {
                
                return;
            }
            DataRow r=seCom.DevexUtil.GetGridActiveRow(grdTowns);
            r["RfCity"] = _ActiveCityRow["GID"];
        }
    }
}
