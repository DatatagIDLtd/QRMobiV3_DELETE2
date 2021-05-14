﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DTMyDatatag.Helpers;

namespace QRMobi
{
    public partial class Webcyc : System.Web.UI.Page
    {
        Processes MyProcess = new Processes();

        SqlConnection conn;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            int ret;
            bool found = false;

            ret = MyProcess.LoadIniFile("QRCycle.ini");

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

            //string key = "C104A4AZ";
            //string code = "101618291";

            //http://localhost:62229/qrcyc.aspx?id=C104A4AZ&code=101618291

            //Get Params
            string key = Request.QueryString["id"];
            string code = Request.QueryString["code"];

            if (key != "" && key != null)
            {
                string SQLComm = "SELECT Make,Model,Colour,Engine_Number,VIN,Frame_Number from vODVSec where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

                var cmd = new SqlCommand(SQLComm, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    found = true;
                }
                else
                {
                    reader.Close();

                    SQLComm = "SELECT Make,Model,Colour,Engine_Number,VIN,Frame_Number from vODVSecMU where IDNumber = '" + key + "' and SecretCode = '" + code + "'";

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

                    this.tbMake.Text = reader["Make"].ToString().Trim();
                    this.tbModel.Text = reader["Model"].ToString().Trim();
                    this.tbColours.Text = reader["Colour"].ToString().Trim();
                    this.tbEngine.Text = engine;
                    this.tbVINSER.Text = vinser;
                    this.tbFrameNo.Text = frame;

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
                   
                    conn.Close();

                    string msg = "QR Scan from Cycle Scheme using ID:" + key + " Code:" + code + " was not located";

                    var eventDataHelper = new EventDataHelper();

                    eventDataHelper.SendNoExpectionEventData("Anonymous", "", msg, "IDNumber", key);

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