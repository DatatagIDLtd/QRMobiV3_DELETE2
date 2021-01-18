using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;


namespace QRMobi
{
    public partial class Qr
        : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            int ret;
            string SQLComm = "";
            bool found = false;

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


            //Get Params
            string key = Request.QueryString["id"];
            key = "UK00A4AD";

            string pathname = "~/qrMasterNew.aspx?id=" + key;
            Response.Redirect(pathname);
            //..https://www.datatag.mobi/qr.aspx?id=UK00A4AD

            //      string key = "UK00A4AD";

            if (key != "" && key != null)
            {

                SQLComm = "SELECT Make,Model,Colour,EngineNum,VIN from VehUKQR where IDNumber = '" + key + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }
                else
                {
                    reader.Close();

                    SQLComm = "SELECT Make,Model,Colour,EngineNum,VIN from VehMUQR where IDNumber = '" + key + "'";

                    cmd = new SqlCommand(SQLComm, conn);

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows) 
                    { 
                        found = true; 
                    }

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

                    this.tbMake.Text = reader[0].ToString();
                    this.tbModel.Text = reader[1].ToString();
                    this.tbColours.Text = reader[2].ToString();
                    this.tbEngine.Text = reader[3].ToString();
                    this.tbVINSER.Text = reader[4].ToString();

                    this.tbType.Text = "Motorcycle";

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
                            this.lbPolice.Text = "There may be further information held on this asset. Please call our 24/7 Security Register on 0345 0700 440";

                        }

                        rdr.Close();
                    }
                }
                else
                {
                    //No Codes so just direct to default page

                    reader.Close();

                    Response.Redirect(QRMobi.OnRedirectURL);
                }

            }

            conn.Close();

        } //End Page Load


        protected void Page_Close(object sender, EventArgs e)
        {
            conn.Close();
        }
     
    }
}