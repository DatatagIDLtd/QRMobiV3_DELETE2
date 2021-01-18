using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace QRMobi
{
    public partial class Webecv : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            //return;

            int ret;
            bool found = false;
            string iniFile = "QRCesarECVV3.ini";

            string imgServerURL = Properties.Settings.Default.ImageServerURL;

           
            //ClientScript.RegisterStartupScript(GetType(), "loc", "getLocation();", true);

            ret = MyProcess.LoadIniFile(iniFile);

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

            //https://www.datatag.mobi/qrecv.aspx?id=7A53C&code=BB36BB30-C3EF-4580-9AA0-38DDDD28FAF5

            //https://alpha.datatag.mobi/qr/qrecv.aspx?id=A0000&code=4187F7D7-4A63-476C-B3B3-6ED554321C5A


            string secret = "";
            string CesarQRCode = "";
            string InstallationID = "";
            string DPF = "";

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

           
            //if (key == "" || key == null)
            //{
            //    key = "A0000";
            //    code = "4187F7D7-4A63-476C-B3B3-6ED554321C5A";
            //}

            if (key != "" && key != null)
            {
                //string SQLComm = "SELECT Make,Model,Colour,EngineNum,Serial_ShortVIN,MemberNum,AssetDesc from vVKSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                string SQLComm = "SELECT Make,Model,ECVCode,Fuel,Stage,EngineNumber,LegacyRandomNumber,CesarId,ECVInstallationID,DPFFitted,CesarQRCode from lvECVWithCesar where ECVCode = '" + key + "' and QRCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }
               
                if (found)
                {
                    reader.Read();

                    this.lbID.Text =  reader["ECVCODE"].ToString().Trim();
                    this.lbMake.Text = reader["Make"].ToString().Trim();
                    this.lbModel.Text = reader["Model"].ToString().Trim();
                    this.lbEngNo.Text = reader["EngineNumber"].ToString().Trim();
                    this.lbFuel.Text = reader["Fuel"].ToString().Trim();
                    this.lbCesarID.Text = reader["CesarID"].ToString().Trim();
                    this.lbStage.Text = reader["Stage"].ToString().Trim();


                    if (this.lbCesarID.Text == "") this.lbCesarID.Text = "-";
                    if (this.lbMake.Text == "") this.lbMake.Text = "-";
                    if (this.lbModel.Text == "") this.lbModel.Text = "-";
                    if (this.lbEngNo.Text == "") this.lbEngNo.Text = "-";
                    if (this.lbFuel.Text == "") this.lbFuel.Text = "-";
                    if (this.lbStage.Text == "") this.lbStage.Text = "-";

                    secret = reader["LegacyRandomNumber"].ToString();
                    CesarQRCode = reader["CesarQRCode"].ToString();

                    InstallationID = reader["ECVInstallationID"].ToString().Trim();
                    DPF = reader["DPFFitted"].ToString().Trim();

                    if (lbStage.Text == "E" && DPF=="False")
                    {
                        lbDPFFitted.Text = "N/A";
                    }
                    else if (DPF == "False")
                    {
                        
                        lbDPFFitted.Text = "NO";

                    }
                    else if (lbStage.Text != "E" && DPF=="True")
                    {
                        lbDPFFitted.Text = "YES";
                    }

                    //Stage Images
                   
                    switch (lbStage.Text.Trim())
                    {
                        case "E":

                            imgECV.ImageUrl = imgServerURL + "/Cesar/ECV/ECV.png";

                            break;

                        case "4":

                            imgECV.ImageUrl = imgServerURL + "/Cesar/ECV/ECV4.png";

                            break;

                        case "5":

                            imgECV.ImageUrl = imgServerURL + "/Cesar/ECV/ECV5.png";

                            break;

                        case "3b":

                            imgECV.ImageUrl = imgServerURL + "/Cesar/ECV/ECV3b.png";

                            break;

                        default:

                            imgECV.ImageUrl = imgServerURL+"/Cesar/cesar-logo.png";

                            break;

                    }

                    this.lbID.Text = key;

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

                    if (secret != "")
                    {
                        ibAsset.PostBackUrl = "~/qrces.aspx?id=" + lbCesarID.Text.Trim() + "&code=" + secret;
                    }
                    else
                    {
                        ibAsset.PostBackUrl = "~/qrces.aspx?id=" + lbCesarID.Text.Trim() + "&code=" + CesarQRCode;
                    }


                    conn.Close();

                }
                else
                {
                   
                    conn.Close();

                    //No Codes so just direct to default page
                    //Response.Redirect(QRMobi.OnRedirectURL);
                    //Response.Redirect("http://www.datatag.mobi/cesarmicro/home.aspx?id=" + this.lbID.Text+"&source=H");
                    //Response.Redirect("http://www.datatag.mobi/cesarmicro/forms/home.aspx?id=" + key);

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

        protected void btnLocate_Click(object sender, EventArgs e)
        {

        }

        protected void ibHire_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Write out long lat
            Processes MyProcess = new Processes();

            decimal dLong = Convert.ToDecimal(this.tbLong.Text.Trim());
            decimal dLat = Convert.ToDecimal(this.tbLat.Text.Trim());

            MyProcess.WriteLongLatPlus(this.lbCesarID.Text, dLong, dLat, this.lbID.Text, "QRECV");

            Timer1.Enabled = false;
        }
    }
}