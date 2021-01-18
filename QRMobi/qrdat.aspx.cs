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
    public partial class Webdat : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            int ret;
            bool found = false;

            ret = MyProcess.LoadIniFile("QRStandard.ini");

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

            //string key = "DT06M2YB2B";
            //string code = "302201557";

            //http://localhost:62229/qrdat.aspx?id=C104A4AZ&code=101618291

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,Engine_Number,VIN,Frame_Number,SerialNum from vODVSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }
                else
                {
                    reader.Close();

                    SQLComm = "SELECT Make,Model,Colour,Engine_Number,VIN,Frame_Number,SerialNum from vODVSecMU where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                    cmd = new SqlCommand(SQLComm, conn);

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows) { found = true; }
                }

                if (found)
                {
                    reader.Read();

                    string engine = reader["Engine_Number"].ToString().Trim();
                    string frame = reader["Frame_Number"].ToString().Trim();
                    string vinser = reader["VIN"].ToString().Trim();
                    string ser = reader["SerialNum"].ToString().Trim();

                    if (ser == "")
                    {
                        this.tbSerial.Visible = false;
                        this.lbSerial.Visible = false;
                    }

                    if (engine == "")
                    {
                        this.tbEngine.Visible = false;
                        this.lbEngine.Visible = false;
                    }

                    if (frame == "")
                    {
                        this.tbFrameNo.Visible = false;
                        this.lbFrame.Visible = false;
                    }

                    if (vinser == "")
                    {
                        this.tbVINSER.Visible = false;
                        this.lbVinSer.Visible = false;
                    }


                    this.lbID.Text = "ID";
                    this.lbMake.Text = "Make";
                    this.lbModel.Text = "Model";
                    this.lbColour.Text = "Colour";
                    this.lbEngine.Text = "Engine No";
                    this.lbVinSer.Text = "Vin/Ser";
                    this.lbFrame.Text = "Frame Number";
                    this.lbSerial.Text = "Serial Number";

                    this.tbMake.Text = reader["Make"].ToString().Trim();
                    this.tbModel.Text = reader["Model"].ToString().Trim();
                    this.tbColours.Text = reader["Colour"].ToString().Trim();
                    this.tbEngine.Text = engine;
                    this.tbVINSER.Text = vinser;
                    this.tbFrameNo.Text = frame;
                    this.tbSerial.Text = ser;

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
                //No Codes so just direct to default page
                Response.Redirect(QRMobi.OnRedirectURL);
            }
            

        }
    }
}