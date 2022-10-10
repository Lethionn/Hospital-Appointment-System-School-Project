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
    public partial class frmUsers : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        seCom.mbTable mbtUsers;
        seCom.mbTable mbtPerms;
        //seCom.DevExGridMan dgmUser;
        seCom.DevEx.CDxMBTGridMan mbtGirdMan;

        seCom.DevEx.CDxMBTGridMan mbtGManPerms;

        seCom.DevExUtilN.CTwoGridMouseAction TwoGrdAct;

        DataTable _tbUTypes;
        public frmUsers()
        {
            InitializeComponent();

            mbtUsers = new seCom.mbTable("select * from tUsers", 0, "tUsers", "USID", "USID", apGlobal.dbCiData.Connection);
            mbtUsers.Refresh();



            _tbUTypes = seCom.seAction.CreateTableForEnum(typeof(apClasses.EUserType));
            grdUtypes.DataSource = _tbUTypes;
            seCom.DevexUtil.GetMainView(grdUtypes).OptionsBehavior.Editable = false;
            seCom.DevexUtil.VisibleGridColumnsAndSizes(grdUtypes, "ID:40,Name:600");
            seCom.DevexUtil.GetMainView(grdUtypes).FocusedRowChanged += UTypes_FocusedRowChanged;



            grdModuls.DataSource = apGlobal.TbModuls;
            
            seCom.DevexUtil.GetMainView(grdModuls).OptionsBehavior.Editable = false;
            seCom.DevexUtil.VisibleGridColumnsAndSizes(grdModuls, "ID:35,Name:200");
            //seCom.DevexUtil.GetMainView(grdModuls).ViewCaption = "r["Name"].ToString();


            //dgmUser = new seCom.DevExGridMan(apGlobal.ApplicationID, (int)EModuls.Users, 0, gridControl, apGlobal.dbCiData.Connection, seCom.DevExGridMan.eSaveTarget.ToFile);
            grdUsers.DataSource = mbtUsers.Table;




            mbtGirdMan = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID,(int)EModuls.Users, 0, mbtUsers, grdUsers, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);
            mbtGirdMan.AddLookUpInfo("UserType", "UType","UserType", apGlobal.MbtUserTypes.Table, "ID", "Description");


            


            mbtPerms =new seCom.mbTable("select * from tPermitions", 0, "tPermitions", "ID", "ID", apGlobal.dbCiData.Connection);
            mbtPerms.Refresh();
            grdsPerms.DataSource = mbtPerms.Table;

            mbtGManPerms = new seCom.DevEx.CDxMBTGridMan(apGlobal.ApplicationID, (int)EModuls.Users, 1, mbtPerms, grdsPerms, apGlobal.dbCiData.Connection, seCom.DevEx.CDxGM.eSaveTarget.ToFile, true, true, true);
            mbtGManPerms.AddLookUpInfo("Modul", "ModulID", "Modul", apGlobal.TbModuls, "ID", "Name");
            seCom.DevexUtil.GetMainView(grdsPerms).OptionsBehavior.Editable = false;





            TwoGrdAct = new seCom.DevExUtilN.CTwoGridMouseAction(grdModuls, grdsPerms);
            TwoGrdAct.Dropped += TwoGrdact_Dropped;




                



        }

        private void UTypes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (mbtPerms == null) return;
            DataRow r = seCom.DevexUtil.GetGridActiveRow(grdUtypes);
            if (r == null) return;
            seCom.DevexUtil.GetMainView(grdsPerms).ViewCaption = r["Name"].ToString();
            DataView v = seCom.cSqlDBA.FilterTable(mbtPerms.Table, "UTYPE=" + r["ID"].ToString());
            grdsPerms.DataSource = v;
        }

        private void TwoGrdact_Dropped(object sender, seCom.DevExUtilN.TwoGridActionEventArgs e)
        {
            int ID = (int)e.Kaynak["ID"];
            DataRow r = seCom.DevexUtil.GetGridActiveRow(grdUtypes);

            if (mbtPerms.GetRow("ModulID,UTYPE", new object[] { ID,r["ID"] }) != null) return;
            string err = "";




            mbtPerms.AddNewRow("UTYPE,ModulID", new object[] { r["ID"], ID },out err);
            
            //DataView v = seCom.cSqlDBA.FilterTable(mbtPerms.Table, "USID=" + r["USID"].ToString());
            //grdsPerms.DataSource = v;





        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            grdUsers.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtUsers.Refresh();
            
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnUpdatePerm_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtPerms.Update();
        }

        private void btnDeletePerm_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow r = seCom.DevexUtil.GetGridActiveRow(grdsPerms);
            r.Delete();
            
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           

        }

        private void bbiUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            mbtUsers.Update();
        }
    }
}