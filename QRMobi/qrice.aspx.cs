using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace QRMobi
{
    public partial class Webice : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            int ret;
            bool found = false;

            ret = MyProcess.LoadIniFile("QRIce.ini");

            string url = "top.html";
            string fullURL = "window.open('" + url + "', '_self', '' );";
           

            //Connect to SQL Database
            conn = new SqlConnection(QRMobi.SQLConn);

            try
            {
                conn.Open();

            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }

            //string key = "EC06B2YB2B";
            //string code = "406594362";

            //https://localhost:62229/qrice.aspx?id=EC06B2YB2BB&code=406594362

            //https://www.datatag.mobi/qrice.aspx?id=EC54C3YB2B&code=401190389

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            if (key != "" && key != null)
            {
                string SQLComm = "SELECT * from vMemSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }

                if (found)
                {
                    reader.Read();

                    string fullname;
                    string middlename;

                    tbUsername.Text = reader["Username"].ToString().Trim();

                    middlename = reader["Middlename"].ToString().Trim();

                    if (middlename == "")
                    {
                        fullname = reader["Forename"].ToString().Trim() + " "+ reader["Lastname"].ToString().Trim();
                    }
                    else
                    {
                        fullname = reader["Forename"].ToString().Trim() + " "+reader["Middlename"].ToString().Trim()+ " "+reader["Lastname"].ToString().Trim();
                    }

                    this.tbID.Text = reader["IDNumber"].ToString().Trim();
                    this.tbDOB.Text = reader["DOB"].ToString().Substring(0, 10);
                    this.tbFullName.Text = fullname;
                    
                    conn.Close();

                }
                else
                {
                   
                    conn.Close();

                    //No Codes so just direct to default page
                    Response.Redirect(QRMobi.OnRedirectURL);
                }
            }
            else
            {
                //No Codes so just direct to default page
                Response.Redirect(QRMobi.OnRedirectURL);
            }
            

        }
    }
}