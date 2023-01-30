using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
namespace JxIntraWeb.App_DataEngine
{
    public class ValidatorJx
    {
        //public const string ApplicationCharAccPwdCommitAlias = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*+-";
        //public bool ApplicationCharAccPwdCommit(string strTextInput)
        //{
        //    string charactersAllowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*+-";
        //    var insTextBox = new TextBox();
        //    insTextBox.Text = strTextInput;
        //    string theText = strTextInput;
        //    string Letter;
        //    int SelectionIndex = insTextBox.SelectionStart;
        //    bool boolCharAllow = true;
        //    for (int x = 0, loopTo = insTextBox.Text.Length - 1; x <= loopTo; x++)
        //    {
        //        Letter = insTextBox.Text.Substring(x, 1);
        //        if (charactersAllowed1.Contains(Letter) == false)
        //        {
        //            boolCharAllow = false;
        //            break;
        //        }
        //    }
        //    return boolCharAllow;
        //}

        //public const string ApplicationCharNumberIntCommitAlias = "1234567890";
        //public bool ApplicationCharNumberIntCommit(string strTextInput)
        //{
        //    string charactersAllowed1 = "1234567890";
        //    var insTextBox = new TextBox();
        //    insTextBox.Text = strTextInput;
        //    string theText = strTextInput;
        //    string Letter;
        //    int SelectionIndex = insTextBox.SelectionStart;
        //    bool boolCharAllow = true;
        //    for (int x = 0, loopTo = insTextBox.Text.Length - 1; x <= loopTo; x++)
        //    {
        //        Letter = insTextBox.Text.Substring(x, 1);
        //        if (charactersAllowed1.Contains(Letter) == false)
        //        {
        //            boolCharAllow = false;
        //            break;
        //        }
        //    }
        //    return boolCharAllow;
        //}

        public static bool IsEmptyDSet(DataSet dataSet)
        {
            //Update: Since a DataTable could contain deleted rows RowState = Deleted, 
            //depending on what you want to achive, it could be a good idea to check 
            //the DefaultView instead(which does not contain deleted rows).
            return !dataSet.Tables.Cast<DataTable>().Any(x => x.DefaultView.Count > 0);
        }
    }
}