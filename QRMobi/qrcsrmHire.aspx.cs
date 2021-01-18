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
    public partial class WebcsrmHire : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            //return;
            int ret;
            bool found = false;
            string MemberNum = "";

            string iniFile = "QRCesarMicro.ini";

            ret = MyProcess.LoadIniFile(iniFile);

            string url = "top.html";
            string fullURL = "window.open('" + url + "', '_self', '' );";

            //Connect to SQL database
            conn = new SqlConnection(QRMobi.SQLConn);

            try
            {
                conn.Open();
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,EngineNum,Serial_ShortVIN,MemberNum,AssetDesc,OwnerType,Company,AddressLine1,AddressLine2,AddressLine3,Town,Postcode,Tel from vVKSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }

                if (found)
                {
                    reader.Read();
                    // set basic details for the table, plus owner details
                    this.lbID.Text = reader["Make"].ToString().Trim();
                    this.lbMake.Text = reader["Make"].ToString().Trim();
                    this.lbModel.Text = reader["Model"].ToString().Trim();
                    this.lbColour.Text = reader["Colour"].ToString().Trim();
                    this.lbEngine.Text = reader["EngineNum"].ToString().Trim();
                    this.lbSerial.Text = reader["Serial_ShortVIN"].ToString().Trim();
                    this.lbType.Text = reader["AssetDesc"].ToString().Trim();
                    String ownertype = reader["OwnerType"].ToString().Trim();
                    String company = reader["Company"].ToString().Trim();
                    String add1 = reader["AddressLine1"].ToString().Trim();
                    String add2 = reader["AddressLine2"].ToString().Trim();
                    String add3 = reader["AddressLine3"].ToString().Trim();
                    String town = reader["Town"].ToString().Trim();
                    String postcode = reader["Postcode"].ToString().Trim();
                    String tel = reader["Tel"].ToString().Trim();
                    if (tel == null) tel = "";


                    //display basic details 
                    if (lbEngine.Text == "") this.lbEngine.Text = "-";
                    if (lbSerial.Text == "") this.lbSerial.Text = "-";
                    if (lbColour.Text == "") this.lbColour.Text = "-";
                    if (lbMake.Text == "") this.lbMake.Text = "-";
                    if (lbModel.Text == "") this.lbModel.Text = "-";
                    if (lbType.Text == "") this.lbType.Text = "-";

                    MemberNum = reader["MemberNum"].ToString().Trim();
                    this.lbType.Text = reader["AssetDesc"].ToString().Trim();
                    this.lbID.Text = key;
                    reader.Close();

                    //get MSQROptions from manufactorers table
                    string SQLComm2 = "SELECT Make, BtnLeftImg, BtnLeftURL, BtnMiddleImg, BtnMiddleURL,BtnRightImg,Link1LeftURL,Link1RightURL,Link2LeftURL,Link2RightURL,Link3LeftURL,Link3RightURL,Link1LeftImg,Link1RightImg,Link2LeftImg,Link2RightImg,Link3LeftImg,Link3RightImg,PicImg from MSQROptions where Make = '" + this.lbMake.Text.ToLower() + "'";
                    var cmdOptions = new SqlCommand(SQLComm2, conn);
                    SqlDataReader readerQROptions = cmdOptions.ExecuteReader();
                    if (readerQROptions.HasRows)
                    {
                        //main buttons
                        readerQROptions.Read();

                        this.ibButtonL.ImageUrl = "~/Imagescsrm/button-hire-it.png";
                        this.ibButtonC.ImageUrl = "~/Imagescsrm/button-scan-it.png";
                        this.ibButtonR.ImageUrl = "~/Imagescsrm/button-found-it.png";

                        this.ibButtonL.OnClientClick = "doalert('" + ownertype.ToUpper() + "\\n \\n" + company + "\\n \\n" + add1 + "\\n" + add2 + "\\n" + add3 + "\\n" + town + "\\n" + postcode + " ')";
                        this.ibButtonR.OnClientClick = "dolink('" + readerQROptions["BtnMiddleURL"].ToString().Trim() + "')";
                        this.ibButtonC.OnClientClick = "doalert('contact Datatag to discuss enabling the stock check functionality')";

                        //ibButtonL (Hire It Again)
                        if (tel != "")
                        {
                            string hireItAgain = "tel:+44" + tel.Substring(1, (tel.Length - 1));
                            this.ibButtonL.OnClientClick = "dolink('" + hireItAgain.ToString().Replace(" ", "").Trim() + "')";
                        }
                        else
                        {
                            this.ibButtonL.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        }


                        //other button links
                        this.ibUser.ImageUrl = readerQROptions["Link1LeftImg"].ToString().Trim();
                        this.ibSafety.ImageUrl = readerQROptions["Link1RightImg"].ToString().Trim();
                        this.ibDealer.ImageUrl = readerQROptions["Link2RightImg"].ToString().Trim();
                        this.ibSoon.ImageUrl = readerQROptions["Link3LeftImg"].ToString().Trim();
                        this.ibService.ImageUrl = "~/ImagescsrmHire/button-website.png";
                        this.ibParts.ImageUrl = "~/ImagescsrmHire/button-branch-details.png";

                        this.ibUser.OnClientClick = "dolink('" + readerQROptions["Link1LeftURL"].ToString().Trim() + "')";
                        this.ibSafety.OnClientClick = "dolink('" + readerQROptions["Link1RightURL"].ToString().Trim() + "')";
                        this.ibParts.OnClientClick = "doalert('" + ownertype.ToUpper() + "\\n \\n" + company + "\\n \\n" + add1 + "\\n" + add2 + "\\n" + add3 + "\\n" + town + "\\n" + postcode + "\\n \\n" + tel + " ')";
                        this.ibDealer.OnClientClick = "dolink('" + readerQROptions["Link2RightURL"].ToString().Trim() + "')";
                        this.ibSoon.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";

                        //images
                        this.imgAsset.ImageUrl = readerQROptions["PicImg"].ToString().Trim();

                        readerQROptions.Close();


                        //check if scanned item is stolen
                        string newmod = this.lbModel.Text.Replace(" ", "");
                        var cmd2 = new SqlCommand("spQueryPNCByKey", conn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add(new SqlParameter("@IDNumber", key.Trim()));

                        using (SqlDataReader rdr = cmd2.ExecuteReader())
                        {
                            //add stolen info to website
                            if (rdr.HasRows)
                            {
                                //text below table
                                this.stolenMessageA.Text = "There may be further information held on this asset.";
                                this.stolenMessageB.Text = "Please call our 24/7 Security Register on 0345 0700440";
                                //marketing version
                                if (this.lbMake.Text.ToUpper() == "STIHL" && this.lbModel.Text == "TS410" || this.lbMake.Text.ToUpper() == "STIHL" && this.lbModel.Text == "TS800")
                                {
                                    this.imgAsset.ImageUrl = this.imgAsset.ImageUrl.Substring(0, (this.imgAsset.ImageUrl.Length - 4)) + "-stolen.png";
                                }
                            }
                            else
                            {
                                //not stolen
                            }
                            rdr.Close();
                        }


                    }
                    else
                    {
                        readerQROptions.Close();
                        //  hardwired default buttons and links where no lookup for make exists - basic offering
                        //
                        // basic offering for hire company and retailer users (with contact supplier button)
                        //
                        this.ibButtonL.ImageUrl = "~/Imagescsrm/button-hire-it.png";
                        this.ibButtonC.ImageUrl = "~/Imagescsrm/button-scan-it.png";
                        this.ibButtonR.ImageUrl = "~/Imagescsrm/button-found-it.png";

                        //ibButtonL (Hire It Again)
                        string hireItAgain = "tel:+44" + tel.Substring(1, (tel.Length - 1));
                        this.ibButtonL.OnClientClick = "dolink('" + hireItAgain.ToString().Replace(" ", "").Trim() + "')";

                        this.ibButtonC.OnClientClick = "doalert('contact Datatag to discuss enabling the stock check functionality')";
                        this.ibButtonR.OnClientClick = "dolink('found.html')";

                        //
                        this.ibUser.ImageUrl = "~/Imagescsrm/button-user.png";
                        this.ibSafety.ImageUrl = "~/Imagescsrm/button-safety.png";
                        this.ibParts.ImageUrl = "~/ImagescsrmHire/button-branch-details.png";
                        this.ibDealer.ImageUrl = "~/Imagescsrm/button-dealer.png";
                        this.ibSoon.ImageUrl = "~/Imagescsrm/button-soon.png";
                        this.ibService.ImageUrl = "~/ImagescsrmHire/button-website.png";
                        this.ibUser.OnClientClick = "dolink('http://www.hae.org.uk')";
                        this.ibSafety.OnClientClick = "dolink('http://www.hae-safetyleaflets.co.uk')";
                        this.ibParts.OnClientClick = "doalert('" + ownertype.ToUpper() + "\\n \\n" + company + "\\n \\n" + add1 + "\\n" + add2 + "\\n" + add3 + "\\n" + town + "\\n" + postcode + "\\n" + tel + " ')";
                        this.ibDealer.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ibSoon.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ibService.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                    }
                    //hire company look up table
                    string SQLComm3 = "SELECT Serial_Number,Branch,Expire_Date,Pic_Name, Company_Name, Nearest_Dealer,Website from MSHireData where Serial_Number = '" + key + "'";
                    var hireOptions = new SqlCommand(SQLComm3, conn);
                    SqlDataReader readerHiretable = hireOptions.ExecuteReader();
                    if (readerHiretable.HasRows)
                    {
                        readerHiretable.Read();

                        //branch name
                        this.lbBranch.Text = readerHiretable["Branch"].ToString().Trim();

                        //data button
                        DateTime now = DateTime.Now;
                        //           string date = now.GetDateTimeFormats('d')[0];
                        //           string time = now.GetDateTimeFormats('t')[0];

                        DateTime expire = DateTime.Parse(readerHiretable["Expire_Date"].ToString().Trim());
                        double total_days = Math.Truncate((expire - now).TotalDays);

                        this.lbHireTime.Text = total_days.ToString();

                        //images
                        this.imgAsset.ImageUrl = readerHiretable["Pic_Name"].ToString().Trim();
                        this.HireCompLogo.ImageUrl = readerHiretable["Company_Name"].ToString().Trim();

                        //main buttons (hire company specific, over-riding manufacturing option)
                        this.ibDealer.OnClientClick = "dolink('" + readerHiretable["Nearest_Dealer"].ToString().Trim() + "')";
                        this.ibService.OnClientClick = "dolink('" + readerHiretable["Website"].ToString().Trim() + "')";

                        readerHiretable.Close();
                    }
                    else
                    {
                        this.ibDealer.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";
                        this.ibService.OnClientClick = "doalert('Contact Datatag for details of additional features which are coming soon.')";

                        readerHiretable.Close();
                    }
                    //** END MB Added Code **//
                }


                else
                {
                    conn.Close();
                    //No Codes so just direct to default page
                    //Response.Redirect(QRMobi.OnRedirectURL);
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

        protected void stolenMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }


}

