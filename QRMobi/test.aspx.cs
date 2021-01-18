using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMobi
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "getLocation()", true);

           
            //Timer1_Tick(null, null);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "getLocation()", true);

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "displaymap()", true);
        }


        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {



        }

    }
}