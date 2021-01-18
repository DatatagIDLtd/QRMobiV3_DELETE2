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