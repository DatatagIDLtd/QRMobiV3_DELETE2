using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMobi
{
    public partial class bigmap : System.Web.UI.Page
    {

        Processes MyProcess = new Processes();

        SqlConnection conn;

        string SQLComm = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            string type = Request.QueryString["type"];

            type = "MYSCANS";

            this.tbHIDUsername.Text = "lee.sparks";

            string SQLComm = "";

            string iniFile = "QRCesarMicro.ini";

            int ret = MyProcess.LoadIniFile(iniFile);

            //Pull all the data into this form
            //MembershipUser UserTmp = Membership.GetUser();
            //if (UserTmp != null)
            //{
            //    this.tbHIDGUID.Text = UserTmp.ProviderUserKey.ToString();
            //    this.tbHIDUsername.Text = UserTmp.UserName;
            //}
            //else
            //{
            //    this.tbHIDGUID.Text = "";
            //}

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

            

            switch (type)
            {
                case "MYSCANS":

                    //SELECT TOP(30) [CreatedOn], [CESARID], [Make], [Model], [UserName], [UserGUID], [Latitude], [Longitude], [Address] FROM[vwQRMyAssetScans] WHERE([UserName] = @UserName) order by[CreatedOn] DESC

                    SQLComm = "SELECT * FROM vwQRMyAssetScans WHERE Username = '"+this.tbHIDUsername.Text+"' ORDER BY CreatedOn DESC";

                    break;

                case "ASSETS":

                    //SELECT TOP(30) [CreatedOn], [CESARID], [PostCode], [UserName], [UserGUID], [Longitude], [Address], [Latitude] FROM[vwQRAssetScans] order by[CreatedOn] DESC

                    SQLComm = "SELECT * FROM vwQRAssetScans WHERE Username = '" + this.tbHIDUsername.Text + "' ORER BY CreatedOn DESC";

                    break;

            }


            var cmd = new SqlCommand(SQLComm, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            int counter = 1;

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    string latlng = reader["Latitude"].ToString() + "," + reader["Longitude"].ToString();

                    switch (counter)
                    {
                        case 1:
                            this.latlng1.Text = latlng;
                            break;
                        case 2:
                            this.latlng2.Text = latlng;
                            break;
                        case 3:
                            this.latlng3.Text = latlng;
                            break;
                        case 4:
                            this.latlng4.Text = latlng;
                            break;
                        case 5:
                            this.latlng5.Text = latlng;
                            break;
                        case 6:
                            this.latlng6.Text = latlng;
                            break;
                        case 7:
                            this.latlng7.Text = latlng;
                            break;
                        case 8:
                            this.latlng8.Text = latlng;
                            break;
                        case 9:
                            this.latlng9.Text = latlng;
                            break;
                        case 10:
                            this.latlng10.Text = latlng;
                            break;
                        case 11:
                            this.latlng11.Text = latlng;
                            break;
                        case 12:
                            this.latlng12.Text = latlng;
                            break;
                        case 13:
                            this.latlng13.Text = latlng;
                            break;
                        case 14:
                            this.latlng14.Text = latlng;
                            break;
                        case 15:
                            this.latlng15.Text = latlng;
                            break;
                        case 16:
                            this.latlng16.Text = latlng;
                            break;
                        case 17:
                            this.latlng17.Text = latlng;
                            break;
                        case 18:
                            this.latlng18.Text = latlng;
                            break;
                        case 19:
                            this.latlng19.Text = latlng;
                            break;
                        case 20:
                            this.latlng20.Text = latlng;
                            break;
                        case 21:
                            this.latlng21.Text = latlng;
                            break;
                        case 22:
                            this.latlng22.Text = latlng;
                            break;
                        case 23:
                            this.latlng23.Text = latlng;
                            break;
                        case 24:
                            this.latlng1.Text = latlng;
                            break;
                        case 25:
                            this.latlng25.Text = latlng;
                            break;
                        case 26:
                            this.latlng26.Text = latlng;
                            break;
                        case 27:
                            this.latlng27.Text = latlng;
                            break;
                        case 28:
                            this.latlng28.Text = latlng;
                            break;
                        case 29:
                            this.latlng29.Text = latlng;
                            break;
                        case 30:
                            this.latlng30.Text = latlng;
                            break;

                    }

                    counter++;

                } // end while

            } //end iff

            reader.Close();
            conn.Close();


        }
    }
}