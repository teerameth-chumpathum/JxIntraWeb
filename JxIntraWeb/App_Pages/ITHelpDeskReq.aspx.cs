using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JxIntraWeb.App_Pages
{
    public partial class ITHelpDeskReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }  
        }

        protected void CmdAct5_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void CmdAct4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void CmdAct1_Click(object sender, EventArgs e)
        {

        }

        protected void CmdAct3_Click(object sender, EventArgs e)
        {

        }
    }
}