using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMobi.Account
{
    public partial class Login : System.Web.UI.Page
    {

        string returnurl = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            string temp = Request.QueryString["ReturnUrl"];

            returnurl = temp.Replace('@', '&');

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            string username = this.LoginUser.UserName.ToString();
            string password = this.LoginUser.Password.ToString();

            //Functions MyFunc = new Functions();

            //Check username field is not empty 
            if (username == "")
            {

                //this.ErrorMessage.Visible = true;
                //this.FailureText.Text = "Email required.";
                return;
            }

            //check password field is not empty 
            if (password == "")
            {

                //this.ErrorMessage.Visible = true;
                //this.FailureText.Text = "Password required.";

                return;
            }

            //SQL Injection Protection
            Regex SpecialCharacters = new Regex("[~!#$%^*()+=|\\{}'<>/?]");
            if (SpecialCharacters.IsMatch(username))
            {
                //this.ErrorMessage.Visible = true;
                //this.FailureText.Text = "Invalid characters used.";

                return;
            }

            MembershipUser user;
            try
            {
                user = Membership.GetUser(username);
            }
            catch (Exception ee)
            {
                user = null;
            }

            //Validate username & password
            if (Membership.ValidateUser(username,password))
            {
                //Login for valid user
                FormsAuthentication.RedirectFromLoginPage(username, false);

                //Log it
                //MyFunc.WriteAuditRecord("CIP", "", "", this.User_Name.Text, "LOGIN", "SUCCESS", this.User_Name.Text);

                string hostname = HttpContext.Current.Request.Url.Host;
                string authority = HttpContext.Current.Request.Url.Authority;

                //Response.Redirect("http://"+authority+returnurl);

                Response.Redirect(returnurl);

            }
            //valid user and is not approved
            else if (user != null && !user.IsApproved)
            {

                //this.ErrorMessage.Visible = true;
                //this.FailureText.Text = "Account has not yet been approved.";

                //Log it
                //MyFunc.WriteAuditRecord("CIP", "", "", this.User_Name.Text, "LOGIN", "FAILED - Not Approved", this.User_Name.Text);

            }

            //valid user and is locked out
            else if (user != null && user.IsLockedOut)
            {
                // Error - locked out
                //this.FailureText.Text = "Your account has been locked. Please email <a href= \"mailto:techsupport@datatag.co.uk\"> techsupport@datatag.co.uk</a>.";
                //this.ErrorMessage.Visible = true;

                //Log it
                //MyFunc.WriteAuditRecord("CIP", "", "", this.User_Name.Text, "LOGIN", "FAILED - Locked", this.User_Name.Text);


            }
            else //invalid user
            {
                // Error - invalid Login
                //this.FailureText.Text = "Incorrect email, password combination. Please try again!";
                //this.ErrorMessage.Visible = true;
                //this.User_Name.Text = "";
                //this.Password.Text = "";
            }
        }
    }
}
