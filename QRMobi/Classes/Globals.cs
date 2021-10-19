using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRMobi
{
    public class Globals
    {
        public static string DirPath = "";
        public static string LogPath = "";

        public static string KeyFieldValue = "";
        public static string SessionID = "";
        public static string Prefix = "";

    }

    public class LatLongEntry
    {
        public string Application { get; set; }
        public string ApplicationArea { get; set; }
        public string CreatedBy { get; set; }
        public string DeviceDateTime { get; set; }
        public string DeviceID { get; set; }
        public string DevicePermissionGiven { get; set; }
        public string DeviceUserID { get; set; }
        public string IMEI { get; set; }
        public string IPAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LookupCode { get; set; }
        public string MembershipPrefix { get; set; }
        public string PostCode { get; set; }
        public string QRCodeURL { get; set; }
        public string SecurityCode { get; set; }
        public string SystemType { get; set; }
        public string UserGUID { get; set; }
        public string UserName { get; set; }
        public string WFStatus { get; set; }
        public string WTW { get; set; }
        public string Address { get; set; }


    }

    public class AuditEntry
    {
        public string ActionSrc { get; set; }
        public string Application { get; set; }
        public string CreatedBy { get; set; }
        public string DatabaseName { get; set; }
        public string IDNumber { get; set; }
        public string LastAction { get; set; }
        public string MemberNum { get; set; }
        public string MessageText { get; set; }
        public string TableName { get; set; }


    }

    static class QRMobi
    {
        //Application Parameters

        public static string SQLConn;       //Server Connection String
        public static string SQLServer;     //Server Name
        public static string UserID;        //User ID
        public static string Password;      //Password
        public static string OnSubmitURL;   //URL Submit Validate
        public static string OnRedirectURL; //URL Redirect After Form Submitt

        //Mail Stuff - Default
        public static string SMTPServer;    //SMTP Server
        public static string AuthID;        //SMTP Authentication ID
        public static string AuthPassword;  //SMTP Authentication Password
        public static int SMTPPort;         //SMTP Port
        public static string Originator;    //Originator
        public static string SendTo;        //Sent To Address
        public static string Subject;       //Email Subject
        public static string Body;          //Body Text

    }

}