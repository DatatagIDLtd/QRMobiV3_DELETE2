using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace QRMobi
{
    public partial class Webcsr : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            int ret;
            bool found = false;

            ret = MyProcess.LoadIniFile("QRCesar.ini");

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

            //string key = "33AN2H";
            //string code = "111111";

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,EngineNum,Vin_Chassis from vODVSec where CesarID = '" + key + "' and SecretCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }
                else
                {
                    reader.Close();

                    SQLComm = "SELECT Make,Model,Colour,EngineNum,Vin_Chassis from vODVSecMU where CesarID = '" + key + "' and SecretCode = '" + code + "'";

                    cmd = new SqlCommand(SQLComm, conn);

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows) { found = true; }
                }

                if (found)
                {
                    reader.Read();

                    this.lbID.Text = "ID";
                    this.lbMake.Text = "Make";
                    this.lbModel.Text = "Model";
                    this.lbColour.Text = "Colour";
                    this.lbEngine.Text = "Engine No";
                    this.lbVinSer.Text = "Vin/Ser";

                    this.tbMake.Text = reader["Make"].ToString().Trim();
                    this.tbModel.Text = reader["Model"].ToString().Trim();
                    this.tbColours.Text = reader["Colour"].ToString().Trim();
                    this.tbEngine.Text = reader["EngineNum"].ToString().Trim();
                    this.tbVINSER.Text = reader["VIN_Chassis"].ToString().Trim();

                    this.tbType.Text = "";

                    this.tbID.Text = key;

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