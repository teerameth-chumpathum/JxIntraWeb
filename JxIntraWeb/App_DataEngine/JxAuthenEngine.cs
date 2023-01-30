using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JxIntraWeb.App_DataEngine
{

    public class JxAuthenEngine
    {
        public string LogInAuthReconsile(string strAccountLog, string strPWDLog, string strTerminalMACAddr, string strTeminal_Prog_Info)
        {
            // 
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase1);
            string strSysMessage = "ERR:";
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                SqlCommand comObj = new SqlCommand();
                comObj.CommandText = "uspU1_JPXAuthentication";
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Connection = objConDB;
                // Input	
                SqlParameter PI1 = new SqlParameter("@strAccountLogIn", strAccountLog);
                PI1.Direction = ParameterDirection.Input;
                PI1.DbType = DbType.String;
                SqlParameter PI2 = new SqlParameter("@strPasswordLogIn", strPWDLog);
                PI2.Direction = ParameterDirection.Input;
                PI2.DbType = DbType.String;
                SqlParameter PI3 = new SqlParameter("@strTeminalMacAddr", strTerminalMACAddr);
                PI3.Direction = ParameterDirection.Input;
                PI3.DbType = DbType.String;
                SqlParameter PI4 = new SqlParameter("@strTeminal_Prog_Info", strTeminal_Prog_Info);
                PI4.Direction = ParameterDirection.Input;
                PI4.DbType = DbType.String;
                // Outpute
                SqlParameter POut1 = new SqlParameter("@strRetponseMsg", SqlDbType.NVarChar);
                POut1.Direction = ParameterDirection.Output;
                POut1.Size = 100;
                // Return
                SqlParameter PO_RETURN = new SqlParameter("RETURN", SqlDbType.Int);
                PO_RETURN.Direction = ParameterDirection.ReturnValue;
                // 
                comObj.Parameters.Add(PI1);
                comObj.Parameters.Add(PI2);
                comObj.Parameters.Add(PI3);
                comObj.Parameters.Add(PI4);
                comObj.Parameters.Add(POut1);
                // --------------------------------Excecute
                comObj.ExecuteNonQuery();
                // 
                string strOutPut1Value = POut1.Value.ToString();
                strSysMessage = strOutPut1Value;
            }
            catch (SqlException ex)
            {
                strSysMessage = "ERR:" + ex.Message;
            }
            finally
            {
                objConDB.Close();
            }
            //
            return strSysMessage;
        }

        public DataSet GetAccountInfo(int intAccID)
        {
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase1);
            try
            {
                if (objConDB.State == System.Data.ConnectionState.Open) { objConDB.Close(); }
                objConDB.Open();
                // 
                string strsqlQuery1 = "SELECT A.USR_ID,B.USR_CODE,B.USR_FULL_NAME,B.USR_CONTACT_DETAIL,A.USR_INILOG_PWDCHANGE,A.USR_ACC_IMMORTAL,A.USR_ACC_EXISTDAY,        "
                                    + "       A.USR_ACC_EXPIRE_DTIME,A.USR_ACC,A.USR_IDENTIFIER_MODE,A.USR_IDENTIFIER_ID,A.USR_ACT_STATUS,A.E_MAIL,A.PHONE_NO,A.REC_REF_NO, "
                                    + "       A.GRP_ID,ISNULL((SELECT TOP(1) GRP_NAME     FROM JPX_GROUP     WHERE GRP_ID=A.GRP_ID),'E.Relation')       AS 'GP_NAME',       "
                                    + "       B.SITE_CODE,ISNULL((SELECT TOP(1) BR_NAME   FROM MA_BRANCH     WHERE BR_CODE=B.SITE_CODE),'E.Relation') AS 'ST_NAME',         "
                                    + "       B.DEPT_CODE,ISNULL((SELECT TOP(1) DEPT_NAME FROM MA_DEPARTMENT WHERE DEPT_CODE=B.DEPT_CODE),'E.Relation') AS 'DE_NAME'        "
                                    + "FROM   JPX_GROUP_USER A INNER JOIN JPX_GROUP_USER_INFO B ON A.USR_ID = B.USR_ID   "
                                    + "WHERE  (A.USR_ID = @USR_ID)                                                       ";

                string strsqlQuery2 = "SELECT ISNULL((SELECT TOP(1) TRANS_NO  FROM  JPX_CMP_LOG  WHERE  (LOG_EXIT_BY = 'U') AND (USR_ID = @USR_ID)),0) AS 'TID' ";
                string strsqlQuery3 = "SELECT A.USR_ID, A.GRP_ID,B.*  FROM  JPX_GROUP_USER A INNER JOIN JPX_GROUP_TIMESCHU B ON A.GRP_ID = B.GRP_ID WHERE (A.USR_ID = @USR_ID)  ORDER BY B.IRX ";
                string strsqlQuery4 = "SELECT A.USR_ID, A.GRP_ID,B.GRP_NAME, B.GRP_ACTIVE,B.GRP_USE_MAC_RULE, B.GRP_USE_TIME_RULE,B.GRP_USE_MENU_RULE, B.REC_REF_NO "
                                    + "FROM JPX_GROUP_USER A INNER JOIN  JPX_GROUP B ON A.GRP_ID = B.GRP_ID  WHERE(A.USR_ID = @USR_ID) ";
                string strsqlQuery5 = "SELECT A.USR_ID, A.GRP_ID,B.MENU_CODE,B.SELECT_ENABLED,B.UPDATE_ENABLED, B.DELETE_ENABLED, B.INSERT_ENABLED "
                                    + "FROM JPX_GROUP_USER A INNER JOIN JPX_GROUP_MENU B ON A.GRP_ID = B.GRP_ID  WHERE(A.USR_ID = @USR_ID) ";
                // 
                SqlCommand comDBX1 = new SqlCommand(strsqlQuery1, objConDB);
                comDBX1.Parameters.AddWithValue("@USR_ID", intAccID);
                SqlDataReader DReader1 = comDBX1.ExecuteReader();
                DataTable DTable1 = new DataTable("TB_ACC_INFO");
                DTable1.Load(DReader1);
                // 
                SqlCommand comDBX2 = new SqlCommand(strsqlQuery2, objConDB);
                comDBX2.Parameters.AddWithValue("@USR_ID", intAccID);
                SqlDataReader DReader2 = comDBX2.ExecuteReader();
                DataTable DTable2 = new DataTable("TB_ACC_LOG");
                DTable2.Load(DReader2);
                // 
                SqlCommand comDBX3 = new SqlCommand(strsqlQuery3, objConDB);
                comDBX3.Parameters.AddWithValue("@USR_ID", intAccID);
                SqlDataReader DReader3 = comDBX3.ExecuteReader();
                DataTable DTable3 = new DataTable("TB_ACC_TIME");
                DTable3.Load(DReader3);
                // 
                SqlCommand comDBX4 = new SqlCommand(strsqlQuery4, objConDB);
                comDBX4.Parameters.AddWithValue("@USR_ID", intAccID);
                SqlDataReader DReader4 = comDBX4.ExecuteReader();
                DataTable DTable4 = new DataTable("TB_ACC_GRULE");
                DTable4.Load(DReader4);
                //
                SqlCommand comDBX5 = new SqlCommand(strsqlQuery5, objConDB);
                comDBX5.Parameters.AddWithValue("@USR_ID", intAccID);
                SqlDataReader DReader5 = comDBX5.ExecuteReader();
                DataTable DTable5 = new DataTable("TB_ACC_MENU");
                DTable5.Load(DReader5);
                //
                DataSet DSet = new DataSet();
                DSet.Tables.Add(DTable1.Copy());
                DSet.Tables.Add(DTable2.Copy());
                DSet.Tables.Add(DTable3.Copy());
                DSet.Tables.Add(DTable4.Copy());
                DSet.Tables.Add(DTable5.Copy());
                // 
                DReader1.Close();
                DReader2.Close();
                DReader3.Close();
                DReader4.Close();
                DReader5.Close();
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

        public string ApplicationLogout_ClearLogPool(int intAccID)
        {
            // Start Trasaction
            SqlConnection objConDB = new SqlConnection(JxDatabaseConfig.ScriptConnectAppDBase1);
            string sqlQuery = string.Empty;
            // Open Connection
            if (objConDB.State == ConnectionState.Open) { objConDB.Close(); }
            objConDB.Open();
            try
            {
                sqlQuery = "UPDATE  JPX_CMP_LOG SET LOG_EXIT_BY='L', TRANS_DTIME_EXIT=GETDATE()  WHERE (USR_ID = @USR_ID) ";
                SqlCommand comLogOut = new SqlCommand(sqlQuery, objConDB);
                comLogOut.Parameters.AddWithValue("@USR_ID", intAccID);
                comLogOut.ExecuteNonQuery();
                // 
                return "TRU:---";
            }
            catch (Exception ex)
            {
                return "ERR:" + ex.Message;
            }
            finally
            {
                // ปิดการเชื่อมต่อ
                objConDB.Close();
            }
        }


    }
}