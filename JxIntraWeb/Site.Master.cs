using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JxIntraWeb.App_DataEngine;
namespace JxIntraWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        DataSet GlobalUsrProfile;
        //
        public string GetUserProfileData(string DataKeyReq)
        {
            string DataRet = "";
            if (DataKeyReq.ToUpper().Trim() == "SITE_CODE") { DataRet = Session["SiteCode"].ToString(); }
            if (DataKeyReq.ToUpper().Trim() == "SITE_NAME") { DataRet = LblUsrSite.Text; }
            if (DataKeyReq.ToUpper().Trim() == "USER_ID") { DataRet= HiddenFieldUsrID.Value.ToString(); }
            if (DataKeyReq.ToUpper().Trim() == "USER_FNAME") { DataRet = LblUsrFullName.Text; }
            //
            return DataRet;
        }
        private void SetUsrInfo()
        {
            if (ValidatorJx.IsEmptyDSet(GlobalUsrProfile) == true)
            {
                // Close Application
                Session["USRID"] = "";
                Server.Transfer("~/Default.aspx");
            }
            else if (GlobalUsrProfile.Tables["TB_ACC_INFO"].Rows.Count > 0)
            {
                DataTable tblAccInfo = GlobalUsrProfile.Tables["TB_ACC_INFO"];
                string SiteCode = "";
                string strSiteName = "";
                string strDeptName = "";
                string strGroupName = "";
                string strFullName = "";
                string strAccount = "";
                string strUserCode = "";
                int USR_ID=0;
                tblAccInfo.Columns["ST_NAME"].ReadOnly = false;
                tblAccInfo.Columns["DE_NAME"].ReadOnly = false;
                tblAccInfo.Columns["GP_NAME"].ReadOnly = false;
                tblAccInfo.Columns["USR_FULL_NAME"].ReadOnly = false;
                tblAccInfo.Columns["USR_ACC"].ReadOnly = false;
                // tblAccInfo.Columns("ST_NAME").AllowDBNull = True
                foreach (DataRow DRow in tblAccInfo.Rows)
                {
                    // DRow("ST_NAME") = Nothing
                    if (DRow["ST_NAME"].Equals(DBNull.Value)) { strSiteName = "null"; } else { strSiteName = DRow["ST_NAME"].ToString(); }
                    if (DRow["DE_NAME"].Equals(DBNull.Value)) { strDeptName = "null"; } else { strDeptName = DRow["DE_NAME"].ToString(); }
                    if (DRow["GP_NAME"].Equals(DBNull.Value)) { strGroupName = "null"; } else { strGroupName = DRow["GP_NAME"].ToString(); }
                    if (DRow["USR_FULL_NAME"].Equals(DBNull.Value)) { strFullName = "null"; } else { strFullName = DRow["USR_FULL_NAME"].ToString(); }
                    if (DRow["USR_ACC"].Equals(DBNull.Value)) { strAccount = "null"; } else { strAccount = DRow["USR_ACC"].ToString(); }
                    if (DRow["SITE_CODE"].Equals(DBNull.Value)) { SiteCode = ""; } else { SiteCode = DRow["SITE_CODE"].ToString(); }
                    // Global Form Param
                    strUserCode = DRow["USR_CODE"].ToString();
                    USR_ID = Convert.ToInt32(DRow["USR_ID"].ToString());
                    //บังคับเปลี่ยน Password
                    //if (DRow["USR_INILOG_PWDCHANGE"].Equals(DBNull.Value)) { boolReqChangePassword = false; } else { boolReqChangePassword = (bool)(DRow["USR_INILOG_PWDCHANGE"]); }
                }
                //
                DataTable tblAccLog =GlobalUsrProfile.Tables["TB_ACC_LOG"];
                tblAccLog.Columns["TID"].ReadOnly = false;
                string strTID = "0";
                foreach (DataRow DRow in tblAccLog.Rows)
                {
                    if (DRow["TID"].Equals(DBNull.Value)) { strTID = "0"; } else { strTID = DRow["TID"].ToString(); }
                }
                // 
                var withBlock = this;
                withBlock.LblUsrSite.Text = strSiteName.ToLower();
                withBlock.LblUsrdept.Text = strDeptName.ToLower();
                withBlock.LblUsrFullName.Text = strFullName.ToLower();
                withBlock.LblUsrCode.Text = strUserCode.ToLower();
                //   
                //withBlock.HiddenFieldSiteID.Value = SiteCode;
                Session["SiteCode"] = SiteCode;
                withBlock.HiddenFieldUsrID.Value = USR_ID.ToString();


            }
        }
        private void SetUsrMenu()
        {
            try
            {
                //ปิดทุกเมนู
                SetAllProgramMainMenuOpen(false);
                if (ValidatorJx.IsEmptyDSet(GlobalUsrProfile) == true)
                {
                    // Close Application
                    Session["USRID"] = "";
                    Server.Transfer("~/Default.aspx");
                }
                else
                {
                    bool GroupMenuLog = true;
                    DataTable tblGroupMenuRule = GlobalUsrProfile.Tables["TB_ACC_GRULE"];
                    foreach (DataRow DRow in tblGroupMenuRule.Rows)
                    {
                        if (DRow["GRP_USE_MENU_RULE"].Equals(DBNull.Value)) { GroupMenuLog = true; } else { GroupMenuLog = (bool)DRow["GRP_USE_MENU_RULE"]; }
                    }
                    //มีการ Lock Menu
                    if (GroupMenuLog == true)
                    {
                        DataTable tblGroupMenu = GlobalUsrProfile.Tables["TB_ACC_MENU"];
                        SetProgramMainMenu(tblGroupMenu);
                    }
                    //เปิด Menu ทั้งหมด
                    else { SetAllProgramMainMenuOpen(true); }
                }
            }
            catch (Exception )
            {
                // Close Application
                Session["USRID"] = "";
                Server.Transfer("~/Default.aspx");
            }
        }
        private void SetProgramMainMenu(DataTable tblGroupMenuRef)
        {
            string MenuCode;
            foreach (DataRow DRow in tblGroupMenuRef.Rows)
            {
                if (DRow["MENU_CODE"].Equals(DBNull.Value)) { MenuCode = "NULL"; } else { MenuCode = DRow["MENU_CODE"].ToString(); }
                //Web HelpDesk
                //AddDataToTableMenuCollection("W10E", "W01:Web HelpDesk", tblData);
                //AddDataToTableMenuCollection("9001", "   |----- 9001 : แจ้งปัญหาการปฏิบัติงาน", tblData);
                //AddDataToTableMenuCollection("9002", "   |----- 9002 : กำหนดผู้รับผิดชองงาน ", tblData);
                //AddDataToTableMenuCollection("9003", "   |----- 9003 : บันทึกการปฏิบัติงาน/ปิดงาน ", tblData);
                //AddDataToTableMenuCollection("9004", "   |----- 9004 : รายงาน", tblData);
                ////Web MainTainnance
                //AddDataToTableMenuCollection("W20E", "W02:Web Mantainance(CM)", tblData);
                //AddDataToTableMenuCollection("9101", "   |----- 9101 : แจ้งซ่อม", tblData);
                //AddDataToTableMenuCollection("9102", "   |----- 9102 : สั่งซ่อม ", tblData);
                //AddDataToTableMenuCollection("9103", "   |----- 9103 : บันทึกการซ่อม/ปิดงาน ", tblData);
                //AddDataToTableMenuCollection("9104", "   |----- 9104 : รายงาน(1)", tblData);
                //AddDataToTableMenuCollection("9105", "   |----- 9105 : รายงาน(2)", tblData);
                ////Web Priviledge
                //AddDataToTableMenuCollection("W30E", "W03:Web Priviledge", tblData);
                //AddDataToTableMenuCollection("9201", "   |----- 9201 : ---", tblData);
                //AddDataToTableMenuCollection("9202", "   |----- 9202 : ---", tblData);
                //AddDataToTableMenuCollection("9203", "   |----- 9203 : ---", tblData);
                //AddDataToTableMenuCollection("9204", "   |----- 9204 : ---", tblData);
                //AddDataToTableMenuCollection("9205", "   |----- 9205 : ---", tblData);
                //
                //HelpDesk
                //if (MenuCode.ToUpper().Trim() == "W10E") { MenuAdmin.Enabled = true; }
                if (MenuCode.ToUpper().Trim() == "9001") { HyperLink9901.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9002") { HyperLink9902.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9003") { HyperLink9903.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9004") { HyperLink9904.Visible = true; }
                //Maintainance
                //if (MenuCode.ToUpper().Trim() == "W20E") { MenuOperate.Enabled = true; }
                if (MenuCode.ToUpper().Trim() == "9101") { HyperLink9101.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9102") { HyperLink9102.Visible = true; }
                //if (MenuCode.ToUpper().Trim() == "9103") { HyperLink9103.Visible = true; }
                //if (MenuCode.ToUpper().Trim() == "9104") { HyperLink9104.Visible = true; }
                //if (MenuCode.ToUpper().Trim() == "9105") { HyperLink9105.Visible = true; }
                //Priviledge
                //if (MenuCode.ToUpper().Trim() == "W20E") { MenuOperate.Enabled = true; }
                if (MenuCode.ToUpper().Trim() == "9201") { HyperLink9201.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9202") { HyperLink9202.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9203") { HyperLink9203.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9204") { HyperLink9204.Visible = true; }
                if (MenuCode.ToUpper().Trim() == "9205") { HyperLink9205.Visible = true; }
                //
                //
            }
        }
        private void SetAllProgramMainMenuOpen(bool VisibleMenu)
        {
            //HelpDesk
            HyperLink9901.Visible = VisibleMenu;
            HyperLink9902.Visible = VisibleMenu;
            HyperLink9903.Visible = VisibleMenu;
            HyperLink9904.Visible = VisibleMenu;

            //Maintanance
            HyperLink9101.Visible = VisibleMenu;
            HyperLink9102.Visible = VisibleMenu;
            //HyperLink9103.Visible = VisibleMenu;
            //HyperLink9104.Visible = VisibleMenu;
            //HyperLink9105.Visible = VisibleMenu;

            //Priviledge
            HyperLink9201.Visible = VisibleMenu;
            HyperLink9202.Visible = VisibleMenu;
            HyperLink9203.Visible = VisibleMenu;
            HyperLink9204.Visible = VisibleMenu;
            HyperLink9204.Visible = VisibleMenu;
            HyperLink9205.Visible = VisibleMenu;
        }
        //
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!Page.IsPostBack)
            {
                if (Session["USRID"] != null)
                {
                    if (string.IsNullOrEmpty(Session["USRID"].ToString()))
                    {
                        Server.Transfer("~/Default.aspx");
                    }
                    else
                    {
                        JxAuthenEngine IncJxAuthenEngineObj= new JxAuthenEngine();
                        try
                        {
                            GlobalUsrProfile = IncJxAuthenEngineObj.GetAccountInfo(Convert.ToInt32(Session["USRID"])) ;
                        }
                        catch (Exception)
                        {
                            GlobalUsrProfile = null;
                        }
                        //
                        SetUsrInfo();
                        SetUsrMenu();
                    }
                }
                else { Server.Transfer("~/Default.aspx"); }
     
            }
        }
        private string ClearServerLogBuffer(int intAccID)
        {
            JxAuthenEngine incJxAuthenEngineObj = new JxAuthenEngine();
            string strResultRet;
            try
            {
                strResultRet = incJxAuthenEngineObj.ApplicationLogout_ClearLogPool(intAccID);
            }
            catch (Exception ex)
            {
                strResultRet = "ERR:" + ex.Message;
            }
            //
            return strResultRet;
        }
        protected void CmdlogOut_Click(object sender, EventArgs e)
        {

            // Clear BufferLog  
            if (ClearServerLogBuffer(Convert.ToInt32(Convert.ToInt32(Session["USRID"]))).Trim().ToUpper().Substring(0, 3).ToUpper() == "TRU")
            {
                Session["USRID"] = "";
                Server.Transfer("~/Default.aspx"); ;
            }
            else
            {
                //Show Modal
            } 
        }
    }
}