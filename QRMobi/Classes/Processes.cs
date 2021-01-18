using System;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;

namespace QRMobi
{
    public class Processes
    {
        public string GetImageAssetURL(string make, string model)
        {

            string url = "";

            //Connect to SQL Database
            SqlConnection conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "SELECT URL from EquipmentImage where Make = '" + make + "' and model = '" + model + "'";

            //System.Diagnostics.Debug.WriteLine(SQLComm);

            var cmd = new SqlCommand(SQLComm, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                url = reader["URL"].ToString();

            }

            reader.Close();
            conn.Close();

            return url;
        }

        public string GetImageAssetOtherURL(string make, string model, string type)
        {

            string url = "";

            //Connect to SQL Database
            SqlConnection conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "";

            switch (type.ToUpper())
            {

                case "WWWSPARES":

                    SQLComm = "SELECT URL from EquipmentLinks where Make = '" + make + "' and model = '" + model + "' and type = '" + type + "'";

                    break;

                case "PDFMANUAL":

                    SQLComm = "SELECT URL from EquipmentLinks where Make = '" + make + "' and model = '" + model + "' and type = '" + type + "'";

                    break;

                case "PDFSERVICE":

                    SQLComm = "SELECT URL from EquipmentLinks where Make = '" + make + "' and model = '" + model + "' and type = '" + type + "'";

                    break;

                default:

                    break;
            }


            var cmd = new SqlCommand(SQLComm, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                url = reader["URL"].ToString();

            }

    
            reader.Close();
            conn.Close();

            return url;
        }

        public string GetImageOEMURL(string guid)
        {

            string url = "";

            //Connect to SQL Database
            SqlConnection conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "SELECT * from vwAppBrand where MemProviderUserID = '"+guid+"'";

            //string SQLComm = "SELECT URL from EquipmentImage where Make = '" + make + "' and model = '" + model + "'";

            System.Diagnostics.Debug.WriteLine(SQLComm);

            var cmd = new SqlCommand(SQLComm, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                url = reader["OEMBrandImageURL"].ToString();

            }

            return url;
        }

        public int WriteLongLat(string ID, decimal LongVal, decimal LatValue)
        {

            if (LongVal == 0 || LatValue == 0) return 0;

            if (ID == "") return 0;

            //Connect to SQL Database

            SqlConnection conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "INSERT INTO MSLatLong (IDNumber,Long,Lat) values ('"+ID+"'," + LongVal + "," + LatValue + ")";

            var cmd = new SqlCommand(SQLComm, conn);

            cmd.ExecuteNonQuery();

            conn.Close();

            return 0;
        }

        public int WriteLongLatPlus(string ID, decimal LongVal, decimal LatValue,string ECVCode, string Src)
        {

            //if (LongVal == 0 || LatValue == 0) return 0;

            if (ID == "") return 0;

            //Connect to SQL Database
            SqlConnection conn = new SqlConnection(QRMobi.SQLConn);

            conn.Open();

            string SQLComm = "INSERT INTO MSQRScanLog (CesarID,ECVCode,Long,Lat,Src) values ('" + ID + "','" + ECVCode + "'," + LongVal + "," + LatValue + ",'"+Src+"')";

            var cmd = new SqlCommand(SQLComm, conn);

            cmd.ExecuteNonQuery();

            conn.Close();

            return 0;
        }

        public int WriteLongLatSP(string AssetID, string ECVCode, string Latitude, string Longitude, string UserGUID, string IPAddress, string Address, string PostCode, string DeviceID)
        {

            //Connect to SQL Database
            SqlConnection conn = new SqlConnection(QRMobi.SQLConn);

            string retcode = "";

       

            string prms = "'" + AssetID +
                      "','" + ECVCode +
                      "','" + Latitude +
                      "','" + Longitude +
                      "','" + UserGUID +
                      "','" + IPAddress +
                      "','" + Address +
                      "','" + PostCode +
                      "','" + DeviceID + "'";
          

            string SQLComm = "EXEC usp_AddGeoDataLog " + prms;

            var cmd = new SqlCommand(SQLComm, conn);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                string temp = e.Message;
                //int rtn = (int)cmd.Parameters["@ReturnCode"].Value;
            }

            conn.Close();
            return 0;
        }

        public int LoadIniFile(string IniName)
        {
            StreamReader reader;

            Globals.DirPath = "c:\\Datatag\\QR\\";
           
            try
            {

                reader = new StreamReader(Globals.DirPath + IniName);

                do
                {
                    QRMobi.SQLConn = reader.ReadLine();
                    QRMobi.SQLServer = reader.ReadLine();
                    QRMobi.UserID = reader.ReadLine();
                    QRMobi.Password = reader.ReadLine();
                    QRMobi.OnSubmitURL = reader.ReadLine();
                    QRMobi.OnRedirectURL = reader.ReadLine();
                    QRMobi.SMTPServer = reader.ReadLine();
                    QRMobi.AuthID = reader.ReadLine();
                    QRMobi.AuthPassword = reader.ReadLine();
                    QRMobi.SMTPPort = Convert.ToInt32(reader.ReadLine());
                    QRMobi.Originator = reader.ReadLine();
                    QRMobi.SendTo = reader.ReadLine();
                    QRMobi.Subject = reader.ReadLine();
                    QRMobi.Body = reader.ReadLine();

                }
                while (reader.Peek() != -1);

                reader.Close();

            }
            catch
            {

            }

            return 0;
              
        }


        public int SendEmail(string from, string to, string subject, string body, string fileattach)
        {
            MailMessage mailObj = new MailMessage(from, to, subject, body);

            SmtpClient SMTPServer = new SmtpClient(QRMobi.SMTPServer);

            SMTPServer.Port = QRMobi.SMTPPort;
            SMTPServer.Credentials = new System.Net.NetworkCredential(QRMobi.AuthID, QRMobi.AuthPassword);
            SMTPServer.EnableSsl = false;

            if (fileattach != "")
            {
                Attachment MyAtt = new Attachment(fileattach);

                mailObj.Attachments.Add(MyAtt);
            }

            try
            {
                SMTPServer.Send(mailObj);
            }
            catch (Exception e)
            {

            }

            return 0;
        }


        public int WriteLocalLogRecord(string Message,string prefix)
        {

            using (StreamWriter wLog = File.AppendText(Globals.LogPath + prefix+"QRMobi" + ".log"))
            {
                wLog.Write("\r\nLog Entry : ");
                wLog.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
              
                wLog.WriteLine(Message);
                wLog.WriteLine("-------------------------------");

                wLog.Close();
            }

            return 0;
        }


    }
}