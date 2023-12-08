using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JxIntraWeb.App_DataEngine
{
    public class JxMasterService
    {
        //0.เลขที่เอกสาร
        public string GetSerialNo(string SerialType)
        {
            // 
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            string strSysMessage = "ERR:";
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                SqlCommand comObj = new SqlCommand();
                comObj.CommandText = "uspU1_JPXGetSerialDocNo";
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Connection = objConDB;
                //uspU1_JPXGetSerialDocNo]
                //@strTypeOfSerial VARCHAR(5),
                //@strSerialDocNo VARCHAR(11) OUTPUT
                // Input	
                SqlParameter PI1 = new SqlParameter("@strTypeOfSerial", SerialType);
                PI1.Direction = ParameterDirection.Input;
                PI1.DbType = DbType.String;
                // Outpute
                SqlParameter POut1 = new SqlParameter("@strSerialDocNo", SqlDbType.VarChar);
                POut1.Direction = ParameterDirection.Output;
                POut1.Size = 11;
                // Return
                SqlParameter PO_RETURN = new SqlParameter("RETURN", SqlDbType.Int);
                PO_RETURN.Direction = ParameterDirection.ReturnValue;
                // 
                comObj.Parameters.Add(PI1);
                comObj.Parameters.Add(POut1);
                // --------------------------------Excecute
                comObj.ExecuteNonQuery();
                // 
                string strOutPut1Value = POut1.Value.ToString();
                strSysMessage = strOutPut1Value;
            }
            // 
            // Throw New System.Exception("ทดลองให้เกิด exception .")
            catch (SqlException)
            {
                strSysMessage = "err:xxxxxxx";
            }
            finally
            {
                objConDB.Close();
            }
            // -----------------------------------------------Return
            return strSysMessage;
        }
        //1.Vehicle Asset Collection
        public DataSet GetVehicleCollection(string KeySearch)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                // 
                string strsqlQuery1 = " SELECT * FROM JxView_VehicleAsset WHERE  (VEH_CODE LIKE @VEH_CODE) OR (VEH_LICENSE LIKE @VEH_LICENSE) ORDER BY VEH_CODE ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                comDBX1.Parameters.AddWithValue("@VEH_CODE", "%" + KeySearch + "%");
                comDBX1.Parameters.AddWithValue("@VEH_LICENSE","%" + KeySearch + "%");
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_VEH_COLLECTION");
                DTable1.Load(DReader1);
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();

                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetVehicleOrderExpense(int VEH_ASSET_ID)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                // 
                string strsqlQuery1 = "SELECT * FROM JxView_OrderExpense WHERE  (VEH_ASSET_ID = @VEH_ASSET_ID) AND (ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC')) ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                comDBX1.Parameters.AddWithValue("@VEH_ASSET_ID", VEH_ASSET_ID);
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_VEHEXP_COLLECTION");
                DTable1.Load(DReader1);
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();

                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetVehicleOrderPart(int VEH_ASSET_ID)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                // 
                string strsqlQuery1 = "SELECT * FROM JxView_OrderPart WHERE  (VEH_ASSET_ID = @VEH_ASSET_ID) AND (ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC'))";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                comDBX1.Parameters.AddWithValue("@VEH_ASSET_ID", VEH_ASSET_ID);
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_VEHPART_COLLECTION");
                DTable1.Load(DReader1);
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();

                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }

        public string GetRepairOrderRecordNo(string RepairOrderNo)
        {
            string OrderRecNo = "";
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                string strsqlQuery1 = "SELECT REC_REF_NO  FROM  MNT_ORDER  WHERE (MNT_ORD_NO = @MNT_ORD_NO)";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                comDBX1.Parameters.AddWithValue("@MNT_ORD_NO", RepairOrderNo);
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                if (DReader1.HasRows){while (DReader1.Read()){OrderRecNo = DReader1["REC_REF_NO"].ToString();}}
                else{OrderRecNo = "";}
                DReader1.Close();
            }
            catch (SqlException){OrderRecNo= "";}
            finally{objConDB.Close();}
            //
            return OrderRecNo;
        }
        //2.Garage....... Collection
        public DataSet GetGarageCollection(string GarageKeySearch)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                string strsqlQuery1 = "SELECT  * FROM MST_GARAGE WHERE (GARAGE_NAME LIKE @GARAGE_NAME) OR (GARAGE_TEL LIKE @GARAGE_TEL) ORDER BY GARAGE_NAME ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@GARAGE_NAME", "%" + GarageKeySearch + "%");
                comDBX1.Parameters.AddWithValue("@GARAGE_TEL", "%" + GarageKeySearch + "%");
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_GARAGE_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        //3.Repair Order....... Collection
        public DataSet GetRepairOrderCollection_Act1(string MNT_OWN_SITECODE)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร OP: เอกสารใหม่ RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ AC:ให้ซ่อม IC:ไม่ให้ซ่อม
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO' FROM JxView_RepairOrderInfo WHERE (MNT_OWN_SITECODE=@MNT_OWN_SITECODE AND ORD_DOC_STCODE='OP' AND ORD_APPR_STATE='PD') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_Act2(string MNT_OWN_SITECODE)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO' FROM JxView_RepairOrderInfo WHERE (MNT_OWN_SITECODE=@MNT_OWN_SITECODE AND ORD_DOC_STCODE='CF' AND ORD_APPR_STATE='PD') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_Act3(string MNT_OWN_SITECODE)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO' FROM JxView_RepairOrderInfo WHERE (MNT_OWN_SITECODE=@MNT_OWN_SITECODE AND ORD_DOC_STCODE='RO' AND ORD_APPR_STATE='PD') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_Act4(string MNT_OWN_SITECODE)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO' FROM JxView_RepairOrderInfo WHERE (MNT_OWN_SITECODE=@MNT_OWN_SITECODE AND ORD_DOC_STCODE='IC' AND ORD_APPR_STATE='IA') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_Act5(string MNT_OWN_SITECODE)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
            //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
            //PD: รอพิจารณา AC: อนุมัติซ่อม IA:ไม่อนุมัติซ่อม
            //NO: ยังไม่ซ่อม IP:กำลังซ่อม SC:ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO' FROM JxView_RepairOrderInfo WHERE (MNT_OWN_SITECODE=@MNT_OWN_SITECODE AND ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND ORD_CLOSE_STATE='IP') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_Act6(string MNT_OWN_SITECODE,DateTime StartDate,DateTime EndDate,string StrVLicense)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                //PD: รอพิจารณา AC: อนุมัติซ่อม IA:ไม่อนุมัติซ่อม
                //NO: ยังไม่ซ่อม IP:กำลังซ่อม SC:ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO' FROM JxView_RepairOrderInfo " +
                                      "WHERE (MNT_OWN_SITECODE=@MNT_OWN_SITECODE AND ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC') AND (VEH_LICENSE LIKE @VEH_LICENSE)) " +
                                      " ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                comDBX1.Parameters.AddWithValue("@VEH_LICENSE", "%" + StrVLicense + "%");
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        //
        public DataSet GetOrderObjInfo(string OrderNo,int VehAssetID) //Fetch Data To Gridview 
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (ObjConDB.State == System.Data.ConnectionState.Open) { ObjConDB.Close(); }
                ObjConDB.Open();
                string strsqlQuery1 = "SELECT *  FROM JxView_RepairOrderInfo WHERE MNT_ORD_NO=@MNT_ORD_NO";
                string strsqlQuery2 = "SELECT *  FROM MNT_ORDER_DESC         WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery3 = "SELECT *  FROM MNT_ORDER_WHEEL        WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery4 = "SELECT *  FROM MNT_ORDER_PRICE        WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery5 = "SELECT *  FROM MNT_ORDER_PART         WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery6 = "SELECT *  FROM MNT_ORDER_DESCL2       WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery7 = "SELECT *  FROM JxView_RepairOrderInfo WHERE (VEH_ASSET_ID=@VEH_ASSET_ID AND ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC')) ORDER BY MNT_ORD_DATE DESC ";
                string strsqlQuery8 = "SELECT *  FROM MNT_ORDER_COMMENT      WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery9 = "SELECT *  FROM MNT_ORDER_IMG          WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                string strsqlQuery10 = "SELECT TOP(1) *  FROM JxView_RepairOrderInfo WHERE (VEH_ASSET_ID=@VEH_ASSET_ID AND ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC')) ORDER BY MNT_ORD_DATE DESC ";

                //
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, ObjConDB);
                comDBX1.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr1 = comDBX1.ExecuteReader();
                DataTable dt1 = new DataTable("TB_ORDER");
                dt1.Load(dr1);
                //
                SqlCommand comDBX2 = new SqlCommand(strsqlQuery2, ObjConDB);
                comDBX2.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr2 = comDBX2.ExecuteReader();
                DataTable dt2 = new DataTable("TB_ORDER_DESC");
                dt2.Load(dr2);
                //
                SqlCommand comDBX3 = new SqlCommand(strsqlQuery3, ObjConDB);
                comDBX3.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr3 = comDBX3.ExecuteReader();
                DataTable dt3 = new DataTable("TB_ORDER_WHLL");
                dt3.Load(dr3);
                //
                SqlCommand comDBX4 = new SqlCommand(strsqlQuery4, ObjConDB);
                comDBX4.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr4 = comDBX4.ExecuteReader();
                DataTable dt4 = new DataTable("TB_ORDER_PRICE");
                dt4.Load(dr4);
                //
                SqlCommand comDBX5 = new SqlCommand(strsqlQuery5, ObjConDB);
                comDBX5.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr5 = comDBX5.ExecuteReader();
                DataTable dt5 = new DataTable("TB_ORDER_PART");
                dt5.Load(dr5);
                //
                SqlCommand comDBX6 = new SqlCommand(strsqlQuery6, ObjConDB);
                comDBX6.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr6 = comDBX6.ExecuteReader();
                DataTable dt6 = new DataTable("TB_ORDER_DESC2");
                dt6.Load(dr6);
                //
                SqlCommand comDBX7 = new SqlCommand(strsqlQuery7, ObjConDB);
                comDBX7.Parameters.AddWithValue("@VEH_ASSET_ID", VehAssetID);
                SqlDataReader dr7 = comDBX7.ExecuteReader();
                DataTable dt7 = new DataTable("TB_HISTRY");
                dt7.Load(dr7);
                //
                SqlCommand comDBX8 = new SqlCommand(strsqlQuery8, ObjConDB);
                comDBX8.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr8 = comDBX8.ExecuteReader();
                DataTable dt8 = new DataTable("TB_COMMENT");
                dt8.Load(dr8);
                //
                SqlCommand comDBX9 = new SqlCommand(strsqlQuery9, ObjConDB);
                comDBX9.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr9 = comDBX9.ExecuteReader();
                DataTable dt9 = new DataTable("TB_IMAGE");
                dt9.Load(dr9);
                //
                //----------------------new-------------------------
                SqlCommand comDBX10 = new SqlCommand(strsqlQuery10, ObjConDB);
                comDBX10.Parameters.AddWithValue("@VEH_ASSET_ID", VehAssetID);
                SqlDataReader dr10 = comDBX10.ExecuteReader();
                DataTable dt10 = new DataTable("TB_HISTORY_TOP");
                dt10.Load(dr10);
                //----------------------new-------------------------

                DataSet DSet = new DataSet();
                DSet.Tables.Add(dt1.Copy());
                DSet.Tables.Add(dt2.Copy());
                DSet.Tables.Add(dt3.Copy());
                DSet.Tables.Add(dt4.Copy());
                DSet.Tables.Add(dt5.Copy());
                DSet.Tables.Add(dt6.Copy());
                DSet.Tables.Add(dt7.Copy());
                DSet.Tables.Add(dt8.Copy());
                DSet.Tables.Add(dt9.Copy());
                DSet.Tables.Add(dt10.Copy());
                // Close Data Reader
                dr1.Close();
                dr2.Close();
                dr3.Close();
                dr4.Close();
                dr5.Close();
                dr6.Close();
                dr7.Close();
                dr8.Close();
                dr9.Close();
                dr10.Close();
                // ------------------------------------------------------
                return DSet;
            }
            catch (SqlException)
            {
                return default;
            }
            finally
            {
                ObjConDB.Close();
            }
        }

        public DataSet GetOrderObjInfoImage(string OrderNo)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (ObjConDB.State == System.Data.ConnectionState.Open) { ObjConDB.Close(); }
                ObjConDB.Open();
                string strsqlQuery1 = "SELECT *  FROM MNT_ORDER_IMG  WHERE MNT_ORD_NO=@MNT_ORD_NO";
                //
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, ObjConDB);
                comDBX1.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr1 = comDBX1.ExecuteReader();
                DataTable dt1 = new DataTable("TB_ORDER_IMG");
                dt1.Load(dr1);
                //
                DataSet DSet = new DataSet();
                DSet.Tables.Add(dt1.Copy());
                // Close Data Reader
                dr1.Close();
                // ------------------------------------------------------
                return DSet;
            }
            catch (SqlException)
            {
                return default;
            }
            finally
            {
                ObjConDB.Close();
            }
        }

        public DataSet GetOrderObjInfoType2(string OrderNo)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (ObjConDB.State == System.Data.ConnectionState.Open) { ObjConDB.Close(); }
                ObjConDB.Open();
                string strsqlQuery1 = "SELECT *  FROM JxView_RepairOrderInfo  WHERE MNT_ORD_NO=@MNT_ORD_NO";
                string strsqlQuery2 = "SELECT *  FROM MNT_ORDER_DESC          WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery3 = "SELECT *  FROM MNT_ORDER_WHEEL         WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery4 = "SELECT *  FROM MNT_ORDER_PRICE         WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery5 = "SELECT *  FROM MNT_ORDER_PART          WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                string strsqlQuery6 = "SELECT *  FROM MNT_ORDER_DESCL2        WHERE MNT_ORD_NO=@MNT_ORD_NO ORDER BY MNT_ORD_LINENO";
                //string strsqlQuery7 = "SELECT *  FROM JxView_RepairOrderInfo WHERE (ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC')) ORDER BY MNT_ORD_DATE ASC ";
                //
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, ObjConDB);
                comDBX1.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr1 = comDBX1.ExecuteReader();
                DataTable dt1 = new DataTable("TB_ORDER");
                dt1.Load(dr1);
                //
                SqlCommand comDBX2 = new SqlCommand(strsqlQuery2, ObjConDB);
                comDBX2.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr2 = comDBX2.ExecuteReader();
                DataTable dt2 = new DataTable("TB_ORDER_DESC");
                dt2.Load(dr2);

                SqlCommand comDBX3 = new SqlCommand(strsqlQuery3, ObjConDB);
                comDBX3.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr3 = comDBX3.ExecuteReader();
                DataTable dt3 = new DataTable("TB_ORDER_WHLL");
                dt3.Load(dr3);
                //
                SqlCommand comDBX4 = new SqlCommand(strsqlQuery4, ObjConDB);
                comDBX4.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr4 = comDBX4.ExecuteReader();
                DataTable dt4 = new DataTable("TB_ORDER_PRICE");
                dt4.Load(dr4);
                //
                SqlCommand comDBX5 = new SqlCommand(strsqlQuery5, ObjConDB);
                comDBX5.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr5 = comDBX5.ExecuteReader();
                DataTable dt5 = new DataTable("TB_ORDER_PART");
                dt5.Load(dr5);
                //
                SqlCommand comDBX6 = new SqlCommand(strsqlQuery6, ObjConDB);
                comDBX6.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr6 = comDBX6.ExecuteReader();
                DataTable dt6 = new DataTable("TB_ORDER_DESC2");
                dt6.Load(dr6);
                //
                //SqlCommand comDBX7 = new SqlCommand(strsqlQuery7, ObjConDB);
                ////comDBX6.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                //SqlDataReader dr7 = comDBX7.ExecuteReader();
                //DataTable dt7 = new DataTable("TB_HISTRY");
                //dt7.Load(dr7);
                //
                DataSet DSet = new DataSet();
                DSet.Tables.Add(dt1.Copy());
                DSet.Tables.Add(dt2.Copy());
                DSet.Tables.Add(dt3.Copy());
                DSet.Tables.Add(dt4.Copy());
                DSet.Tables.Add(dt5.Copy());
                DSet.Tables.Add(dt6.Copy());
                //DSet.Tables.Add(dt7.Copy());
                // Close Data Reader
                dr1.Close();
                dr2.Close();
                dr3.Close();
                dr4.Close();
                dr5.Close();
                dr6.Close();
                //dr7.Close();
                // ------------------------------------------------------
                return DSet;
            }
            catch (SqlException)
            {
                return default;
            }
            finally
            {
                ObjConDB.Close();
            }
        }

        //////
        public DataSet GetRepairOrderCollection_ForApprove()
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  *,dbo.GetReqMaintanceInfo(MNT_ORD_NO) AS 'REQ_INFO',(SUBSTRING(MNT_OWN_USR, 1,10) +'...') AS 'OP_SHT_NAME' FROM JxView_RepairOrderInfo WHERE  ORD_DOC_STCODE='CF' AND ORD_APPR_STATE='PD' ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                //comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_MoreDetail()
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  * FROM JxView_RepairOrderInfo WHERE ( ORD_DOC_STCODE='RO' AND ORD_APPR_STATE='PD') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                //comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_Maintaining(DateTime StartDate, DateTime EndDate,string keySearch1, string keySearch2)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                //PD: รอพิจารณา AC: อนุมัติซ่อม IA:ไม่อนุมัติซ่อม
                //NO: ยังไม่ซ่อม IP:กำลังซ่อม SC:ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
                string strsqlQuery1 = "SELECT  * FROM JxView_RepairOrderInfo WHERE (MNT_ORD_DATE BETWEEN @StartDate AND @EndDate) AND (ActualMN_INFO LIKE @ActualMN_INFO AND  ReqMN_INFO LIKE @ReqMN_INFO)  AND " +
                                      "   (ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND ORD_CLOSE_STATE='IP') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                //comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                comDBX1.Parameters.AddWithValue("@StartDate", StartDate.Date);
                comDBX1.Parameters.AddWithValue("@EndDate", EndDate.Date);
                comDBX1.Parameters.AddWithValue("@ActualMN_INFO", "%" + keySearch1 + "%");
                comDBX1.Parameters.AddWithValue("@ReqMN_INFO", "%" + keySearch2 + "%");
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_MaintainingAll()
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                //PD: รอพิจารณา AC: อนุมัติซ่อม IA:ไม่อนุมัติซ่อม
                //NO: ยังไม่ซ่อม IP:กำลังซ่อม SC:ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
                string strsqlQuery1 = "SELECT  * FROM JxView_RepairOrderInfo WHERE (ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND ORD_CLOSE_STATE='IP') ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                //comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        public DataSet GetRepairOrderCollection_OrderClosed(DateTime StartDate, DateTime EndDate, string keySearch1, string keySearch2)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                //PD: รอพิจารณา AC: อนุมัติซ่อม IA:ไม่อนุมัติซ่อม
                //NO: ยังไม่ซ่อม IP:กำลังซ่อม SC:ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
                string strsqlQuery1 = "SELECT  * FROM JxView_RepairOrderInfo WHERE (MNT_ORD_DATE BETWEEN @StartDate AND @EndDate) AND (ActualMN_INFO LIKE @ActualMN_INFO  AND  ReqMN_INFO LIKE @ReqMN_INFO)  AND " +
                                      "     (ORD_DOC_STCODE='AC' AND ORD_APPR_STATE='AC' AND (ORD_CLOSE_STATE='SC' OR ORD_CLOSE_STATE='NC')) ORDER BY MNT_ORD_DATE ASC ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@StartDate", StartDate.Date);
                comDBX1.Parameters.AddWithValue("@EndDate", EndDate.Date);
                comDBX1.Parameters.AddWithValue("@ActualMN_INFO", "%" + keySearch1 + "%");
                comDBX1.Parameters.AddWithValue("@ReqMN_INFO", "%" + keySearch2 + "%");
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_RORDER_COLLECTION");
                DTable1.Load(DReader1);
                // 
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DReader1.Close();
                // 
                return DSet;
            }
            catch (SqlException)
            {
                // MessageBox.Show(ex.Message)
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }

        public DataSet GetLastHistory(string OrderNo)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (ObjConDB.State == System.Data.ConnectionState.Open) { ObjConDB.Close(); }
                ObjConDB.Open();
                string strsqlQuery1 = "SELECT *  FROM MNT_ORDER_DESC      WHERE MNT_ORD_NO=@MNT_ORD_NO";
                //
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, ObjConDB);
                comDBX1.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                SqlDataReader dr1 = comDBX1.ExecuteReader();
                DataTable dt1 = new DataTable("TB_LAST_HISTORY");
                dt1.Load(dr1);
                //
                DataSet DSet = new DataSet();
                DSet.Tables.Add(dt1.Copy());
                // Close Data Reader
                dr1.Close();
                // ------------------------------------------------------
                return DSet;
            }
            catch (SqlException)
            {
                return default;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
    }
}