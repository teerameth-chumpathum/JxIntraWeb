using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JxIntraWeb.App_DataEngine
{
    public class JxTransactionService
    {
        private bool IsOrderRecReferenceNoChanged(string OrderNo, string OrderRecReferenceNo)
        {
            //Connection
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            if (objConDB.State == ConnectionState.Open) { objConDB.Close(); }
            objConDB.Open();
            //
            bool IsOrderRefNoChanged = true;

            try
            {
                //
                string sqlQuery = "SELECT MNT_ORD_NO,REC_REF_NO  FROM MNT_ORDER  WHERE (MNT_ORD_NO = @MNT_ORD_NO)  AND (REC_REF_NO = @REC_REF_NO)";
                SqlCommand comDBX = new SqlCommand(sqlQuery, objConDB);
                comDBX.Parameters.AddWithValue("@MNT_ORD_NO", OrderNo);
                comDBX.Parameters.AddWithValue("@REC_REF_NO", OrderRecReferenceNo);
                SqlDataReader dr = comDBX.ExecuteReader();
                if (dr.HasRows) { IsOrderRefNoChanged = false; }
                else { IsOrderRefNoChanged = true; }
                dr.Close();
            }
            catch { IsOrderRefNoChanged = true; }
            finally { objConDB.Close(); }
            //
            return IsOrderRefNoChanged;
        }
        public string SaveOrderRequest(string MNT_ORD_NO,string MNT_OWN_SITECODE, string MNT_OWN_SITE, int MNT_OWN_USRID, string MNT_OWN_USR, DateTime MNT_ORD_DATE, 
                                       int VEH_ASSET_ID, int SERVICE_GARAGE_ID,string DRIVER_SIGN,string SITE_EMP_SIGN,DataSet RepairDSet,string ORD_DOC_STCODE,string SITE_DRIVER_NAME,string SITE_EMP_NAME,
                                       int VEH_AGE,float ORD_VEH_MILEDGE,string MNT_TYPE)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "INSERT INTO MNT_ORDER (MNT_ORD_NO,MNT_OWN_SITECODE,MNT_OWN_USRID,MNT_ORD_DATE,VEH_ASSET_ID,SERVICE_GARAGE_ID,DRIVER_SIGN,SITE_EMP_SIGN,ORD_DOC_STCODE ,ORD_APPR_STATE,ORD_CLOSE_STATE,SITE_DRIVER_NAME,SITE_EMP_NAME,VEH_AGE,ORD_VEH_MILEDGE,MNT_TYPE) " +
                           "                VALUES(@MNT_ORD_NO,@MNT_OWN_SITECODE,@MNT_OWN_USRID,@MNT_ORD_DATE,@VEH_ASSET_ID,@SERVICE_GARAGE_ID,@DRIVER_SIGN,@SITE_EMP_SIGN,@ORD_DOC_STCODE,'PD','NO',@SITE_DRIVER_NAME,@SITE_EMP_NAME,@VEH_AGE,@ORD_VEH_MILEDGE,@MNT_TYPE) ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                comInsertDoc1.Parameters.AddWithValue("@MNT_OWN_USRID", MNT_OWN_USRID);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_DATE", MNT_ORD_DATE);
                comInsertDoc1.Parameters.AddWithValue("@VEH_ASSET_ID", VEH_ASSET_ID);
                comInsertDoc1.Parameters.AddWithValue("@SERVICE_GARAGE_ID", SERVICE_GARAGE_ID);
                comInsertDoc1.Parameters.AddWithValue("@DRIVER_SIGN", DRIVER_SIGN);
                comInsertDoc1.Parameters.AddWithValue("@SITE_EMP_SIGN", SITE_EMP_SIGN);
                comInsertDoc1.Parameters.AddWithValue("@ORD_DOC_STCODE", ORD_DOC_STCODE);
                comInsertDoc1.Parameters.AddWithValue("@SITE_DRIVER_NAME", SITE_DRIVER_NAME);
                comInsertDoc1.Parameters.AddWithValue("@SITE_EMP_NAME", SITE_EMP_NAME);
                comInsertDoc1.Parameters.AddWithValue("@VEH_AGE", VEH_AGE);
                comInsertDoc1.Parameters.AddWithValue("@ORD_VEH_MILEDGE", ORD_VEH_MILEDGE);
                comInsertDoc1.Parameters.AddWithValue("@MNT_TYPE", MNT_TYPE);

                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "INSERT INTO MNT_ORDER_OPERATOR (MNT_ORD_NO,MNT_OWN_SITE,MNT_OWN_USR)    " +
                           "                         VALUES(@MNT_ORD_NO,@MNT_OWN_SITE,@MNT_OWN_USR) ";

                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@MNT_OWN_SITE", MNT_OWN_SITE);
                comInsertDoc2.Parameters.AddWithValue("@MNT_OWN_USR", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();

                //TBL_MN_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESC(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)     " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert1 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert1.Transaction = T1;
                    comInsert1.ExecuteNonQuery();
                }
                //TBL_MNWHEEL_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MNWHEEL_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_WHEEL " +
                               "  (MNT_ORD_NO,MNT_ORD_LINENO,MNT_WHL_POS,MNT_REQ_REASON,WHL_DAMAGE_AREA1,WHL_DAMAGE_AREA2,WHL_DAMAGE_AREA3,WHL_DAMAGE_AREA4 ," +
                               "   WHL_DAMAGE_OTH,WHL_DAMAGE_TYPE1,WHL_DAMAGE_TYPE2,WHL_DAMAGE_TYPE3,WHL_DAMAGE_TYPE4,WHL_DAMAGE_TYPEOTH,WHL_SERIAL,WHL_R_MILE,WHL_SIZE)                    " +
                               "VALUES " +
                               "  (@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_WHL_POS,@MNT_REQ_REASON,@WHL_DAMAGE_AREA1,@WHL_DAMAGE_AREA2,@WHL_DAMAGE_AREA3,@WHL_DAMAGE_AREA4," +
                               "   @WHL_DAMAGE_OTH,@WHL_DAMAGE_TYPE1,@WHL_DAMAGE_TYPE2,@WHL_DAMAGE_TYPE3,@WHL_DAMAGE_TYPE4,@WHL_DAMAGE_TYPEOTH,@WHL_SERIAL,@WHL_R_MILE,@WHL_SIZE)";
                    SqlCommand comInsert2 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert2.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert2.Parameters.AddWithValue("@MNT_WHL_POS", DRow["W_POS"].ToString());
                    comInsert2.Parameters.AddWithValue("@MNT_REQ_REASON", DRow["MnRemark"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA1", (bool)DRow["DamageArea1"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA2", (bool)DRow["DamageArea2"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA3", (bool)DRow["DamageArea3"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA4", (bool)DRow["DamageArea4"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_OTH", DRow["DamageAreaAno"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE1", (bool)DRow["DamageType1"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE2", (bool)DRow["DamageType2"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE3", (bool)DRow["DamageType3"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE4", (bool)DRow["DamageType4"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPEOTH", DRow["DamageTypeAno"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_SERIAL", DRow["Serial"].ToString());
                    comInsert2.Parameters.AddWithValue("@WHL_R_MILE", DRow["RMile"].ToString());
                    comInsert2.Parameters.AddWithValue("@WHL_SIZE", DRow["WhlSize"].ToString());
                    //
                    comInsert2.Transaction = T1;
                    comInsert2.ExecuteNonQuery();
                }
                //
                foreach (DataRow DRow in RepairDSet.Tables["TBL_M4_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESCL2(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert4 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert4.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    //
                    comInsert4.Transaction = T1;
                    comInsert4.ExecuteNonQuery();
                }
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string UpdateOrderRequest(string MNT_ORD_NO, string MNT_OWN_SITECODE, string MNT_OWN_SITE, int MNT_OWN_USRID, string MNT_OWN_USR, DateTime MNT_ORD_DATE,
                                     int VEH_ASSET_ID, int SERVICE_GARAGE_ID, string DRIVER_SIGN, string SITE_EMP_SIGN, DataSet RepairDSet,string OrderRecReferenceNo, 
                                     string SITE_DRIVER_NAME, string SITE_EMP_NAME,int VEH_AGE,float ORD_VEH_MILEDGE, string MNT_TYPE)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) {return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET VEH_ASSET_ID=@VEH_ASSET_ID,SERVICE_GARAGE_ID=@SERVICE_GARAGE_ID,                         " +
                           "    DRIVER_SIGN=@DRIVER_SIGN,SITE_EMP_SIGN=@SITE_EMP_SIGN,SITE_DRIVER_NAME=@SITE_DRIVER_NAME,                 " +
                           "    SITE_EMP_NAME=@SITE_EMP_NAME,MNT_ORD_DATE=@MNT_ORD_DATE,VEH_AGE=@VEH_AGE,ORD_VEH_MILEDGE=@ORD_VEH_MILEDGE," +
                           "    MNT_TYPE=@MNT_TYPE " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO  ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@VEH_ASSET_ID", VEH_ASSET_ID);
                comInsertDoc1.Parameters.AddWithValue("@SERVICE_GARAGE_ID", SERVICE_GARAGE_ID);
                comInsertDoc1.Parameters.AddWithValue("@DRIVER_SIGN", DRIVER_SIGN);
                comInsertDoc1.Parameters.AddWithValue("@SITE_EMP_SIGN", SITE_EMP_SIGN);
                comInsertDoc1.Parameters.AddWithValue("@SITE_DRIVER_NAME", SITE_DRIVER_NAME);
                comInsertDoc1.Parameters.AddWithValue("@SITE_EMP_NAME", SITE_EMP_NAME);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_DATE", MNT_ORD_DATE);
                comInsertDoc1.Parameters.AddWithValue("@VEH_AGE", VEH_AGE);
                comInsertDoc1.Parameters.AddWithValue("@ORD_VEH_MILEDGE", ORD_VEH_MILEDGE);
                comInsertDoc1.Parameters.AddWithValue("@MNT_TYPE", MNT_TYPE);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET LEDT_USR=@LEDT_USR, LEDT_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@LEDT_USR", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_DESC WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc1.Transaction = T1;
                comDelDoc1.ExecuteNonQuery();
                //TBL_MN_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESC(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)     " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert1 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert1.Transaction = T1;
                    comInsert1.ExecuteNonQuery();
                }
                //
                sqlQuery = "DELETE FROM MNT_ORDER_WHEEL WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc2.Transaction = T1;
                comDelDoc2.ExecuteNonQuery();
                //TBL_MNWHEEL_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MNWHEEL_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_WHEEL " +
                               "  (MNT_ORD_NO,MNT_ORD_LINENO,MNT_WHL_POS,MNT_REQ_REASON,WHL_DAMAGE_AREA1,WHL_DAMAGE_AREA2,WHL_DAMAGE_AREA3,WHL_DAMAGE_AREA4 ," +
                               "   WHL_DAMAGE_OTH,WHL_DAMAGE_TYPE1,WHL_DAMAGE_TYPE2,WHL_DAMAGE_TYPE3,WHL_DAMAGE_TYPE4,WHL_DAMAGE_TYPEOTH,WHL_SERIAL,WHL_R_MILE,WHL_SIZE)                    " +
                               "VALUES " +
                               "  (@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_WHL_POS,@MNT_REQ_REASON,@WHL_DAMAGE_AREA1,@WHL_DAMAGE_AREA2,@WHL_DAMAGE_AREA3,@WHL_DAMAGE_AREA4," +
                               "   @WHL_DAMAGE_OTH,@WHL_DAMAGE_TYPE1,@WHL_DAMAGE_TYPE2,@WHL_DAMAGE_TYPE3,@WHL_DAMAGE_TYPE4,@WHL_DAMAGE_TYPEOTH,@WHL_SERIAL,@WHL_R_MILE,@WHL_SIZE)";
                    SqlCommand comInsert2 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert2.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert2.Parameters.AddWithValue("@MNT_WHL_POS", DRow["W_POS"].ToString());
                    comInsert2.Parameters.AddWithValue("@MNT_REQ_REASON", DRow["MnRemark"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA1", (bool)DRow["DamageArea1"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA2", (bool)DRow["DamageArea2"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA3", (bool)DRow["DamageArea3"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA4", (bool)DRow["DamageArea4"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_OTH", DRow["DamageAreaAno"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE1", (bool)DRow["DamageType1"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE2", (bool)DRow["DamageType2"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE3", (bool)DRow["DamageType3"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE4", (bool)DRow["DamageType4"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPEOTH", DRow["DamageTypeAno"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_SERIAL", DRow["Serial"].ToString());
                    comInsert2.Parameters.AddWithValue("@WHL_R_MILE", DRow["RMile"].ToString());
                    comInsert2.Parameters.AddWithValue("@WHL_SIZE", DRow["WhlSize"].ToString());
                    //
                    comInsert2.Transaction = T1;
                    comInsert2.ExecuteNonQuery();
                }
                //
                sqlQuery = "DELETE FROM MNT_ORDER_DESCL2 WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc4 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc4.Transaction = T1;
                comDelDoc4.ExecuteNonQuery();
                //
                foreach (DataRow DRow in RepairDSet.Tables["TBL_M4_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESCL2(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert4 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert4.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    //
                    comInsert4.Transaction = T1;
                    comInsert4.ExecuteNonQuery();
                }
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string UpdateOrderRequestCF(string MNT_ORD_NO, string MNT_OWN_SITECODE, string MNT_OWN_SITE, int MNT_OWN_USRID, string MNT_OWN_USR, DateTime MNT_ORD_DATE,
                                  int VEH_ASSET_ID, int SERVICE_GARAGE_ID, string DRIVER_SIGN, string SITE_EMP_SIGN, DataSet RepairDSet, string OrderRecReferenceNo,
                                  string SITE_DRIVER_NAME,string SITE_EMP_NAME, int VEH_AGE, float ORD_VEH_MILEDGE, string MNT_TYPE)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET VEH_ASSET_ID=@VEH_ASSET_ID,SERVICE_GARAGE_ID=@SERVICE_GARAGE_ID," +
                           "    DRIVER_SIGN=@DRIVER_SIGN,SITE_EMP_SIGN=@SITE_EMP_SIGN,ORD_DOC_STCODE='CF',   " +
                           "    SITE_DRIVER_NAME=@SITE_DRIVER_NAME,SITE_EMP_NAME=@SITE_EMP_NAME,             " +
                           "    VEH_AGE=@VEH_AGE,ORD_VEH_MILEDGE=@ORD_VEH_MILEDGE,                           " +
                           "    MNT_TYPE=@MNT_TYPE                                                           " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                                     ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@VEH_ASSET_ID", VEH_ASSET_ID);
                comInsertDoc1.Parameters.AddWithValue("@SERVICE_GARAGE_ID", SERVICE_GARAGE_ID);
                comInsertDoc1.Parameters.AddWithValue("@DRIVER_SIGN", DRIVER_SIGN);
                comInsertDoc1.Parameters.AddWithValue("@SITE_EMP_SIGN", SITE_EMP_SIGN);
                comInsertDoc1.Parameters.AddWithValue("@SITE_DRIVER_NAME", SITE_DRIVER_NAME);
                comInsertDoc1.Parameters.AddWithValue("@SITE_EMP_NAME", SITE_EMP_NAME);
                comInsertDoc1.Parameters.AddWithValue("@VEH_AGE", VEH_AGE);
                comInsertDoc1.Parameters.AddWithValue("@ORD_VEH_MILEDGE", ORD_VEH_MILEDGE);
                comInsertDoc1.Parameters.AddWithValue("@MNT_TYPE", MNT_TYPE);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET LEDT_USR=@LEDT_USR, LEDT_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@LEDT_USR", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_DESC WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc1.Transaction = T1;
                comDelDoc1.ExecuteNonQuery();
                //TBL_MN_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESC(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)     " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert1 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert1.Transaction = T1;
                    comInsert1.ExecuteNonQuery();
                }
                //
                sqlQuery = "DELETE FROM MNT_ORDER_WHEEL WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc2.Transaction = T1;
                comDelDoc2.ExecuteNonQuery();
                //TBL_MNWHEEL_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MNWHEEL_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_WHEEL " +
                               "  (MNT_ORD_NO,MNT_ORD_LINENO,MNT_WHL_POS,MNT_REQ_REASON,WHL_DAMAGE_AREA1,WHL_DAMAGE_AREA2,WHL_DAMAGE_AREA3,WHL_DAMAGE_AREA4 ," +
                               "   WHL_DAMAGE_OTH,WHL_DAMAGE_TYPE1,WHL_DAMAGE_TYPE2,WHL_DAMAGE_TYPE3,WHL_DAMAGE_TYPE4,WHL_DAMAGE_TYPEOTH,WHL_SERIAL,WHL_R_MILE,WHL_SIZE)                    " +
                               "VALUES " +
                               "  (@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_WHL_POS,@MNT_REQ_REASON,@WHL_DAMAGE_AREA1,@WHL_DAMAGE_AREA2,@WHL_DAMAGE_AREA3,@WHL_DAMAGE_AREA4," +
                               "   @WHL_DAMAGE_OTH,@WHL_DAMAGE_TYPE1,@WHL_DAMAGE_TYPE2,@WHL_DAMAGE_TYPE3,@WHL_DAMAGE_TYPE4,@WHL_DAMAGE_TYPEOTH,@WHL_SERIAL,@WHL_R_MILE,@WHL_SIZE)";
                    SqlCommand comInsert2 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert2.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert2.Parameters.AddWithValue("@MNT_WHL_POS", DRow["W_POS"].ToString());
                    comInsert2.Parameters.AddWithValue("@MNT_REQ_REASON", DRow["MnRemark"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA1", (bool)DRow["DamageArea1"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA2", (bool)DRow["DamageArea2"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA3", (bool)DRow["DamageArea3"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_AREA4", (bool)DRow["DamageArea4"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_OTH", DRow["DamageAreaAno"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE1", (bool)DRow["DamageType1"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE2", (bool)DRow["DamageType2"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE3", (bool)DRow["DamageType3"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPE4", (bool)DRow["DamageType4"]);
                    comInsert2.Parameters.AddWithValue("@WHL_DAMAGE_TYPEOTH", DRow["DamageTypeAno"].ToString());
                    //
                    comInsert2.Parameters.AddWithValue("@WHL_SERIAL", DRow["Serial"].ToString());
                    comInsert2.Parameters.AddWithValue("@WHL_R_MILE", DRow["RMile"].ToString());
                    comInsert2.Parameters.AddWithValue("@WHL_SIZE", DRow["WhlSize"].ToString());
                    //
                    comInsert2.Transaction = T1;
                    comInsert2.ExecuteNonQuery();
                }
                //
                sqlQuery = "DELETE FROM MNT_ORDER_DESCL2 WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc4 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc4.Transaction = T1;
                comDelDoc4.ExecuteNonQuery();
                //
                foreach (DataRow DRow in RepairDSet.Tables["TBL_M4_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESCL2(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert4 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert4.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    //
                    comInsert4.Transaction = T1;
                    comInsert4.ExecuteNonQuery();
                }
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string DeleteOrderRequest(string MNT_ORD_NO,string MNT_OWN_USR,string OrderRecReferenceNo)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET ORD_DOC_STCODE='DL',REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss') WHERE MNT_ORD_NO=@MNT_ORD_NO  ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET LEDT_USR=@LEDT_USR, LEDT_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@LEDT_USR", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string InApproveOrderRequest(string MNT_ORD_NO, string MNT_OWN_USR, string OrderRecReferenceNo,string MNHeaderRem)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET ORD_DOC_STCODE='IC',ORD_APPR_STATE='IA'," +
                           "       ORD_MTN_HEADER_REM=@ORD_MTN_HEADER_REM,REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss') WHERE MNT_ORD_NO=@MNT_ORD_NO  ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@ORD_MTN_HEADER_REM", MNHeaderRem);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET MNT_APPROVER=@MNT_APPROVER, APPRV_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@MNT_APPROVER", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string MoreDetailOrderRequest(string MNT_ORD_NO, string MNT_OWN_USR, string OrderRecReferenceNo, string MNHeaderRem)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                //ORD_DOC_STCODE='RO' AND ORD_APPR_STATE='PD'
                sqlQuery = "UPDATE MNT_ORDER SET ORD_DOC_STCODE='RO',ORD_APPR_STATE='PD'," +
                           "       ORD_MTN_HEADER_REM=@ORD_MTN_HEADER_REM,REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss') WHERE MNT_ORD_NO=@MNT_ORD_NO  ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@ORD_MTN_HEADER_REM", MNHeaderRem);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET MNT_APPROVER=@MNT_APPROVER, APPRV_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@MNT_APPROVER", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string ApproveOrderRequest(string MNT_ORD_NO, string MNT_OWN_USR, string OrderRecReferenceNo, string MNHeaderRem)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                //ORD_DOC_STCODE='RO' AND ORD_APPR_STATE='PD'
                sqlQuery = "UPDATE MNT_ORDER SET ORD_DOC_STCODE='AC',ORD_APPR_STATE='AC',ORD_CLOSE_STATE='IP'," +
                           "       ORD_MTN_HEADER_REM=@ORD_MTN_HEADER_REM,REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss') WHERE MNT_ORD_NO=@MNT_ORD_NO  ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@ORD_MTN_HEADER_REM", MNHeaderRem);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET MNT_APPROVER=@MNT_APPROVER, APPRV_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@MNT_APPROVER", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string RollBackOrderRequest(string MNT_ORD_NO, string MNT_OWN_USR, string OrderRecReferenceNo)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET ORD_DOC_STCODE='OP',REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss') WHERE MNT_ORD_NO=@MNT_ORD_NO  ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET LEDT_USR=@LEDT_USR, LEDT_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                           ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@LEDT_USR", MNT_OWN_USR);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }

        public DataSet GetOrderCollection_CounterSite(string MNT_OWN_SITECODE)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  'JxEngineCount' AS 'ENGINE_COUNT', " +
                                      " (SELECT  COUNT(*) FROM JxView_RepairOrderInfo WHERE(MNT_OWN_SITECODE = @MNT_OWN_SITECODE AND ORD_DOC_STCODE = 'OP' AND ORD_APPR_STATE = 'PD')) AS 'FolderFile1Amt'," +
                                      " (SELECT  COUNT(*) FROM JxView_RepairOrderInfo WHERE(MNT_OWN_SITECODE = @MNT_OWN_SITECODE AND ORD_DOC_STCODE = 'CF' AND ORD_APPR_STATE = 'PD')) AS 'FolderFile2Amt'," +
                                      " (SELECT  Count(*) FROM JxView_RepairOrderInfo WHERE(MNT_OWN_SITECODE = @MNT_OWN_SITECODE AND ORD_DOC_STCODE = 'RO' AND ORD_APPR_STATE = 'PD')) AS 'FolderFile3Amt'," +
                                      " (SELECT  COUNT(*) FROM JxView_RepairOrderInfo WHERE(MNT_OWN_SITECODE = @MNT_OWN_SITECODE AND ORD_DOC_STCODE = 'IC' AND ORD_APPR_STATE = 'IA')) AS 'FolderFile4Amt'," +
                                      " (SELECT  COUNT(*) FROM JxView_RepairOrderInfo WHERE(MNT_OWN_SITECODE = @MNT_OWN_SITECODE AND ORD_DOC_STCODE = 'AC' AND ORD_APPR_STATE = 'AC' AND ORD_CLOSE_STATE='IP')) AS 'FolderFile5Amt' ";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_ORDER_COUNTER");
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
        public DataSet GetOrderCollection_CounterCentral()
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                //DL: ลบเอกสาร  OP: เอกสารใหม่   RO: ขอรายละเอียดเพิ่มเติม CF:ยืนยันเอกสารรออนุมัติ   AC:ให้ซ่อม   IC:ไม่ให้ซ่อม 
                string strsqlQuery1 = "SELECT  'JxEngineCountCentral' AS 'ENGINE_COUNT', " +
                                      " (SELECT  COUNT(*) FROM JxView_RepairOrderInfo WHERE(ORD_DOC_STCODE = 'CF' AND ORD_APPR_STATE = 'PD')) AS 'FolderFile1Amt'," +
                                      " (SELECT  Count(*) FROM JxView_RepairOrderInfo WHERE(ORD_DOC_STCODE = 'RO' AND ORD_APPR_STATE = 'PD')) AS 'FolderFile2Amt'," +
                                      " (SELECT  COUNT(*) FROM JxView_RepairOrderInfo WHERE(ORD_DOC_STCODE = 'AC' AND ORD_APPR_STATE = 'AC') AND (ORD_CLOSE_STATE='IP')) AS 'FolderFile3Amt'";
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                //comDBX1.Parameters.AddWithValue("@MNT_OWN_SITECODE", MNT_OWN_SITECODE);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_ORDER_COUNTER");
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

        public DataSet GetVehicleTypeCollection()
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();

                string strsqlQuery1 = "SELECT VEH_TYPE_ID,VEH_TYPE FROM MST_VEHICLE_TYPE_Config ORDER BY VEH_TYPE_ID ";

                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                //
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_VEHTYPE");
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
        public DataSet GetPartRequestionCollection(string PartRequestionNo)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase3);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();

                string strsqlQuery1 = "SELECT * FROM tbt_GIRM where OutboundOrderNo = @OutboundOrderNo ";
                //string strsqlQuery2 = "SELECT * FROM tbt_GIRMDetail where OutboundOrderNo = @OutboundOrderNo";
                string strsqlQuery2 = "SELECT tbt_GIRMDetail.*,tbt_GIRMDetail.ProductCode,tbm_Product.ProductNameTH,tbm_Product.ProductNameEN                " +
                                      "FROM   tbm_Product INNER JOIN  " +
                                      "       tbt_GIRMDetail ON tbm_Product.ProductCode = tbt_GIRMDetail.ProductCode WHERE OutboundOrderNo =@OutboundOrderNo ";
                //
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                comDBX1.Parameters.AddWithValue("@OutboundOrderNo", PartRequestionNo);
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("tbt_GIRM");
                DTable1.Load(DReader1);
                // 
                SqlCommand comDBX2 = new SqlCommand(strsqlQuery2, objConDB);
                comDBX2.Parameters.AddWithValue("@OutboundOrderNo", PartRequestionNo);
                SqlDataReader DReader2 = comDBX2.ExecuteReader();
                DataTable DTable2 = new DataTable("tbt_GIRMDetail");
                DTable2.Load(DReader2);

                //
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DSet.Tables.Add(DTable2.Copy());
                DReader1.Close(); DReader2.Close();
                // 
                return DSet;
            }
            catch (SqlException ex)
            {
                string x = ex.Message;
                return default;
            }
            finally
            {
                objConDB.Close();
            }
        }
        //public string UpdateOrder(string MNT_ORD_NO, string MNT_OWN_SITECODE, string MNT_OWN_SITE, int MNT_OWN_USRID, string MNT_OWN_USR, DateTime MNT_ORD_DATE,
        //                int VEH_ASSET_ID, int SERVICE_GARAGE_ID, string DRIVER_SIGN, string SITE_EMP_SIGN, DataSet RepairDSet, string OrderRecReferenceNo)
        public string UpdateOrder(string MNT_ORD_NO,DataSet RepairDSet, string OrderRecReferenceNo,string USR_OPERATE,float TotalRepairPrice, DateTime OrderDate,string MNT_TYPE)
        {
            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET MNT_TOTAL_PRICE=@MNT_TOTAL_PRICE,MNT_ORD_DATE=@MNT_ORD_DATE, REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss'),MNT_TYPE=@MNT_TYPE " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO                                       ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@MNT_TOTAL_PRICE", TotalRepairPrice);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_DATE", OrderDate);
                comInsertDoc1.Parameters.AddWithValue("@MNT_TYPE", MNT_TYPE);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET MNT_OFFICE_OP=@MNT_OFFICE_OP,OFFICE_OP_DTIME=GETDATE() " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO  ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@MNT_OFFICE_OP", USR_OPERATE);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_PRICE WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc1.Transaction = T1;
                comDelDoc1.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_PART WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc2.Transaction = T1;
                comDelDoc2.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_DESCL2 WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc3 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc3.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc3.Transaction = T1;
                comDelDoc3.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_COMMENT WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc4 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc4.Transaction = T1;
                comDelDoc4.ExecuteNonQuery();

                //TBL_MN_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_PRICE(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC,MNT_LINENO_PRICE,MNT_LINENO_SERVICER)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC,@MNT_LINENO_PRICE,@MNT_LINENO_SERVICER) ";
                    SqlCommand comInsert1 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_PRICE",(float)(DRow["MnCost"]));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_SERVICER", DRow["MnServicer"].ToString());
                    //
                    comInsert1.Transaction = T1;
                    comInsert1.ExecuteNonQuery();
                }
                //
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION3"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_PART(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC,MNT_LINENO_AMT,MNT_PRICE)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC,@MNT_LINENO_AMT,@MNT_PRICE) ";
                    SqlCommand comInsert3 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert3.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert3.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert3.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert3.Parameters.AddWithValue("@MNT_LINENO_AMT", Convert.ToInt32(DRow["MnAmt"]));
                    comInsert3.Parameters.AddWithValue("@MNT_PRICE", Convert.ToDouble(DRow["MnPrice"])); //ADD 20230130
                    //
                    comInsert3.Transaction = T1;
                    comInsert3.ExecuteNonQuery();
                }
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION4"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESCL2(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert4 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert4.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    //
                    comInsert4.Transaction = T1;
                    comInsert4.ExecuteNonQuery();
                }
                //
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION7"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_COMMENT(MNT_ORD_NO,MNT_ORD_LINENO,DATE_NOTE,DESC_NOTE,MILEDGE_NOTE,PRICE_NOTE,SERVICER_NOTE)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@DATE_NOTE,@DESC_NOTE,@MILEDGE_NOTE,@PRICE_NOTE,@SERVICER_NOTE) ";
                    SqlCommand comInsert5 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert5.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert5.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert5.Parameters.AddWithValue("@DATE_NOTE", DRow["DATE_NOTE"].ToString());
                    comInsert5.Parameters.AddWithValue("@DESC_NOTE", DRow["DESC_NOTE"].ToString());
                    comInsert5.Parameters.AddWithValue("@MILEDGE_NOTE", DRow["MILEDGE_NOTE"].ToString());
                    comInsert5.Parameters.AddWithValue("@PRICE_NOTE", DRow["PRICE_NOTE"].ToString());
                    comInsert5.Parameters.AddWithValue("@SERVICER_NOTE", DRow["SERVICER_NOTE"].ToString());
                    //
                    comInsert5.Transaction = T1;
                    comInsert5.ExecuteNonQuery();
                }

                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string UpdateCloseOrder(string MNT_ORD_NO,string CLOSE_STATE,string USR_OPERATE, DataSet RepairDSet, string OrderRecReferenceNo,float MNT_TOTAL_PRICE, DateTime CloseDate)
        {
             //SC: ซ่อมสำเหร็จ NC:ซ่อมไม่ได้
             if (CLOSE_STATE != "SC" && CLOSE_STATE != "NC") { return "ERR:ข้อมูลสถานะการปิดงานไม่ถูกต้อง!!"; }

            //Record Reffrence No.
            if (IsOrderRecReferenceNoChanged(MNT_ORD_NO, OrderRecReferenceNo) == true) { return "ERR:ข้อมูลเปลี่ยนแปลงขณะที่ท่านเรียกดูข้อมูล!!"; }
            //
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MNT_ORDER SET MNT_TOTAL_PRICE=@MNT_TOTAL_PRICE,ORD_CLOSE_STATE=@ORD_CLOSE_STATE,REC_REF_NO=FORMAT(GETDATE(),'ddMMyyyyHHmmss') " +
                           "WHERE MNT_ORD_NO = @MNT_ORD_NO ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@MNT_TOTAL_PRICE", MNT_TOTAL_PRICE);
                comInsertDoc1.Parameters.AddWithValue("@ORD_CLOSE_STATE", CLOSE_STATE);
                //
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                sqlQuery = "UPDATE MNT_ORDER_OPERATOR SET MNT_OFFICE_OP=@MNT_OFFICE_OP,OFFICE_OP_DTIME=GETDATE(),MNT_CLOSE_ORD=@MNT_CLOSE_ORD,CLOSE_ORD_DTIME=@CLOSE_ORD_DTIME " +
                           "WHERE MNT_ORD_NO=@MNT_ORD_NO  ";
                SqlCommand comInsertDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc2.Parameters.AddWithValue("@MNT_OFFICE_OP", USR_OPERATE);
                comInsertDoc2.Parameters.AddWithValue("@MNT_CLOSE_ORD", USR_OPERATE);
                comInsertDoc2.Parameters.AddWithValue("@CLOSE_ORD_DTIME", CloseDate);
                comInsertDoc2.Transaction = T1;
                comInsertDoc2.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_PRICE WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc1.Transaction = T1;
                comDelDoc1.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_PART WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc2 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc2.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc2.Transaction = T1;
                comDelDoc2.ExecuteNonQuery();
                //
                sqlQuery = "DELETE FROM MNT_ORDER_DESCL2 WHERE MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comDelDoc3 = new SqlCommand(sqlQuery, ObjConDB);
                comDelDoc3.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comDelDoc3.Transaction = T1;
                comDelDoc3.ExecuteNonQuery();
                //TBL_MN_COLLECTION
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_PRICE(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC,MNT_LINENO_PRICE,MNT_LINENO_SERVICER)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC,@MNT_LINENO_PRICE,@MNT_LINENO_SERVICER) ";
                    SqlCommand comInsert1 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert1.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_PRICE", (float)(DRow["MnCost"]));
                    comInsert1.Parameters.AddWithValue("@MNT_LINENO_SERVICER", DRow["MnServicer"].ToString());
                    //
                    comInsert1.Transaction = T1;
                    comInsert1.ExecuteNonQuery();
                }
                //
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION3"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_PART(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC,MNT_LINENO_AMT,MNT_PRICE)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC,@MNT_LINENO_AMT,@MNT_PRICE) ";
                    SqlCommand comInsert3 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert3.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert3.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert3.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    comInsert3.Parameters.AddWithValue("@MNT_LINENO_AMT", Convert.ToInt32(DRow["MnAmt"]));
                    comInsert3.Parameters.AddWithValue("@MNT_PRICE", Convert.ToDouble(DRow["MnPrice"]));    //ADD 20230131
                    //
                    comInsert3.Transaction = T1;
                    comInsert3.ExecuteNonQuery();
                }
                foreach (DataRow DRow in RepairDSet.Tables["TBL_MN_COLLECTION4"].Rows)
                {
                    sqlQuery = "INSERT INTO MNT_ORDER_DESCL2(MNT_ORD_NO,MNT_ORD_LINENO,MNT_LINENO_DESC)      " +
                               "                     VALUES(@MNT_ORD_NO,@MNT_ORD_LINENO,@MNT_LINENO_DESC) ";
                    SqlCommand comInsert4 = new SqlCommand(sqlQuery, ObjConDB);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                    comInsert4.Parameters.AddWithValue("@MNT_ORD_LINENO", Convert.ToInt32(DRow["IDx"].ToString()));
                    comInsert4.Parameters.AddWithValue("@MNT_LINENO_DESC", DRow["MnDesc"].ToString());
                    //
                    comInsert4.Transaction = T1;
                    comInsert4.ExecuteNonQuery();
                }
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }



      //  SELECT TOP(1000) [RecID]
      //,[MNT_ORD_NO]
      //,[Image_File]
      //,[Image_Note]
      //  FROM[TP_MNT_MGS].[dbo].[MNT_ORDER_IMG]
        public string SaveOrderImageDetail(string MNT_ORD_NO,string Image_File,string Image_FileActual,string Image_Note)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "INSERT INTO MNT_ORDER_IMG (MNT_ORD_NO,Image_File,Image_FileActual,Image_Note)    " +
                           "                    VALUES(@MNT_ORD_NO,@Image_File,@Image_FileActual,@Image_Note) ";

                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Parameters.AddWithValue("@Image_File", Image_File);
                comInsertDoc1.Parameters.AddWithValue("@Image_FileActual", Image_FileActual);
                comInsertDoc1.Parameters.AddWithValue("@Image_Note", Image_Note);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally
            {
                ObjConDB.Close();
            }
        }
        public string DeleteOrderImageReccord(string MNT_ORD_NO,int RecID)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "DELETE FROM MNT_ORDER_IMG WHERE RecID=@RecID AND MNT_ORD_NO=@MNT_ORD_NO ";
                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@RecID", RecID);
                comInsertDoc1.Parameters.AddWithValue("@MNT_ORD_NO", MNT_ORD_NO);
                comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally{ObjConDB.Close();}
        }



      //  SELECT GARAGE_ID,GARAGE_NAME,GARAGE_ADDR,GARAGE_CONTACT,GARAGE_TEL
      //  FROM[TP_MNT_MGS].[dbo].[MST_GARAGE]




        public string UpdateGarageData (int GARAGE_ID, string GARAGE_NAME,string GARAGE_ADDR,string GARAGE_CONTACT,string GARAGE_TEL)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            //SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MST_GARAGE SET GARAGE_NAME=@GARAGE_NAME,GARAGE_ADDR=@GARAGE_ADDR,GARAGE_CONTACT=@GARAGE_CONTACT,GARAGE_TEL=@GARAGE_TEL WHERE GARAGE_ID=@GARAGE_ID  ";
                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_ID", GARAGE_ID);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_NAME", GARAGE_NAME);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_ADDR", GARAGE_ADDR);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_CONTACT", GARAGE_CONTACT);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_TEL", GARAGE_TEL);
                //comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                //T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                //T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally { ObjConDB.Close(); }
        }
        public string UpdateVehicleData(int VEH_ASSET_ID, string VEH_CODE, string VEH_LICENSE,int VEH_TYPE_ID,string VEH_BRAND,string VEH_MODEL,string VEH_FUEL_SPEC,DateTime? VEH_ST_USE_DTIME)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            //SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "UPDATE MST_VEHICLE_ASSET SET VEH_CODE=@VEH_CODE,VEH_LICENSE=@VEH_LICENSE,VEH_TYPE_ID=@VEH_TYPE_ID,VEH_BRAND=@VEH_BRAND,VEH_MODEL=@VEH_MODEL,VEH_FUEL_SPEC=@VEH_FUEL_SPEC,VEH_ST_USE_DTIME=@VEH_ST_USE_DTIME WHERE VEH_ASSET_ID=@VEH_ASSET_ID  ";
                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);
                comInsertDoc1.Parameters.AddWithValue("@VEH_ASSET_ID", VEH_ASSET_ID);
                comInsertDoc1.Parameters.AddWithValue("@VEH_CODE", VEH_CODE);
                comInsertDoc1.Parameters.AddWithValue("@VEH_LICENSE", VEH_LICENSE);
                comInsertDoc1.Parameters.AddWithValue("@VEH_TYPE_ID", VEH_TYPE_ID);
                comInsertDoc1.Parameters.AddWithValue("@VEH_BRAND", VEH_BRAND);
                comInsertDoc1.Parameters.AddWithValue("@VEH_MODEL", VEH_MODEL);
                comInsertDoc1.Parameters.AddWithValue("@VEH_FUEL_SPEC", VEH_FUEL_SPEC);
                if (VEH_ST_USE_DTIME == null) { comInsertDoc1.Parameters.AddWithValue("@VEH_ST_USE_DTIME", DBNull.Value); }
                else { comInsertDoc1.Parameters.AddWithValue("@VEH_ST_USE_DTIME", VEH_ST_USE_DTIME); }
                
                //comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                //T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                //T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally { ObjConDB.Close(); }
        }
        public string AddNewGarageData(string GARAGE_NAME, string GARAGE_ADDR, string GARAGE_CONTACT, string GARAGE_TEL)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            //SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "INSERT INTO MST_GARAGE(GARAGE_NAME,GARAGE_ADDR,GARAGE_CONTACT,GARAGE_TEL) VALUES(@GARAGE_NAME,@GARAGE_ADDR,@GARAGE_CONTACT,@GARAGE_TEL)";
                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);

                comInsertDoc1.Parameters.AddWithValue("@GARAGE_NAME", GARAGE_NAME);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_ADDR", GARAGE_ADDR);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_CONTACT", GARAGE_CONTACT);
                comInsertDoc1.Parameters.AddWithValue("@GARAGE_TEL", GARAGE_TEL);
                //comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                //T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                //T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally { ObjConDB.Close(); }
        }
        public string AddNewVehData(string VEH_CODE,string VEH_LICENSE,int VEH_TYPE_ID,string VEH_BRAND,string VEH_MODEL,string VEH_FUEL_SPEC,DateTime? VEH_ST_USE_DTIME)
        {
            SqlConnection ObjConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase2);
            // Open Connection
            if (ObjConDB.State == ConnectionState.Open) { ObjConDB.Close(); }
            ObjConDB.Open();
            // เริ่มกระบวนการ Transaction
            //SqlTransaction T1 = ObjConDB.BeginTransaction();

            string sqlQuery = "";
            try
            {
                sqlQuery = "INSERT INTO MST_VEHICLE_ASSET(VEH_CODE,VEH_LICENSE,VEH_TYPE_ID,VEH_BRAND,VEH_MODEL,VEH_FUEL_SPEC,VEH_ST_USE_DTIME) VALUES(@VEH_CODE,@VEH_LICENSE,@VEH_TYPE_ID,@VEH_BRAND,@VEH_MODEL,@VEH_FUEL_SPEC,@VEH_ST_USE_DTIME)";
                SqlCommand comInsertDoc1 = new SqlCommand(sqlQuery, ObjConDB);

                comInsertDoc1.Parameters.AddWithValue("@VEH_CODE", VEH_CODE);
                comInsertDoc1.Parameters.AddWithValue("@VEH_LICENSE", VEH_LICENSE);
                comInsertDoc1.Parameters.AddWithValue("@VEH_TYPE_ID", VEH_TYPE_ID);
                comInsertDoc1.Parameters.AddWithValue("@VEH_BRAND", VEH_BRAND);
                //
                comInsertDoc1.Parameters.AddWithValue("@VEH_MODEL", VEH_MODEL);
                comInsertDoc1.Parameters.AddWithValue("@VEH_FUEL_SPEC", VEH_FUEL_SPEC);
                if (VEH_ST_USE_DTIME == null) { comInsertDoc1.Parameters.AddWithValue("@VEH_ST_USE_DTIME", DBNull.Value); }
                else { comInsertDoc1.Parameters.AddWithValue("@VEH_ST_USE_DTIME", VEH_ST_USE_DTIME); }

                //comInsertDoc1.Transaction = T1;
                comInsertDoc1.ExecuteNonQuery();
                //
                //T1.Commit();
                return "TRU:---";
            }
            catch (Exception ex)
            {
                //T1.Rollback();
                return "ERR:" + ex.Message;
            }
            finally { ObjConDB.Close(); }
        }


    }
}