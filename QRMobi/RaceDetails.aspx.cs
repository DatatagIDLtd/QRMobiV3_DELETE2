using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace QRMobi
{
    public partial class RaceDetails : System.Web.UI.Page
    {
        string key = "";
        SqlConnection conn =  new SqlConnection("Data Source = 54.246.102.210; Initial Catalog = DTMaster; User ID = DTUser; Password=DTUser1");
        public class raceDetails
        {
            public string Date { get; set; }
            public string Event { get; set; }
            public string Organised_By { get; set; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["id"];


            List<raceDetails> records = new List<raceDetails>();
            conn.Open();
                //get data from table
                string SQLRaceData = "SELECT RaceLocation, DateOfRace, OfficialName from MSRaceData where IDNumber = '" + key + "' order by DateOfRace desc";
                System.Diagnostics.Debug.WriteLine(SQLRaceData);
                var raceData = new SqlCommand(SQLRaceData, conn);
                SqlDataReader readerRaceData = raceData.ExecuteReader();
                while (readerRaceData.Read())
                {
                    var raceLoc = readerRaceData["RaceLocation"].ToString().Trim();
                    var dateRace = readerRaceData["DateOfRace"].ToString().Substring(0, 10).Trim();
                    var officer = readerRaceData["OfficialName"].ToString().Trim();
                    records.Add(new raceDetails
                    {
                             Date = dateRace,
                              Event = raceLoc,
                              Organised_By = officer,

                     });
                }
            readerRaceData.Close();
            conn.Close();
            this.searchData.DataSource = null;
            this.searchData.DataSource = records;
            this.searchData.DataBind();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            string pathname = "~/qr.aspx?id=" + key ;
         //   Response.Redirect(pathname);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

        }
    }
}
