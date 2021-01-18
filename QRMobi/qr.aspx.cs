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
    
    public partial class qr
        : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            //return;

            int ret;
            bool found = false;

            string MemberNum = "";

            ret = MyProcess.LoadIniFile("QRMaster.ini");

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

            string key = Request.QueryString["id"];

            //  UK65A7AC  - Datatag dummy registration code - an actual kit which has been registered on the system
            // KTM - Datatag registered default kit - MasterMX marketing version
            //  string key = "UK65A7AC";
            // Kawasaki (real database example)
            //  string key = "UK00A4AD";
            // Honda (real database example)
            //   string key = "UK12A3AS";
            // Triumph (real database example)
            //     string key = "UK14C9AX";
            //     string key = "UK04H7AN";
            // Suzuki (real database example)
            //      string key = "UK21B3AF";
            // Ducati (real database example)
            //     string key = "UK35D6AB";
            // Yamaha (real database example)
            //  string key = "UK14A4AE";
            // Buell (real database example)
            //   string key = "UK13D8AB";
            // Daelim (real database example)
            //      string key = "UK47G4AB";
            // BMW (real database example)
            //   string key = "UK16K3AP";
            // Harley-Davidson (real database example)
            // string key = "UK93D7AD";
            // Indian (real database example)
            //   string key = "UK15T2AK";
            // Piaggio (real database example)
            //   string key = "UK71H3AK";
            // Husqvarna (real database example)
            //       string key = "UK77F3AD";
            // Sym (real database example)
            //     string key = "UK36J6AH";


            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,EngineNum,VIN,VRN from VehUKQR where IDNumber = '" + key + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }

                if (found)
                {
                    reader.Read();

                    this.lbID.Text = reader["Make"].ToString().Trim();
                    this.lbVRM.Text = reader["VRN"].ToString().Trim();
                    this.lbMake.Text = reader["Make"].ToString().Trim();
                    this.lbModel.Text = reader["Model"].ToString().Trim();
                    this.lbColour.Text = reader["Colour"].ToString().Trim();
                    this.lbEngine.Text = reader["EngineNum"].ToString().Trim();
                    this.lbSerial.Text = reader["VIN"].ToString().Trim();

                    if (lbVRM.Text == "") this.lbVRM.Text = "-";
                    if (lbEngine.Text == "") this.lbEngine.Text = "-";
                    if (lbSerial.Text == "") this.lbSerial.Text = "-";
                    if (lbColour.Text == "") this.lbColour.Text = "-";
                    if (lbMake.Text == "") this.lbMake.Text = "-";
                    if (lbModel.Text == "") this.lbModel.Text = "-";

                    this.lbID.Text = key;
                    reader.Close();

                    //write record to sql database MSQRAccess (A QR scan has been made or a button has been pressed)
                    if (this.lbType.Text == "-")
                    {
                        string SQLComm3 = "INSERT INTO MSQRAccess (IDNumber,Lat,Long) values ('" + this.lbID.Text.ToUpper() + "','" + this.lat.Text.ToUpper() + "','" + this.@long.Text.ToUpper() + "')";
                        System.Diagnostics.Debug.WriteLine(SQLComm3);
                        var cmdWriteOut = new SqlCommand(SQLComm3, conn);
                        SqlDataReader readerWriteOut = cmdWriteOut.ExecuteReader();
                        readerWriteOut.Close();
                        this.lbType.Text = "Master Scheme";

                    }


                    //compare Make with QROptions table to see if bespoke links are available or not
                    string SQLComm2 = "SELECT Make, PicImg, BtnLeftImg, BtnLeftURL, BtnMiddleImg, BtnMiddleURL,BtnRightImg,Link1LeftURL,Link1RightURL,Link2LeftURL,Link2RightURL,Link3LeftURL,Link3RightURL,Link4LeftURL,Link4RightURL,Link1LeftImg,Link1RightImg,Link2LeftImg,Link2RightImg,Link3LeftImg,Link3RightImg,Link4LeftImg,Link4RightImg  from MSQROptions where Make = '" + this.lbMake.Text.ToUpper() +  "'";
                    System.Diagnostics.Debug.WriteLine(SQLComm2);
                    var cmdOptions = new SqlCommand(SQLComm2, conn);
                    SqlDataReader readerQROptions = cmdOptions.ExecuteReader();
                    if (readerQROptions.HasRows)
                    {
                        readerQROptions.Read();

                        //main picture image
                        this.imgAsset.ImageUrl = readerQROptions["PicImg"].ToString().Trim();
                   
     
                        //main buttons
                        this.ibHire.ImageUrl = readerQROptions["BtnLeftImg"].ToString().Trim();
                        this.ibHire.OnClientClick = "dolink('" + readerQROptions["BtnLeftURL"].ToString().Trim() + "')";
                        this.ibStolen.ImageUrl = readerQROptions["BtnMiddleImg"].ToString().Trim();
                        this.ibStolen.OnClientClick = "dolink('" + readerQROptions["BtnMiddleURL"].ToString().Trim() + "')";
                        this.ibScan.ImageUrl = readerQROptions["BtnRightImg"].ToString().Trim();
                        this.ibScan.OnClientClick = "doalert('contact Datatag to discuss enabling the theft check functionality')";

                        //other button links
                        this.ib1Left.ImageUrl = readerQROptions["Link1LeftImg"].ToString().Trim();
                        this.ib1Right.ImageUrl = readerQROptions["Link1RightImg"].ToString().Trim();
                        this.ib2Left.ImageUrl = readerQROptions["Link2LeftImg"].ToString().Trim();
                        this.ib2Right.ImageUrl = readerQROptions["Link2RightImg"].ToString().Trim();
                        this.ib3Left.ImageUrl = readerQROptions["Link3LeftImg"].ToString().Trim();
                        this.ib3Right.ImageUrl = readerQROptions["Link3RightImg"].ToString().Trim();
                        this.ib4Left.ImageUrl = readerQROptions["Link4LeftImg"].ToString().Trim();
                        this.ib4Right.ImageUrl = readerQROptions["Link4RightImg"].ToString().Trim();

                        this.ib1Left.OnClientClick = "dolink('" + readerQROptions["Link1LeftURL"].ToString().Trim() + "')";
                        this.ib1Right.OnClientClick = "dolink('" + readerQROptions["Link1RightURL"].ToString().Trim() + "')";
                        this.ib2Left.OnClientClick = "dolink('" + readerQROptions["Link2LeftURL"].ToString().Trim() + "')";
                        this.ib2Right.OnClientClick = "dolink('" + readerQROptions["Link2RightURL"].ToString().Trim() + "')";
                        this.ib3Left.OnClientClick = "dolink('" + readerQROptions["Link3LeftURL"].ToString().Trim() + "')";
                        this.ib3Right.OnClientClick = "dolink('" + readerQROptions["Link3RightURL"].ToString().Trim() + "')";
                        this.ib4Left.OnClientClick = "dolink('" + readerQROptions["Link4LeftURL"].ToString().Trim() + "')";
                        this.ib4Right.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";

                        readerQROptions.Close();

                        if (lbMake.Text.ToUpper() == "KTM" && lbModel.Text == "250 EXC")
                        {
                            this.imgAsset.ImageUrl = "~/ImagesMaster/ktm250.png";
                            this.Image1.ImageUrl = "~/ImagesMaster/mastermx-logo.png";

                            this.ib4Right.OnClientClick = "dolink('RaceDetails.aspx?id=" + key + "')";

                        }

                    }
                    else
                    {
                        readerQROptions.Close();
                        
                        //Display a Basic Version if not in look-up table
                        this.ibHire.ImageUrl = "~/ImagesMaster/button-found-it.png";
                        this.ibHire.OnClientClick = "dolink('master_found.html')";
                        this.ibStolen.ImageUrl = "~/ImagesMaster/button-report-stolen.png";
                        this.ibStolen.OnClientClick = "dolink('master_found.html')";
                        this.ibScan.ImageUrl = "~/ImagesMaster/button-theft-check.png";
                        this.ibScan.OnClientClick = "doalert('contact Datatag to discuss enabling the theft check functionality')";

                        this.ib1Left.ImageUrl = "~/ImagesMaster/button-user.png";
                        this.ib1Right.ImageUrl = "~/ImagesMaster/button-safety.png";
                        this.ib2Left.ImageUrl = "~/ImagesMaster/button-warranty.png";
                        this.ib2Right.ImageUrl = "~/ImagesMaster/button-dealer.png";
                        this.ib3Left.ImageUrl = "~/ImagesMaster/button-parts.png";
                        this.ib3Right.ImageUrl = "~/ImagesMaster/button-servise.png";
                        this.ib4Left.ImageUrl = "~/ImagesMaster/button-re-register.png";
                        this.ib4Right.ImageUrl = "~/ImagesMaster/button-racing.png";

                        this.ib1Left.OnClientClick = "dolink('http://www.mcia.co.uk/')";
                        this.ib1Right.OnClientClick = "dolink('http://www.mcia.co.uk/Services/Safety.aspx')";
                        this.ib2Left.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ib2Right.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ib3Left.OnClientClick = "dolink('https://www.google.co.uk/?gws_rd=ssl#q=" + this.lbMake.Text + "+" + this.lbModel.Text + "+" + "parts&tbm=shop')";
                        this.ib3Right.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ib4Left.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ib4Right.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";

                    }

                }
                else
                {
                    conn.Close();
                    //No Codes so just direct to default page

                    reader.Close();

                    Response.Redirect("http://masterscheme.org/");
                }

            }
            else
            {
                conn.Close();
                //No Codes so just direct to default page

                Response.Redirect("http://masterscheme.org/");
            }

            conn.Close();

        } //End Page Load


        protected void Page_Close(object sender, EventArgs e)
        {
  
            conn.Close();
        }


    }
}
