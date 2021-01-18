using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMobi.Pages
{
    public partial class NotFound : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();


        protected void Page_Load(object sender, EventArgs e)
        {

            string ini = Request.QueryString["ini"];

            int ret = MyProcess.LoadIniFile(ini);

            this.hlContinue.NavigateUrl = QRMobi.OnRedirectURL;
            this.hlContinue.Target = "_self";
        }
    }
}