using JxIntraWeb.App_DataEngine;
using JxIntraWeb.App_Report;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JxIntraWeb.App_Pages
{
    public partial class PrintTool : System.Web.UI.Page
    {
        private void GeneratMNDataPrint(string OrderNo, int VehAssetID)
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet1 incDataSet1Obj = new DataSet1();
            DataSet OrderDSet;
            DataSet OrderDSet2;
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
            string DC_REQ = "";
            string ORDER_NO = "";
            string ORDER_DATE = "";
            string vage = "-";
            string vmiledge = "-";
            //
            string MNT_OWN_USR = "";

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
                    //
                    SERVICE_GARAGE_ID = Convert.ToInt32(DRow["SERVICE_GARAGE_ID"]);
                    GARAGE_NAME = DRow["GARAGE_NAME"].ToString();
                    GARAGE_ADDR = DRow["GARAGE_ADDR"].ToString();
                    GARAGE_CONTACT = DRow["GARAGE_CONTACT"].ToString();
                    GARAGE_TEL = DRow["GARAGE_TEL"].ToString();
                    //
                    DC_REQ = DRow["MNT_OWN_SITE"].ToString();
                    ORDER_NO = DRow["MNT_ORD_NO"].ToString();
                    ORDER_DATE = Convert.ToDateTime(DRow["MNT_ORD_DATE"]).ToString("dd/MM/yyyy");
                    //
                    vage = Convert.ToInt32(DRow["VEH_AGE"]).ToString("0"); ;
                    vmiledge = Convert.ToDecimal(DRow["ORD_VEH_MILEDGE"]).ToString("#,##0.00") ;
                    //
                    MNT_OWN_USR = DRow["MNT_OWN_USR"].ToString();

                }           
                //
                DataRow newR_HD = incDataSet1Obj.Tables["DataTable1"].NewRow();
                newR_HD["vcode"] = VEH_CODE;
                newR_HD["vlicense"] = VEH_LICENSE;
                newR_HD["vbland"] = VEH_BRAND;
                newR_HD["vmodel"] = VEH_MODEL;
                newR_HD["vtype"] = VEH_TYPE;
                newR_HD["vage"] = vage;
                newR_HD["vmiledge"] = vmiledge;
                newR_HD["vfuel"] = VEH_FUEL_SPEC;
                newR_HD["garage_info"] = SERVICE_GARAGE_ID.ToString() + " " + GARAGE_NAME + " " + GARAGE_ADDR;
                newR_HD["garage_contact"] = GARAGE_CONTACT + " " + GARAGE_TEL;
                newR_HD["dc_req"] = DC_REQ;
                newR_HD["order_no"] = ORDER_NO;
                newR_HD["order_date"] = ORDER_DATE;
                newR_HD["MNT_OWN_USR"] = MNT_OWN_USR;
                incDataSet1Obj.Tables["DataTable1"].Rows.Add(newR_HD);
                //

                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC"].Rows)
                {
                    DataRow newR_D1 = incDataSet1Obj.Tables["DataTable2"].NewRow();
                    newR_D1["IRx"] = Convert.ToInt32(DRow["MNT_ORD_LINENO"]);
                    newR_D1["Desc"] = DRow["MNT_LINENO_DESC"].ToString();
                    incDataSet1Obj.Tables["DataTable2"].Rows.Add(newR_D1);
                }
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC2"].Rows)
                {
                    DataRow newR_D1 = incDataSet1Obj.Tables["TB_ORDER_DESC2"].NewRow();
                    //newR_D1["IRx"] = Convert.ToInt32(DRow["MNT_ORD_LINENO"]);  //Auto Increment
                    newR_D1["Desc"] = DRow["MNT_LINENO_DESC"].ToString();
                    incDataSet1Obj.Tables["TB_ORDER_DESC2"].Rows.Add(newR_D1);
                }
                //
                string MNT_WHL_POS = "";
                string MNT_REQ_REASON = "";
                string WHL_DAMAGE_AREA1 = "_";
                string WHL_DAMAGE_AREA2 = "_";
                string WHL_DAMAGE_AREA3 = "_";
                string WHL_DAMAGE_AREA4 = "_";
                //
                string WHL_DAMAGE_TYPE1 = "_";
                string WHL_DAMAGE_TYPE2 = "_";
                string WHL_DAMAGE_TYPE3 = "_";
                string WHL_DAMAGE_TYPE4 = "_";
                //
                string WHL_DAMAGE_OTH = "";
                string WHL_DAMAGE_TYPEOTH = "";
                //
                string WHL_SERIAL = "";
                string WHL_R_MILE = "";
                string WHL_SIZE = "";
                //
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_WHLL"].Rows)
                {
                    MNT_WHL_POS = DRow["MNT_WHL_POS"].ToString();
                    MNT_REQ_REASON = DRow["MNT_REQ_REASON"].ToString();
                    //
                    if ((bool)DRow["WHL_DAMAGE_AREA1"]) { WHL_DAMAGE_AREA1 = "Y"; } else { WHL_DAMAGE_AREA1 = "_"; }
                    if ((bool)DRow["WHL_DAMAGE_AREA2"]) { WHL_DAMAGE_AREA2 = "Y"; } else { WHL_DAMAGE_AREA2 = "_"; }
                    if ((bool)DRow["WHL_DAMAGE_AREA3"]) { WHL_DAMAGE_AREA3 = "Y"; } else { WHL_DAMAGE_AREA3 = "_"; }
                    if ((bool)DRow["WHL_DAMAGE_AREA4"]) { WHL_DAMAGE_AREA4 = "Y"; } else { WHL_DAMAGE_AREA4 = "_"; }
                    //
                    if ((bool)DRow["WHL_DAMAGE_TYPE1"]) { WHL_DAMAGE_TYPE1 = "Y"; } else { WHL_DAMAGE_TYPE1 = "_"; }
                    if ((bool)DRow["WHL_DAMAGE_TYPE2"]) { WHL_DAMAGE_TYPE2 = "Y"; } else { WHL_DAMAGE_TYPE2 = "_"; }
                    if ((bool)DRow["WHL_DAMAGE_TYPE3"]) { WHL_DAMAGE_TYPE3 = "Y"; } else { WHL_DAMAGE_TYPE3 = "_"; }
                    if ((bool)DRow["WHL_DAMAGE_TYPE4"]) { WHL_DAMAGE_TYPE4 = "Y"; } else { WHL_DAMAGE_TYPE4 = "_"; }
                    //
                    WHL_DAMAGE_OTH = DRow["WHL_DAMAGE_OTH"].ToString();
                    WHL_DAMAGE_TYPEOTH = DRow["WHL_DAMAGE_TYPEOTH"].ToString();
                    //WHL_SERIAL, WHL_R_MILE, WHL_SIZE
                    WHL_SERIAL = DRow["WHL_SERIAL"].ToString();
                    WHL_R_MILE = DRow["WHL_R_MILE"].ToString();
                    WHL_SIZE = DRow["WHL_SIZE"].ToString();
                    //--
                    DataRow newR_D2 = incDataSet1Obj.Tables["DataTable3"].NewRow();
                    newR_D2["IRx"] = Convert.ToInt32(DRow["MNT_ORD_LINENO"]);
                    newR_D2["MNT_WHL_POS"] = MNT_WHL_POS;
                    newR_D2["MNT_REQ_REASON"] = MNT_REQ_REASON;
                    newR_D2["WHL_DAMAGE_AREA1"] = WHL_DAMAGE_AREA1;
                    newR_D2["WHL_DAMAGE_AREA2"] = WHL_DAMAGE_AREA2;
                    newR_D2["WHL_DAMAGE_AREA3"] = WHL_DAMAGE_AREA3;
                    newR_D2["WHL_DAMAGE_AREA4"] = WHL_DAMAGE_AREA4;
                    newR_D2["WHL_DAMAGE_TYPE1"] = WHL_DAMAGE_TYPE1;
                    newR_D2["WHL_DAMAGE_TYPE2"] = WHL_DAMAGE_TYPE2;
                    newR_D2["WHL_DAMAGE_TYPE3"] = WHL_DAMAGE_TYPE3;
                    newR_D2["WHL_DAMAGE_TYPE4"] = WHL_DAMAGE_TYPE4;

                    newR_D2["WHL_DAMAGE_OTH"] = WHL_DAMAGE_OTH;
                    newR_D2["WHL_DAMAGE_TYPEOTH"] = WHL_DAMAGE_TYPEOTH;
                    newR_D2["WHL_SERIAL"] = WHL_SERIAL;
                    newR_D2["WHL_R_MILE"] = WHL_R_MILE;
                    newR_D2["WHL_SIZE"] = WHL_SIZE;
                    incDataSet1Obj.Tables["DataTable3"].Rows.Add(newR_D2);
                }
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_PRICE"].Rows)
                {
                    DataRow newR_T5 = incDataSet1Obj.Tables["DataTable4"].NewRow();
                    newR_T5["IRx"] = Convert.ToInt32(DRow["MNT_ORD_LINENO"]);
                    newR_T5["Desc"] = DRow["MNT_LINENO_DESC"].ToString();
                    newR_T5["Price"] = Convert.ToDecimal(DRow["MNT_LINENO_PRICE"]);
                    newR_T5["Servicer"] = DRow["MNT_LINENO_SERVICER"].ToString();
                    incDataSet1Obj.Tables["DataTable4"].Rows.Add(newR_T5);

                }
                foreach (DataRow DRow in OrderDSet.Tables["TB_COMMENT"].Rows)
                {
                    DataRow newR_T6 = incDataSet1Obj.Tables["DataTable5"].NewRow();
                    newR_T6["IRx"] = DRow["MNT_ORD_LINENO"];
                    newR_T6["DateNote"] = DRow["DATE_NOTE"].ToString();
                    newR_T6["Desc"] = DRow["DESC_NOTE"].ToString();
                    newR_T6["Miledge"] = DRow["MILEDGE_NOTE"].ToString();
                    newR_T6["Price"] = DRow["PRICE_NOTE"];
                    newR_T6["Servicer"] = DRow["SERVICER_NOTE"].ToString();
                    incDataSet1Obj.Tables["DataTable5"].Rows.Add(newR_T6);
                }
                //
                string Path = "~/Upload/";
                string PathAbsolute = "";
                string PathAbsoluteUri = "";   // new Uri(Server.MapPath("~/images/Mudassar.jpg")).AbsoluteUri;
                foreach (DataRow DRow in OrderDSet.Tables["TB_IMAGE"].Rows)
                {
                    DataRow newR_T7 = incDataSet1Obj.Tables["TB_ORDER_IMG"].NewRow();
                    PathAbsolute = "";
                    PathAbsolute = Path + DRow["Image_FileActual"].ToString();
                    newR_T7["IMG_DESC"] = DRow["Image_Note"].ToString();
                    PathAbsoluteUri =  new Uri(Server.MapPath(PathAbsolute)).AbsoluteUri;
                    //newR_T7["IMG_PATH"] = @"file:\\E:\JPX_WORK\JxIntraWeb\JxIntraWeb\Upload\202209-ROD2022-000477076517144a054ecea8179b49e4f49975.jpg";
                    newR_T7["IMG_PATH"] = PathAbsoluteUri;
                    incDataSet1Obj.Tables["TB_ORDER_IMG"].Rows.Add(newR_T7);
                }
                //

                //---------------------NEW--------------------------
                var mnt_no_top = "";
                foreach (DataRow data in OrderDSet.Tables["TB_HISTORY_TOP"].Rows)
                {
                    mnt_no_top = data["MNT_ORD_NO"].ToString();
                }

                OrderDSet2 = IncJxMasterServiceObj.GetLastHistory(mnt_no_top);
                foreach (DataRow DRow in OrderDSet2.Tables["TB_LAST_HISTORY"].Rows)
                {
                    DataRow newr_lasth = incDataSet1Obj.Tables["dt_last_history"].NewRow();
                    //newr_lasth["IRx"] = Convert.ToInt32(DRow["MNT_ORD_LINENO"]);
                    //newr_lasth["Desc"] = DRow["MNT_LINENO_DESC"].ToString();
                    //newr_lasth["Price"] = Convert.ToDecimal(DRow["MNT_LINENO_PRICE"]);
                    //newr_lasth["Servicer"] = DRow["MNT_LINENO_SERVICER"].ToString();
                    newr_lasth["JobId"] = DRow["MNT_ORD_NO"].ToString();
                    newr_lasth["IRx"] = Convert.ToInt32(DRow["MNT_ORD_LINENO"]);
                    newr_lasth["Desc"] = DRow["MNT_LINENO_DESC"].ToString();
                    incDataSet1Obj.Tables["dt_last_history"].Rows.Add(newr_lasth);

                }
                //---------------------NEW--------------------------

            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }

            //
            PrintMNForm(incDataSet1Obj);
            string DocumentType = Session["PRINT_TYPE"].ToString();
            //
        }
        private void PrintMNForm(DataSet DSetReportSource)
        {
            // Execute file Mode
            {
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportViewer1.LocalReport.ReportEmbeddedResource = "JxIntraWeb.App_Report.Report1.rdlc";
                ReportViewer1.LocalReport.ReportEmbeddedResource = "~/Report1.rdlc";
                ReportViewer1.LocalReport.DataSources.Clear();
                // 
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Header", DSetReportSource.Tables["DataTable1"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detail1", DSetReportSource.Tables["DataTable2"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detail2", DSetReportSource.Tables["DataTable3"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detail4", DSetReportSource.Tables["DataTable4"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detail3", DSetReportSource.Tables["DataTable5"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DT_MNT_ORDER_DESCL2", DSetReportSource.Tables["TB_ORDER_DESC2"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DT_IMG", DSetReportSource.Tables["TB_ORDER_IMG"]));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DT_LAST_HISTORY", DSetReportSource.Tables["dt_last_history"]));
                // 
                ReportViewer1.DocumentMapCollapsed = true;
                //ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                ReportViewer1.ZoomPercent = 100;
                //
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["PRINT_DOCNO"] != null)
                {
                    if (string.IsNullOrEmpty(Session["PRINT_DOCNO"].ToString()))
                    {
                        Server.Transfer("~/Default.aspx");
                    }
                    else
                    {
                        string DocumentNo = Session["PRINT_DOCNO"].ToString();
                        int VehicleAssetID = Convert.ToInt32(Session["PRINT_VEHID"].ToString());
                        Session.Remove("PRINT_DOCNO");
                        Session.Remove("PRINT_VEHID");
                        GeneratMNDataPrint(DocumentNo, VehicleAssetID);
                    }
                }
                else { Server.Transfer("~/Default.aspx"); }

            }
        }
    }
}