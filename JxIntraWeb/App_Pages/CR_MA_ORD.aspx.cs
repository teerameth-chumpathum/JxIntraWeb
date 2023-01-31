using JxIntraWeb.App_DataEngine;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JxIntraWeb.App_Pages
{
    public partial class CR_MA_ORD : System.Web.UI.Page
    {
        public DataTable MaintainTbl;
        public DataTable MaintainTbl2;
        public DataTable MaintainTbl3;
        public DataTable MaintainTbl4;
        public DataTable MaintainTbl5;
        public DataTable MaintainTblWheel;
        public DataTable MaintainTbl7;
        //
        public DataTable MaintainTblImage;


        private string SetImageBase64(string fileNameRef)
        {
            //FTP Server URL.
            string ftp = "ftp://192.168.2.105:2121/";

            //FTP Folder name. Leave blank if you want to list files from root folder.
            string ftpFolder = "JxFileAsset/TPTruckDrv/Mnt_Image/";
            try
            {
                //string fileName = "Screenshot.png";
                string fileName = fileNameRef;
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("Administrator", "p@ssw0rdTP");
                request.UsePassive = true;
                request.UseBinary = true;
                request.EnableSsl = false;

                //Fetch the Response and read it into a MemoryStream object.
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (MemoryStream stream = new MemoryStream())
                {
                    response.GetResponseStream().CopyTo(stream);
                    string base64String = Convert.ToBase64String(stream.ToArray(), 0, stream.ToArray().Length);
                    return "data:image/png;base64," + base64String;
                }
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
        private void ImprementOrderImage(string OrderNo)
        {
            //JxMasterService IncJxMasterServiceObj = new JxMasterService();
            //DataSet OrderImageDSet;

            //try
            //{
            //    //ดึงข้อมูลจาก Database Server
            //    OrderImageDSet = IncJxMasterServiceObj.GetOrderObjInfoImage(OrderNo);
            //    //
            //    GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //    MaintainTblImage = incGlobalDataPatternObj.CreateDataTableMaintainImageCollection();
            //    foreach (DataRow DRow in OrderImageDSet.Tables["TB_ORDER_IMG"].Rows)
            //    {
            //        incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]), DRow["Image_File"].ToString(), DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), SetImageBase64(DRow["Image_FileActual"].ToString()), MaintainTblImage);
            //    }
            //    //Session["MaintainTblImage"] = MaintainTblImage;
            //    //
            //    var withBlock = GrdOrderImage;
            //    withBlock.DataSource = MaintainTblImage;
            //    withBlock.DataBind();
            //    withBlock.AutoGenerateColumns = false;
            //    //

            //}
            //catch (Exception ex)
            //{
            //    //
            //}


            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet OrderImageDSet;
            string Path = "~/Upload/"; //Server.MapPath("~/App_Images/"); 
            //string Path = Server.MapPath("~/App_Images/ImagesUpL/");
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderImageDSet = IncJxMasterServiceObj.GetOrderObjInfoImage(OrderNo);
                //
                GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
                MaintainTblImage = incGlobalDataPatternObj.CreateDataTableMaintainImageCollection();
                foreach (DataRow DRow in OrderImageDSet.Tables["TB_ORDER_IMG"].Rows)
                {
                    //incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]),DRow["Image_File"].ToString(), DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), SetImageBase64(DRow["Image_FileActual"].ToString()), MaintainTblImage);
                    incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]), DRow["Image_File"].ToString(), DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), Path + DRow["Image_FileActual"].ToString(), MaintainTblImage);
                }
                //Session["MaintainTblImage"] = MaintainTblImage;
                //
                var withBlock = GrdOrderImage;
                withBlock.DataSource = MaintainTblImage;
                withBlock.DataBind();
                withBlock.AutoGenerateColumns = false;
                //

            }
            catch (Exception ex)
            {
                //
            }





        }
        private void ImprementOrderImage2(string OrderNo)
        {
            //JxMasterService IncJxMasterServiceObj = new JxMasterService();
            //DataSet OrderImageDSet;

            //try
            //{
            //    //ดึงข้อมูลจาก Database Server
            //    OrderImageDSet = IncJxMasterServiceObj.GetOrderObjInfoImage(OrderNo);
            //    //
            //    GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //    MaintainTblImage = incGlobalDataPatternObj.CreateDataTableMaintainImageCollection();
            //    foreach (DataRow DRow in OrderImageDSet.Tables["TB_ORDER_IMG"].Rows)
            //    {
            //        incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]), DRow["Image_File"].ToString(), DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), SetImageBase64(DRow["Image_FileActual"].ToString()), MaintainTblImage);
            //    }
            //    //Session["MaintainTblImage"] = MaintainTblImage;
            //    //
            //    var withBlock = GrdOrderImage2;
            //    withBlock.DataSource = MaintainTblImage;
            //    withBlock.DataBind();
            //    withBlock.AutoGenerateColumns = false;
            //    //

            //}
            //catch (Exception ex)
            //{
            //    //
            //}

            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet OrderImageDSet;
            string Path = "~/Upload/"; //Server.MapPath("~/App_Images/"); 
            //string Path = Server.MapPath("~/App_Images/ImagesUpL/");
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderImageDSet = IncJxMasterServiceObj.GetOrderObjInfoImage(OrderNo);
                //
                GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
                MaintainTblImage = incGlobalDataPatternObj.CreateDataTableMaintainImageCollection();
                foreach (DataRow DRow in OrderImageDSet.Tables["TB_ORDER_IMG"].Rows)
                {
                    //incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]),DRow["Image_File"].ToString(), DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), SetImageBase64(DRow["Image_FileActual"].ToString()), MaintainTblImage);
                    incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]), DRow["Image_File"].ToString(), DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), Path + DRow["Image_FileActual"].ToString(), MaintainTblImage);
                }
                //Session["MaintainTblImage"] = MaintainTblImage;
                //
                var withBlock = GrdOrderImage2;
                withBlock.DataSource = MaintainTblImage;
                withBlock.DataBind();
                withBlock.AutoGenerateColumns = false;
                //

            }
            catch (Exception ex)
            {
                //
            }




        }
        private void SetSumarizeCounter()
        {
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            DataSet CountDSet;
            try
            {
                //
                CountDSet = IncJxTransactionServiceObj.GetOrderCollection_CounterCentral();
                int FileFolder1 = 0;
                int FileFolder2 = 0;
                int FileFolder3 = 0;
                //
                foreach (DataRow DRow in CountDSet.Tables["TB_ORDER_COUNTER"].Rows)
                {
                    FileFolder1 = Convert.ToInt32(DRow["FolderFile1Amt"]);
                    FileFolder2 = Convert.ToInt32(DRow["FolderFile2Amt"]);
                    FileFolder3 = Convert.ToInt32(DRow["FolderFile3Amt"]);
                }
                LblAct1Amt.Text = FileFolder1.ToString();
                LblAct2Amt.Text = FileFolder2.ToString();
                LblAct3Amt.Text = FileFolder3.ToString();
            }
            catch
            {
                LblAct1Amt.Text = "-";
                LblAct2Amt.Text = "-";
                LblAct3Amt.Text = "-";
            }

        }
        private void SetComboDataSourceBinding()
        {
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            DataSet SourceDSet;
            try
            {
                SourceDSet = IncJxTransactionServiceObj.GetVehicleTypeCollection();
                CmbVehType.DataSource = SourceDSet.Tables["TB_VEHTYPE"];
                CmbVehType.DataTextField = "VEH_TYPE";
                CmbVehType.DataValueField = "VEH_TYPE_ID";
                CmbVehType.DataBind();
                CmbVehType.SelectedIndex = 0;
            }
            catch 
            {
                CmbVehType.DataSource = default;
                CmbVehType.DataTextField = "VEH_TYPE";
                CmbVehType.DataValueField = "VEH_TYPE_ID";
                CmbVehType.DataBind();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetSumarizeCounter();
                SetComboDataSourceBinding();
                //
                RdoCR.Enabled = false;
                RdoPM.Enabled = false;
                RdoCR0.Enabled = false;
                RdoPM0.Enabled = false;
            }
        }
        private void ImprementOrderData(string OrderNo, int VEH_ASSET_IDRef)
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet OrderDSet;
            string REC_REF_NO = "";
            string OrderDate = "";
            int VEH_ASSET_ID = 0;
            string VEH_CODE = "";
            string VEH_LICENSE = "";
            string VEH_TYPE = "";
            string VEH_BRAND = "";
            string VEH_MODEL = "";
            string VEH_FUEL_SPEC = "";
            //
            int SERVICE_GARAGE_ID = 0;
            string GARAGE_NAME = "";
            string GARAGE_ADDR = "";
            string GARAGE_CONTACT = "";
            string GARAGE_TEL = "";
            int VEH_AGE = 0;
            float ORD_VEH_MILEDGE = 0f;
            string MNT_TYPE = "";
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderDSet = IncJxMasterServiceObj.GetOrderObjInfo(OrderNo, VEH_ASSET_IDRef);

                //
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER"].Rows)
                {
                    REC_REF_NO = DRow["REC_REF_NO"].ToString();
                    OrderDate = Convert.ToDateTime(DRow["MNT_ORD_DATE"]).ToString("dd/MM/yyyy");
                    VEH_ASSET_ID = Convert.ToInt32(DRow["VEH_ASSET_ID"]);
                    VEH_CODE = DRow["VEH_CODE"].ToString();
                    VEH_LICENSE = DRow["VEH_LICENSE"].ToString();
                    VEH_TYPE = DRow["VEH_TYPE"].ToString();
                    VEH_BRAND = DRow["VEH_BRAND"].ToString();
                    VEH_MODEL = DRow["VEH_MODEL"].ToString();
                    VEH_FUEL_SPEC = DRow["VEH_FUEL_SPEC"].ToString();
                    //
                    SERVICE_GARAGE_ID = Convert.ToInt32(DRow["SERVICE_GARAGE_ID"]);
                    GARAGE_NAME = DRow["GARAGE_NAME"].ToString();
                    GARAGE_ADDR = DRow["GARAGE_ADDR"].ToString();
                    GARAGE_CONTACT = DRow["GARAGE_CONTACT"].ToString();
                    GARAGE_TEL = DRow["GARAGE_TEL"].ToString();
                    VEH_AGE = Convert.ToInt32(DRow["VEH_AGE"]);
                    ORD_VEH_MILEDGE = float.Parse(DRow["ORD_VEH_MILEDGE"].ToString());
                    MNT_TYPE = DRow["MNT_TYPE"].ToString();
                }
                //
                if (MNT_TYPE.ToUpper().Trim() == "PM")
                { RdoPM.Checked = true; RdoCR.Checked = false; }
                else { RdoPM.Checked = false; RdoCR.Checked = true; }
                //
                HideRecRefNo.Value = REC_REF_NO;
                TxtOrderNo.Text = OrderNo;
                TxtOrderDate.Text = OrderDate;
                HideVehID.Value = VEH_ASSET_ID.ToString();
                TxtVehCode.Text = VEH_CODE;
                TxtVehLicense.Text = VEH_LICENSE;
                TxtVehType.Text = VEH_TYPE;
                TxtVehModel.Text = VEH_MODEL;
                TxtVehFuel.Text = VEH_FUEL_SPEC;
                //
                HideGarageID.Value = SERVICE_GARAGE_ID.ToString();
                TxtGarageName.Text = GARAGE_NAME;
                TxtGarageAddr.Text = GARAGE_ADDR;
                TxtGarageContact.Text = GARAGE_CONTACT + " " + GARAGE_TEL;
                TxtVehMiledge.Text = ORD_VEH_MILEDGE.ToString("#,##0.00");
                TxtVehAge.Text = VEH_AGE.ToString("#,##0");
                //
                GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
                MaintainTbl = incGlobalDataPatternObj.CreateDataTableMaintainCollection();
                MaintainTblWheel = incGlobalDataPatternObj.CreateDataTableMaintainWheelCollection();
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainCollection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTbl);
                }
                Session["MaintainTbl"] = MaintainTbl;
                //
                var withBlock = GrdRepairDesc;
                withBlock.DataSource = MaintainTbl;
                withBlock.DataBind();
                withBlock.AutoGenerateColumns = false;
                //
                string MNT_WHL_POS = "";
                string MNT_REQ_REASON = "";
                bool WHL_DAMAGE_AREA1 = false;
                bool WHL_DAMAGE_AREA2 = false;
                bool WHL_DAMAGE_AREA3 = false;
                bool WHL_DAMAGE_AREA4 = false;
                //
                bool WHL_DAMAGE_TYPE1 = false;
                bool WHL_DAMAGE_TYPE2 = false;
                bool WHL_DAMAGE_TYPE3 = false;
                bool WHL_DAMAGE_TYPE4 = false;
                //
                string WHL_DAMAGE_OTH = "";
                string WHL_DAMAGE_TYPEOTH = "";
                //
                //
                string WHL_SERIAL = "";
                string WHL_R_MILE = "";
                string WHL_SIZE = "";
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_WHLL"].Rows)
                {
                    MNT_WHL_POS = DRow["MNT_WHL_POS"].ToString();
                    MNT_REQ_REASON = DRow["MNT_REQ_REASON"].ToString();
                    //
                    WHL_DAMAGE_AREA1 = (bool)DRow["WHL_DAMAGE_AREA1"];
                    WHL_DAMAGE_AREA2 = (bool)DRow["WHL_DAMAGE_AREA2"];
                    WHL_DAMAGE_AREA3 = (bool)DRow["WHL_DAMAGE_AREA3"];
                    WHL_DAMAGE_AREA4 = (bool)DRow["WHL_DAMAGE_AREA4"];
                    //
                    WHL_DAMAGE_TYPE1 = (bool)DRow["WHL_DAMAGE_TYPE1"];
                    WHL_DAMAGE_TYPE2 = (bool)DRow["WHL_DAMAGE_TYPE2"];
                    WHL_DAMAGE_TYPE3 = (bool)DRow["WHL_DAMAGE_TYPE3"];
                    WHL_DAMAGE_TYPE4 = (bool)DRow["WHL_DAMAGE_TYPE4"];
                    //
                    WHL_DAMAGE_OTH = DRow["WHL_DAMAGE_OTH"].ToString();
                    WHL_DAMAGE_TYPEOTH = DRow["WHL_DAMAGE_TYPEOTH"].ToString();
                    //
                    WHL_SERIAL = DRow["WHL_SERIAL"].ToString();
                    WHL_R_MILE = DRow["WHL_R_MILE"].ToString();
                    WHL_SIZE = DRow["WHL_SIZE"].ToString();

                    incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection(MNT_WHL_POS, MNT_REQ_REASON, WHL_DAMAGE_AREA1, WHL_DAMAGE_AREA2, WHL_DAMAGE_AREA3, WHL_DAMAGE_AREA4,
                        WHL_DAMAGE_TYPE1, WHL_DAMAGE_TYPE2, WHL_DAMAGE_TYPE3, WHL_DAMAGE_TYPE4, WHL_DAMAGE_OTH, WHL_DAMAGE_TYPEOTH, WHL_SERIAL, WHL_R_MILE, WHL_SIZE, MaintainTblWheel);
                }
                Session["MaintainTblWheel"] = MaintainTblWheel;
                //
                MaintainTbl5 = OrderDSet.Tables["TB_HISTRY"];
                //
                var withBlockx = GrdWheelPos;
                withBlockx.DataSource = MaintainTblWheel;
                withBlockx.DataBind();
                withBlockx.AutoGenerateColumns = false;
                //
                var withBlocky = GrdRepairDesc4x;
                withBlocky.DataSource = MaintainTbl5;
                withBlocky.DataBind();
                withBlocky.AutoGenerateColumns = false;


                //ModeOperate=CRT | EDT
                HideModeOperate.Value = "EDT";
                MultiView1.ActiveViewIndex = 5;

            }
            catch
            {
                MultiView1.ActiveViewIndex = 5;
            }
        }
        private void ImprementOrderRepair(string OrderNo)
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet OrderDSet;
            string REC_REF_NO = "";
            string OrderDate = "";
            float MNT_TOTAL_PRICE = 0;
            int VEH_ASSET_ID = 0;
            string VEH_CODE = "";
            string VEH_LICENSE = "";
            string VEH_TYPE = "";
            string VEH_BRAND = "";
            string VEH_MODEL = "";
            string VEH_FUEL_SPEC = "";
            //
            int SERVICE_GARAGE_ID = 0;
            string GARAGE_NAME = "";
            string GARAGE_ADDR = "";
            string GARAGE_CONTACT = "";
            string GARAGE_TEL = "";
            int VEH_AGE = 0;
            float ORD_VEH_MILEDGE = 0f;
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderDSet = IncJxMasterServiceObj.GetOrderObjInfoType2(OrderNo);

                //
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER"].Rows)
                {
                    REC_REF_NO = DRow["REC_REF_NO"].ToString();
                    OrderDate = Convert.ToDateTime(DRow["MNT_ORD_DATE"]).ToString("dd/MM/yyyy");
                    MNT_TOTAL_PRICE= float.Parse(DRow["MNT_TOTAL_PRICE"].ToString());
                    VEH_ASSET_ID = Convert.ToInt32(DRow["VEH_ASSET_ID"]);
                    VEH_CODE = DRow["VEH_CODE"].ToString();
                    VEH_LICENSE = DRow["VEH_LICENSE"].ToString();
                    VEH_TYPE = DRow["VEH_ASSET_ID"].ToString();
                    VEH_BRAND = DRow["VEH_BRAND"].ToString();
                    VEH_MODEL = DRow["VEH_MODEL"].ToString();
                    VEH_FUEL_SPEC = DRow["VEH_FUEL_SPEC"].ToString();

                    SERVICE_GARAGE_ID = Convert.ToInt32(DRow["SERVICE_GARAGE_ID"]);
                    GARAGE_NAME = DRow["GARAGE_NAME"].ToString();
                    GARAGE_ADDR = DRow["GARAGE_ADDR"].ToString();
                    GARAGE_CONTACT = DRow["GARAGE_CONTACT"].ToString();
                    GARAGE_TEL = DRow["GARAGE_TEL"].ToString();
                    VEH_AGE = Convert.ToInt32(DRow["VEH_AGE"]);
                    ORD_VEH_MILEDGE = float.Parse(DRow["ORD_VEH_MILEDGE"].ToString());
                }
                //HideRecRefNoR.Value = REC_REF_NO;
                TxtOrderNoR.Text = OrderNo;
                TxtOrderDateR.Text = OrderDate;
                //HideVehIDR.Value = VEH_ASSET_ID.ToString();
                TxtVehCodeR.Text = VEH_CODE;
                TxtVehLicenseR.Text = VEH_LICENSE;
                TxtVehTypeR.Text = VEH_TYPE;
                TxtVehModelR.Text = VEH_MODEL;
                TxtVehFuelR.Text = VEH_FUEL_SPEC;
                //
                //HideGarageIDR.Value = SERVICE_GARAGE_ID.ToString();
                TxtGarageNameR.Text = GARAGE_NAME;
                TxtGarageAddrR.Text = GARAGE_ADDR;
                TxtGarageContactR.Text = GARAGE_CONTACT + " " + GARAGE_TEL;
                TxtVehMiledgeR.Text = ORD_VEH_MILEDGE.ToString("#,##0.00");
                TxtVehAgeR.Text = VEH_AGE.ToString("#,##0");
                //
                GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
                DataTable MaintainTblR;
                DataTable MaintainTblWheelR;
                MaintainTblR = incGlobalDataPatternObj.CreateDataTableMaintainCollection();
                //MaintainTbl2 = incGlobalDataPatternObj.CreateDataTableMaintainCostCollection();
                //MaintainTbl3 = incGlobalDataPatternObj.CreateDataTableMaintainPartCollection();
                //MaintainTbl4 = incGlobalDataPatternObj.CreateDataTableMaintainL2Collection();
                MaintainTblWheelR = incGlobalDataPatternObj.CreateDataTableMaintainWheelCollection();
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainCollection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTblR);
                }
                //Session["MaintainTbl"] = MaintainTbl;

                //foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_PRICE"].Rows)
                //{
                //    incGlobalDataPatternObj.AddDataToTableMaintainCostCollection(DRow["MNT_LINENO_DESC"].ToString(), float.Parse(DRow["MNT_LINENO_PRICE"].ToString()), DRow["MNT_LINENO_SERVICER"].ToString(), MaintainTbl2);
                //}
                //Session["MaintainTbl2"] = MaintainTbl2;
                //foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_PART"].Rows)
                //{
                //    incGlobalDataPatternObj.AddDataToTableMaintainPartCollection(DRow["MNT_LINENO_DESC"].ToString(),Convert.ToInt32(DRow["MNT_LINENO_AMT"].ToString()), MaintainTbl3);
                //}
                //Session["MaintainTbl3"] = MaintainTbl3;

                //foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC2"].Rows)
                //{
                //    incGlobalDataPatternObj.AddDataToTableMaintainL2Collection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTbl4);
                //}
                //Session["MaintainTbl4"] = MaintainTbl4;
                //MaintainTbl5 = OrderDSet.Tables["TB_HISTRY"];
                //
                var withBlock2 = GrdRepairDescR;
                withBlock2.DataSource = MaintainTblR;
                withBlock2.DataBind();
                withBlock2.AutoGenerateColumns = false;
                //
                var withBlock3 = GridViewX1;
                withBlock3.DataSource = OrderDSet.Tables["TB_ORDER_PRICE"];
                withBlock3.DataBind();
                withBlock3.AutoGenerateColumns = false;
                TxtMntTotalPrice.Text = MNT_TOTAL_PRICE.ToString("#,##0.00");
                //
                var withBlock4 = GridViewX2;
                withBlock4.DataSource = OrderDSet.Tables["TB_ORDER_PART"];
                withBlock4.DataBind();
                withBlock4.AutoGenerateColumns = false;
                //
                var withBlock5 = GridViewX3;
                withBlock5.DataSource = OrderDSet.Tables["TB_ORDER_DESC2"];
                withBlock5.DataBind();
                withBlock5.AutoGenerateColumns = false;
                //

                //var withBlock6 = GrdRepairDesc4;
                //withBlock6.DataSource = MaintainTbl5;
                //withBlock6.DataBind();
                //withBlock6.AutoGenerateColumns = false;
                //
                string MNT_WHL_POS = "";
                string MNT_REQ_REASON = "";
                bool WHL_DAMAGE_AREA1 = false;
                bool WHL_DAMAGE_AREA2 = false;
                bool WHL_DAMAGE_AREA3 = false;
                bool WHL_DAMAGE_AREA4 = false;
                //
                bool WHL_DAMAGE_TYPE1 = false;
                bool WHL_DAMAGE_TYPE2 = false;
                bool WHL_DAMAGE_TYPE3 = false;
                bool WHL_DAMAGE_TYPE4 = false;

                string WHL_DAMAGE_OTH = "";
                string WHL_DAMAGE_TYPEOTH = "";
                //
                string WHL_SERIAL = "";
                string WHL_R_MILE = "";
                string WHL_SIZE = "";
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_WHLL"].Rows)
                {
                    MNT_WHL_POS = DRow["MNT_WHL_POS"].ToString();
                    MNT_REQ_REASON = DRow["MNT_REQ_REASON"].ToString();
                    //
                    WHL_DAMAGE_AREA1 = (bool)DRow["WHL_DAMAGE_AREA1"];
                    WHL_DAMAGE_AREA2 = (bool)DRow["WHL_DAMAGE_AREA2"];
                    WHL_DAMAGE_AREA3 = (bool)DRow["WHL_DAMAGE_AREA3"];
                    WHL_DAMAGE_AREA4 = (bool)DRow["WHL_DAMAGE_AREA4"];
                    //
                    WHL_DAMAGE_TYPE1 = (bool)DRow["WHL_DAMAGE_TYPE1"];
                    WHL_DAMAGE_TYPE2 = (bool)DRow["WHL_DAMAGE_TYPE2"];
                    WHL_DAMAGE_TYPE3 = (bool)DRow["WHL_DAMAGE_TYPE3"];
                    WHL_DAMAGE_TYPE4 = (bool)DRow["WHL_DAMAGE_TYPE4"];
                    //
                    WHL_DAMAGE_OTH = DRow["WHL_DAMAGE_OTH"].ToString();
                    WHL_DAMAGE_TYPEOTH = DRow["WHL_DAMAGE_TYPEOTH"].ToString();
                    //
                    WHL_SERIAL = DRow["WHL_SERIAL"].ToString();
                    WHL_R_MILE = DRow["WHL_R_MILE"].ToString();
                    WHL_SIZE = DRow["WHL_SIZE"].ToString();
                    //
                    incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection(MNT_WHL_POS,MNT_REQ_REASON, WHL_DAMAGE_AREA1, WHL_DAMAGE_AREA2,WHL_DAMAGE_AREA3, WHL_DAMAGE_AREA4,
                                                                      WHL_DAMAGE_TYPE1, WHL_DAMAGE_TYPE2, WHL_DAMAGE_TYPE3, WHL_DAMAGE_TYPE4, WHL_DAMAGE_OTH, WHL_DAMAGE_TYPEOTH, WHL_SERIAL, WHL_R_MILE, WHL_SIZE, MaintainTblWheelR);
                }
                //Session["MaintainTblWheel"] = MaintainTblWheel;
                var withBlockx = GrdWheelPosR;
                withBlockx.DataSource = MaintainTblWheelR;
                withBlockx.DataBind();
                withBlockx.AutoGenerateColumns = false;


            }
            catch 
            {
                MultiView1.ActiveViewIndex = 6;
            }
        }
        //
        private void ImprementOrderDataUpp(string OrderNo,int VehAssetID)
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet OrderDSet;
            string REC_REF_NO = "";
            string OrderDate = "";
            int VEH_ASSET_ID = 0;
            string VEH_CODE = "";
            string VEH_LICENSE = "";
            string VEH_TYPE = "";
            string VEH_BRAND = "";
            string VEH_MODEL = "";
            string VEH_FUEL_SPEC = "";
            //
            int SERVICE_GARAGE_ID = 0;
            string GARAGE_NAME = "";
            string GARAGE_ADDR = "";
            string GARAGE_CONTACT = "";
            string GARAGE_TEL = "";
            int VEH_AGE = 0;
            float ORD_VEH_MILEDGE = 0f;
            float MNT_TOTAL_PRICE = 0;
            string MNT_TYPE = "";
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderDSet = IncJxMasterServiceObj.GetOrderObjInfo(OrderNo, VehAssetID);

                //
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER"].Rows)
                {
                    REC_REF_NO = DRow["REC_REF_NO"].ToString();
                    OrderDate = Convert.ToDateTime(DRow["MNT_ORD_DATE"]).ToString("dd/MM/yyyy");
                    VEH_ASSET_ID = Convert.ToInt32(DRow["VEH_ASSET_ID"]);
                    VEH_CODE = DRow["VEH_CODE"].ToString();
                    VEH_LICENSE = DRow["VEH_LICENSE"].ToString();
                    VEH_TYPE = DRow["VEH_TYPE"].ToString();
                    VEH_BRAND = DRow["VEH_BRAND"].ToString();
                    VEH_MODEL = DRow["VEH_MODEL"].ToString();
                    VEH_FUEL_SPEC = DRow["VEH_FUEL_SPEC"].ToString();

                    SERVICE_GARAGE_ID = Convert.ToInt32(DRow["SERVICE_GARAGE_ID"]);
                    GARAGE_NAME = DRow["GARAGE_NAME"].ToString();
                    GARAGE_ADDR = DRow["GARAGE_ADDR"].ToString();
                    GARAGE_CONTACT = DRow["GARAGE_CONTACT"].ToString();
                    GARAGE_TEL = DRow["GARAGE_TEL"].ToString();
                    VEH_AGE = Convert.ToInt32(DRow["VEH_AGE"]);
                    ORD_VEH_MILEDGE = float.Parse(DRow["ORD_VEH_MILEDGE"].ToString());
                    MNT_TOTAL_PRICE = float.Parse(DRow["MNT_TOTAL_PRICE"].ToString());
                    MNT_TYPE = DRow["MNT_TYPE"].ToString();
                }
                //
                if (MNT_TYPE.ToUpper().Trim() == "PM")
                { RdoPM0.Checked = true; RdoCR0.Checked = false; }
                else { RdoPM0.Checked = false; RdoCR0.Checked = true; }
                //
                HideRecRefNo2.Value = REC_REF_NO;
                TxtOrderNo2.Text = OrderNo;
                TxtOrderDate2.Text = OrderDate;
                HideVehID2.Value = VEH_ASSET_ID.ToString();
                TxtVehCode2.Text = VEH_CODE;
                TxtVehLicense2.Text = VEH_LICENSE;
                TxtVehType2.Text = VEH_TYPE;
                TxtVehModel2.Text = VEH_MODEL;
                TxtVehFuel2.Text = VEH_FUEL_SPEC;

                HideGarageID2.Value = SERVICE_GARAGE_ID.ToString();
                TxtGarageName2.Text = GARAGE_NAME;
                TxtGarageAddr2.Text = GARAGE_ADDR;
                TxtGarageContact2.Text = GARAGE_CONTACT + " " + GARAGE_TEL;
                TxtVehMiledge2.Text = ORD_VEH_MILEDGE.ToString("#,##0.00");
                TxtVehAge2.Text = VEH_AGE.ToString("#,##0");

                //
                GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
                MaintainTbl = incGlobalDataPatternObj.CreateDataTableMaintainCollection();
                MaintainTbl2 = incGlobalDataPatternObj.CreateDataTableMaintainCostCollection();
                MaintainTbl3 = incGlobalDataPatternObj.CreateDataTableMaintainPartCollection();
                MaintainTbl4 = incGlobalDataPatternObj.CreateDataTableMaintainL2Collection();
                MaintainTblWheel = incGlobalDataPatternObj.CreateDataTableMaintainWheelCollection();
                MaintainTbl7 = incGlobalDataPatternObj.CreateDataTableMaintainCommentCollection();
                //

                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainCollection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTbl);
                }
                Session["MaintainTbl"] = MaintainTbl;

                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_PRICE"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainCostCollection(DRow["MNT_LINENO_DESC"].ToString(), float.Parse(DRow["MNT_LINENO_PRICE"].ToString()), DRow["MNT_LINENO_SERVICER"].ToString(), MaintainTbl2);
                }
                Session["MaintainTbl2"] = MaintainTbl2;
                double MnPriceOP = 0.00;
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_PART"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainPartCollection(
                        DRow["MNT_LINENO_DESC"].ToString(), 
                        Convert.ToInt32(DRow["MNT_LINENO_AMT"].ToString()), 
                        Convert.ToDouble(DRow["MNT_PRICE"].ToString()), 
                        MaintainTbl3);
                    MnPriceOP += Convert.ToDouble(DRow["MNT_PRICE"].ToString());
                }
                lblAmtPrice.Text = MnPriceOP.ToString("#,##0.00");

                Session["MaintainTbl3"] = MaintainTbl3;
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC2"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainL2Collection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTbl4);
                }
                Session["MaintainTbl4"] = MaintainTbl4;
                MaintainTbl5 = OrderDSet.Tables["TB_HISTRY"];

                foreach (DataRow DRow in OrderDSet.Tables["TB_COMMENT"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainCommentCollection(DRow["DATE_NOTE"].ToString(), DRow["DESC_NOTE"].ToString(), DRow["MILEDGE_NOTE"].ToString(), DRow["PRICE_NOTE"].ToString(), DRow["SERVICER_NOTE"].ToString(), MaintainTbl7);
                }
                Session["MaintainTbl7"] = MaintainTbl7;






                var withBlock2 = GrdRepairDesc2;
                withBlock2.DataSource = MaintainTbl;
                withBlock2.DataBind();
                withBlock2.AutoGenerateColumns = false;
                //
                var withBlock3 = GrdRepairDesc3;
                withBlock3.DataSource = MaintainTbl2;
                withBlock3.DataBind();
                withBlock3.AutoGenerateColumns = false;
                TxtTotalPrice.Text = MNT_TOTAL_PRICE.ToString("#,##0.00");
                //
                var withBlock3x = GrdVehDeptComment;
                withBlock3x.DataSource = MaintainTbl7;
                withBlock3x.DataBind();
                withBlock3x.AutoGenerateColumns = false;
                //
                var withBlock4 = GrdRepairPart;
                withBlock4.DataSource = MaintainTbl3;
                withBlock4.DataBind();
                withBlock4.AutoGenerateColumns = false;
                //
                var withBlock5 = GrdRepairDetail;
                withBlock5.DataSource = MaintainTbl4;
                withBlock5.DataBind();
                withBlock5.AutoGenerateColumns = false;
                //

                var withBlock6 = GrdRepairDesc4;
                withBlock6.DataSource = MaintainTbl5;
                withBlock6.DataBind();
                withBlock6.AutoGenerateColumns = false;
                //
                string MNT_WHL_POS = "";
                string MNT_REQ_REASON = "";
                bool WHL_DAMAGE_AREA1 = false;
                bool WHL_DAMAGE_AREA2 = false;
                bool WHL_DAMAGE_AREA3 = false;
                bool WHL_DAMAGE_AREA4 = false;
                //
                bool WHL_DAMAGE_TYPE1 = false;
                bool WHL_DAMAGE_TYPE2 = false;
                bool WHL_DAMAGE_TYPE3 = false;
                bool WHL_DAMAGE_TYPE4 = false;
                //
                string WHL_DAMAGE_OTH = "";
                string WHL_DAMAGE_TYPEOTH = "";
                //
                string WHL_SERIAL = "";
                string WHL_R_MILE = "";
                string WHL_SIZE = "";
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_WHLL"].Rows)
                {
                    MNT_WHL_POS = DRow["MNT_WHL_POS"].ToString();
                    MNT_REQ_REASON = DRow["MNT_REQ_REASON"].ToString();
                    //
                    WHL_DAMAGE_AREA1 = (bool)DRow["WHL_DAMAGE_AREA1"];
                    WHL_DAMAGE_AREA2 = (bool)DRow["WHL_DAMAGE_AREA2"];
                    WHL_DAMAGE_AREA3 = (bool)DRow["WHL_DAMAGE_AREA3"];
                    WHL_DAMAGE_AREA4 = (bool)DRow["WHL_DAMAGE_AREA4"];
                    //
                    WHL_DAMAGE_TYPE1 = (bool)DRow["WHL_DAMAGE_TYPE1"];
                    WHL_DAMAGE_TYPE2 = (bool)DRow["WHL_DAMAGE_TYPE2"];
                    WHL_DAMAGE_TYPE3 = (bool)DRow["WHL_DAMAGE_TYPE3"];
                    WHL_DAMAGE_TYPE4 = (bool)DRow["WHL_DAMAGE_TYPE4"];
                    //
                    WHL_DAMAGE_OTH = DRow["WHL_DAMAGE_OTH"].ToString();
                    WHL_DAMAGE_TYPEOTH = DRow["WHL_DAMAGE_TYPEOTH"].ToString();
                    //WHL_SERIAL, WHL_R_MILE, WHL_SIZE
                    WHL_SERIAL = DRow["WHL_SERIAL"].ToString();
                    WHL_R_MILE = DRow["WHL_R_MILE"].ToString();
                    WHL_SIZE = DRow["WHL_SIZE"].ToString();

                    incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection(MNT_WHL_POS, MNT_REQ_REASON, WHL_DAMAGE_AREA1, WHL_DAMAGE_AREA2, WHL_DAMAGE_AREA3, WHL_DAMAGE_AREA4,
                                                                      WHL_DAMAGE_TYPE1, WHL_DAMAGE_TYPE2, WHL_DAMAGE_TYPE3, WHL_DAMAGE_TYPE4, WHL_DAMAGE_OTH, WHL_DAMAGE_TYPEOTH, WHL_SERIAL, WHL_R_MILE, WHL_SIZE, MaintainTblWheel);
                }
                Session["MaintainTblWheel"] = MaintainTblWheel;
                var withBlockx = GrdWheelPos2;
                withBlockx.DataSource = MaintainTblWheel;
                withBlockx.DataBind();
                withBlockx.AutoGenerateColumns = false;

                //ModeOperate=CRT | EDT
                HideModeOperate2.Value = "EDT";
                MultiView1.ActiveViewIndex = 6;

            }
            catch
            {
                MultiView1.ActiveViewIndex = 6;
            }
        }
        private void CommandControl(bool ShowInApprove, bool ShowReqReason,bool ShowApprove)
        {
            CmdOrderInApprove.Visible = ShowInApprove;
            CmdOrderReqReason.Visible = ShowReqReason;
            CmdOrderApprove.Visible = ShowApprove;
        }
        private void CommandControl2(bool ShowSave,bool ShowClose)
        {
            CmdSaveClose.Visible = true;
            RdoFail.Visible = true;
            RdoSuccess.Visible = true;
            //
            CmdSave.Visible = ShowSave;
            CmdSaveClose.Visible = ShowClose;
            imgCloseDateSet.Visible = ShowClose;
            TxtCloseDateSet.Visible = ShowClose;
        }
        private void CommandControl2x()
        {
            CmdSave.Visible = true;
            CmdSaveClose.Visible = false;
            RdoFail.Visible = false;
            RdoSuccess.Visible = false;
            imgCloseDateSet.Visible = false;
            TxtCloseDateSet.Visible = false;
        }
        private void SetDocumentViewOnlyMode()
        {
            TxtVehAge.ReadOnly = true;
            TxtVehMiledge.ReadOnly = true;
            //
            for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).ReadOnly = true;
            }
            GrdRepairDesc.Columns[0].Visible = false;
            //
            ImageMap1.Enabled = false;
            GrdWheelPos.Columns[0].Visible = false;
            for (int IRow = 0; IRow < GrdWheelPos.Rows.Count; IRow++)
            {
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWRepairReason")).ReadOnly = true;
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageAreaOther")).ReadOnly = true;
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageTypeAno")).ReadOnly = true;
                //
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea1")).Enabled = false;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea2")).Enabled = false;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea3")).Enabled = false;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea4")).Enabled = false;
                //
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType1")).Enabled = false;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType2")).Enabled = false;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType3")).Enabled = false;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType4")).Enabled = false;
            }
        }
        private void SetDocumentViewOnlyMode2()
        {
            TxtVehAge2.ReadOnly = true;
            TxtVehMiledge2.ReadOnly = true;
            //
            for (int IRow = 0; IRow < GrdRepairDesc2.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDesc2.Rows[IRow].FindControl("TxtDescription")).ReadOnly = true;
            }
            GrdRepairDesc2.Columns[0].Visible = false;
            //
            ImageMap2.Enabled = false;
            GrdWheelPos2.Columns[0].Visible = false;
            for (int IRow = 0; IRow < GrdWheelPos2.Rows.Count; IRow++)
            {
                ((TextBox)GrdWheelPos2.Rows[IRow].FindControl("TxtWRepairReason")).ReadOnly = true;
                ((TextBox)GrdWheelPos2.Rows[IRow].FindControl("TxtDamageAreaOther")).ReadOnly = true;
                ((TextBox)GrdWheelPos2.Rows[IRow].FindControl("TxtDamageTypeAno")).ReadOnly = true;
                //
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea1")).Enabled = false;
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea2")).Enabled = false;
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea3")).Enabled = false;
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea4")).Enabled = false;
                //
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType1")).Enabled = false;
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType2")).Enabled = false;
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType3")).Enabled = false;
                ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType4")).Enabled = false;
            }
            //
            for (int IRow = 0; IRow < GrdRepairDesc3.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3")).ReadOnly = true;
                ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Price")).ReadOnly = true;
                ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Servicer")).ReadOnly = true;
            }
            GrdRepairDesc3.Columns[0].Visible = false;
            CmdAddDescLine0.Visible = false;
            CmdAddDescLine.Visible = false;
            //
            for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPart")).ReadOnly = true;
                ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPartAmt")).ReadOnly = true;
            }
            GrdRepairPart.Columns[0].Visible = false;
            CmdAddPart.Visible = false;
            //
            for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).ReadOnly = true;
            }
            GrdRepairDetail.Columns[0].Visible = false;
            CmdDetail.Visible = false;
            Panel1.Enabled = false;
            //
            RdoCR.Enabled = false;
            RdoPM.Enabled = false;
            RdoCR0.Enabled = false;
            RdoPM0.Enabled = false;
            //
        }
        private void SetDocumentOpenPart()
        {
            //TxtVehAge2.ReadOnly = true;
            //TxtVehMiledge2.ReadOnly = true;
            ////
            //for (int IRow = 0; IRow < GrdRepairDesc2.Rows.Count; IRow++)
            //{
            //    ((TextBox)GrdRepairDesc2.Rows[IRow].FindControl("TxtDescription")).ReadOnly = true;
            //}
            //GrdRepairDesc2.Columns[0].Visible = false;
            ////
            //ImageMap2.Enabled = false;
            //GrdWheelPos2.Columns[0].Visible = false;
            //for (int IRow = 0; IRow < GrdWheelPos2.Rows.Count; IRow++)
            //{
            //    ((TextBox)GrdWheelPos2.Rows[IRow].FindControl("TxtWRepairReason")).ReadOnly = true;
            //    ((TextBox)GrdWheelPos2.Rows[IRow].FindControl("TxtDamageAreaOther")).ReadOnly = true;
            //    ((TextBox)GrdWheelPos2.Rows[IRow].FindControl("TxtDamageTypeAno")).ReadOnly = true;
            //    //
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea1")).Enabled = false;
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea2")).Enabled = false;
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea3")).Enabled = false;
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageArea4")).Enabled = false;
            //    //
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType1")).Enabled = false;
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType2")).Enabled = false;
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType3")).Enabled = false;
            //    ((CheckBox)GrdWheelPos2.Rows[IRow].FindControl("ChkDamageType4")).Enabled = false;
            //}
            //
            for (int IRow = 0; IRow < GrdRepairDesc3.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3")).ReadOnly = false;
                ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Price")).ReadOnly = false;
                ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Servicer")).ReadOnly = false;
            }
            GrdRepairDesc3.Columns[0].Visible = true;
            CmdAddDescLine0.Visible = true;
            CmdAddDescLine.Visible = true;
            //
            for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPart")).ReadOnly = false;
                ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPartAmt")).ReadOnly = false;
            }
            GrdRepairPart.Columns[0].Visible = true;
            CmdAddPart.Visible = true;
            //
            for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).ReadOnly = false;
            }
            GrdRepairDetail.Columns[0].Visible = true;
            CmdDetail.Visible = true;
            Panel1.Enabled = true ;
            //
            RdoCR0.Enabled = true;
            RdoPM0.Enabled = true;
        }



        protected void CmdAct1_Click(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_ForApprove();
                Session["OrderCollectionTblTemp"] = DSetAsset.Tables["TB_RORDER_COLLECTION"];  //เก็บไว้กรอง
                var withBlock = GrdRepairOrderAct1;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();
                //ADD 26012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtnORD2.Enabled = false;
                }
                //END 26012023
            }
            catch { }
            MultiView1.ActiveViewIndex = 0;
        }

        protected void CmdAct2_Click(object sender, EventArgs e)
        {
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_MoreDetail();
                var withBlock = GrdRepairOrderAct2;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();

                //ADD 26012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtnORD2.Enabled = false;
                }
                //END 26012023
            }
            catch { }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void CmdAct3_Click(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_MaintainingAll();
                var withBlock = GrdRepairOrderAct3;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();
                //ADD 26012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtnORD2.Enabled = false;
                }
                //END 26012023
            }
            catch { }
            MultiView1.ActiveViewIndex = 2;
        }

        protected void CmdAct4_Click(object sender, EventArgs e)
        {
            //
            //DataSet DSetAsset;
            //JxMasterService incJxMasterServiceObj = new JxMasterService();
            ////
            //try
            //{
            //    DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_OrderClosed();
            //    var withBlock = GrdRepairOrderAct4;
            //    withBlock.AutoGenerateColumns = false;
            //    withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
            //    withBlock.DataBind();
            //}
            //catch { }
            imgBtnORD4.Enabled = false;
            MultiView1.ActiveViewIndex = 3;
        }

        protected void CmdOpenVehCollection_Click(object sender, EventArgs e)
        {

        }

        protected void CmdOpenGarageCollection_Click(object sender, EventArgs e)
        {

        }

        protected void GrdRepairDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CalTotalPrice()
        {
            float TotalP = 0;
            float TotalPItm = 0;
            string StrTotalP = "";
            if (GrdRepairDesc3.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDesc3.Rows.Count; IRow++)
                {
                    StrTotalP = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Price")).Text.Trim();
                    TotalPItm = float.Parse(StrTotalP);
                    TotalP += TotalPItm;
                }
            }
            else { TotalP = 0; }

            TxtTotalPrice.Text = TotalP.ToString("#,##0.00");

        }
        protected void CmdAddDescLine_Click(object sender, EventArgs e)
        {
            //
            string IDx = "";
            string TxtDescription = "";
            string TxtServicer = "";
            string StrPrice = "0";
            float MnPrice = 0;
            MaintainTbl2 = (DataTable)Session["MaintainTbl2"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //MaintainTbl2 = incGlobalDataPatternObj.CreateDataTableMaintainCostCollection();
            //
            if (GrdRepairDesc3.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDesc3.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc3.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3")).Text.Trim();
                    TxtServicer = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Servicer")).Text.Trim();
                    StrPrice= ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Price")).Text.Trim();
                    MnPrice= float.Parse(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl2.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnCost"] = MnPrice;
                            dr["MnServicer"] = TxtServicer;
                            break;
                        }
                    }
                }

                incGlobalDataPatternObj.AddDataToTableMaintainCostCollection("--",0,"--", MaintainTbl2);
                MaintainTbl2.AcceptChanges();

            }
            else
            {
                incGlobalDataPatternObj.AddDataToTableMaintainCostCollection("--",0,"--", MaintainTbl2);
                MaintainTbl2.AcceptChanges();
            }
            Session["MaintainTbl2"] = MaintainTbl2;
            //
            var withBlock = GrdRepairDesc3;
            withBlock.DataSource = Session["MaintainTbl2"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {

        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CmdRollBackDoc_Click(object sender, EventArgs e)
        {

        }

        protected void CmdDeleteDoc_Click(object sender, EventArgs e)
        {

        }

        protected void CmdSaveOrd_Click(object sender, EventArgs e)
        {

        }

        protected void CmdReqApproveOrd_Click(object sender, EventArgs e)
        {

        }

        protected void CmdSearchAssetVeh_Click(object sender, EventArgs e)
        {

        }

        protected void CmdCloseVehCollection_Click(object sender, EventArgs e)
        {

        }

        protected void GrdAssetVehSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow RowGet = GrdAssetVehSelector.SelectedRow;
            //
            TxtVehID4.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text.Replace("&#160;", " "); 
            TxtVehCode4.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_CODE")].Text.Replace("&#160;", " "); 
            TxtVehLicense4.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_LICENSE")].Text.Replace("&#160;", " ");
            //
            int VehTypeValue = Convert.ToInt32(GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_TYPE_ID")].Text.Replace("&#160;", " "));
            CmbVehType.SelectedValue = VehTypeValue.ToString();
            //
            TxtVehBrand4.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_BRAND")].Text.Replace("&#160;", " "); 
            TxtVehModel4.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_MODEL")].Text.Replace("&#160;", " "); 
            TxtVehFuel4.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_FUEL_SPEC")].Text.Replace("&#160;", " "); 
            string STDate= GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ST_USE_DTIME")].Text.Replace("&#160;", " ");
            DateTime? oDate;
            if (IsDateTime(STDate) == true)
            {
                //oDate = DateTime.ParseExact(STDate, "dd/MM/yyyy", null);
                oDate = Convert.ToDateTime(STDate);
            }else { oDate = null; }
            if (oDate != null)
            {
                TxtVehYear4.Text= oDate?.ToString("dd/MM/yyyy");
            }
            else { TxtVehYear4.Text = ""; }

            //
            Panel4.Visible = true;
            HiddenVehMode.Value = "EDT";
        }
        public bool IsDateTime(string text)
        {
            DateTime dateTime;
            bool isDateTime = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDateTime = DateTime.TryParse(text, out dateTime);

            return isDateTime;
        }
        protected void GrdGarageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow RowGet = GrdGarageSelector.SelectedRow;
            TxtGarageIDE.Text = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_ID")].Text.Replace("&#160;", " ");
            TxtGarageNameE.Text = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_NAME")].Text.Replace("&#160;", " ");
            TxtGarageAddrE.Text = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_ADDR")].Text.Replace("&#160;", " ");
            TxtGarageContE.Text = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_CONTACT")].Text.Replace("&#160;", " ");
            TxtGarageTelE.Text= GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_TEL")].Text.Replace("&#160;", " ");
            //
            Panel3.Visible = true;
            HideGarageMode.Value = "EDT";
        }

        protected void CmdSearchGarage_Click(object sender, EventArgs e)
        {

        }

        protected void GrdRepairOrderAct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct1.DataKeys[GrdRepairOrderAct1.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct1.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct1.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            ImprementOrderData(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(true, true, true);
        }

        protected void CmdOrderInApprove_Click(object sender, EventArgs e)
        {
            string ProcRet = "ERR:";
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            try
            {
                string MNT_ORD_NO = TxtOrderNo.Text.Trim();
                string OrderRecReferenceNo = HideRecRefNo.Value.ToString();
                string USR_FNAME = "";
                string MN_HEADER_REM = TxtMNHeadRem.Text.Trim();
                var master = Master as Site;
                if (master != null)
                {
                    USR_FNAME = master.GetUserProfileData("USER_FNAME");
                }
                ProcRet = IncJxTransactionServiceObj.InApproveOrderRequest(MNT_ORD_NO, USR_FNAME, OrderRecReferenceNo, MN_HEADER_REM);
                if (ProcRet.ToUpper().Substring(0, 2) == "TR")
                {
                    Response.Write("<script>alert('ไม่อนุมัติให้ซ่อม: เรียบร้อย!!');</script>");
                    //SetSumarizeCounter();
                    MultiView1.ActiveViewIndex = 4;
                }
                else
                {
                    Response.Write("<script>alert('ไม่อนุมัติให้ซ่อม: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Err.Description: " + ex.Message + "');</script>");
                MultiView1.ActiveViewIndex = 5;
            }
            //
            SetSumarizeCounter();
        }

        protected void CmdOrderReqReason_Click(object sender, EventArgs e)
        {
            string ProcRet = "ERR:";
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            try
            {
                string MNT_ORD_NO = TxtOrderNo.Text.Trim();
                string OrderRecReferenceNo = HideRecRefNo.Value.ToString();
                string USR_FNAME = "";
                string MN_HEADER_REM = TxtMNHeadRem.Text.Trim();
                var master = Master as Site;
                if (master != null)
                {
                    USR_FNAME = master.GetUserProfileData("USER_FNAME");
                }
                ProcRet = IncJxTransactionServiceObj.MoreDetailOrderRequest(MNT_ORD_NO, USR_FNAME, OrderRecReferenceNo, MN_HEADER_REM);
                if (ProcRet.ToUpper().Substring(0, 2) == "TR")
                {
                    Response.Write("<script>alert('ขอรายละเอียดเพิ่มเติม: เรียบร้อย!!');</script>");
                    //SetSumarizeCounter();
                    MultiView1.ActiveViewIndex = 4;
                }
                else
                {
                    Response.Write("<script>alert('ขอรายละเอียดเพิ่มเติม: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Err.Description: " + ex.Message + "');</script>");
                MultiView1.ActiveViewIndex = 5;
            }
            //
            SetSumarizeCounter();
        }

        protected void CmdOrderApprove_Click(object sender, EventArgs e)
        {
            string ProcRet = "ERR:";
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            try
            {
                string MNT_ORD_NO = TxtOrderNo.Text.Trim();
                string OrderRecReferenceNo = HideRecRefNo.Value.ToString();
                string USR_FNAME = "";
                string MN_HEADER_REM = TxtMNHeadRem.Text.Trim();
                var master = Master as Site;
                if (master != null)
                {
                    USR_FNAME = master.GetUserProfileData("USER_FNAME");
                }
                ProcRet = IncJxTransactionServiceObj.ApproveOrderRequest(MNT_ORD_NO, USR_FNAME, OrderRecReferenceNo, MN_HEADER_REM);
                if (ProcRet.ToUpper().Substring(0, 2) == "TR")
                {
                    Response.Write("<script>alert('อนุมัติซ่อม: เรียบร้อย!!');</script>");
                    //SetSumarizeCounter();
                    MultiView1.ActiveViewIndex = 4;
                }
                else
                {
                    Response.Write("<script>alert('อนุมัติซ่อม: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Err.Description: " + ex.Message + "');</script>");
                MultiView1.ActiveViewIndex = 5;
            }
            SetSumarizeCounter();
        }

        protected void GrdRepairOrderAct2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct2.DataKeys[GrdRepairOrderAct2.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct2.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct2.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            ImprementOrderData(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(false,false, false);
        }
        private int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                    if (((BoundField)cell.ContainingField).DataField.ToUpper().Trim().Equals(columnName.ToUpper().Trim()))
                        break;
                columnIndex++; 
            }
            return columnIndex;
        }
        protected void GrdRepairOrderAct3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct3.DataKeys[GrdRepairOrderAct3.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct3.SelectedRow;
            int  VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct3.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            ImprementOrderDataUpp(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage2(OrderNo);
            SetDocumentViewOnlyMode2();
            SetDocumentOpenPart();
            CommandControl2(true,true);
        }

        protected void GrdRepairOrderAct4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct4.DataKeys[GrdRepairOrderAct4.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            //T2.Text = OrderNo;
            ImprementOrderDataUpp(OrderNo,0);
            ImprementOrderImage2(OrderNo);
            SetDocumentViewOnlyMode2();
            CommandControl2(false, false);
        }

        protected void RdoFail_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoFail.Checked == true) { RdoSuccess.Checked = false; }
        }

        protected void RdoSuccess_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoSuccess.Checked == true) { RdoFail.Checked = false; }
        }
        private string SaveRepairOrder(bool SetCloseAfterUpdate)
        {
            //Validate 

            //เตรียมข้อมูล
            string MNT_ORD_NO = TxtOrderNo2.Text.Trim();
            MaintainTbl2 = (DataTable)Session["MaintainTbl2"];
            MaintainTbl3 = (DataTable)Session["MaintainTbl3"];
            MaintainTbl4 = (DataTable)Session["MaintainTbl4"];
            MaintainTbl7 = (DataTable)Session["MaintainTbl7"];
            //รายการซ่อม
            string IDx = "";
            string TxtDescription = "";
            float PriceMN = 0;
            string StrPriceMN = "";
            string TxtServicer = "";
            //
            string StrAmt = "0";
            float MnAmt = 0;
            string MNT_TYPE = "CR";
            if (RdoPM0.Checked == true) { MNT_TYPE = "PM"; }
            //
            if (GrdRepairDesc3.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDesc3.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc3.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3")).Text.Trim();
                    StrPriceMN = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Price")).Text.Trim();
                    PriceMN = float.Parse(StrPriceMN);
                    TxtServicer = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Servicer")).Text.Trim();

                    //
                    foreach (DataRow dr in MaintainTbl2.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnCost"] = PriceMN;
                            dr["MnServicer"] = TxtServicer;
                            break;
                        }
                    }
                }
            }
            MaintainTbl2.AcceptChanges();
            Session["MaintainTbl2"] = MaintainTbl2;
            //

            string DATE_NOTE = "";
            string DESC_NOTE = "";
            string MILEDGE_NOTE = "0.00";
            string PRICE_NOTE = "0.00";
            string SERVICER_NOTE = "---";
            if (GrdVehDeptComment.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdVehDeptComment.Rows.Count; IRow++)
                {
                    IDx = GrdVehDeptComment.DataKeys[IRow].Value.ToString();
                    DATE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDATE_NOTE")).Text.Trim();
                    DESC_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDESC_NOTE")).Text.Trim();
                    MILEDGE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtMILEDGE_NOTE")).Text.Trim();
                    PRICE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtPRICE_NOTE")).Text.Trim();
                    SERVICER_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtSERVICER_NOTE")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl7.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["DATE_NOTE"] = DATE_NOTE;
                            dr["DESC_NOTE"] = DESC_NOTE;
                            dr["MILEDGE_NOTE"] = MILEDGE_NOTE;
                            dr["PRICE_NOTE"] = PRICE_NOTE;
                            dr["SERVICER_NOTE"] = SERVICER_NOTE;
                            break;
                        }
                    }
                }
            }
            MaintainTbl7.AcceptChanges();
            Session["MaintainTbl7"] = MaintainTbl7;
            //
            if (GrdRepairPart.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
                {
                    IDx = GrdRepairPart.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPart")).Text.Trim();
                    StrAmt = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPartAmt")).Text.Trim();
                    MnAmt = Convert.ToInt32(StrAmt);
                    string StrPrice = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescPrice")).Text.Trim();
                    double MnPrice = Convert.ToDouble(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl3.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnAmt"] = MnAmt;
                            dr["MnPrice"] = MnPrice;
                            break;
                        }
                    }
                }
            }
            MaintainTbl3.AcceptChanges();
            Session["MaintainTbl3"] = MaintainTbl3;
            //
            if (GrdRepairDetail.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDetail.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl4.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            break;
                        }
                    }
                }
            }
            MaintainTbl4.AcceptChanges();
            Session["MaintainTbl4"] = MaintainTbl4;
            //Validate
            if (MaintainTbl2.Rows.Count == 0) { return "ERR:ข้อมูลรายการซ่อมไม่ถูกต้อง!!"; }
            //

            //บันทึก
            //Pack as DataSet// TBL_MN_COLLECTION
            MaintainTbl3.TableName = "TBL_MN_COLLECTION3";
            MaintainTbl4.TableName = "TBL_MN_COLLECTION4";
            MaintainTbl7.TableName = "TBL_MN_COLLECTION7";
            DataSet DSet = new DataSet();
            DSet.Tables.Add(MaintainTbl2.Copy());
            DSet.Tables.Add(MaintainTbl3.Copy());
            DSet.Tables.Add(MaintainTbl4.Copy());
            DSet.Tables.Add(MaintainTbl7.Copy());
            //
            int USR_ID = 0;
            string USR_FNAME = "";
            string MNT_OWN_SITECODE = "";
            string MNT_OWN_SITE = "";
            var master = Master as Site;
            if (master != null)
            {
                USR_ID = Convert.ToInt32(master.GetUserProfileData("USER_ID"));
                USR_FNAME = master.GetUserProfileData("USER_FNAME");
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                MNT_OWN_SITE = master.GetUserProfileData("SITE_NAME");
            }
            //--------------------------------
            //ค่าซ่อมรวม
            float TotalRepairPrice = float.Parse(TxtTotalPrice.Text); ;
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            string ProcRet = "ERR:";
     
                string MNT_ORD_RecordRefNo = HideRecRefNo2.Value.ToString().Trim();  //
                try
                {
                    //Update Only
                    if (SetCloseAfterUpdate == false)
                    {
                        string OrdDateStr = TxtOrderDate2.Text;
                        DateTime OrdDate = DateTime.ParseExact(OrdDateStr, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ProcRet = IncJxTransactionServiceObj.UpdateOrder(MNT_ORD_NO, DSet, MNT_ORD_RecordRefNo, USR_FNAME, TotalRepairPrice, OrdDate, MNT_TYPE);
                    }
                    //Update And Close Order
                    else
                    {
                    ////SC: ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
                    ///

                    //if (CloseDate == "" || EDate == "") { return; }
                    //
                    //string MNT_OWN_SITECODE = "";
                    //var master = Master as Site;
                    //if (master != null)
                    //{
                    //    MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                    //}

                    string CloseDateStr = TxtCloseDateSet.Text;
                    DateTime CloseDate = DateTime.ParseExact(CloseDateStr, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    string CLOSE_STATE = "--";
                    if (RdoFail.Checked == true) { CLOSE_STATE = "NC"; }
                    else if (RdoSuccess.Checked == true) { CLOSE_STATE = "SC"; }
                    else { CLOSE_STATE = "--"; }
                    ProcRet = IncJxTransactionServiceObj.UpdateCloseOrder(MNT_ORD_NO, CLOSE_STATE, USR_FNAME, DSet,MNT_ORD_RecordRefNo, TotalRepairPrice, CloseDate);
                    }
                }
                catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
    
            return ProcRet;
            //--------------------------------
        }
        private string GetRecordReferenceNo(string OrderNo)
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            string RecsNo = "";

            try
            {
                RecsNo = IncJxMasterServiceObj.GetRepairOrderRecordNo(OrderNo);
            }
            catch { RecsNo = ""; }
            //
            return RecsNo;
        }
        protected void CmdSave_Click(object sender, EventArgs e)
        {
            CalTotalPrice();
            //
            string Operate_Result = "";
            string OrderRecordNo = "";


                //แก้ไขเอกสาร
                Operate_Result = SaveRepairOrder(false);

                if (Operate_Result.ToUpper().Substring(0, 2) == "TR")
                {
                    string OrderNo = TxtOrderNo2.Text;
                    OrderRecordNo = GetRecordReferenceNo(OrderNo);
                    HideRecRefNo2.Value = OrderRecordNo;
                    Response.Write("<script>alert('บันทึก: เรียบร้อย!!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + Operate_Result.Replace("ERR:", "") + "');</script>");
                }
        }
        protected void CmdPrint_Click(object sender, EventArgs e)
        {
            Session["PRINT_VEHID"] = HideVehID2.Value.ToString();
            Session["PRINT_DOCNO"] = TxtOrderNo2.Text.Trim();
            Session["PRINT_TYPE"] = "2";
            Server.Transfer("PrintTool2.aspx");
        }




        protected void TxtTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CmdAddDescLine0_Click(object sender, EventArgs e)
        {
            CalTotalPrice();
        }

        protected void GrdRepairDesc3_SelectedIndexChanged(object sender, EventArgs e) //รายละเอียดการซ่อมครั้งนี้
        {
            //
            string IDx_Del = GrdRepairDesc3.DataKeys[GrdRepairDesc3.SelectedRow.RowIndex]["IDx"].ToString();
            MaintainTbl2 = (DataTable)Session["MaintainTbl2"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            //Update Session Datatable
            if (GrdRepairDesc3.Rows.Count > 0)
            {
                string IDx = "";
                string TxtDescription = "";
                string TxtServicer = "";
                string StrPrice = "0";
                float MnPrice = 0;
                //
                for (int IRow = 0; IRow < GrdRepairDesc3.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc3.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3")).Text.Trim();
                    TxtServicer = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Servicer")).Text.Trim();
                    StrPrice = ((TextBox)GrdRepairDesc3.Rows[IRow].FindControl("TxtDescription3Price")).Text.Trim();
                    MnPrice = float.Parse(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl2.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnCost"] = MnPrice;
                            dr["MnServicer"] = TxtServicer;
                            //
                            break;
                        }
                    }
                }
            }
            //
            foreach (DataRow dr in MaintainTbl2.Rows)
            {
                if (dr["IDx"].ToString() == IDx_Del)
                    dr.Delete();
            }
            //
            MaintainTbl2.AcceptChanges();
            Session["MaintainTbl2"] = MaintainTbl2;
            //
            var withBlock = GrdRepairDesc3;
            withBlock.DataSource = Session["MaintainTbl2"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
            //
            CalTotalPrice();
        }

        protected void CmdAddPart_Click(object sender, EventArgs e) //เพิ่มแถวรายการเบิกอะไหล่
        {
            //
            string IDx = "";
            string TxtDescription = "";
            string StrAmt = "0";
            float MnAmt = 0;
            string StrPrice = "";
            double MnPrice = 0.00;
            double AmtPrice = 0.00;
            MaintainTbl3 = (DataTable)Session["MaintainTbl3"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();

            //
            if (GrdRepairPart.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
                {
                    IDx = GrdRepairPart.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPart")).Text.Trim();
                    StrAmt = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPartAmt")).Text.Trim();
                    MnAmt = Convert.ToInt32(StrAmt);
                    StrPrice = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescPrice")).Text.Trim();
                    MnPrice = Convert.ToDouble(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl3.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnAmt"] = MnAmt;
                            dr["MnPrice"] = MnPrice;
                            AmtPrice += MnPrice;
                            break;
                        }
                    }
                }
                lblAmtPrice.Text = AmtPrice.ToString("#,##0.00");
                incGlobalDataPatternObj.AddDataToTableMaintainPartCollection("--", 1,0.00, MaintainTbl3);
                MaintainTbl3.AcceptChanges();
            }
            else
            {
                incGlobalDataPatternObj.AddDataToTableMaintainPartCollection("--", 1,0.00, MaintainTbl3);
                MaintainTbl3.AcceptChanges();
            }
            Session["MaintainTbl3"] = MaintainTbl3;
            //
            var withBlock = GrdRepairPart;
            withBlock.DataSource = Session["MaintainTbl3"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
        }

        protected void GrdRepairPart_SelectedIndexChanged(object sender, EventArgs e)   //โหลดรายการเบิกอะไหล่
        {
            //
            string IDx_Del = GrdRepairPart.DataKeys[GrdRepairPart.SelectedRow.RowIndex]["IDx"].ToString();
            MaintainTbl3 = (DataTable)Session["MaintainTbl3"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            //Update Session Datatable
            if (GrdRepairPart.Rows.Count > 0)
            {
                string IDx = "";
                string TxtDescription = "";
                string StrAmt = "0";
                float MnAmt = 0;
                //
                for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
                {
                    IDx = GrdRepairPart.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPart")).Text.Trim();
                    StrAmt = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPartAmt")).Text.Trim();
                    MnAmt = Convert.ToInt32(StrAmt);
                    string StrPrice = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescPrice")).Text.Trim();
                    double MnPrice = Convert.ToDouble(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl3.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnAmt"] = MnAmt;
                            dr["MnPrice"] = MnPrice;
                            //
                            break;
                        }
                    }
                }
            }
            //
            foreach (DataRow dr in MaintainTbl3.Rows)
            {
                if (dr["IDx"].ToString() == IDx_Del)
                    dr.Delete();
            }
            //
            MaintainTbl3.AcceptChanges();
            Session["MaintainTbl3"] = MaintainTbl3;
            //
            var withBlock = GrdRepairPart;
            withBlock.DataSource = Session["MaintainTbl3"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
            //

        }

        protected void CmdDetail_Click(object sender, EventArgs e)
        {
            //
            string IDx = "";
            string TxtDescription = "";

            MaintainTbl4 = (DataTable)Session["MaintainTbl4"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();

            //
            if (GrdRepairDetail.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDetail.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl4.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            break;
                        }
                    }
                }

                incGlobalDataPatternObj.AddDataToTableMaintainL2Collection("--", MaintainTbl4);
                MaintainTbl4.AcceptChanges();

            }
            else
            {
                incGlobalDataPatternObj.AddDataToTableMaintainL2Collection("--",MaintainTbl4);
                MaintainTbl4.AcceptChanges();
            }
            Session["MaintainTbl4"] = MaintainTbl4;
            //
            var withBlock = GrdRepairDetail;
            withBlock.DataSource = Session["MaintainTbl4"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
        }

        protected void GrdRepairDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            string IDx_Del = GrdRepairDetail.DataKeys[GrdRepairDetail.SelectedRow.RowIndex]["IDx"].ToString();
            MaintainTbl4 = (DataTable)Session["MaintainTbl4"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            //Update Session Datatable
            if (GrdRepairDetail.Rows.Count > 0)
            {
                string IDx = "";
                string TxtDescription = "";
                //
                for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDetail.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).Text.Trim();

                    //
                    foreach (DataRow dr in MaintainTbl4.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            //
                            break;
                        }
                    }
                }
            }
            //
            foreach (DataRow dr in MaintainTbl4.Rows)
            {
                if (dr["IDx"].ToString() == IDx_Del)
                    dr.Delete();
            }
            //
            MaintainTbl4.AcceptChanges();
            Session["MaintainTbl4"] = MaintainTbl4;
            //
            var withBlock = GrdRepairDetail;
            withBlock.DataSource = Session["MaintainTbl4"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
            //
        }

        protected void CmdSaveClose_Click(object sender, EventArgs e)
        {
            CalTotalPrice();
            //
            string CloseDateStr = TxtCloseDateSet.Text;
            if (CloseDateStr == "-" || CloseDateStr == "")
            {
                Response.Write("<script>alert('กรุณาระบุวันที่!!');</script>");
                return;
            }
            string Operate_Result = "";
            string OrderRecordNo = "";


            //แก้ไขเอกสาร
            Operate_Result = SaveRepairOrder(true);

            if (Operate_Result.ToUpper().Substring(0, 2) == "TR")
            {
                string OrderNo = TxtOrderNo2.Text;
                OrderRecordNo = GetRecordReferenceNo(OrderNo);
                HideRecRefNo2.Value = OrderRecordNo;
                SetSumarizeCounter();
                Response.Write("<script>alert('บันทึก: เรียบร้อย!!');</script>");
                MultiView1.ActiveViewIndex = 4;
            }
            else
            {
                Response.Write("<script>alert('บันทึก: " + Operate_Result.Replace("ERR:", "") + "');</script>");
            }
        }

        protected void CmdOpenX_Click(object sender, EventArgs e)
        {

        }

        protected void GrdRepairDesc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MNT_ORD_NO = GrdRepairDesc4.DataKeys[GrdRepairDesc4.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            //int VehID = Convert.ToInt32(HideVehID2.Value);
            //
            ImprementOrderRepair(MNT_ORD_NO);
            //
            ModalPopupExtender1.Show();
        }
  
        protected void GrdRepairDesc4x_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MNT_ORD_NO = GrdRepairDesc4x.DataKeys[GrdRepairDesc4x.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            //int VehID = Convert.ToInt32(HideVehID2.Value);
            //
           ImprementOrderRepair(MNT_ORD_NO);
            //
            ModalPopupExtender1.Show();
        }

        protected void CmdAddDesc_Click(object sender, EventArgs e)
        {
            //
            string IDx = "";
            string DATE_NOTE = "";
            string DESC_NOTE = "";
            string MILEDGE_NOTE = "0.00";
            string PRICE_NOTE = "0.00";
            string SERVICER_NOTE = "---";


            MaintainTbl7 = (DataTable)Session["MaintainTbl7"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            if (GrdVehDeptComment.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdVehDeptComment.Rows.Count; IRow++)
                {
                    IDx = GrdVehDeptComment.DataKeys[IRow].Value.ToString();
                    DATE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDATE_NOTE")).Text.Trim();
                    DESC_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDESC_NOTE")).Text.Trim();
                    MILEDGE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtMILEDGE_NOTE")).Text.Trim();
                    PRICE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtPRICE_NOTE")).Text.Trim();
                    SERVICER_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtSERVICER_NOTE")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl7.Rows)
                    {
                            if (dr["IDx"].ToString() == IDx)
                            {
                            dr["DATE_NOTE"] = DATE_NOTE;
                            dr["DESC_NOTE"] = DESC_NOTE;
                            dr["MILEDGE_NOTE"] = MILEDGE_NOTE;
                            dr["PRICE_NOTE"] = PRICE_NOTE;
                            dr["SERVICER_NOTE"] = SERVICER_NOTE;
                            break;
                            }
                    }
                }
                //
                incGlobalDataPatternObj.AddDataToTableMaintainCommentCollection("--", "--", "--", "--", "--", MaintainTbl7);
                MaintainTbl7.AcceptChanges();
            }
            else
            {
                incGlobalDataPatternObj.AddDataToTableMaintainCommentCollection("--", "--", "--","--","--", MaintainTbl7);
                MaintainTbl7.AcceptChanges();
            }
            Session["MaintainTbl7"] = MaintainTbl7;
            //
            var withBlock = GrdVehDeptComment;
            withBlock.DataSource = MaintainTbl7;
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
        }

        protected void GrdVehDeptComment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            string IDx_Del = GrdVehDeptComment.DataKeys[GrdVehDeptComment.SelectedRow.RowIndex]["IDx"].ToString();
            MaintainTbl7 = (DataTable)Session["MaintainTbl7"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            //Update Session Datatable
            if (GrdVehDeptComment.Rows.Count > 0)
            {
                string IDx = "";
                string DATE_NOTE = "";
                string DESC_NOTE = "";
                string MILEDGE_NOTE = "0.00";
                string PRICE_NOTE = "0.00";
                string SERVICER_NOTE = "---";
                //
                for (int IRow = 0; IRow < GrdVehDeptComment.Rows.Count; IRow++)
                {
                    IDx = GrdVehDeptComment.DataKeys[IRow].Value.ToString();
                    DATE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDATE_NOTE")).Text.Trim();
                    DESC_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDESC_NOTE")).Text.Trim();
                    MILEDGE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtMILEDGE_NOTE")).Text.Trim();
                    PRICE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtPRICE_NOTE")).Text.Trim();
                    SERVICER_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtSERVICER_NOTE")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl7.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["DATE_NOTE"] = DATE_NOTE;
                            dr["DESC_NOTE"] = DESC_NOTE;
                            dr["MILEDGE_NOTE"] = MILEDGE_NOTE;
                            dr["PRICE_NOTE"] = PRICE_NOTE;
                            dr["SERVICER_NOTE"] = SERVICER_NOTE;
                            break;
                        }
                    }
                }
            }
            //
            foreach (DataRow dr in MaintainTbl7.Rows)
            {
                if (dr["IDx"].ToString() == IDx_Del)
                    dr.Delete();
            }
            //
            MaintainTbl7.AcceptChanges();
            Session["MaintainTbl7"] = MaintainTbl7;
            //
            var withBlock = GrdVehDeptComment;
            withBlock.DataSource = Session["MaintainTbl7"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
            //
        }

        protected void CmdGarage_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 7;
        }

        protected void CmdSearchGarage_Click1(object sender, EventArgs e)
        {
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            string GarageKeySearch = TGarageKey.Text.Trim();
            DSetAsset = incJxMasterServiceObj.GetGarageCollection(GarageKeySearch);
            var withBlock = GrdGarageSelector;
            withBlock.AutoGenerateColumns = false;
            withBlock.DataSource = DSetAsset.Tables["TB_GARAGE_COLLECTION"];
            withBlock.DataBind();
        }

        protected void CmdSaveGarageE_Click(object sender, EventArgs e)
        {
            string ModeOperate = HideGarageMode.Value.ToString().Trim().ToUpper();
            //
            //TxtGarageIDE.Text = "";
            string GName = TxtGarageNameE.Text.Trim();
            string GAddr = TxtGarageAddrE.Text.Trim();
            string GCont = TxtGarageContE.Text.Trim();
            string GTel  = TxtGarageTelE.Text.Trim();
            //
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            string ProcRet = "";
            if (ModeOperate == "ADD") 
            {
                ProcRet = IncJxTransactionServiceObj.AddNewGarageData(GName, GAddr, GCont, GTel);
                if (ProcRet.Trim().ToUpper().Substring(0, 3).ToUpper() == "TRU")
                {
                    Response.Write("<script>alert('บันทึก: เรียบร้อย ');</script>");
                    Panel3.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            if (ModeOperate == "EDT") 
            {
                int GID = Int32.Parse(TxtGarageIDE.Text);
                ProcRet = IncJxTransactionServiceObj.UpdateGarageData(GID, GName, GAddr, GCont, GTel);
                if (ProcRet.Trim().ToUpper().Substring(0, 3).ToUpper() == "TRU")
                {
                    Response.Write("<script>alert('บันทึก: เรียบร้อย ');</script>");
                    Panel3.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            //     
        }

        protected void CmdClosePanel_Click(object sender, EventArgs e)
        {
            HideGarageMode.Value = "VIE";
            TxtGarageIDE.Text = "";
            TxtGarageNameE.Text = "";
            TxtGarageAddrE.Text = "";
            TxtGarageContE.Text = "";
            TxtGarageTelE.Text = "";
            //
            Panel3.Visible = false;
        }

        protected void CmdAddGarage_Click(object sender, EventArgs e)
        {
            HideGarageMode.Value = "ADD";
            Panel3.Visible = true;
            //
            TxtGarageIDE.Text = "--Auto--";
            TxtGarageNameE.Text = "";
            TxtGarageAddrE.Text = "";
            TxtGarageContE.Text = "";
            TxtGarageTelE.Text = "";
            TxtGarageNameE.Focus();
        }

        protected void CmdVehicle_Click(object sender, EventArgs e)
        {
            imgBtn8.Enabled = false;
            MultiView1.ActiveViewIndex = 8;
        }

        protected void CmdSearchVehicle_Click(object sender, EventArgs e)
        {
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            string KeySearch = TVehicleKey.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetVehicleCollection(KeySearch);
                var withBlock = GrdAssetVehSelector;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_VEH_COLLECTION"];
                withBlock.DataBind();
                if (withBlock.Rows.Count == 0)
                {
                    imgBtn8.Enabled = false;
                }
                else { imgBtn8.Enabled = true; }
            }
            catch { }

        }

        protected void CmdClosePanelVeh_Click(object sender, EventArgs e)
        {
            HiddenVehMode.Value = "VIE";
            TxtVehID4.Text = "";
            TxtVehCode4.Text = "";
            TxtVehLicense4.Text = "";
            CmbVehType.SelectedIndex = 0;
            TxtVehBrand4.Text = "";
            TxtVehModel4.Text = "";
            TxtVehFuel4.Text = "";
            TxtVehYear4.Text = "0";
            //
            Panel4.Visible = false;
        }

        protected void CmdSaveVehE_Click(object sender, EventArgs e)
        {
            string ModeOperate = HiddenVehMode.Value.ToString().Trim().ToUpper();
            //

            //TxtVehID4.Text = "";
            string VVehCode=TxtVehCode4.Text.Trim();
            string VVehLicense=TxtVehLicense4.Text.Trim();
            int VVehType=Convert.ToInt32(CmbVehType.SelectedValue.ToString());
            string VVehBrand=TxtVehBrand4.Text.Trim();
            string VVehModel=TxtVehModel4.Text.Trim();
            string VVehFuel=TxtVehFuel4.Text.Trim();
            //
            string STDate = TxtVehYear4.Text.Trim();
            DateTime? oDate;
            if (IsDateTime(STDate) == true)
            {
                //oDate = DateTime.ParseExact(STDate, "dd/MM/yyyy", null);
                oDate = Convert.ToDateTime(STDate);
            }
            else { oDate = null; }
            //
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            string ProcRet = "";
            if (ModeOperate == "ADD")
            {
                ProcRet = IncJxTransactionServiceObj.AddNewVehData(VVehCode, VVehLicense, VVehType, VVehBrand, VVehModel, VVehFuel, oDate);
                if (ProcRet.Trim().ToUpper().Substring(0, 3).ToUpper() == "TRU")
                {
                    Response.Write("<script>alert('บันทึก: เรียบร้อย ');</script>");
                    Panel4.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            if (ModeOperate == "EDT")
            {
                int VVehID = Int32.Parse(TxtVehID4.Text);
                ProcRet = IncJxTransactionServiceObj.UpdateVehicleData(VVehID, VVehCode, VVehLicense, VVehType, VVehBrand, VVehModel, VVehFuel, oDate);
                if (ProcRet.Trim().ToUpper().Substring(0, 3).ToUpper() == "TRU")
                {
                    Response.Write("<script>alert('บันทึก: เรียบร้อย ');</script>");
                    Panel4.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            // 
        }

        protected void CmdAddVehicle_Click(object sender, EventArgs e)
        {
            HiddenVehMode.Value = "ADD";
            Panel4.Visible = true;
            //
            TxtVehID4.Text = "--Auto--";
            TxtVehCode4.Text = "";
            TxtVehLicense4.Text = "";
            CmbVehType.SelectedIndex = 0;
            TxtVehBrand4.Text = "";
            TxtVehModel4.Text = "";
            TxtVehFuel4.Text = "";
            TxtVehYear4.Text="";
            TxtVehCode4.Focus();
        }

        protected void CmdHistry_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 9;
        }

        protected void CmdSearchVehicle2_Click(object sender, EventArgs e)
        {
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            string KeySearch = TVehicleKey2.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetVehicleCollection(KeySearch);
                var withBlock = GrdAssetVehSelector2;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_VEH_COLLECTION"];
                withBlock.DataBind();
                
            }
            catch { }
            GrdAssetVehSelector2.Visible = true;
        }

        protected void GrdAssetVehSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow RowGet = GrdAssetVehSelector2.SelectedRow;
            //
            DataSet DSetAsset;
            DataSet DSetAsset2;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            string KeySearch = GrdAssetVehSelector2.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text.Replace("&#160;", " ");
            try
            {
                DSetAsset = incJxMasterServiceObj.GetVehicleOrderExpense(Convert.ToInt32(KeySearch));
                var withBlock = GrdRepairOrderAct5;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_VEHEXP_COLLECTION"];
                withBlock.DataBind();

                DSetAsset2 = incJxMasterServiceObj.GetVehicleOrderPart(Convert.ToInt32(KeySearch));
                var withBlock2 = GrdRepairOrderAct6;
                withBlock2.AutoGenerateColumns = false;
                withBlock2.DataSource = DSetAsset2.Tables["TB_VEHPART_COLLECTION"];
                withBlock2.DataBind();
            }
            catch { }

            //
            GrdAssetVehSelector2.Visible = false;
            GrdRepairOrderAct5.Visible = true;
            GrdRepairOrderAct6.Visible = true;
            Panel5.Visible = true;

          
 
        }

        protected void CmdPrintX1_Click(object sender, EventArgs e)
        {
            Session["PRINT_VEHID"] = HideVehID.Value.ToString();
            Session["PRINT_DOCNO"] = TxtOrderNo.Text.Trim();
            Session["PRINT_TYPE"] = "2";
            Server.Transfer("PrintTool2.aspx");
        }

        protected void CmdAdjOrder_Click(object sender, EventArgs e)
        {
            string OrderNo = TxtOrderNo.Text.Trim();
            GridViewRow RowGet = GrdRepairOrderAct3.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(HideVehID.Value.ToString());
            //T2.Text = OrderNo;
            ImprementOrderDataUpp(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage2(OrderNo);
            SetDocumentViewOnlyMode2();
            SetDocumentOpenPart();
            //CommandControl2(true, true);
            CommandControl2x();
        }

        protected void TxtVehLicense_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ImbS1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                TxtKeyS1.Text = TxtKeyS1.Text.Replace("%", "");
                string strFilter = "";
                //
                strFilter = "MNT_OWN_SITE like '%" + TxtKeyS1.Text + "%' OR " +
                            "MNT_ORD_NO   like '%" + TxtKeyS1.Text + "%' OR " +
                            "VEH_CODE     like '%" + TxtKeyS1.Text + "%' OR " +
                            "VEH_LICENSE  like '%" + TxtKeyS1.Text + "%' ";
                //
                //Session["OrderCollectionTblTemp"] = DSetAsset.Tables["TB_RORDER_COLLECTION"];  //เก็บไว้กรอง
                DataTable DtableSource = (DataTable)Session["OrderCollectionTblTemp"];
                DataTable DTablex = DtableSource.Select(strFilter).CopyToDataTable();

                var withBlock = GrdRepairOrderAct1;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DTablex;
                withBlock.DataBind();

            }
            catch
            {
                var withBlock = GrdRepairOrderAct1;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = null;
                withBlock.DataBind();
            }
        }

        protected void TxtOrderDate2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtVehCode2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtVehModel2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtGarageContact2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtOrderDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgOrderDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void TGarageKey_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgCloseDate_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void TxtCloseDateSet_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtPRICE_NOTE_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtMILEDGE_NOTE_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChBA1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBA1.Checked == true)
            {
                GrdRepairOrderAct1.Columns[8].Visible = true;
            }
            else
            {
                GrdRepairOrderAct1.Columns[8].Visible = false;
            }
            //
        }

        protected void CmdSearchRQ_Click(object sender, EventArgs e)
        {
            //
            //
            string SDate = TxtSDate.Text;
            string EDate = TxtEDate.Text;
            if (SDate == "" || EDate == "") { return; }
            //
            DateTime StartDate = DateTime.ParseExact(SDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime EndDate = DateTime.ParseExact(EDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //
            SetSumarizeCounter();
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //
            try
            {
                string keySearch1 = TxtKeyMNx.Text.Trim();
                string keySearch2 = TxtKeyMNz.Text.Trim();
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Maintaining(StartDate, EndDate, keySearch1, keySearch2);
                var withBlock = GrdRepairOrderAct3;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();
            }
            catch { }
        }

        protected void CmdSearchRQ0_Click(object sender, EventArgs e)
        {
            //
            string SDate = TxtSDate0.Text;
            string EDate = TxtEDate0.Text;
            if (SDate == "" || EDate == "") { return; }
            //
            DateTime StartDate = DateTime.ParseExact(SDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime EndDate = DateTime.ParseExact(EDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //
            SetSumarizeCounter();
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //
            try
            {
                string keySearch1 = TxtKeyMN.Text.Trim();
                string keySearch2 = TxtKeyMNy.Text.Trim();
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_OrderClosed(StartDate, EndDate, keySearch1, keySearch2);
                var withBlock = GrdRepairOrderAct4;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();

                //ADD 26012023
                var grdCount = withBlock.Rows.Count;
                if (grdCount == 0)
                {
                    imgBtnORD4.Enabled = false;
                }
                else { imgBtnORD4.Enabled = true; }
                //END 26012023
            }
            catch { }
        }

        protected void TxtKeyMNx_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CmdPartRequisitionGet_Click(object sender, EventArgs e)
        {
            //
            string IDx = "";
            string TxtDescription = "";
            string StrAmt = "0";
            float MnAmt = 0;
            string StrPrice = "";
            double MnPrice = 0.00;
            double AmtPrice= 0.00;
            MaintainTbl3 = (DataTable)Session["MaintainTbl3"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();

            //
            if (GrdRepairPart.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
                {
                    IDx = GrdRepairPart.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPart")).Text.Trim();
                    StrAmt = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescriptionPartAmt")).Text.Trim();
                    MnAmt = Convert.ToInt32(StrAmt);
                    StrPrice = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescPrice")).Text.Trim();
                    MnPrice = Convert.ToDouble(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl3.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            dr["MnAmt"] = MnAmt;
                            dr["MnPrice"] = MnPrice;
                            AmtPrice =+ MnPrice;
                            break;
                        }
                    }
                }
                //lblAmtPrice.Text = Convert.ToString(AmtPrice);
                lblAmtPrice.Text = AmtPrice.ToString("#,##0.00");
                //incGlobalDataPatternObj.AddDataToTableMaintainPartCollection("--", 1, MaintainTbl3);
                MaintainTbl3.AcceptChanges();
            }
            else
            {
                //incGlobalDataPatternObj.AddDataToTableMaintainPartCollection("--", 1, MaintainTbl3);
                MaintainTbl3.AcceptChanges();
            }
            //
            DataSet DSetAsset;
            JxTransactionService incJxTransactionServiceObj = new JxTransactionService();
            //
            try
            {
                string ReqOrderNo = TxtPartRequestionNo.Text.Trim();
                if (ReqOrderNo == "") { return; }
                DSetAsset = incJxTransactionServiceObj.GetPartRequestionCollection(ReqOrderNo);
                string PartDesc = "";
                int PartAmt = 0;
                double PartPrice = 0.00;
                foreach (DataRow dr in DSetAsset.Tables["tbt_GIRMDetail"].Rows)
                {
                    PartDesc = dr["OutboundOrderNo"].ToString() + "|" + dr["ProductCode"].ToString() + "|" + dr["ProductnameTH"].ToString();
                    if (PartDesc.Length > 1000) { PartDesc = PartDesc.Substring(0, 1000); }
                    PartAmt  = Int32.Parse(dr["QuantityShip"].ToString());
                    AmtPrice += PartPrice;
                    incGlobalDataPatternObj.AddDataToTableMaintainPartCollection(PartDesc,PartAmt,PartPrice,MaintainTbl3);  
                }
            }
            catch { }
            //
            Session["MaintainTbl3"] = MaintainTbl3;
            //
            var withBlock = GrdRepairPart;
            withBlock.DataSource = Session["MaintainTbl3"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;

            lblAmtPrice.Text = AmtPrice.ToString("#,##0.00");
        }

        protected void imgBtnORD0_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct1";
            var strState = "สั่งซ่อม_เอกสารรอพิจารณาอนุมัติ";
            ExportGridToExcel(strGrdId,strState);
        }
        protected void imgBtnORD2_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct2";
            var strState = "สั่งซ่อม_รายการขอรายละเอียดเพิ่มเติม";
            ExportGridToExcel(strGrdId, strState);
        }

        protected void imgBtnORD3_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct3";
            var strState = "สั่งซ่อม_รายการที่อยู่ระหว่างการซ่อม";
            ExportGridToExcel(strGrdId, strState);
        }

        protected void imgBtnORD4_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct4";
            var strState = "สั่งซ่อม_รายการที่ปิดงานซ่อมเรียบร้อยแล้ว";
            ExportGridToExcel(strGrdId, strState);
        }

        protected void imgBtn8_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdAssetVehSelector";
            var strState = "B-รายการยานพาหนะ";
            ExportGridToExcel(strGrdId, strState);
        }
        private void ExportGridToExcel(string GrdId,string StateJ)
        {
            try
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid password')", true);
                var grd = GrdId;
                var d = DateTime.Now.ToString();
                var dreplace = d.Replace('/', '-');
                var dreplace2 = dreplace.Replace(' ', '_');
                var fileName = StateJ + dreplace2 + ".xls";
                //var fileName = "Excel" + dreplace2 + ".xlsx";
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/ms-excel";
                //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                switch (grd)
                {
                    case "GrdRepairOrderAct1":
                        GrdRepairOrderAct1.RenderControl(htw);
                        break;
                    case "GrdRepairOrderAct2":
                        GrdRepairOrderAct2.RenderControl(htw);
                        break;
                    case "GrdRepairOrderAct3":
                        GrdRepairOrderAct3.RenderControl(htw);
                        break;
                    case "GrdRepairOrderAct4":
                        GrdRepairOrderAct4.RenderControl(htw);
                        break;
                    case "GrdRepairOrderAct6":
                        GrdRepairOrderAct6.RenderControl(htw);
                        break;
                    case "GrdAssetVehSelector":
                        GrdAssetVehSelector.RenderControl(htw);
                        break;
                    default:
                        break;
                }
                //GrdRepairOrderAct0.RenderControl(htw);
                Response.Output.Write(sw.ToString());

            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Export Error')", true);
            }
            finally
            {
                Response.End();
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void txtDescPrice_TextChanged(object sender, EventArgs e)
        {
            string IDx = "";
            string StrPrice = "";
            double MnPrice = 0.00;
            double AmtPrice = 0.00;
            MaintainTbl3 = (DataTable)Session["MaintainTbl3"];
            if (GrdRepairPart.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
                {
                    IDx = GrdRepairPart.DataKeys[IRow].Value.ToString();
                    
                    StrPrice = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescPrice")).Text.Trim();
                    MnPrice = Convert.ToDouble(StrPrice);
                    //
                    foreach (DataRow dr in MaintainTbl3.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            AmtPrice += MnPrice;
                            break;
                        }
                    }
                }
                lblAmtPrice.Text = AmtPrice.ToString("#,##0.00");
                //incGlobalDataPatternObj.AddDataToTableMaintainPartCollection("--", 1, 0.00, MaintainTbl3);
                MaintainTbl3.AcceptChanges();
            }
            else
            {
                for (int IRow = 0; IRow < GrdRepairPart.Rows.Count; IRow++)
                {
                    StrPrice = ((TextBox)GrdRepairPart.Rows[IRow].FindControl("TxtDescPrice")).Text.Trim();
                }
                lblAmtPrice.Text = AmtPrice.ToString("#,##0.00");
            }

        }
    }
}