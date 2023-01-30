using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JxIntraWeb.App_DataEngine;

namespace JxIntraWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)       
            {
                this.LblLogInRet.Text = "";   
            }
        }
        private bool ValidateDataAuth()
        {
            bool CommitAuth = true;  //Default true
            try
            {
                //บัญชีชื่อ
                if (TxtAccount.Text == "")
                {
                    CommitAuth = false;
                }

                //รหัสผ่าน
                if (TxtPassword.Text == "")
                {
                    CommitAuth = false;
                }
            }
            catch (Exception e)
            {
                CommitAuth = false;
                LblLogInRet.Text = e.Message;
            }
            return CommitAuth;
        }
        protected void CmdLogIn_Click(object sender, EventArgs e)
        {
            //
            string AccountInp = TxtAccount.Text.Trim().ToLower();
            string PasswordInp = TxtPassword.Text.Trim().ToLower();
            string TerminalMACAddrInPut = "";
            string TerminalClientInfo = "";
            //
            string LogInResult="";
            string AccountID = "";
            string USR_IDENTIFIER_MODE;
            if (ValidateDataAuth() == true)
            {
                // LogIn Process
                JxAuthenEngine incLogInAuth = new JxAuthenEngine();
                LogInResult = incLogInAuth.LogInAuthReconsile(AccountInp, PasswordInp, TerminalMACAddrInPut, TerminalClientInfo);
                //Pattern Output[T: 0000000000
                //              E: Error Description..
                //              L:EM->... --------EM :ยืนยันตัวตนด้วย OTP ทาง EMail
                //              L:PN->... --------PN:ยืนยันตัวตนด้วย OTP ทางโทรศัพท์
                //              L:PS->... --------ยืนยันตัวตนโดยรหัสผ่านชุดที่ 2
                if (LogInResult.Trim().ToUpper().Substring(0, 1).ToUpper() == "T")
                {
                    TxtPassword.Text = "";
                    // เปิดโปรแกรมหลัก
                    // SET @strRetponseMsg='T:' + FORMAT(@intUserIDx,'0000000000') +':บัญชีชื่อและรหัสผ่านถูกต้อง' ;
                    AccountID = LogInResult.Trim().ToUpper().Substring(2, 10);
                    Session["USRID"] = AccountID;
                    this.LblLogInRet.Text = "";
                    Server.Transfer("/App_Pages/Welcome.aspx");
                }
                else if (LogInResult.Trim().ToUpper().Substring(0, 1).ToUpper() == "L")  //Log Buffer
                {
                    // @strUSR_IDENTIFIER_MODE --> FPS:ยืนยันตัวตนโดยรหัสผ่านชุดที่ 2   FEM :ยืนยันตัวตนด้วย OTP ส่งทาง EMail   FPN:ยืนยันตัวตนด้วย OTP ส่งทางโทรศัพท์
                    // SET @strRetponseMsg='F' + @strUSR_IDENTIFIER_MODE + ':System Buffer(LOG)= Lock Account -> ' + @strAccountLogIn;
                    USR_IDENTIFIER_MODE = LogInResult.Trim().ToUpper().Substring(2, 2);
                    switch (LogInResult.Trim().ToUpper().Substring(0, 3).ToUpper() ?? "")
                    {
                        case "PS":
                            // MessageBox.Show("เปิดหน้า รหัสผ่านชุดที่ 2", "คำชี้แจง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            //JPX_TERMINAL.OpenPWD2thVerifyMode(Conversions.ToInteger(strAccountID), strAccountLogInput);
                            break;
                        case "EM":
                            //MessageBox.Show("เปิดหน้า OTP รับทาง E-Mail", "คำชี้แจง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            //JPX_TERMINAL.OpenOTPVerifyMode(Conversions.ToInteger(strAccountID), strAccountLogInput);
                            break;
                        case "PN":
                            //MessageBox.Show("เปิดหน้า OTP รับทาง SMS Phone", "คำชี้แจง", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            //JPX_TERMINAL.OpenOTPVerifyMode(Conversions.ToInteger(strAccountID), strAccountLogInput);
                            break;
                        default:
                            LblLogInRet.Text="** ระบบไม่พบรูปแบบการยืนยันตัวตน!!";
                            break;
                    }
                    //
                    Session["USRID"] = "";
                    LblLogInRet.Text =  LogInResult.Replace("E:", "");
                    TxtPassword.Text = "";
                    TxtAccount.Focus();
                }
                else
                {
                    Session["USRID"] = "";
                    LblLogInRet.Text=LogInResult.Replace("E:","");
                    TxtPassword.Text = "";
                    TxtAccount.Focus();
                }
            }
            else
            {
                LblLogInRet.Text= LogInResult.Replace("E:", "");
                TxtPassword.Text="";
                TxtAccount.Focus();
            }
        }
    }
}