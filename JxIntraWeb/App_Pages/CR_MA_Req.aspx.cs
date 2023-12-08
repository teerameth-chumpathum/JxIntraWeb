using JxIntraWeb.App_DataEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JxIntraWeb.App_Pages
{   
    public partial class CR_MA_Req : System.Web.UI.Page
    {
        public DataTable MaintainTbl;
        public DataTable MaintainTblImage;
        public DataTable MaintainTblWheel;
        //
        public DataTable MaintainTbl4;
        public DataTable MainHistory;
        public DataTable MaintainTbl7;
        //
        private void CommandControl(bool ShowRollBackDoc,bool ShowDeleteDoc,bool ShowSaveDoc,bool ShowConfirmDoc)
        {
            CmdRollBackDoc.Visible = ShowRollBackDoc;
            CmdDeleteDoc.Visible = ShowDeleteDoc;
            CmdSaveOrd.Visible = ShowSaveDoc;
            CmdReqApproveOrd.Visible = ShowConfirmDoc;
        }
        private void SetDocumentViewOnlyMode()
        {
            TxtVehAge.ReadOnly = true;
            TxtVehMiledge.ReadOnly = true;
            //CmdOpenVehCollection.Visible = false;
            //CmdOpenGarageCollection.Visible = false;
            CmdOpenVehCollection.Enabled = false;
            CmdOpenGarageCollection.Enabled = false;
            //
            for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).ReadOnly=true;
            }
            GrdRepairDesc.Columns[0].Visible = false;
            CmdAddDescLine.Visible = false;
            //
            for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).ReadOnly = true;
            }
            GrdRepairDetail.Columns[0].Visible = false;
            CmdDetail.Visible = false;
            //
            //Image
            //for (int IRow = 0; IRow < GrdOrderImage.Rows.Count; IRow++)
            //{
            //    ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).ReadOnly = false;
            //}
            GrdOrderImage.Columns[0].Visible = false;
            CmdAddImage.Visible = false;
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
                //
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtSN")).ReadOnly = true;
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtRubberMil")).ReadOnly = true;
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWhellSize")).ReadOnly = true;
                //                
            }
            TxtDrvName.ReadOnly = true;
            TxtSiteEmpName.ReadOnly = true;
            //
            RdoCR.Enabled = false;
            RdoPM.Enabled = false;
        }
        private void SetDocumentEditableMode()
        {
            TxtVehAge.ReadOnly = false;
            TxtVehMiledge.ReadOnly = false;

            //CmdOpenVehCollection.Visible = true;
            //CmdOpenGarageCollection.Visible = true;
            CmdOpenVehCollection.Enabled = true;
            CmdOpenGarageCollection.Enabled = true;
            //
            for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).ReadOnly = false;
            }
            GrdRepairDesc.Columns[0].Visible = true;
            CmdAddDescLine.Visible = true;
            //
            for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
            {
                ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).ReadOnly = false;
            }
            GrdRepairDetail.Columns[0].Visible = true;
            CmdDetail.Visible = true;
            //
            //Image
            //for (int IRow = 0; IRow < GrdOrderImage.Rows.Count; IRow++)
            //{
            //    ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).ReadOnly = false;
            //}
            GrdOrderImage.Columns[0].Visible = true;
            CmdAddImage.Visible = true;
            //
            ImageMap1.Enabled = true;
            GrdWheelPos.Columns[0].Visible = true;
            for (int IRow = 0; IRow < GrdWheelPos.Rows.Count; IRow++)
            {
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWRepairReason")).ReadOnly = false;
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageAreaOther")).ReadOnly = false;
                ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageTypeAno")).ReadOnly = false;
                //
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea1")).Enabled = true;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea2")).Enabled = true;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea3")).Enabled = true;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea4")).Enabled = true;
                //
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType1")).Enabled = true;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType2")).Enabled = true;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType3")).Enabled = true;
                ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType4")).Enabled = true;
            }
            //
            TxtDrvName.ReadOnly = false;
            //
            RdoCR.Enabled = true;
            RdoPM.Enabled = true;
        }
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
                        SetSumarizeCounter();
                    }
                }
                else { Server.Transfer("~/Default.aspx"); }    
            }
        }
        protected void CmdAct5_Click(object sender, EventArgs e)
        {
      
        }
        private string GetRepairOrderNo()
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            string Docno;
            Docno = IncJxMasterServiceObj.GetSerialNo("ORD01");
            return "ROD" + Docno;
        }
        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {
            string PostBackVal = e.PostBackValue;
            //TX.Text = PostBackVal.Trim().ToUpper();
            MaintainTblWheel = (DataTable)Session["MaintainTblWheel"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            if (GrdWheelPos.Rows.Count > 0)
            {
                string IDx = "";
                string RepairReason = "";
                bool DamageArea1 = false;
                bool DamageArea2 = false;
                bool DamageArea3 = false;
                bool DamageArea4 = false;
                string DamageAreaAno = "";
                //
                bool DamageType1 = false;
                bool DamageType2 = false;
                bool DamageType3 = false;
                bool DamageType4 = false;
                string DamageTypeAno = "";
                //

                for (int IRow = 0; IRow < GrdWheelPos.Rows.Count; IRow++)
                {
                    IDx = GrdWheelPos.DataKeys[IRow].Value.ToString();
                    RepairReason = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWRepairReason")).Text.Trim();
                    DamageArea1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea1")).Checked;
                    DamageArea2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea2")).Checked;
                    DamageArea3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea3")).Checked;
                    DamageArea4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea4")).Checked;
                    DamageAreaAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageAreaOther")).Text.Trim();
                    //
                    DamageType1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType1")).Checked;
                    DamageType2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType2")).Checked;
                    DamageType3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType3")).Checked;
                    DamageType4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType4")).Checked;
                    DamageTypeAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageTypeAno")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTblWheel.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnRemark"] = RepairReason;
                            //
                            dr["DamageArea1"] = DamageArea1;
                            dr["DamageArea2"] = DamageArea2;
                            dr["DamageArea3"] = DamageArea3;
                            dr["DamageArea4"] = DamageArea4;
                            dr["DamageAreaAno"] = DamageAreaAno;
                            //
                            dr["DamageType1"] = DamageType1;
                            dr["DamageType2"] = DamageType2;
                            dr["DamageType3"] = DamageType3;
                            dr["DamageType4"] = DamageType4;
                            dr["DamageTypeAno"] = DamageTypeAno;
                            break;
                        }
                    }
                }
            }
            //เพิ่ม Reccord To DataTable
            if (PostBackVal.Trim().ToUpper() == "1")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("1", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "2")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("2", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "3")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("3", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "4")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("4", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "5")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("5", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "6")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("6", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "7")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("7", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "8")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("8", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            //
            if (PostBackVal.Trim().ToUpper() == "9")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("9", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "10")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("10", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "11")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("11", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "12")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("12", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "13")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("13", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "14")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("14", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "15")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("15", "-", false, false, false, false, false, false, false, false, "-", "-","-","-","-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "16")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("16", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "17")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("17", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "18")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("18", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "02")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("02", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "03")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("03", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }
            if (PostBackVal.Trim().ToUpper() == "04")
            {
                incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("04", "-", false, false, false, false, false, false, false, false, "-", "-", "-", "-", "-", MaintainTblWheel);
            }



            //
            Session["MaintainTblWheel"] = MaintainTblWheel;
            //
            var withBlockx = GrdWheelPos;
            withBlockx.DataSource = MaintainTblWheel;
            withBlockx.DataBind();
            withBlockx.AutoGenerateColumns = false;
        } 
        protected void CmdAddImage_Click(object sender, EventArgs e)
        {
            CmdAddImage.Visible = false;
            PanelGetImage.Visible = true;
            lblMessage.Text = "";
            TxtImageNote.Text = "";
        }
        protected void CmdCloseImageSelector_Click(object sender, EventArgs e)
        {
            CmdAddImage.Visible = true;
            PanelGetImage.Visible = false;
            lblMessage.Text = "";
            TxtImageNote.Text = "";
        }     
        protected void CmdAddDescLine_Click(object sender, EventArgs e)
        {
            //
            string IDx = "";
            string TxtDescription = "";
            MaintainTbl = (DataTable)Session["MaintainTbl"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            if (GrdRepairDesc.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            break;
                        }
                    }
                }

                incGlobalDataPatternObj.AddDataToTableMaintainCollection("--", MaintainTbl);
                MaintainTbl.AcceptChanges();

            }
            else
            {
                incGlobalDataPatternObj.AddDataToTableMaintainCollection("--", MaintainTbl);
                MaintainTbl.AcceptChanges();
            }
            Session["MaintainTbl"] = MaintainTbl;
            //
            var withBlock = GrdRepairDesc;
            withBlock.DataSource = Session["MaintainTbl"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
        }
        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string IDx_Del = GrdWheelPos.SelectedRow.Cells[1].Text;
            string IDx_Del = GrdWheelPos.DataKeys[GrdWheelPos.SelectedRow.RowIndex]["IDx"].ToString();
            MaintainTblWheel = (DataTable)Session["MaintainTblWheel"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();

            //Update Session Datatable
            if (GrdWheelPos.Rows.Count > 0)
            {
                string IDx = "";
                string RepairReason = "";
                bool DamageArea1 = false;
                bool DamageArea2 = false;
                bool DamageArea3 = false;
                bool DamageArea4 = false;
                string DamageAreaAno = "";
                //
                bool DamageType1 = false;
                bool DamageType2 = false;
                bool DamageType3 = false;
                bool DamageType4 = false;
                string DamageTypeAno = "";
                //

                for (int IRow = 0; IRow < GrdWheelPos.Rows.Count; IRow++)
                {
                    IDx = GrdWheelPos.DataKeys[IRow].Value.ToString();
                    RepairReason = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWRepairReason")).Text.Trim();
                    DamageArea1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea1")).Checked;
                    DamageArea2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea2")).Checked;
                    DamageArea3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea3")).Checked;
                    DamageArea4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea4")).Checked;
                    DamageAreaAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageAreaOther")).Text.Trim();
                    //
                    DamageType1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType1")).Checked;
                    DamageType2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType2")).Checked;
                    DamageType3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType3")).Checked;
                    DamageType4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType4")).Checked;
                    DamageTypeAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageTypeAno")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTblWheel.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnRemark"] = RepairReason;
                            //
                            dr["DamageArea1"] = DamageArea1;
                            dr["DamageArea2"] = DamageArea2;
                            dr["DamageArea3"] = DamageArea3;
                            dr["DamageArea4"] = DamageArea4;
                            dr["DamageAreaAno"] = DamageAreaAno;
                            //
                            dr["DamageType1"] = DamageType1;
                            dr["DamageType2"] = DamageType2;
                            dr["DamageType3"] = DamageType3;
                            dr["DamageType4"] = DamageType4;
                            dr["DamageTypeAno"] = DamageTypeAno;
                            break;
                        }
                    }
                }
            }
            //
            foreach (DataRow dr in MaintainTblWheel.Rows)
            {
                if (dr["IDx"].ToString() == IDx_Del)
                    dr.Delete();
            }
            //
            MaintainTblWheel.AcceptChanges();
            Session["MaintainTblWheel"] = MaintainTblWheel;
            //
            var withBlock = GrdWheelPos;
            withBlock.DataSource = (DataTable)Session["MaintainTblWheel"]; ;
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
        }
        protected void CmdSearchAssetVeh_Click(object sender, EventArgs e)
        {
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetVehicleCollection(KeySearch);
                var withBlock = GrdAssetVehSelector;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_VEH_COLLECTION"];
                withBlock.DataBind();
            }
            catch { }
            ModalPopupExtender1.Show();
        }
        private int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                    if (((BoundField)cell.ContainingField).DataField.ToUpper().Trim().Equals(columnName.ToUpper().Trim()))
                        break;
                columnIndex++; // keep adding 1 while we don't have the correct name
            }
            return columnIndex;
        }
        protected void GrdAssetVehSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow RowGet = GrdAssetVehSelector.SelectedRow;
            TxtVehCode.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_CODE")].Text;
            TxtVehLicense.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_LICENSE")].Text;
            TxtVehType.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_TYPE")].Text;
            //
            TxtVehBrand.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_BRAND")].Text;
            TxtVehModel.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_MODEL")].Text;
            TxtVehFuel.Text = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_FUEL_SPEC")].Text;
            HideVehID.Value = GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text;
            //
            int YearNow=Convert.ToInt32(DateTime.Now.Year.ToString());
            var VehYear= GrdAssetVehSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ST_USE_DTIME")].Text;
            int VehYearReg;
            int VehAge;
            if (int.TryParse(VehYear, out VehYearReg))
            {
                if (VehYearReg > 0)
                {
                    //Positive number 
                    VehAge = YearNow - VehYearReg;
                    if (VehAge > 0)
                    {
                        TxtVehAge.Text = VehAge.ToString("0");
                    }
                    else {TxtVehAge.Text = "-";}
                }
            }
            //
            if (VehYearReg == 0) { TxtVehAge.Text = "-"; }
        }
        protected void CmdOpenGarageCollection_Click(object sender, EventArgs e)
        {

        }
        protected void CmdSearchGarage_Click(object sender, EventArgs e)
        {
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            string GarageKeySearch = TxtGarageKeySearch.Text.Trim();
            DSetAsset = incJxMasterServiceObj.GetGarageCollection(GarageKeySearch);
            var withBlock = GrdGarageSelector;
            withBlock.AutoGenerateColumns = false;
            withBlock.DataSource = DSetAsset.Tables["TB_GARAGE_COLLECTION"];
            withBlock.DataBind();
            //
            ModalPopupExtender2.Show();
        }
        protected void GrdGarageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow RowGet = GrdGarageSelector.SelectedRow;
            HideGarageID.Value = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_ID")].Text.Replace("&#160;", " ");
            TxtGarageName.Text = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_NAME")].Text.Replace("&#160;", " ");
            TxtGarageAddr.Text = GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_ADDR")].Text.Replace("&#160;", " ");
            TxtGarageContact.Text= GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_CONTACT")].Text.Replace("&#160;", " ") + " " + GrdGarageSelector.SelectedRow.Cells[GetColumnIndexByName(RowGet, "GARAGE_TEL")].Text.Replace("&#160;", " ");
            //
        }
        protected void GrdRepairDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDx_Del = GrdRepairDesc.DataKeys[GrdRepairDesc.SelectedRow.RowIndex]["IDx"].ToString();
            MaintainTbl = (DataTable)Session["MaintainTbl"];
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            //
            //Update Session Datatable
            if (GrdRepairDesc.Rows.Count > 0)
            {
                string IDx = "";
                string MnDesc = "";
                //
                for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc.DataKeys[IRow].Value.ToString();
                    MnDesc = ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = MnDesc;
                            //
                            break;
                        }
                    }
                }
            }
            //
            foreach (DataRow dr in MaintainTbl.Rows)
            {
                if (dr["IDx"].ToString() == IDx_Del)
                    dr.Delete();
            }
            //
            MaintainTbl.AcceptChanges();
            Session["MaintainTbl"] = MaintainTbl;
            //
            var withBlock = GrdRepairDesc;
            withBlock.DataSource = Session["MaintainTbl"];
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
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
        protected void CmdSaveOrd_Click(object sender, EventArgs e)
        {
            string STDate = TxtOrderDate.Text.Trim();
            //DateTime? oDate;
            //if (IsDateTime(STDate) == true)
            //{
            //    oDate = DateTime.ParseExact(STDate, "dd/MM/yyyy", null);
            //}
            //else { oDate = null; }
            //if (oDate == null)
            //{
            //    Response.Write("<script>alert('!!วันที่ใบแจ้งซ่อมไม่ถูกต้อง!!');</script>");
            //    return;
            //}
            //
            string Operate_Result = "";
            string OrderRecordNo = "";
            //string x = HideModeOperate.Value.ToString().ToUpper().Trim();
            //add new mode
            if (HideModeOperate.Value.ToString().ToUpper().Trim() == "CRT")
            {
                //เปิดเอกสารใหม่
                Operate_Result = SaveReqRepairOrder();

                if (Operate_Result.ToUpper().Substring(0, 2) == "TR")
                {
                    string OrderNo = TxtOrderNo.Text;
                    OrderRecordNo = GetRecordReferenceNo(OrderNo);
                    //
                    HideModeOperate.Value = "EDT";
                    HideRecRefNo.Value = OrderRecordNo;
                    Response.Write("<script>alert('บันทึก: เรียบร้อย!!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + Operate_Result.Replace("ERR:", "") + "');</script>");
                }
            }
            //edit mode
            else if (HideModeOperate.Value.ToString().ToUpper().Trim() == "EDT")
            {
                //แก้ไขเอกสาร
                Operate_Result = SaveReqRepairOrder();

                if (Operate_Result.ToUpper().Substring(0, 2) == "TR")
                {
                    string OrderNo = TxtOrderNo.Text;
                    OrderRecordNo = GetRecordReferenceNo(OrderNo);
                    //
                    HideModeOperate.Value = "EDT";
                    HideRecRefNo.Value = OrderRecordNo;
                    Response.Write("<script>alert('บันทึก: เรียบร้อย!!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + Operate_Result.Replace("ERR:", "") + "');</script>");
                }
            }
            else
            {
                //
            }
            //
            SetSumarizeCounter();
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
        private string SaveReqRepairOrder()
        {
            //Validate 
            //DL: ลบเอกสาร  OP: เอกสารใหม่   CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม
            //List<string> DocSTCommitVal = new List<string> { "DL", "OP", "CF", "AC", "IC" };
            //if (!DocSTCommitVal.Contains(ORD_DOC_STCODE.ToUpper().Trim())){ return "ERR:ข้อมูลไม่ถูกต้อง!!"; }
            if (string.IsNullOrEmpty(HideVehID.Value) == true) { return "ERR:ข้อมูลรถยานพาหนะไม่ถูกต้อง!!"; }
            if (string.IsNullOrEmpty(HideGarageID.Value) == true) { return "ERR:ข้อมูลอู่ซ่อมไม่ถูกต้อง!!"; }
            //เตรียมข้อมูล
            string MNT_ORD_NO = TxtOrderNo.Text.Trim();
            string MNT_OWN_SITECODE = "";
            string MNT_OWN_SITE = "";
            //DateTime MNT_ORD_DATE = DateTime.ParseExact(TxtOrderDate.Text.Trim(), "dd/MM/yyyy", null);
            //DateTime MNT_ORD_DATEx = Convert.ToDateTime(TxtOrderDate.Text.Trim());
            DateTime MNT_ORD_DATE = DateTime.ParseExact(TxtOrderDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            // 
            //string STDate = TxtOrderDate.Text.Trim();
            //DateTime? oDate;
            //if (IsDateTime(STDate) == true)
            //{
            //    oDate = DateTime.ParseExact(STDate, "dd/MM/yyyy", null);
            //}
            //else { oDate = null; }

            int VEH_ASSET_ID = Convert.ToInt32(HideVehID.Value);
            int SERVICE_GARAGE_ID = Convert.ToInt32(HideGarageID.Value);
            string DRIVER_SIGN = "--";
            string SITE_EMP_SIGN = "--";
            string MNT_TYPE = "CR";
            if (RdoPM.Checked == true) { MNT_TYPE = "PM"; }
            //
            MaintainTbl = (DataTable)Session["MaintainTbl"];
            MaintainTblWheel = (DataTable)Session["MaintainTblWheel"];
            // รายการซ่อม
            string IDx = "";
            string TxtDescription = "";
            //
            if (GrdRepairDesc.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            break;
                        }
                    }
                }
            }
            MaintainTbl.AcceptChanges();
            Session["MaintainTbl"] = MaintainTbl;

            // รายการซ่อมยาง
            if (GrdWheelPos.Rows.Count > 0)
            {
                IDx = "";
                string RepairReason = "";
                bool DamageArea1 = false;
                bool DamageArea2 = false;
                bool DamageArea3 = false;
                bool DamageArea4 = false;
                string DamageAreaAno = "";
                //
                bool DamageType1 = false;
                bool DamageType2 = false;
                bool DamageType3 = false;
                bool DamageType4 = false;
                string DamageTypeAno = "";
                //
                string RSerial = "";
                string RMile = "";
                string WSize = "";
                //
                for (int IRow = 0; IRow < GrdWheelPos.Rows.Count; IRow++)
                {
                    IDx = GrdWheelPos.DataKeys[IRow].Value.ToString();
                    RepairReason = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWRepairReason")).Text.Trim();
                    DamageArea1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea1")).Checked;
                    DamageArea2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea2")).Checked;
                    DamageArea3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea3")).Checked;
                    DamageArea4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea4")).Checked;
                    DamageAreaAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageAreaOther")).Text.Trim();
                    //
                    DamageType1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType1")).Checked;
                    DamageType2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType2")).Checked;
                    DamageType3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType3")).Checked;
                    DamageType4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType4")).Checked;
                    DamageTypeAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageTypeAno")).Text.Trim();
                    //
                    RSerial = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtSN")).Text.Trim();
                    RMile = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtRubberMil")).Text.Trim();
                    WSize = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWhellSize")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTblWheel.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnRemark"] = RepairReason;
                            //
                            dr["DamageArea1"] = DamageArea1;
                            dr["DamageArea2"] = DamageArea2;
                            dr["DamageArea3"] = DamageArea3;
                            dr["DamageArea4"] = DamageArea4;
                            dr["DamageAreaAno"] = DamageAreaAno;
                            //
                            dr["DamageType1"] = DamageType1;
                            dr["DamageType2"] = DamageType2;
                            dr["DamageType3"] = DamageType3;
                            dr["DamageType4"] = DamageType4;
                            dr["DamageTypeAno"] = DamageTypeAno;
                            //
                            dr["Serial"] = RSerial;
                            dr["RMile"] = RMile;
                            dr["WhlSize"] = WSize;
                            //
                            break;
                        }
                    }
                }
            }
            MaintainTblWheel.AcceptChanges();
            Session["MaintainTblWheel"] = MaintainTblWheel;
            //
            // รายการความคิดเห็นช่าง
            MaintainTbl4= (DataTable)Session["MaintainTbl4"] ;
            MaintainTbl4.Clear();
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            if (GrdRepairDetail.Rows.Count > 0)
            {
                //IDx = "";
                TxtDescription = "";
                //
                for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
                {
                    //IDx = GrdRepairDetail.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).Text.Trim();

                    incGlobalDataPatternObj.AddDataToTableMaintainL2Collection(TxtDescription, MaintainTbl4);
                    MaintainTbl4.AcceptChanges();
                }
            }
            Session["MaintainTbl4"] = MaintainTbl4;
            //

            //------------------------------------------12-08-2023-Edit--------------------------------------------------


            //MaintainTbl7 = (DataTable)Session["MaintainTbl7"];
            //string DATE_NOTE = "";
            //string DESC_NOTE = "";
            //string MILEDGE_NOTE = "0.00";
            //string PRICE_NOTE = "0.00";
            //string SERVICER_NOTE = "---";
            //if (GrdVehDeptComment.Rows.Count > 0)
            //{
            //    for (int IRow = 0; IRow < GrdVehDeptComment.Rows.Count; IRow++)
            //    {
            //        IDx = GrdVehDeptComment.DataKeys[IRow].Value.ToString();
            //        DATE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDATE_NOTE")).Text.Trim();
            //        DESC_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtDESC_NOTE")).Text.Trim();
            //        MILEDGE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtMILEDGE_NOTE")).Text.Trim();
            //        PRICE_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtPRICE_NOTE")).Text.Trim();
            //        SERVICER_NOTE = ((TextBox)GrdVehDeptComment.Rows[IRow].FindControl("TxtSERVICER_NOTE")).Text.Trim();
            //        //
            //        foreach (DataRow dr in MaintainTbl7.Rows)
            //        {
            //            if (dr["IDx"].ToString() == IDx)
            //            {
            //                dr["DATE_NOTE"] = DATE_NOTE;
            //                dr["DESC_NOTE"] = DESC_NOTE;
            //                dr["MILEDGE_NOTE"] = MILEDGE_NOTE;
            //                dr["PRICE_NOTE"] = PRICE_NOTE;
            //                dr["SERVICER_NOTE"] = SERVICER_NOTE;
            //                break;
            //            }
            //        }
            //    }
            //}
            //MaintainTbl7.AcceptChanges();
            //Session["MaintainTbl7"] = MaintainTbl7;

            ////------------------------------------------12-08-2023-Edit--------------------------------------------------

            // Validate
            if (MaintainTbl.Rows.Count == 0) { return "ERR:ข้อมูลรายการขอซ่อมไม่ถูกต้อง!!"; }
            //
            //if (MaintainTblWheel.Rows.Count == 0) { return "ERR:ข้อมูลรถยานพาหนะไม่ถูกต้อง!!"; }
            //บันทึก
            //Pack as DataSet
            DataSet DSet = new DataSet();
            DSet.Tables.Add(MaintainTbl.Copy());
            DSet.Tables.Add(MaintainTblWheel.Copy());
            DSet.Tables.Add(MaintainTbl4.Copy());
            DSet.Tables.Add(MaintainTbl7.Copy());
            //DSet.Tables.Add(MaintainTbl2.Copy());
            //
            int USR_ID=0;
            string USR_FNAME = "";
            var master = Master as Site;
            if (master != null)
            {
                USR_ID = Convert.ToInt32(master.GetUserProfileData("USER_ID"));
                USR_FNAME= master.GetUserProfileData("USER_FNAME");
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                MNT_OWN_SITE = master.GetUserProfileData("SITE_NAME");
            }
            //--------------------------------
            string SITE_DRIVER_NAME = TxtDrvName.Text.Trim();
            string SITE_EMP_NAME = TxtSiteEmpName.Text.Trim();
            int VEH_AGE = 0;
            float VEH_MILEDGE = 0f;
            var stringNumberint = TxtVehAge.Text.Trim();
            bool isNumber = int.TryParse(stringNumberint, out VEH_AGE);

            var stringNumberFloat = TxtVehMiledge.Text.Trim();
            isNumber = float.TryParse(stringNumberFloat, out VEH_MILEDGE);

            //
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            string ProcRet = "ERR:";
            if (HideModeOperate.Value.ToString().ToUpper().Trim() == "CRT")
            {
                string ORD_DOC_STCODE = "OP";
                try
                {
                    ProcRet = IncJxTransactionServiceObj.SaveOrderRequest(MNT_ORD_NO, MNT_OWN_SITECODE, MNT_OWN_SITE, USR_ID, USR_FNAME,
                              MNT_ORD_DATE, VEH_ASSET_ID, SERVICE_GARAGE_ID, DRIVER_SIGN, SITE_EMP_SIGN, DSet, ORD_DOC_STCODE, SITE_DRIVER_NAME, SITE_EMP_NAME, VEH_AGE, VEH_MILEDGE, MNT_TYPE);
                }
                catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
            }
            else if(HideModeOperate.Value.ToString().ToUpper().Trim() == "EDT")
            {
                string MNT_ORD_RecordRefNo = HideRecRefNo.Value.ToString().Trim();  //
                try
                {
                    ProcRet = IncJxTransactionServiceObj.UpdateOrderRequest(MNT_ORD_NO, MNT_OWN_SITECODE, MNT_OWN_SITE, USR_ID, USR_FNAME,
                              MNT_ORD_DATE, VEH_ASSET_ID, SERVICE_GARAGE_ID, DRIVER_SIGN, SITE_EMP_SIGN, DSet, MNT_ORD_RecordRefNo, SITE_DRIVER_NAME, SITE_EMP_NAME, VEH_AGE, VEH_MILEDGE, MNT_TYPE);
                }
                catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
            }
            else
            { }
            //
            return ProcRet;
            //--------------------------------
        }
        private string SaveReqRepairOrderCF()
        {
            //Validate 
            //DL: ลบเอกสาร  OP: เอกสารใหม่   CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม
            //List<string> DocSTCommitVal = new List<string> { "DL", "OP", "CF", "AC", "IC" };
            //if (!DocSTCommitVal.Contains(ORD_DOC_STCODE.ToUpper().Trim())){ return "ERR:ข้อมูลไม่ถูกต้อง!!"; }
            if (string.IsNullOrEmpty(HideVehID.Value) == true) { return "ERR:ข้อมูลรถยานพาหนะไม่ถูกต้อง!!"; }
            if (string.IsNullOrEmpty(HideGarageID.Value) == true) { return "ERR:ข้อมูลอู่ซ่อมไม่ถูกต้อง!!"; }
            //เตรียมข้อมูล
            string MNT_ORD_NO = TxtOrderNo.Text.Trim();
            string MNT_OWN_SITECODE = "";
            string MNT_OWN_SITE = "";
            //DateTime MNT_ORD_DATE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //DateTime MNT_ORD_DATE = Convert.ToDateTime(TxtOrderDate.Text.Trim());
            DateTime MNT_ORD_DATE = DateTime.ParseExact(TxtOrderDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            int VEH_ASSET_ID = Convert.ToInt32(HideVehID.Value);
            int SERVICE_GARAGE_ID = Convert.ToInt32(HideGarageID.Value);
            string DRIVER_SIGN = "--";
            string SITE_EMP_SIGN = "--";
            int VEH_AGE = 0;
            float VEH_MILEDGE = 0f;
            var stringNumberint = TxtVehAge.Text.Trim();
            bool isNumber = int.TryParse(stringNumberint, out VEH_AGE);

            var stringNumberFloat = TxtVehMiledge.Text.Trim();
            isNumber = float.TryParse(stringNumberFloat, out VEH_MILEDGE);
            string MNT_TYPE = "CR";
            if (RdoPM.Checked == true) { MNT_TYPE = "PM"; }
            //
            MaintainTbl = (DataTable)Session["MaintainTbl"];
            MaintainTblWheel = (DataTable)Session["MaintainTblWheel"];
            //รายการซ่อม
            string IDx = "";
            string TxtDescription = "";
            //
            if (GrdRepairDesc.Rows.Count > 0)
            {
                for (int IRow = 0; IRow < GrdRepairDesc.Rows.Count; IRow++)
                {
                    IDx = GrdRepairDesc.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDesc.Rows[IRow].FindControl("TxtDescription")).Text.Trim();
                    //
                    foreach (DataRow dr in MaintainTbl.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnDesc"] = TxtDescription;
                            break;
                        }
                    }
                }
            }
            MaintainTbl.AcceptChanges();
            Session["MaintainTbl"] = MaintainTbl;

            //รายการซ่อมยาง
            if (GrdWheelPos.Rows.Count > 0)
            {
                IDx = "";
                string RepairReason = "";
                bool DamageArea1 = false;
                bool DamageArea2 = false;
                bool DamageArea3 = false;
                bool DamageArea4 = false;
                string DamageAreaAno = "";
                //
                bool DamageType1 = false;
                bool DamageType2 = false;
                bool DamageType3 = false;
                bool DamageType4 = false;
                string DamageTypeAno = "";
                //
                //
                string RSerial = "";
                string RMile = "";
                string WSize = "";

                for (int IRow = 0; IRow < GrdWheelPos.Rows.Count; IRow++)
                {
                    IDx = GrdWheelPos.DataKeys[IRow].Value.ToString();
                    RepairReason = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWRepairReason")).Text.Trim();
                    DamageArea1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea1")).Checked;
                    DamageArea2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea2")).Checked;
                    DamageArea3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea3")).Checked;
                    DamageArea4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageArea4")).Checked;
                    DamageAreaAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageAreaOther")).Text.Trim();
                    //
                    DamageType1 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType1")).Checked;
                    DamageType2 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType2")).Checked;
                    DamageType3 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType3")).Checked;
                    DamageType4 = ((CheckBox)GrdWheelPos.Rows[IRow].FindControl("ChkDamageType4")).Checked;
                    DamageTypeAno = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtDamageTypeAno")).Text.Trim();
                    //
                    //
                    RSerial = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtSN")).Text.Trim();
                    RMile = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtRubberMil")).Text.Trim();
                    WSize = ((TextBox)GrdWheelPos.Rows[IRow].FindControl("TxtWhellSize")).Text.Trim();
                    foreach (DataRow dr in MaintainTblWheel.Rows)
                    {
                        if (dr["IDx"].ToString() == IDx)
                        {
                            dr["MnRemark"] = RepairReason;
                            //
                            dr["DamageArea1"] = DamageArea1;
                            dr["DamageArea2"] = DamageArea2;
                            dr["DamageArea3"] = DamageArea3;
                            dr["DamageArea4"] = DamageArea4;
                            dr["DamageAreaAno"] = DamageAreaAno;
                            //
                            dr["DamageType1"] = DamageType1;
                            dr["DamageType2"] = DamageType2;
                            dr["DamageType3"] = DamageType3;
                            dr["DamageType4"] = DamageType4;
                            dr["DamageTypeAno"] = DamageTypeAno;
                            //
                            dr["Serial"] = RSerial;
                            dr["RMile"] = RMile;
                            dr["WhlSize"] = WSize;
                            //

                            break;
                        }
                    }
                }
            }
            //
            MaintainTblWheel.AcceptChanges();
            Session["MaintainTblWheel"] = MaintainTblWheel;
            //
            //รายการความคิดเห็นช่าง
            MaintainTbl4 = (DataTable)Session["MaintainTbl4"];
            MaintainTbl4.Clear();
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            if (GrdRepairDetail.Rows.Count > 0)
            {
                //IDx = "";
                TxtDescription = "";
                //
                for (int IRow = 0; IRow < GrdRepairDetail.Rows.Count; IRow++)
                {
                    //IDx = GrdRepairDetail.DataKeys[IRow].Value.ToString();
                    TxtDescription = ((TextBox)GrdRepairDetail.Rows[IRow].FindControl("TxtDescriptionDet")).Text.Trim();

                    incGlobalDataPatternObj.AddDataToTableMaintainL2Collection(TxtDescription, MaintainTbl4);
                    MaintainTbl4.AcceptChanges();
                }
            }
            Session["MaintainTbl4"] = MaintainTbl4;
            //
            //Validate
            if (MaintainTbl.Rows.Count == 0) { return "ERR:ข้อมูลรายการซ่อมไม่ถูกต้อง!!"; }
            //
            //if (MaintainTblWheel.Rows.Count == 0) { return "ERR:ข้อมูลรถยานพาหนะไม่ถูกต้อง!!"; }
            //บันทึก
            //Pack as DataSet
            DataSet DSet = new DataSet();
            DSet.Tables.Add(MaintainTbl.Copy());
            DSet.Tables.Add(MaintainTblWheel.Copy());
            DSet.Tables.Add(MaintainTbl4.Copy());
            //
            int USR_ID = 0;
            string USR_FNAME = "";
            var master = Master as Site;
            if (master != null)
            {
                USR_ID = Convert.ToInt32(master.GetUserProfileData("USER_ID"));
                USR_FNAME = master.GetUserProfileData("USER_FNAME");
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                MNT_OWN_SITE = master.GetUserProfileData("SITE_NAME");
            }
            //--------------------------------
            string SITE_DRIVER_NAME = TxtDrvName.Text.Trim();
            string SITE_EMP_NAME = TxtSiteEmpName.Text.Trim();
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            string ProcRet = "ERR:";
            //Document Confirm
            
            if (HideModeOperate.Value.ToString().ToUpper().Trim() == "CRT")
            {
                string ORD_DOC_STCODE = "CF";
                try
                {
                    ProcRet = IncJxTransactionServiceObj.SaveOrderRequest(MNT_ORD_NO, MNT_OWN_SITECODE, MNT_OWN_SITE, USR_ID, USR_FNAME,
                              MNT_ORD_DATE, VEH_ASSET_ID, SERVICE_GARAGE_ID, DRIVER_SIGN, SITE_EMP_SIGN, DSet, ORD_DOC_STCODE, SITE_DRIVER_NAME, SITE_EMP_NAME, VEH_AGE, VEH_MILEDGE, MNT_TYPE);
                }
                catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
            }
            else if (HideModeOperate.Value.ToString().ToUpper().Trim() == "EDT")
            {
                string ORD_RECNO = HideRecRefNo.Value.ToString();
                try
                {
                    ProcRet = IncJxTransactionServiceObj.UpdateOrderRequestCF(MNT_ORD_NO, MNT_OWN_SITECODE, MNT_OWN_SITE, USR_ID, USR_FNAME,
                              MNT_ORD_DATE, VEH_ASSET_ID, SERVICE_GARAGE_ID, DRIVER_SIGN, SITE_EMP_SIGN, DSet, ORD_RECNO, SITE_DRIVER_NAME, SITE_EMP_NAME, VEH_AGE, VEH_MILEDGE, MNT_TYPE);
                }
                catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
            }
            else
            {
                //
            }
            //
            return ProcRet;
            //--------------------------------
        }
        protected void CmdReqApproveOrd_Click(object sender, EventArgs e)
        {
            //
            string Operate_Result = "";
            //add new mode
            if (HideModeOperate.Value.ToString().ToUpper().Trim() == "CRT")
            {
                //Confirm เอกสาร
                Operate_Result = SaveReqRepairOrderCF();

                if (Operate_Result.ToUpper().Substring(0, 2) == "TR")
                {
                    //HideModeOperate.Value = "EDT";
                    Response.Write("<script>alert('บันทึก: ส่งขออนุมัติเรียบร้อย!!');</script>");
                    MultiView1.ActiveViewIndex = 7;
                }
                else
                {
                    Response.Write("<script>alert('บันทึก: " + Operate_Result.Replace("ERR:", "") + "');</script>");
                }
            }
            else if (HideModeOperate.Value.ToString().ToUpper().Trim() == "EDT")
            {
                string MNT_ORD_RecordRefNo = HideRecRefNo.Value.ToString().Trim();  //
                try
                {
                    Operate_Result = SaveReqRepairOrderCF();
                    if (Operate_Result.ToUpper().Substring(0, 2) == "TR")
                    {
                        //HideModeOperate.Value = "EDT";
                        Response.Write("<script>alert('บันทึก: ส่งขออนุมัติเรียบร้อย!!');</script>");
                        MultiView1.ActiveViewIndex = 7;
                    }
                    else
                    {
                        Response.Write("<script>alert('บันทึก: " + Operate_Result.Replace("ERR:", "") + "');</script>");
                    }
                }
                catch (Exception ex) { Operate_Result = "ERR:" + ex.Message; }
            }
            else
            {
               
            }
            //
            SetSumarizeCounter();
        }
        protected void CmdAct1_Click(object sender, EventArgs e) //เอกสารใหม่
        {
            SetSumarizeCounter();
            //
            
            string MNT_OWN_SITECODE = "";
            string MNT_OWN_SITENAME = "";
            var master = Master as Site;
            if (master != null)
            {
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                MNT_OWN_SITENAME = master.GetUserProfileData("SITE_NAME");
            }
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Act1(MNT_OWN_SITECODE);
                Session["OrderCollectionTbl"]= DSetAsset.Tables["TB_RORDER_COLLECTION"];  //เก็บไว้กรอง
                System.Diagnostics.Debug.WriteLine(Session["OrderCollectionTbl"]);
                var withBlock = GrdRepairOrderAct0;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();

                //ADD 24012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtn0.Enabled = false;
                }
                else { imgBtn0.Enabled = true; }
                //END 24012023


            }
            catch { }
            //LblSite1.Text = " ----- " + MNT_OWN_SITECODE  + "-" + MNT_OWN_SITENAME.ToUpper();
            MultiView1.ActiveViewIndex = 0;
            TxtOrderDate.ReadOnly = false;
        }
        protected void CmdOpenVehCollection_Click(object sender, EventArgs e)
        {

        } 
        protected void CmdAct5_Click1(object sender, EventArgs e)
        {

        }
        protected void CmdAct7_Click(object sender, EventArgs e)
        {
            var master = Master as Site;
            string UserOperate = "";
            if (master != null)
            {
                UserOperate = master.GetUserProfileData("USER_FNAME");
                TxtSiteEmpName.Text = UserOperate;
            }
            else
            {
                TxtSiteEmpName.Text = "-";
            }           
            //
            GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
            MaintainTbl = incGlobalDataPatternObj.CreateDataTableMaintainCollection();
            incGlobalDataPatternObj.AddDataToTableMaintainCollection("--", MaintainTbl);
            //incGlobalDataPatternObj.AddDataToTableMaintainCollection("Description 2", MaintainTbl);
            //incGlobalDataPatternObj.AddDataToTableMaintainCollection("Description 3", MaintainTbl);
            Session["MaintainTbl"] = MaintainTbl;
            //
            MaintainTbl4 = incGlobalDataPatternObj.CreateDataTableMaintainL2Collection();
            incGlobalDataPatternObj.AddDataToTableMaintainL2Collection("--", MaintainTbl4);
            MaintainTbl4.AcceptChanges();
            MaintainTbl4.TableName = "TBL_M4_COLLECTION";
            Session["MaintainTbl4"] = MaintainTbl4;
            //
            //------------------------08-12-2023-------------------------------------------------------
           

            incGlobalDataPatternObj.AddDataToTableMaintainCommentCollection("--", "--", "--", "--", "--", MaintainTbl7);
            MaintainTbl7.AcceptChanges();

            Session["MaintainTbl7"] = MaintainTbl7;

            //------------------------08-12-2023-------------------------------------------------------
            TxtOrderDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TxtOrderNo.Text = GetRepairOrderNo();
            MaintainTblWheel = incGlobalDataPatternObj.CreateDataTableMaintainWheelCollection();
            //incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("W1", "-", false, false, false, false, false, false, false, false, "", "", MaintainTblWheel);
            //incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection("W2", "-", false, false, false, false, false, false, false, false, "", "", MaintainTblWheel);
            Session["MaintainTblWheel"] = MaintainTblWheel;
            //
            MaintainTblImage = incGlobalDataPatternObj.CreateDataTableMaintainImageCollection();
            Session["MaintainTblImage"] = MaintainTblImage;
            //
            var withBlockImg = GrdOrderImage;
            withBlockImg.DataSource = MaintainTblImage;
            withBlockImg.DataBind();
            withBlockImg.AutoGenerateColumns = false;
            //
            var withBlock = GrdRepairDesc;
            withBlock.DataSource = MaintainTbl;
            withBlock.DataBind();
            withBlock.AutoGenerateColumns = false;
            //
            var withBlockx = GrdWheelPos;
            withBlockx.DataSource = MaintainTblWheel;
            withBlockx.DataBind();
            withBlockx.AutoGenerateColumns = false;
            //
            var withBlock4 = GrdRepairDetail;
            withBlock4.DataSource = MaintainTbl4;
            withBlock4.DataBind();
            withBlock4.AutoGenerateColumns = false;
            //
            //
            var withBlock7 = gridviewComment;
            withBlock7.DataSource = MaintainTbl7;
            withBlock7.DataBind();
            withBlock7.AutoGenerateColumns = false;
            //
            SetComponantInitialState();
            SetDocumentEditableMode();
            CommandControl(false, false, true, true);
            HideModeOperate.Value = "CRT";
            MultiView1.ActiveViewIndex = 5;
            TxtOrderDate.ReadOnly = false;
        }
        private void SetComponantInitialState()
        {
            TxtVehCode.Text = "";
            TxtVehLicense.Text = "";
            TxtVehBrand.Text = "";
            TxtVehModel.Text = "";
            HideVehID.Value = null;
            HideGarageID.Value = null;
            HideRecRefNo.Value = null;
            TxtVehMiledge.Text = "";
            TxtVehType.Text = "";
            TxtVehAge.Text = "";
            TxtVehFuel.Text = "";
            TxtGarageName.Text = "";
            TxtGarageAddr.Text = "";
            TxtGarageContact.Text = "";
            TxtDrvName.Text = "";
            //TxtSiteEmpName.Text = "";
        }
        protected void CmdAct2_Click(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            //
            string MNT_OWN_SITECODE = "";
            string MNT_OWN_SITENAME = "";
            var master = Master as Site;
            if (master != null)
            {
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                MNT_OWN_SITENAME = master.GetUserProfileData("SITE_NAME");
            }

            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Act2(MNT_OWN_SITECODE);
                Session["OrderCollectionTbl"] = DSetAsset.Tables["TB_RORDER_COLLECTION"];  //เก็บไว้กรอง
                var withBlock = GrdRepairOrderAct1;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();
                //ADD 24012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtn1.Enabled = false;
                }
                else { imgBtn1.Enabled = true; }
                //END 24012023
            }
            catch { }
            //ModeOperate=CRT | EDT
            HideModeOperate.Value = "CRT";
            //LblSite2.Text = "  ----- " + MNT_OWN_SITECODE + "-" + MNT_OWN_SITENAME.ToUpper();
            MultiView1.ActiveViewIndex = 1;
            TxtOrderDate.ReadOnly = true;
        }
        protected void CmdAct3_Click(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            //
            string MNT_OWN_SITECODE = "";
            string MNT_OWN_SITENAME = "";
            var master = Master as Site;
            if (master != null)
            {
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                MNT_OWN_SITENAME = master.GetUserProfileData("SITE_NAME");
            }
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Act3(MNT_OWN_SITECODE);
                var withBlock = GrdRepairOrderAct2;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();
                //ADD 24012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtn2.Enabled = false;
                }
                else { imgBtn2.Enabled = true; }
                //END 24012023
            }
            catch { }

            //LblSite3.Text = "  ----- " + MNT_OWN_SITECODE + "-" + MNT_OWN_SITENAME.ToUpper();
            MultiView1.ActiveViewIndex = 2;
            TxtOrderDate.ReadOnly = true;
        }
        protected void CmdAct4_Click(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            //
            string MNT_OWN_SITECODE = "";
            var master = Master as Site;
            if (master != null)
            {
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
            }
            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Act4(MNT_OWN_SITECODE);
                var withBlock = GrdRepairOrderAct3;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();

                //ADD 24012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtn3.Enabled = false;
                }
                else { imgBtn3.Enabled = true; }
                //END 24012023
            }
            catch { }
            MultiView1.ActiveViewIndex = 3;
            TxtOrderDate.ReadOnly = true;
        }
        protected void CmdAct5_Click2(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            //
            string MNT_OWN_SITECODE = "";
            var master = Master as Site;
            if (master != null)
            {
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
            }

            //
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Act5(MNT_OWN_SITECODE);
                var withBlock = GrdRepairOrderAct4;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();

                //ADD 24012023
                var grdCount = withBlock.Rows.Count.ToString();
                if (grdCount == "0")
                {
                    imgBtn4.Enabled = false;
                }
                else { imgBtn4.Enabled = true; }
                //END 24012023
            }
            catch { }
            MultiView1.ActiveViewIndex = 4;
            TxtOrderDate.ReadOnly = true;
        }
        protected void CmdAct6_Click(object sender, EventArgs e)
        {
            SetSumarizeCounter();
            imgBtn6.Enabled = false;
            MultiView1.ActiveViewIndex = 6;
            TxtOrderDate.ReadOnly = true;
        }
        protected void CmdSearchRQ_Click(object sender, EventArgs e)
        {

            string SDate = TxtSDate.Text;
            string EDate = TxtEDate.Text;
            if (SDate == "" || EDate == ""){return;}
            //
            string MNT_OWN_SITECODE = "";
            var master = Master as Site;
            if (master != null)
            {
                MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
            }
            

            DateTime StartDate = DateTime.ParseExact(SDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime EndDate = DateTime.ParseExact(EDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //
            if (StartDate > EndDate) { return;}
            string StrVLicense = TxtLicense.Text;
            DataSet DSetAsset;
            JxMasterService incJxMasterServiceObj = new JxMasterService();
            //string KeySearch = TxtVehKeySearch.Text.Trim();
            try
            {
                DSetAsset = incJxMasterServiceObj.GetRepairOrderCollection_Act6(MNT_OWN_SITECODE, StartDate, EndDate,StrVLicense);
                var withBlock = GrdRepairOrderAct6;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = DSetAsset.Tables["TB_RORDER_COLLECTION"];
                withBlock.DataBind();

                if ( withBlock.Rows.Count == 0)
                {
                    imgBtn6.Enabled = false;
                }
                else
                {
                    imgBtn6.Enabled = true;
                }
            }
            catch { }

        }
        private void SetSumarizeCounter()
        {
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            DataSet CountDSet;
            try
            {
                var master = Master as Site;
                string MNT_OWN_SITECODE = "";
                if (master != null)
                {
                    MNT_OWN_SITECODE = master.GetUserProfileData("SITE_CODE");
                }
                //ดึงข้อมูลจาก Database Server
                CountDSet = IncJxTransactionServiceObj.GetOrderCollection_CounterSite(MNT_OWN_SITECODE);
                int FileFolder1 = 0;
                int FileFolder2 = 0;
                int FileFolder3 = 0;
                int FileFolder4 = 0;
                int FileFolder5 = 0;
                foreach (DataRow DRow in CountDSet.Tables["TB_ORDER_COUNTER"].Rows)
                {
                    FileFolder1 = Convert.ToInt32(DRow["FolderFile1Amt"]);
                    FileFolder2 = Convert.ToInt32(DRow["FolderFile2Amt"]);
                    FileFolder3 = Convert.ToInt32(DRow["FolderFile3Amt"]);
                    FileFolder4 = Convert.ToInt32(DRow["FolderFile4Amt"]);
                    FileFolder5 = Convert.ToInt32(DRow["FolderFile5Amt"]);
                }
                LblAct1Amt.Text = FileFolder1.ToString();
                LblAct2Amt.Text = FileFolder2.ToString();
                LblAct3Amt.Text = FileFolder3.ToString();
                LblAct4Amt.Text = FileFolder4.ToString();
                LblAct5Amt.Text = FileFolder5.ToString();
            }
            catch
            {
                LblAct1Amt.Text = "-";
                LblAct2Amt.Text = "-";
                LblAct3Amt.Text = "-";
                LblAct4Amt.Text = "-";
                LblAct5Amt.Text = "-";
            }

        }
        private void ImprementOrderData(string OrderNo)
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
            string SITE_DRIVER_NAME = "";
            string SITE_EMP_NAME = "";
            string ORD_MTN_HEADER_REM = "";
            int VEH_AGE=0;
            float ORD_VEH_MILEDGE=0f;
            string MNT_TYPE = "";
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderDSet = IncJxMasterServiceObj.GetOrderObjInfo(OrderNo,0);
             
                //
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER"].Rows)
                {
                    REC_REF_NO = DRow["REC_REF_NO"].ToString();
                    OrderDate = Convert.ToDateTime(DRow["MNT_ORD_DATE"]).ToString("dd/MM/yyyy");
                    VEH_ASSET_ID= Convert.ToInt32(DRow["VEH_ASSET_ID"]);
                    VEH_CODE = DRow["VEH_CODE"].ToString();
                    VEH_LICENSE = DRow["VEH_LICENSE"].ToString();
                    //VEH_TYPE = DRow["VEH_ASSET_ID"].ToString();
                    VEH_TYPE = DRow["VEH_TYPE"].ToString();
                    VEH_BRAND = DRow["VEH_BRAND"].ToString();
                    VEH_MODEL = DRow["VEH_MODEL"].ToString();
                    VEH_FUEL_SPEC = DRow["VEH_FUEL_SPEC"].ToString();
                    //
                    SERVICE_GARAGE_ID = Convert.ToInt32(DRow["SERVICE_GARAGE_ID"]);
                    GARAGE_NAME=DRow["GARAGE_NAME"].ToString();
                    GARAGE_ADDR = DRow["GARAGE_ADDR"].ToString();
                    GARAGE_CONTACT = DRow["GARAGE_CONTACT"].ToString();
                    GARAGE_TEL = DRow["GARAGE_TEL"].ToString();
                    //
                    SITE_DRIVER_NAME = DRow["SITE_DRIVER_NAME"].ToString();
                    SITE_EMP_NAME = DRow["SITE_EMP_NAME"].ToString();
                    ORD_MTN_HEADER_REM= DRow["ORD_MTN_HEADER_REM"].ToString();
                    VEH_AGE = Convert.ToInt32(DRow["VEH_AGE"]);
                    ORD_VEH_MILEDGE = float.Parse(DRow["ORD_VEH_MILEDGE"].ToString());
                    MNT_TYPE = DRow["MNT_TYPE"].ToString();
                }
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
                //
                TxtDrvName.Text = SITE_DRIVER_NAME;
                TxtSiteEmpName.Text = SITE_EMP_NAME;
                TxtMNHeadRem.Text = ORD_MTN_HEADER_REM;
                //
                TxtVehMiledge.Text = ORD_VEH_MILEDGE.ToString("#,##0.00");
                TxtVehAge.Text = VEH_AGE.ToString("#,##0");
                //
                if (MNT_TYPE.ToUpper().Trim() == "PM") 
                { RdoPM.Checked = true; RdoCR.Checked = false; } 
                else { RdoPM.Checked = false; RdoCR.Checked = true; }
                //
                GlobalDataPattern incGlobalDataPatternObj = new GlobalDataPattern();
                MaintainTbl = incGlobalDataPatternObj.CreateDataTableMaintainCollection();
                MaintainTblWheel = incGlobalDataPatternObj.CreateDataTableMaintainWheelCollection();
                MaintainTbl7 = incGlobalDataPatternObj.CreateDataTableMaintainCommentCollection();

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
                MaintainTbl4 = incGlobalDataPatternObj.CreateDataTableMaintainL2Collection();
                MaintainTbl4.TableName = "TBL_M4_COLLECTION";
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC2"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainL2Collection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTbl4);
                }
                MaintainTbl4.AcceptChanges();
                Session["MaintainTbl4"] = MaintainTbl4;
                var withBlock4 = GrdRepairDetail;
                withBlock4.DataSource = Session["MaintainTbl4"];
                withBlock4.DataBind();
                withBlock4.AutoGenerateColumns = false;
                ////----------------------------------------NEW--------------------------------------------------------
                //MainHistory = OrderDSet.Tables["TB_HISTRY"];

                //var withBlock6 = GridView1;
                //withBlock6.DataSource = MainHistory;
                //withBlock6.DataBind();
                //withBlock6.AutoGenerateColumns = false;

               
                ////----------------------------------------NEW--------------------------------------------------------

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
                    MNT_WHL_POS= DRow["MNT_WHL_POS"].ToString();
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
                    incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection(MNT_WHL_POS, MNT_REQ_REASON, WHL_DAMAGE_AREA1, WHL_DAMAGE_AREA2, WHL_DAMAGE_AREA3, WHL_DAMAGE_AREA4,
                                                                      WHL_DAMAGE_TYPE1, WHL_DAMAGE_TYPE2, WHL_DAMAGE_TYPE3, WHL_DAMAGE_TYPE4, WHL_DAMAGE_OTH, WHL_DAMAGE_TYPEOTH, WHL_SERIAL, WHL_R_MILE, WHL_SIZE, MaintainTblWheel);
                }
                Session["MaintainTblWheel"] = MaintainTblWheel;
                var withBlockx = GrdWheelPos;
                withBlockx.DataSource = MaintainTblWheel;
                withBlockx.DataBind();
                withBlockx.AutoGenerateColumns = false;

                

                //
                //
                //ModeOperate=CRT | EDT
                HideModeOperate.Value = "EDT";
                MultiView1.ActiveViewIndex = 5;

            }
            catch 
            {
                MultiView1.ActiveViewIndex = 7;
            }   
        }
        private void ImprementOrderImage(string OrderNo)
        {
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
                    incGlobalDataPatternObj.AddDataToTableMaintainImageCollection(Convert.ToInt32(DRow["RecID"]), DRow["Image_File"].ToString(),DRow["Image_FileActual"].ToString(), DRow["Image_Note"].ToString(), Path + DRow["Image_FileActual"].ToString(), MaintainTblImage);
                }
                //Session["MaintainTblImage"] = MaintainTblImage;
                //
                var withBlock = GrdOrderImage;
                withBlock.DataSource = MaintainTblImage;
                withBlock.DataBind();
                withBlock.AutoGenerateColumns = false;
                //
               
            }
            catch(Exception ex)
            {
                //
            }
        }
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
        //----------------------------NEW---------------------------------------------


        protected void GrdRepairOrderAct0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct0.DataKeys[GrdRepairOrderAct0.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct0.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct0.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            
            
            //T1.Text = OrderNo;
            TxtMNHeadRem.Visible = false;
            //ImprementOrderData(OrderNo);
            ImprementOrderData2(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentEditableMode();
            CommandControl(false, true, true, true);
        }
        protected void GrdRepairOrderAct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct1.DataKeys[GrdRepairOrderAct1.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct1.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct1.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo
            TxtMNHeadRem.Visible = false;
            //ImprementOrderData(OrderNo);
            ImprementOrderData2(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(true,false,false,false);
        }
        protected void GrdRepairOrderAct2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct2.DataKeys[GrdRepairOrderAct2.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct2.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct2.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            TxtMNHeadRem.Visible = true;
            //ImprementOrderData(OrderNo);
            ImprementOrderData2(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(true, false, false, false);
        }
        protected void GrdRepairOrderAct3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct3.DataKeys[GrdRepairOrderAct3.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct3.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct3.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            TxtMNHeadRem.Visible = true;
            //ImprementOrderData(OrderNo);
            ImprementOrderData2(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(false, false, false, false);
        }
        protected void GrdRepairOrderAct4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct4.DataKeys[GrdRepairOrderAct4.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct4.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct4.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            TxtMNHeadRem.Visible = true;
            //ImprementOrderData(OrderNo);
            ImprementOrderData2(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(false, false, false, false);
        }
        protected void CmdDeleteDoc_Click(object sender, EventArgs e)
        {
            string ProcRet = "ERR:";
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            try
            {
                string MNT_ORD_NO = TxtOrderNo.Text.Trim();
                string OrderRecReferenceNo = HideRecRefNo.Value.ToString();
                string USR_FNAME = "";
                var master = Master as Site;
                if (master != null)
                {
                    USR_FNAME = master.GetUserProfileData("USER_FNAME");
                }
                ProcRet = IncJxTransactionServiceObj.DeleteOrderRequest(MNT_ORD_NO, USR_FNAME, OrderRecReferenceNo);
                if (ProcRet.ToUpper().Substring(0, 2) == "TR")
                {
                    Response.Write("<script>alert('ลบ: เรียบร้อย!!');</script>");
                    SetSumarizeCounter();
                    MultiView1.ActiveViewIndex = 7;
                }
                else
                {
                    Response.Write("<script>alert('ลบ: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Err.Description: " + ex.Message + "');</script>");
                MultiView1.ActiveViewIndex = 7;
            }
        }
        protected void CmdRollBackDoc_Click(object sender, EventArgs e)
        {
            string ProcRet = "ERR:";
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            try
            {
                string MNT_ORD_NO = TxtOrderNo.Text.Trim();
                string OrderRecReferenceNo = HideRecRefNo.Value.ToString();
                string USR_FNAME = "";
                var master = Master as Site;
                if (master != null)
                {
                    USR_FNAME = master.GetUserProfileData("USER_FNAME");
                }
                ProcRet = IncJxTransactionServiceObj.RollBackOrderRequest(MNT_ORD_NO, USR_FNAME, OrderRecReferenceNo);
                if (ProcRet.ToUpper().Substring(0, 2) == "TR")
                {
                    Response.Write("<script>alert('ดึงเอกสารกลับ: เรียบร้อย!!');</script>");
                    SetSumarizeCounter();
                    MultiView1.ActiveViewIndex = 7;

                }
                else
                {
                    Response.Write("<script>alert('ดึงเอกสารกลับ: " + ProcRet.Replace("ERR:", "") + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Err.Description: " + ex.Message + "');</script>");
                MultiView1.ActiveViewIndex = 7;
            }
        }
        protected void GrdRepairOrderAct6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = GrdRepairOrderAct6.DataKeys[GrdRepairOrderAct6.SelectedRow.RowIndex]["MNT_ORD_NO"].ToString();
            GridViewRow RowGet = GrdRepairOrderAct6.SelectedRow;
            int VEH_ASSET_ID = Convert.ToInt32(GrdRepairOrderAct6.SelectedRow.Cells[GetColumnIndexByName(RowGet, "VEH_ASSET_ID")].Text);
            //T2.Text = OrderNo;
            TxtMNHeadRem.Visible = true;
            //ImprementOrderData(OrderNo);
            ImprementOrderData2(OrderNo, VEH_ASSET_ID);
            ImprementOrderImage(OrderNo);
            SetDocumentViewOnlyMode();
            CommandControl(false, false, false, false);
        }
        private readonly Random _random = new Random();
        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        private string PrefixfileNameEttension()
        {
            string PrefixfileName = "";
            string PatternDay=DateTime.Now.ToString("yyyyMMddHHmmss");
            string PatternRandom=RandomNumber(10000, 99999).ToString();
            PrefixfileName = PatternRandom + "-" + PatternDay + "-";
            return PrefixfileName;
        }
        protected void CmdUpLoad_Click(object sender, EventArgs e)
        {
            //if (Path.GetFileName(FileSelector.FileName) == "") { return; }
            // //บันทึกรูปลง FTP
            // string ftp = "ftp://192.168.2.105:2121/";
            // string ftpFolder = "JxFileAsset/TPTruckDrv/Mnt_Image/";
            // byte[] fileBytes = null;
            // string fileName = Path.GetFileName(FileSelector.FileName);
            // using (StreamReader sr = new StreamReader(FileSelector.PostedFile.InputStream))
            // {
            //     using (MemoryStream ms = new MemoryStream())
            //     {
            //         sr.BaseStream.CopyTo(ms);
            //         fileBytes = ms.ToArray();
            //     }
            // }
            // try
            // {
            //     string filename_new = PrefixfileNameEttension() + fileName;
            //     //FTP Request.
            //     //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
            //     FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + filename_new);
            //     request.Method = WebRequestMethods.Ftp.UploadFile;

            //     //FTP Server credentials.
            //     request.Credentials = new NetworkCredential("Administrator", "p@ssw0rdTP");
            //     request.ContentLength = fileBytes.Length;
            //     request.UsePassive = true;
            //     request.UseBinary = true;
            //     request.ServicePoint.ConnectionLimit = fileBytes.Length;
            //     request.EnableSsl = false;
            //     //
            //     using (Stream requestStream = request.GetRequestStream())
            //     {
            //         requestStream.Write(fileBytes, 0, fileBytes.Length);
            //         requestStream.Close();
            //     }
            //     //
            //     FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //     lblMessage.Text = "";
            //     lblMessage.Text += fileName + "บันทึกไฟล์เข้า FTP เรียบร้อย.<br />";
            //     response.Close();
            //     //บันทึกลงฐานข้อมูล
            //     string MNT_ORD_NO = TxtOrderNo.Text.Trim();
            //     string Image_File = fileName;
            //     string Image_Note = TxtImageNote.Text.Trim();
            //     JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            //     string ProcRet = "ERR:";
            //     try
            //     {
            //         ProcRet = IncJxTransactionServiceObj.SaveOrderImageDetail(MNT_ORD_NO, Image_File, filename_new, Image_Note);
            //     }
            //     catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
            //     lblMessage.Text += fileName + "ลงทะเบียนไฟล์เข้า Ms SQL เรียบร้อย.<br />";
            //     //Imprement Data
            //     ImprementOrderImage(MNT_ORD_NO);

            // }
            // catch (WebException ex)
            // {
            //     throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            // }
            
            if (FileSelector.HasFile)
            {
                try
                {
                    string MNT_ORD_NO = TxtOrderNo.Text.Trim();
                    //string Path = Server.MapPath("~/App_Images/ImagesUpL/"); 
                    string Path = Server.MapPath("~/Upload/").ToString(); 
                    string ActualfileName = FileSelector.PostedFile.FileName;
                    string extension = System.IO.Path.GetExtension(FileSelector.PostedFile.FileName);
                    string guidFileName = System.Guid.NewGuid().ToString("N");
                    string FilePrefix = DateTime.Now.ToString("yyyyMM-");
                    //N: cd26ccf675d64521884f1693c62ed303
                    //D: cd26ccf6 - 75d6 - 4521 - 884f - 1693c62ed303
                    //B: { cd26ccf6 - 75d6 - 4521 - 884f - 1693c62ed303}
                    //P: (cd26ccf6 - 75d6 - 4521 - 884f - 1693c62ed303)
                    //X: { 0xcd26ccf6,0x75d6,0x4521,{ 0x88,0x4f,0x16,0x93,0xc6,0x2e,0xd3,0x03} }
                    FileSelector.SaveAs(Path + FilePrefix+ MNT_ORD_NO + guidFileName + extension);
                    lblMessage.Text = "Upload Status: Successful" + "["+ guidFileName + extension + "]";
                    //
                    //บันทึกลงฐานข้อมูล
                    string Image_File = ActualfileName;
                    string Image_Note = TxtImageNote.Text.Trim();
                    JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
                    string ProcRet = "ERR:";
                    try
                    {
                        ProcRet = IncJxTransactionServiceObj.SaveOrderImageDetail(MNT_ORD_NO, Image_File, FilePrefix + MNT_ORD_NO + guidFileName + extension, Image_Note);
                    }
                    catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
                    lblMessage.Text = Image_File + "ลงทะเบียนไฟล์เข้า Server เรียบร้อย.<br />";
                    //Clear Selection
                    TxtImageNote.Text = "";
                    //Imprement Data
                    ImprementOrderImage(MNT_ORD_NO);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Upload Status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
        protected void CmdPrint_Click(object sender, EventArgs e)
        {
            Session["PRINT_VEHID"] = HideVehID.Value.ToString();
            Session["PRINT_DOCNO"] = TxtOrderNo.Text.Trim();
            Session["PRINT_TYPE"] = "1";
            Server.Transfer("PrintTool.aspx");
        }
        protected void GrdOrderImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MNT_ORD_NO = TxtOrderNo.Text.Trim();
            string IDx_Del = GrdOrderImage.DataKeys[GrdOrderImage.SelectedRow.RowIndex]["Image_ILx"].ToString();
            //
            JxTransactionService IncJxTransactionServiceObj = new JxTransactionService();
            string ProcRet = "ERR:";
            try
            {
                ProcRet = IncJxTransactionServiceObj.DeleteOrderImageReccord(MNT_ORD_NO,Convert.ToInt32(IDx_Del));
                //
                if (ProcRet.Trim().ToUpper().Substring(0, 3).ToUpper() == "TRU")
                {
                    lblMessage.Text ="";
                    //Clear Selection
                    TxtImageNote.Text = "";
                    //Imprement Data
                    ImprementOrderImage(MNT_ORD_NO);
                }
                else
                {

                }
            }
            catch (Exception ex) { ProcRet = "ERR:" + ex.Message; }
        }
        protected void imgOrderDate3_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void CmdHistry_Click(object sender, EventArgs e)
        {

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
                incGlobalDataPatternObj.AddDataToTableMaintainL2Collection("--", MaintainTbl4);
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
        protected void ImbS1_Click(object sender, ImageClickEventArgs e)
        {        
            try
                {
                    TxtKeyS1.Text = TxtKeyS1.Text.Replace("%", "");
                    string strFilter = "";
                    //
                    strFilter = "MNT_ORD_NO  like '%" + TxtKeyS1.Text + "%' OR " +
                                "VEH_CODE    like '%" + TxtKeyS1.Text + "%' OR " +
                                "REQ_INFO    like '%" + TxtKeyS1.Text + "%' OR " +
                                "VEH_LICENSE like '%" + TxtKeyS1.Text + "%' ";
                //
                //MaintainTbl4 = (DataTable)Session["MaintainTbl4"];
                //MaintainTbl4.Clear();

                DataTable DtableSource = (DataTable)Session["OrderCollectionTbl"];
                    DataTable DTablex = DtableSource.Select(strFilter).CopyToDataTable();

                    var withBlock = GrdRepairOrderAct0;
                    withBlock.AutoGenerateColumns = false;
                     withBlock.DataSource =  DTablex;
                    withBlock.DataBind();

                }
                catch 
                {
                var withBlock = GrdRepairOrderAct0;
                withBlock.AutoGenerateColumns = false;
                withBlock.DataSource = null;
                withBlock.DataBind();
            }
        }
        protected void ImbS2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                TxtKeyS2.Text = TxtKeyS2.Text.Replace("%", "");
                string strFilter = "";
                //
                strFilter = "MNT_ORD_NO  like '%" + TxtKeyS2.Text + "%' OR " +
                            "VEH_CODE    like '%" + TxtKeyS2.Text + "%' OR " +
                            "REQ_INFO    like '%" + TxtKeyS2.Text + "%' OR " +
                            "VEH_LICENSE like '%" + TxtKeyS2.Text + "%' ";
                //
                DataTable DtableSource = (DataTable)Session["OrderCollectionTbl"];
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

        protected void TxtOrderDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GrdPartOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void TxtDescriptionDet0_TextChanged(object sender, EventArgs e)
        {

        }

        //Export Grid To Excel Start
        protected void imgBtn0_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct0";
            var strState = "แจ้งซ่อม_เอกสารใหม่";
            ExportGridToExcel(strGrdId, strState);
        }
        protected void imgBtn1_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct1";
            var strState = "แจ้งซ่อม_เอกสารรอพิจารณาอนุมัติ";
            ExportGridToExcel(strGrdId, strState);
        }
        protected void imgBtn2_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct2";
            var strState = "แจ้งซ่อม_รายการขอรายละเอียดเพิ่มเติม";
            ExportGridToExcel(strGrdId, strState);
        }
        protected void imgBtn3_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct3";
            var strState = "แจ้งซ่อม_รายการไม่อนุมัติซ่อม";
            ExportGridToExcel(strGrdId, strState);
        }
        protected void imgBtn4_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct4";
            var strState = "แจ้งซ่อม_รายการอยู่ระหว่างซ่อม";
            ExportGridToExcel(strGrdId, strState);
        }
        protected void imgBtn6_Click(object sender, ImageClickEventArgs e)
        {
            var strGrdId = "GrdRepairOrderAct6";
            var strState = "แจ้งซ่อม_รายการปิดงานซ่อมแล้ว";
            ExportGridToExcel(strGrdId, strState);
        }

        private void ExportGridToExcel(string GrdId, string StateJ)
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
                    case "GrdRepairOrderAct0":
                        GrdRepairOrderAct0.RenderControl(htw);
                        break;
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

        protected void gridviewHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ImprementOrderData2(string OrderNo,int Grid_VA_ID)
        {
            JxMasterService IncJxMasterServiceObj = new JxMasterService();
            DataSet OrderDSet;
            string REC_REF_NO = "";
            string OrderDate = "";
            int VEH_ASSET_ID = Grid_VA_ID;
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
            string SITE_DRIVER_NAME = "";
            string SITE_EMP_NAME = "";
            string ORD_MTN_HEADER_REM = "";
            int VEH_AGE = 0;
            float ORD_VEH_MILEDGE = 0f;
            string MNT_TYPE = "";
            try
            {
                //ดึงข้อมูลจาก Database Server
                OrderDSet = IncJxMasterServiceObj.GetOrderObjInfo(OrderNo, VEH_ASSET_ID);

                //
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER"].Rows)
                {
                    REC_REF_NO = DRow["REC_REF_NO"].ToString();
                    OrderDate = Convert.ToDateTime(DRow["MNT_ORD_DATE"]).ToString("dd/MM/yyyy");
                    VEH_ASSET_ID = Convert.ToInt32(DRow["VEH_ASSET_ID"]);
                    VEH_CODE = DRow["VEH_CODE"].ToString();
                    VEH_LICENSE = DRow["VEH_LICENSE"].ToString();
                    //VEH_TYPE = DRow["VEH_ASSET_ID"].ToString();
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
                    SITE_DRIVER_NAME = DRow["SITE_DRIVER_NAME"].ToString();
                    SITE_EMP_NAME = DRow["SITE_EMP_NAME"].ToString();
                    ORD_MTN_HEADER_REM = DRow["ORD_MTN_HEADER_REM"].ToString();
                    VEH_AGE = Convert.ToInt32(DRow["VEH_AGE"]);
                    ORD_VEH_MILEDGE = float.Parse(DRow["ORD_VEH_MILEDGE"].ToString());
                    MNT_TYPE = DRow["MNT_TYPE"].ToString();
                }
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
                //
                TxtDrvName.Text = SITE_DRIVER_NAME;
                TxtSiteEmpName.Text = SITE_EMP_NAME;
                TxtMNHeadRem.Text = ORD_MTN_HEADER_REM;
                //
                TxtVehMiledge.Text = ORD_VEH_MILEDGE.ToString("#,##0.00");
                TxtVehAge.Text = VEH_AGE.ToString("#,##0");
                //
                if (MNT_TYPE.ToUpper().Trim() == "PM")
                { RdoPM.Checked = true; RdoCR.Checked = false; }
                else { RdoPM.Checked = false; RdoCR.Checked = true; }
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
                MaintainTbl4 = incGlobalDataPatternObj.CreateDataTableMaintainL2Collection();
                MaintainTbl4.TableName = "TBL_M4_COLLECTION";
                foreach (DataRow DRow in OrderDSet.Tables["TB_ORDER_DESC2"].Rows)
                {
                    incGlobalDataPatternObj.AddDataToTableMaintainL2Collection(DRow["MNT_LINENO_DESC"].ToString(), MaintainTbl4);
                }
                MaintainTbl4.AcceptChanges();
                Session["MaintainTbl4"] = MaintainTbl4;
                var withBlock4 = GrdRepairDetail;
                withBlock4.DataSource = Session["MaintainTbl4"];
                withBlock4.DataBind();
                withBlock4.AutoGenerateColumns = false;
                //------------------------------------------------------------------------------------------------
                //MainHistory = OrderDSet.Tables["TB_HISTRY"];

                //var withBlock6 = GridView1;
                //withBlock6.DataSource = MainHistory;
                //withBlock6.DataBind();
                //withBlock6.AutoGenerateColumns = false;

                
                //------------------------------------------------------------------------------------------------

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
                    //
                    WHL_SERIAL = DRow["WHL_SERIAL"].ToString();
                    WHL_R_MILE = DRow["WHL_R_MILE"].ToString();
                    WHL_SIZE = DRow["WHL_SIZE"].ToString();
                    //
                    incGlobalDataPatternObj.AddDataToTableMaintainWheelCollection(MNT_WHL_POS, MNT_REQ_REASON, WHL_DAMAGE_AREA1, WHL_DAMAGE_AREA2, WHL_DAMAGE_AREA3, WHL_DAMAGE_AREA4,
                                                                      WHL_DAMAGE_TYPE1, WHL_DAMAGE_TYPE2, WHL_DAMAGE_TYPE3, WHL_DAMAGE_TYPE4, WHL_DAMAGE_OTH, WHL_DAMAGE_TYPEOTH, WHL_SERIAL, WHL_R_MILE, WHL_SIZE, MaintainTblWheel);
                }
                Session["MaintainTblWheel"] = MaintainTblWheel;
                var withBlockx = GrdWheelPos;
                withBlockx.DataSource = MaintainTblWheel;
                withBlockx.DataBind();
                withBlockx.AutoGenerateColumns = false;
                //
                //
                //ModeOperate=CRT | EDT
                HideModeOperate.Value = "EDT";
                MultiView1.ActiveViewIndex = 5;

            }
            catch
            {
                MultiView1.ActiveViewIndex = 7;
            }
        }

        //Export Grid To Excel End

    }
}