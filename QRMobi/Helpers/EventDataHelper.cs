using DTCommsLib1;
using DTCommsLib1.Models;
using System;
using System.Web.Configuration;


namespace DTMyDatatag.Helpers
{
    public class EventDataHelper
    {
        readonly ExceptionClient _exceptionClient;
        readonly ClientConfig _clientConfig;
        readonly string _APIUserName;
        readonly string _APIPassword;
        readonly string _APIToken;
        readonly string _EmailRecipient;
        readonly string _EmailRegex;
        readonly int _EventSourceID;
        readonly ClientEmailConfig _clientEmailConfig;
        readonly string _From;
        readonly string _Subject;
        readonly string _SmtpPort;
        readonly string _SmtpHost;
        readonly string _EnableSSL;
        readonly string _UseDefaultCredentials;
        readonly string _Username;
        readonly string _Password;
        readonly string _Endpoint;

        public EventDataHelper()
        {
            _exceptionClient = new ExceptionClient();
            _APIUserName = WebConfigurationManager.AppSettings["APIUserName"];
            _APIPassword = WebConfigurationManager.AppSettings["APIPassword"];
            _APIToken = WebConfigurationManager.AppSettings["APIToken"];
            _EmailRecipient = WebConfigurationManager.AppSettings["EmailRecipient"];
            _EmailRegex = WebConfigurationManager.AppSettings["EmailRegex"];
            _EventSourceID = Convert.ToInt32(WebConfigurationManager.AppSettings["EventSourceID"]);
            _From = WebConfigurationManager.AppSettings["EmailFrom"];
            _Subject = WebConfigurationManager.AppSettings["EmailSubject"];
            _SmtpPort = WebConfigurationManager.AppSettings["EmailSmtpPort"];
            _SmtpHost = WebConfigurationManager.AppSettings["EmailSmtpHost"];
            _EnableSSL = WebConfigurationManager.AppSettings["EmailEnableSSL"];
            _UseDefaultCredentials = WebConfigurationManager.AppSettings["EmailUseDefaultCredentials"];
            _Username = WebConfigurationManager.AppSettings["EmailUsername"];
            _Password = WebConfigurationManager.AppSettings["EmailPassword"];
            _Endpoint = WebConfigurationManager.AppSettings["Endpoint"];

            _clientConfig = new ClientConfig()
            {
                ContentType = "application/json",
                APIUserName = _APIUserName,
                APIPassword = _APIPassword,
                APIToken = _APIToken,
                EmailRecipient = _EmailRecipient,
                EmailRegex = _EmailRegex
            };

            _clientEmailConfig = new ClientEmailConfig()
            {
                From = _From,
                Subject = _Subject,
                SmtpPort = Convert.ToInt32(_SmtpPort),
                SmtpHost = _SmtpHost,
                EnableSSL = Convert.ToBoolean(_EnableSSL),
                UseDefaultCredentials = Convert.ToBoolean(_UseDefaultCredentials),
                Username = _Username,
                Password = _Password,
                EmailRegEx = _EmailRegex,
                EmailRecipient = _EmailRecipient
            };
        }

        public void SendNoExpectionEventData(string username, string tableField, string fieldData, string recordID, string keyValue)
        {
            try
            {
                _clientConfig.HttpMethod = "POST";
                _clientConfig.Endpoint = _Endpoint;
                _clientConfig.ObjectName = "EventData";
                _clientConfig.OperatorID = "";
                _clientConfig.UserName = username;
                _clientConfig.EventSourceID = 20;
                _clientConfig.DatabaseName = "QR Databases";
                _clientConfig.TableName = "";
                _clientConfig.TableField = tableField; //Either "ColourID1", "InteriorColour" or "ProductID".
                _clientConfig.FieldData = "";
                _clientConfig.RecordID = recordID; //Some kind of unique identifier of the record - AstItemCode.
                _clientConfig.EventAdviceID = 45;
                _clientConfig.Destination = "DTDEAD";
                _clientConfig.Mute = false;
                _clientConfig.SnoozeUntil = "";
                _clientConfig.EventTypeID = 401;
                _clientConfig.MembershipType = "";
                _clientConfig.KeyName = recordID;
                _clientConfig.KeyValue = keyValue; //IDNumber.
                _clientConfig.Report = fieldData;
                _clientConfig.EmailRecipient = WebConfigurationManager.AppSettings["EmailRecipient"];
                _clientConfig.CreatedBy = username;
                _clientConfig.APIFields = new System.Collections.Generic.Dictionary<string, string>();
                

                var response = _exceptionClient.AddException(_clientConfig);
                if (response.ToUpper().Contains("ERROR"))
                {
                    _exceptionClient.SendEmail(_clientEmailConfig, response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}