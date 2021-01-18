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
    public partial class Webcom : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            int ret;
            bool found = false;

            ret = MyProcess.LoadIniFile("QRCompass.ini");

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

            //string key = "B100A0AZ";
            //string code = "508646331";
            

            //http://www.datatag.mobi/qrcom.aspx?id=B100A0AZ&code=508646331

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,Outboard_EngineNumber,AssetDesc,Craft_Category from vOVKSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }
                

                if (found)
                {
                    reader.Read();

                    string asset = reader["AssetDesc"].ToString().Trim();
                    string cat = reader["Craft_Category"].ToString().Trim();
                    string engine = reader["Outboard_EngineNumber"].ToString().Trim();
                    //string frame = reader["Frame_Number"].ToString().Trim();
                    //string vinser = reader["VIN"].ToString().Trim();
                    //string ser = reader["SerialNum"].ToString().Trim();

                    
                    switch (asset)
                    {
                        case "outboard":

                            if (engine == "")
                            {
                                this.tbEngine.Visible = false;
                                this.lbEngine.Visible = false;
                            }

                            if (cat == "")
                            {
                                this.tbType.Visible = false;
                                this.lbType.Visible = false;
                            }


                            this.lbID.Text = "ID";
                            this.lbMake.Text = "Make";
                            this.lbModel.Text = "Model";
                            this.lbColour.Text = "Colour";
                            this.lbEngine.Text = "Engine No";
                            this.lbType.Text = "Category";

                           
                            break;

                        case "boat":

                            this.lbID.Text = "ID";
                            this.lbMake.Text = "Make";
                            this.lbModel.Text = "Model";
                            this.lbColour.Text = "Colour";
                            this.lbEngine.Text = "Engine No";
                            this.lbType.Text = "Category";

                            if (engine == "")
                            {
                                this.tbEngine.Visible = false;
                                this.lbEngine.Visible = false;
                            }

                            if (cat == "")
                            {
                                this.tbType.Visible = false;
                                this.lbType.Visible = false;
                            }

                            break;
                    }


                    this.tbMake.Text = reader["Make"].ToString().Trim();
                    this.tbModel.Text = reader["Model"].ToString().Trim();
                    this.tbColours.Text = reader["Colour"].ToString().Trim();
           

                    this.tbType.Text = "";

                    this.tbID.Text = key;

                    reader.Close();

                    var cmd2 = new SqlCommand("spQueryPNCByKey", conn);

                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add(new SqlParameter("@IDNumber", key.Trim()));

                    using (SqlDataReader rdr = cmd2.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            //Has PNC Records
                            this.tbPolice.Text = "Yes";

                        }

                        rdr.Close();
                    }

                    conn.Close();

                }
                else
                {
                    reader.Close();
                    conn.Close();

                    //No Codes so just direct to default page
                    Response.Redirect(QRMobi.OnRedirectURL);
                }
            }
            else
            {
                
                conn.Close();

                //No Codes so just direct to default page
                Response.Redirect(QRMobi.OnRedirectURL);
            }
            

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            var lo = Decimal.Parse(Long.Text.ToString());
            var la = Decimal.Parse(Lat.Text.ToString());

            string key = tbID.Text.Trim();

            MyProcess.WriteLongLat(key, lo, la);

            Timer1.Enabled = false;
        }

     
        
    }
}