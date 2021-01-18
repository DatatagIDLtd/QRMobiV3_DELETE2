using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Web.UI.HtmlControls;

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
            string iniFile = "QRCesarV3.ini";

            string SQLComm = "";

            string imgServerURL = Properties.Settings.Default.ImageServerURL;

            this.ibECV.Visible = false;

            ret = MyProcess.LoadIniFile(iniFile);

            string url = "top.html";
            string fullURL = "window.open('" + url + "', '_self', '' );";

            //https://www.datatag.mobi/qrces.aspx?id=14CE5R&code=154033366

            //https://alpha.datatag.mobi/qr/qrces.aspx?id=00AL7M&code=158180808

            //https://alpha.datatag.mobi/qr/qrces.aspx?id=00AZ3H&code=8236AD11-7B0A-4E0F-9FED-F2604318BD2F

            //https://www.datatag.mobi/qrces.aspx?id=50AL7N&code=159776485

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

            //string key = "50AL7N";
            //string code = "154033366";

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            //key = "00AZ3H";
            //code = "156420887";
            //code = "8236AD11-7B0A-4E0F-9FED-F2604318BD2F";

            //Live Hitashi
            //key = "61AZ3M";
            //code = "C57896FE-6C4D-4A18-B898-8C81035934D0";

        //key = "00AZ3H";
        //code = "156420887";

        https://www.datatag.mobi/qrces.aspx?id=61AZ3M&code=C57896FE-6C4D-4A18-B898-8C81035934D0

            Guid x;
            bool UseQR = false;
            if (Guid.TryParse(code, out x))
            {
                UseQR = true;
            }

            //if (key == "50AL7N") {

            //    key = "14CE5R";
            //    code = "154033366";

            // }

            //if (key == "" || key == null)
            //{
            //    key = "50AL7N";
            //    code = "159776485";
            // }

            string QRCode = "";
            string ECVCode = "";

            string InstallationID = "";

            if (key != "" && key != null)
            {
                //Keep for a bit
                //string SQLComm = "SELECT Make,Model,Colour,EngineNum,Vin_Chassis,HOSDBCategory from vVKSEC where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                if (!UseQR)
                {
                    SQLComm = "SELECT Make,Model,Colour,Engine_Number,Vin,HOSDB_Category from vAssetOwnerCESARLegacy where CESAR_ID = '" + key + "' and LegacyRandomNumber = '" + code + "'";
                }
                else
                {
                    SQLComm = "SELECT Make,Model,Colour,Engine_Number,Vin,HOSDB_Category from vAssetOwnerCESARLegacy where CESAR_ID = '" + key + "' and QRCode = '" + code + "'";
                }

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e2)
                {
                    Response.Write("There was a problem");
                    return;
                }


                if (reader.HasRows)
                {
                    found = true;
                }


                if (found)
                {
                    reader.Read();

                    //if (key == "50AL7N")
                    //{
                    //    this.lbID.Text = "14CE5R"; 
                    //}
                    //else
                    //{
                    //    this.lbID.Text = key;
                    //}

                    this.lbID.Text = key;
                    this.lbMake.Text = reader["Make"].ToString().Trim();
                    this.lbModel.Text = reader["Model"].ToString().Trim();
                    this.lbColour.Text = reader["Colour"].ToString().Trim();
                    this.lbEngine.Text = reader["Engine_Number"].ToString().Trim();
                    this.lbSerial.Text = reader["VIN"].ToString().Trim();
                    this.lbHOSDBCategory.Text = reader["HOSDB_Category"].ToString().Trim();
                    

                    if (lbMake.Text == "") lbMake.Text = "N/A";
                    if (lbModel.Text == "") lbModel.Text = "N/A";
                    if (lbColour.Text == "") lbColour.Text = "N/A";
                    if (lbEngine.Text == "") lbEngine.Text = "N/A";
                    if (lbSerial.Text == "") lbSerial.Text = "N/A";
                    
                    if (lbHOSDBCategory.Text == "") lbHOSDBCategory.Text = "-";

                    string tmpMake = lbMake.Text.Replace(" ", "");

                    //Deal with the image
                    string urlCheck = imgServerURL + "/oemlogo/" + tmpMake + ".png";

                    try
                    {
                        new System.Net.WebClient().DownloadData(urlCheck);

                        this.imgAsset.ImageUrl = urlCheck;

                    }
                    catch (System.Net.WebException ee)
                    {
                        this.imgAsset.ImageUrl = imgServerURL + "/oemlogo/noimage.jpg";
                    }
                

                    lbECV.Text = "NO";

                    reader.Close();

                    //Now check for ECV Information Available
                    SQLComm = "SELECT Make,Model,ECVCode,Fuel,Stage,EngineNumber,CesarId,QRCode,ECVInstallationID from lvECVWithCesar where CesarID = '" + key + "'";

                    cmd.CommandText = SQLComm;

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        this.lbECVCode.Text = reader["ECVCode"].ToString().Trim();
                        QRCode = reader["QRCode"].ToString().Trim();
                        InstallationID = reader["ECVInstallationID"].ToString().Trim();

                        this.ibECV.Visible = true;

                        lbECV.Text = "YES";

                        this.ibECV.PostBackUrl = "~/qrecv.aspx?id=" + lbECVCode.Text + "&code=" + QRCode;
                    }

                    reader.Close();

                    //Pull in some links

                    string URL = "";
                    string ButtonCode = "";

                    SQLComm = "SELECT URL,ButtonCode from ECVLinks where ECVInstallationID = '" + InstallationID + "'";

                    cmd.CommandText = SQLComm;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                    
                        URL = reader["URL"].ToString();
                        ButtonCode = reader["ButtonCode"].ToString();

                        switch (ButtonCode)
                        {
                            case "1":

                                //ibSafety.PostBackUrl = URL;
                              
                                //OnClientClick = "target='blank'"

                                break;

                            case "2":

                                //ibUser.PostBackUrl = URL;

                                break;

                            case "3":

                                //ibParts.PostBackUrl = URL;

                                break;

                            case "4":

                                ibDealer.PostBackUrl = URL;

                                break;

                            case "5":

                                break;

                            case "6":

                                //ibService.PostBackUrl = URL;

                                break;


                        }

                      
                    } // END While

                    reader.Close();

                    conn.Close();

                }
                else
                {

                    conn.Close();

                    //No Codes so just direct to default page
                    //Response.Redirect(QRMobi.OnRedirectURL);
                    Response.Redirect("~/Pages/NotFound.aspx?ini=" + iniFile);
                }
            }
            else
            {
                //No Codes so just direct to default page
                //Response.Redirect(QRMobi.OnRedirectURL);
                Response.Redirect("~/Pages/NotFound.aspx?ini=" + iniFile);
            }


        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Write out long lat
            Processes MyProcess = new Processes();

            //ClientScript.RegisterStartupScript(GetType(), "loc", "getLocation();", true);

            decimal dLong = Convert.ToDecimal(this.tbLong.Text.Trim());
            decimal dLat = Convert.ToDecimal(this.tbLat.Text.Trim());

            MyProcess.WriteLongLatPlus(this.lbID.Text, dLong, dLat, this.lbECVCode.Text, "QRCES");

            this.Timer1.Enabled = false;
        }
    }
}