using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Xml.Linq;
using System.Net;
using System.Threading;
using System.Configuration;
using System.CodeDom;
using System.Web.Compilation;
using System.Web.Security;

namespace QRMobi
{
    public partial class Webcsrm : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        protected string templat = "";
        string RequestUrl = "";

        SqlConnection conn;

        //private string GetAddress(string latitude, string longitude)
        //{
        //    string locationName = "";
        //    string postcode = "";
        //    string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyC4HFYPpRxO9KimpmBerRXC_oR1HLyiJbc&latlng={0},{1}&sensor = false", latitude, longitude);

        //    XElement xml = XElement.Load(url);
        //    if (xml.Element("status").Value == "OK")
        //    {
        //        locationName = string.Format("{0}", xml.Element("result").Element("formatted_address").Value);
        //    }


        //    //Not accurate enough
        //    XDocument doc = XDocument.Load(url);

        //    foreach (var name in doc.Root.DescendantNodes().OfType<XElement>().Select(x => x.Value).Distinct())
        //    {
        //        string temp = name.ToString();
        //        if (locationName.Contains(temp) & temp.Length == 8)
        //        {
        //            postcode = temp;

        //            break;
        //        }
        //    }

        private string GetAddress(string latitude, string longitude)
        {
            string locationName = "";
            string postcode = "Non Geocodable";
            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyC4HFYPpRxO9KimpmBerRXC_oR1HLyiJbc&latlng={0},{1}&sensor = false", latitude, longitude);

            XDocument xdoc;

            try
            {
                xdoc = XDocument.Load(url);
            }
            catch
            {
                //Failed
                return postcode;
            }


            XElement xresult = xdoc.Element("GeocodeResponse").Element("result");

            if (xresult != null)
            {
                //WebRequest request = WebRequest.Create(url);
                //WebResponse response = request.GetResponse();
                //stream stream = response.GetResponseStream();

                XElement xml = XElement.Load(url);


                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                if (result != null)
                {

                    foreach (var addElement in result.Elements("address_component").Select(item => item))
                    {

                        XElement type = addElement.Element("type");

                        if (type.Value == "postal_code")
                        {
                            XElement long_name = addElement.Element("long_name");

                            postcode = long_name.Value;
                        }

                    }

                }
            }

            return postcode;
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            //push for secure connection
            RequestUrl = Request.Url.ToString();

            bool IsLocal = false;
            string iniFile = "";

            if (RequestUrl.Contains("192.168.1"))
            {
                IsLocal = true;
            }

            if (!Request.IsLocal && !Request.IsSecureConnection)
            {
                if (!IsLocal)
                {
                    string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                    Response.Redirect(redirectUrl, false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

            }

            string imgServerURL = Properties.Settings.Default.ImageServerURL;
            string Interval = Properties.Settings.Default.Interval;

            Timer1.Interval = Convert.ToInt32(Interval);

            int ret;

            if (!IsPostBack)
            {
                MultiView.ActiveViewIndex = 0;

                this.btnLeftMode.Text = "1";
                this.btnRightMode.Text = "1";
                this.btnMiddleMode.Text = "1";

                this.SessionCurrent.Text = "new";

                ibFound.Enabled = false;

                iniFile = "QRCesarMicro.ini";

                ret = MyProcess.LoadIniFile(iniFile);
            }
            else
            {
                this.SessionCurrent.Text = "live";
            }


            MembershipUser UserTmp = Membership.GetUser();
            if (UserTmp != null)
            {
                this.tbHIDGUID.Text = UserTmp.ProviderUserKey.ToString();
                this.tbHIDUsername.Text = UserTmp.UserName;
            }
            else
            {
                this.tbHIDGUID.Text = "";
            }

            if (User.Identity.IsAuthenticated)
            {
                gvMyAssets.DataBind();
                gvMyScans.DataBind();

            }


            bool found = false;

            string MemberNum = "";
            string ownertype = "";


            string url = "top.html";
            string fullURL = "window.open('" + url + "', '_self', '' );";

            //http://www.datatag.mobi/qrcsrm.aspx?id=DT01B9YB2B&code=308139188

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

            string key = "";
            string code = "";

            if (Request.IsLocal)
            {
                key = "DT01B9YB2B";
                code = "308139188";
            }
            else
            {
                key = Request.QueryString["id"];
                code = Request.QueryString["code"];
            }


            //Get Params
            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,EngineNum,Serial_ShortVIN,MemberNum,AssetDesc,OwnerType,Company,AddressLine1,AddressLine2,AddressLine3,Town,Postcode from vVKSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                //System.Diagnostics.Debug.WriteLine(SQLComm);

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

                    ownertype = reader["OwnerType"].ToString().Trim();

                    String company = reader["Company"].ToString().Trim();
                    String add1 = reader["AddressLine1"].ToString().Trim();
                    String add2 = reader["AddressLine2"].ToString().Trim();
                    String add3 = reader["AddressLine3"].ToString().Trim();
                    String town = reader["Town"].ToString().Trim();
                    String postcode = reader["Postcode"].ToString().Trim();

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


                    //Set Default image for asset
                    string imageurl = MyProcess.GetImageAssetURL(this.lbMake.Text.Trim(), lbModel.Text.Trim());
                    if (imageurl != "")
                    {
                        this.imgAsset.ImageUrl = imgServerURL + imageurl;
                    }
                    else
                    {
                        //Default to OEM logo
                        //Get OEM Image
                        if (User.Identity.IsAuthenticated)
                        {
                            //Set Default image for asset
                            imageurl = MyProcess.GetImageOEMURL(this.tbHIDGUID.Text);

                            if (imageurl == "")
                            {
                                this.imgAsset.Visible = false;
                            }
                            else
                            {
                                this.imgAsset.ImageUrl = imgServerURL + imageurl;
                            }

                        }
                        else
                        {
                            this.ImageRight.Visible = false;
                        }

                    }


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
                            //if (this.lbMake.Text.ToUpper() == "STIHL" && this.lbModel.Text == "TS410" || this.lbMake.Text.ToUpper() == "STIHL" && this.lbModel.Text == "TS800")
                            //{
                            //    this.imgAsset.ImageUrl = this.imgAsset.ImageUrl.Substring(0, (this.imgAsset.ImageUrl.Length - 4)) + "-stolen.png";
                            //}

                            ibFound.Visible = true;

                            //this.imgAsset.ImageUrl = "~/Imagescsrm/stihl-stolen.png";

                            this.ibFound.ImageUrl = "~/Imagescsrm2/Report.png";
                            this.ibFound.Enabled = true;

                        }
                        else
                        {
                            //not stolen
                            this.ibFound.ImageUrl = "~/Imagescsrm2/Blank.png";
                            this.ibFound.Enabled = false;
                        }
                        rdr.Close();
                    }

                    //Get OEM Image
                    if (User.Identity.IsAuthenticated)
                    {

                        //Set Default image for asset
                        imageurl = MyProcess.GetImageOEMURL(this.tbHIDGUID.Text);

                        if (imageurl == "")
                        {
                            this.ImageRight.Visible = false;
                        }
                        else
                        {
                            this.ImageRight.ImageUrl = imgServerURL + imageurl;
                        }

                    }
                    else
                    {
                        this.ImageRight.Visible = false;
                    }



                    this.ibUser.ImageUrl = "~/Imagescsrm2/User.png";
                    this.ibSafety.ImageUrl = "~/Imagescsrm2/Safety.png";
                    this.ibParts.ImageUrl = "~/Imagescsrm2/Parts.png";
                    this.ibDealer.ImageUrl = "~/Imagescsrm2/Dealer.png";

                    //Set Default image for asset
                    string userlink = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "PDFMANUAL");
                    this.ibUser.OnClientClick = "dolink('" + imgServerURL + userlink + "')";

                    this.ibSafety.OnClientClick = "dolink('http://www.hae-safetyleaflets.co.uk')";

                    string userparts = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "WWWSPARES");
                    this.ibParts.OnClientClick = "dolink('" + userparts + "')";

                    this.ibDealer.OnClientClick = "dolink('http://www.cesarscheme.org/Dealer_Locator.html')";


                    //this.ibSpare1.ImageUrl = "~/Imagescsrm2/Blank.png";
                    //this.ibSpare2.ImageUrl = "~/Imagescsrm2/Blank.png";

                    //this.ibSpare1.Enabled = false;
                    //this.ibSpare2.Enabled = false;

                    string lng = this.lng.Text;
                    string lat = this.lat.Text;

                    if (!IsPostBack)
                    {
                        if (!User.Identity.IsAuthenticated)
                        {
                            //Button Mode NOT Auth
                            //Contact US
                            this.ibLeft.ImageUrl = "~/Imagescsrm2/contact.png";
                            //this.ibLeft.OnClientClick = "dolink('found.html')";
                            //this.ibLeft.OnClientClick = "add();return false;";

                            this.ibMiddle.ImageUrl = "~/Imagescsrm2/bg.jpg";
                            this.ibMiddle.Visible = false;

                            //Login
                            this.ibRight.ImageUrl = "~/Imagescsrm2/SignIn.png";
                            this.ibRight.Visible = true;

                            //Buttons
                            this.ibService.ImageUrl = "~/Imagescsrm2/Blank.png";
                            this.ibService.Enabled = false;
                        }
                        else
                        {

                            //MyScans
                            this.ibLeft.ImageUrl = "~/Imagescsrm2/Scan.png";

                            //this.ibLeft.OnClientClick = "add();return false;";

                            //Contact US
                            this.ibMiddle.ImageUrl = "~/Imagescsrm2/Contact.png";
                            this.ibMiddle.Visible = true;

                            //Asset Scans
                            this.ibRight.ImageUrl = "~/Imagescsrm2/Asset.png";
                            this.ibRight.Visible = true;

                            //Service
                            this.ibService.ImageUrl = "~/Imagescsrm2/Service.png";
                            this.ibService.Enabled = true;

                            //Set Default image for asset
                            string serviceurl = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "PDFSERVICE");
                            if (serviceurl != "")
                            {
                                this.ibService.OnClientClick = "dolink('" + imgServerURL + serviceurl + "')";
                            }

                        }
                    }

                    conn.Close();
                }
                else
                {
                    conn.Close();

                    Response.Redirect("~/Pages/NotFound.aspx?ini=" + iniFile);

                }

            }
        }

        protected void stolenMessage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.SessionCurrent.Text == "new")
                {
                    Timer1.Enabled = true;
                }
            }

        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string stLng = String.Format("{0}", Request.Form["lng"]);
            string stLat = String.Format("{0}", Request.Form["lat"]);
            string stAddress = String.Format("{0}", Request.Form["tbHIDAddress"]);

            string UserGUID = "";
            string PostCode = "";

            MembershipUser UserTmp = Membership.GetUser();
            if (UserTmp != null)
            {
                UserGUID = UserTmp.ProviderUserKey.ToString();

                PostCode = GetAddress(stLat, stLng);

            }
            else
            {
                UserGUID = "";
            }

            string AssetID = this.lbID.Text.Trim();
            string ECVCode = "";
            string IPAddress = Request.UserHostAddress;
            string DeviceID = "";


            Processes MyProc = new Processes();
            int ret = MyProc.WriteLongLatSP(AssetID, ECVCode, stLat, stLng, UserGUID, IPAddress, stAddress, PostCode, DeviceID);


            if (this.tbHIDAddress.Text != "")
            {
                string[] stTemp = this.tbHIDAddress.Text.Split(',');
            }

            Timer1.Enabled = false;
        }

        protected void ibLeft_Click(object sender, ImageClickEventArgs e)
        {

            ibMiddle.ImageUrl = "~/Imagescsrm2/contact.png";
            ibLeft.ImageUrl = "~/Imagescsrm2/Scan.png";
            ibRight.ImageUrl = "~/Imagescsrm2/Asset.png";

            //Reset buttons if user jumps across buttons
            this.btnRightMode.Text = "1";
            this.btnMiddleMode.Text = "1";

            //CONTACT OR MYSCANS
            if (!User.Identity.IsAuthenticated)
            {

                //CONTACT
                switch (this.btnLeftMode.Text)
                {
                    case "1":

                        ibLeft.ImageUrl = "~/Imagescsrm2/contact_Over.png";

                        MultiView.ActiveViewIndex = 4;
                        this.btnLeftMode.Text = "2";

                        break;

                    case "2":

                        ibLeft.ImageUrl = "~/Imagescsrm2/contact.png";

                        this.btnLeftMode.Text = "1";
                        MultiView.ActiveViewIndex = 0;

                        break;
                }

                //Response.Redirect("contact.html");
            }
            else
            {
                //MY SCANS
                ibLeft.ImageUrl = "~/Imagescsrm2/Scan_Over.png";
                ibRight.ImageUrl = "~/Imagescsrm2/Asset.png";

                switch (this.btnLeftMode.Text)
                {
                    case "1":

                        MultiView.ActiveViewIndex = 2;
                        this.btnLeftMode.Text = "2";

                        break;

                    case "2":

                        //MAP

                        string url = "bigmap.aspx?type=MYSCANS";
                        string fullURL = "window.open('" + url + "', '_blank', 'status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                        btnMapFull.Attributes.Add("OnClick", fullURL);

                        MultiView.ActiveViewIndex = 1;
                        this.btnLeftMode.Text = "1";

                        //Populate the map
                        //Connect to SQL Database
                        conn = new SqlConnection(QRMobi.SQLConn);

                        conn.Open();

                        string SQLComm = "SELECT * from vwQRAssetScans where UserName = '" + this.tbHIDUsername.Text + "'";

                        var cmd = new SqlCommand(SQLComm, conn);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                        }

                        reader.Close();
                        conn.Close();


                        break;

                    case "3":

                        MultiView.ActiveViewIndex = 2;
                        this.btnLeftMode.Text = "2";

                        break;

                }

            }
        }

        protected void ibRight_Click1(object sender, ImageClickEventArgs e)
        {
            //LOGIN OR MY ASSETS

            ibMiddle.ImageUrl = "~/Imagescsrm2/contact.png";
            ibLeft.ImageUrl = "~/Imagescsrm2/Scan.png";
            ibRight.ImageUrl = "~/Imagescsrm2/Asset.png";

            //Reset buttons if user jumps across buttons
            this.btnLeftMode.Text = "1";
            this.btnMiddleMode.Text = "1";


            if (!User.Identity.IsAuthenticated)
            {
                //LOGIN

                string cov = RequestUrl.Replace('&', '@');

                Response.Redirect("~/Account/login.aspx?ReturnUrl=" + cov);
            }
            else
            {
                // MY ASSETS
                ibRight.ImageUrl = "~/Imagescsrm2/Asset_Over.png";
                ibLeft.ImageUrl = "~/Imagescsrm2/Scan.png";

                switch (this.btnRightMode.Text)
                {
                    case "1":

                        MultiView.ActiveViewIndex = 3;
                        this.btnRightMode.Text = "2";

                        break;

                    case "2":

                        //MAP

                        string url = "bigmap.aspx?type=ASSETS";
                        string fullURL = "window.open('" + url + "', '_blank', 'status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                        btnMapFull.Attributes.Add("OnClick", fullURL);

                        MultiView.ActiveViewIndex = 1;
                        this.btnRightMode.Text = "1";

                        //Populate the map
                        //Connect to SQL Database
                        conn = new SqlConnection(QRMobi.SQLConn);

                        conn.Open();

                        string SQLComm = "SELECT * from vwQRAssetScans where UserName = '" + this.tbHIDUsername.Text + "'";

                        var cmd = new SqlCommand(SQLComm, conn);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                        }

                        reader.Close();
                        conn.Close();


                        break;

                    case "3":

                        MultiView.ActiveViewIndex = 3;
                        this.btnRightMode.Text = "2";

                        break;

                }


            }


        }

        protected void ibMiddle_Click(object sender, ImageClickEventArgs e)
        {
            //CONTACT OR MY SCANS

            ibMiddle.ImageUrl = "~/Imagescsrm2/contact.png";
            ibLeft.ImageUrl = "~/Imagescsrm2/Scan.png";
            ibRight.ImageUrl = "~/Imagescsrm2/Asset.png";

            //Reset buttons if user jumps across buttons
            this.btnLeftMode.Text = "1";
            this.btnRightMode.Text = "1";

            //Response.Redirect("contact.html");

            if (User.Identity.IsAuthenticated)
            {

                //CONTACT
                switch (this.btnMiddleMode.Text)
                {
                    case "1":

                        ibMiddle.ImageUrl = "~/Imagescsrm2/contact_Over.png";

                        MultiView.ActiveViewIndex = 4;
                        this.btnMiddleMode.Text = "2";

                        break;

                    case "2":

                        ibMiddle.ImageUrl = "~/Imagescsrm2/contact.png";

                        this.btnMiddleMode.Text = "1";
                        MultiView.ActiveViewIndex = 0;

                        break;
                }

            }


        }

        protected void ibFound_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("found.html");
        }

        protected void gvMyScans_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = this.gvMyScans.SelectedValue.ToString();

            string imgServerURL = Properties.Settings.Default.ImageServerURL;

            //Connect to SQL Database
            conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "SELECT Make,Model,Colour,EngineNum,Serial_ShortVIN,MemberNum,AssetDesc,OwnerType,Company,AddressLine1,AddressLine2,AddressLine3,Town,Postcode from vVKSec where IDNumber = '" + key + "'";

            var cmd = new SqlCommand(SQLComm, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                // set basic details for the table, plus owner details
                this.lbID.Text = key;
                this.lbMake.Text = reader["Make"].ToString().Trim();
                this.lbModel.Text = reader["Model"].ToString().Trim();
                this.lbColour.Text = reader["Colour"].ToString().Trim();
                this.lbEngine.Text = reader["EngineNum"].ToString().Trim();
                this.lbSerial.Text = reader["Serial_ShortVIN"].ToString().Trim();
                this.lbType.Text = reader["AssetDesc"].ToString().Trim();

            }

            reader.Close();
            conn.Close();



            //Set Default image for asset
            //string imageurl = MyProcess.GetImageAssetURL(this.lbMake.Text.Trim(), lbModel.Text.Trim());
            //this.imgAsset.ImageUrl = imgServerURL + imageurl;

            //Set Default image for asset
            string imageurl = MyProcess.GetImageAssetURL(this.lbMake.Text.Trim(), lbModel.Text.Trim());
            if (imageurl != "")
            {
                this.imgAsset.ImageUrl = imgServerURL + imageurl;
            }
            else
            {
                //Default to OEM logo
                //Get OEM Image
                if (User.Identity.IsAuthenticated)
                {
                    //Set Default image for asset
                    imageurl = MyProcess.GetImageOEMURL(this.tbHIDGUID.Text);

                    if (imageurl == "")
                    {
                        this.imgAsset.Visible = false;
                    }
                    else
                    {
                        this.imgAsset.ImageUrl = imgServerURL + imageurl;
                    }

                }
                else
                {
                    this.ImageRight.Visible = false;
                }

            }

            //Set Default image for asset
            string userlink = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "PDFMANUAL");
            this.ibUser.OnClientClick = "dolink('" + imgServerURL + userlink + "')";

            this.ibSafety.OnClientClick = "dolink('http://www.hae-safetyleaflets.co.uk')";

            string userparts = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "WWWSPARES");
            this.ibParts.OnClientClick = "dolink('" + userparts + "')";

            this.ibDealer.OnClientClick = "dolink('http://www.cesarscheme.org/Dealer_Locator.html')";


            MultiView.ActiveViewIndex = 0;
            this.btnLeftMode.Text = "3";


        }

        protected void gvMyAssets_SelectedIndexChanged(object sender, EventArgs e)
        {

            string key = this.gvMyAssets.SelectedValue.ToString();

            string imgServerURL = Properties.Settings.Default.ImageServerURL;

            //Connect to SQL Database
            conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "SELECT Make,Model,Colour,EngineNum,Serial_ShortVIN,MemberNum,AssetDesc,OwnerType,Company,AddressLine1,AddressLine2,AddressLine3,Town,Postcode from vVKSec where IDNumber = '" + key + "'";

            var cmd = new SqlCommand(SQLComm, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                // set basic details for the table, plus owner details
                this.lbID.Text = key;
                this.lbMake.Text = reader["Make"].ToString().Trim();
                this.lbModel.Text = reader["Model"].ToString().Trim();
                this.lbColour.Text = reader["Colour"].ToString().Trim();
                this.lbEngine.Text = reader["EngineNum"].ToString().Trim();
                this.lbSerial.Text = reader["Serial_ShortVIN"].ToString().Trim();
                this.lbType.Text = reader["AssetDesc"].ToString().Trim();

            }

            reader.Close();
            conn.Close();



            //Set Default image for asset
            //string imageurl = MyProcess.GetImageAssetURL(this.lbMake.Text.Trim(), lbModel.Text.Trim());
            //this.imgAsset.ImageUrl = imgServerURL + imageurl;

            //Set Default image for asset
            string imageurl = MyProcess.GetImageAssetURL(this.lbMake.Text.Trim(), lbModel.Text.Trim());
            if (imageurl != "")
            {
                this.imgAsset.ImageUrl = imgServerURL + imageurl;
            }
            else
            {
                //Default to OEM logo
                //Get OEM Image
                if (User.Identity.IsAuthenticated)
                {
                    //Set Default image for asset
                    imageurl = MyProcess.GetImageOEMURL(this.tbHIDGUID.Text);

                    if (imageurl == "")
                    {
                        this.imgAsset.Visible = false;
                    }
                    else
                    {
                        this.imgAsset.ImageUrl = imgServerURL + imageurl;
                    }

                }
                else
                {
                    this.ImageRight.Visible = false;
                }

            }

            //Set Default image for asset
            string userlink = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "PDFMANUAL");
            this.ibUser.OnClientClick = "dolink('" + imgServerURL + userlink + "')";

            this.ibSafety.OnClientClick = "dolink('http://www.hae-safetyleaflets.co.uk')";

            string userparts = MyProcess.GetImageAssetOtherURL(this.lbMake.Text.Trim(), lbModel.Text.Trim(), "WWWSPARES");
            this.ibParts.OnClientClick = "dolink('" + userparts + "')";

            this.ibDealer.OnClientClick = "dolink('http://www.cesarscheme.org/Dealer_Locator.html')";


            MultiView.ActiveViewIndex = 0;
            this.btnRightMode.Text = "3";
        }


        protected void gvMyAssets_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int cell1 = 6;
                int cell2 = 7;

                switch (e.Row.RowIndex + 1)
                {

                    case 1:

                        this.latlng1.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add1.Text = e.Row.Cells[7].Text;
                        break;
                    case 2:

                        this.latlng2.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add2.Text = e.Row.Cells[7].Text;
                        break;
                    case 3:

                        this.latlng3.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add3.Text = e.Row.Cells[7].Text;
                        break;
                    case 4:

                        this.latlng4.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add4.Text = e.Row.Cells[7].Text;
                        break;
                    case 5:

                        this.latlng5.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add5.Text = e.Row.Cells[7].Text;
                        break;
                    case 6:

                        this.latlng6.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add6.Text = e.Row.Cells[7].Text;
                        break;
                    case 7:

                        this.latlng7.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add7.Text = e.Row.Cells[7].Text;
                        break;
                    case 8:

                        this.latlng8.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add8.Text = e.Row.Cells[7].Text;
                        break;
                    case 9:

                        this.latlng9.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add9.Text = e.Row.Cells[7].Text;
                        break;

                    case 10:

                        this.latlng10.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 11:

                        this.latlng11.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 12:

                        this.latlng12.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 13:

                        this.latlng13.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 14:

                        this.latlng14.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 15:

                        this.latlng15.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 16:

                        this.latlng16.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 17:

                        this.latlng17.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 18:

                        this.latlng18.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 19:

                        this.latlng19.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 20:

                        this.latlng20.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 21:

                        this.latlng21.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 22:

                        this.latlng22.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 23:

                        this.latlng23.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 24:

                        this.latlng24.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 25:

                        this.latlng25.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 26:

                        this.latlng26.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 27:

                        this.latlng27.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 28:

                        this.latlng28.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 29:

                        this.latlng29.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 30:

                        this.latlng30.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;


                }



            }
        }

        protected void gvMyScans_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            //MyScans

            int cell1 = 5;
            int cell2 = 6;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                switch (e.Row.RowIndex + 1)
                {

                    case 1:

                        this.latlng1.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add1.Text = e.Row.Cells[7].Text;
                        break;
                    case 2:

                        this.latlng2.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add2.Text = e.Row.Cells[7].Text;
                        break;
                    case 3:

                        this.latlng3.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add3.Text = e.Row.Cells[7].Text;
                        break;
                    case 4:

                        this.latlng4.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add4.Text = e.Row.Cells[7].Text;
                        break;
                    case 5:

                        this.latlng5.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add5.Text = e.Row.Cells[7].Text;
                        break;
                    case 6:

                        this.latlng6.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add6.Text = e.Row.Cells[7].Text;
                        break;
                    case 7:

                        this.latlng7.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add7.Text = e.Row.Cells[7].Text;
                        break;
                    case 8:

                        this.latlng8.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add8.Text = e.Row.Cells[7].Text;
                        break;
                    case 9:

                        this.latlng9.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add9.Text = e.Row.Cells[7].Text;
                        break;

                    case 10:

                        this.latlng10.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 11:

                        this.latlng11.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 12:

                        this.latlng12.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 13:

                        this.latlng13.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 14:

                        this.latlng14.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 15:

                        this.latlng15.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 16:

                        this.latlng16.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 17:

                        this.latlng17.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 18:

                        this.latlng18.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 19:

                        this.latlng19.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 20:

                        this.latlng20.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 21:

                        this.latlng21.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 22:

                        this.latlng22.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 23:

                        this.latlng23.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 24:

                        this.latlng24.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 25:

                        this.latlng25.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 26:

                        this.latlng26.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 27:

                        this.latlng27.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 28:

                        this.latlng28.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 29:

                        this.latlng29.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;

                    case 30:

                        this.latlng30.Text = e.Row.Cells[cell1].Text + "," + e.Row.Cells[cell2].Text;
                        //this.add10.Text = e.Row.Cells[7].Text;
                        break;


                }

            }
        }

    }




}

