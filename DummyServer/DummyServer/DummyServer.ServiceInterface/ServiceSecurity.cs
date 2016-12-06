using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Web;
using ServiceStack;
using System.Net;
using System.Security;
using System.Web;

namespace DummyServer.ServiceInterface
{
    //API custom Http headers class
    public class ApiCustomHttpHeaders
    {        
        public static string UserId = "VEWS-USERID";
        public static string DeviceId = "VEWS-DEVICEID";
        public static string Signature = "VEWS-SIGNATURE";
        public static string SignatureMethod = "VEWS-SIGN_METHOD";
        public static string VEWSVersion = "VEWS-VERSION";
        public static string TimeStamp = "VEWS-RESTIME";
        public static string ReqId = "VEWS-REQID";
    }

    //Class to check the Headers from the client Http request
    public class HeaderAutentication : ServiceStack.RequestFilterAttribute, IHasRequestFilter
    {
        //Overloaded servicestack function used to call the CanExecute function. It is automatically called
        //by servicestack when a request is executed
        public override void Execute(IRequest req, IResponse res, object response)
        {
            CanExecute(req, res);
        }

        //Own function to check the validity of the Http header fields
        private void CanExecute(IRequest req, IResponse res)
        {
            //SERVER TEST INFO
            string serverVEWSversion = "V1R1";
            string serverSignatureMethod = "HMAC_SHA256";
            System.DateTime initDate = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan serverTime = new TimeSpan(System.DateTime.UtcNow.Ticks - initDate.Ticks);
            int requestExpirationTime = 5;  //minutes

            //Check for valid userID
            var reqUserId = req.Headers[ApiCustomHttpHeaders.UserId];
            if (string.IsNullOrEmpty(reqUserId))
            {
                //Send code 400 Bad Request with error message
                string errorMsg = string.Format("You must provide a valid user ID for your request");
                res.StatusCode = 400;
                res.StatusDescription = errorMsg;
                return;
            }

            //Check for valid deviceID
            var reqDeviceID = req.Headers[ApiCustomHttpHeaders.DeviceId];
            if (string.IsNullOrEmpty(reqDeviceID))
            {
                //Send code 400 Bad Request with error message
                string errorMsg = string.Format("You must provide a valid device ID for your request");
                res.StatusCode = 400;
                res.StatusDescription = errorMsg;
                return;
            }
            
            //Check if the signature method of the client is the same of the server
            var reqSignatureMethod = req.Headers[ApiCustomHttpHeaders.SignatureMethod];
            if (reqSignatureMethod != serverSignatureMethod)
            {
                //Send code 400 Bad Request with error message
                string errorMsg = string.Format(
                    "The signature method of the client is not the same as the server's. Server's signature method: {0}, Client's signature method: {1}",
                    serverSignatureMethod, reqSignatureMethod);
                res.StatusCode = 400;
                res.StatusDescription = errorMsg;
                return;
            }

            //Check if the VEWS version of the client is the same of the server
            var reqVEWSVersion = req.Headers[ApiCustomHttpHeaders.VEWSVersion];
            if(reqVEWSVersion != serverVEWSversion)
            {
                //Send code 400 Bad Request with error message
                string errorMsg = string.Format(
                    "The VEWS version of the client is not the same as the server's. Server's VEWS version: {0}, Client's VEWS version: {1}",
                    serverVEWSversion, reqVEWSVersion);
                res.StatusCode = 400;
                res.StatusDescription = errorMsg;
                return;
            }

            //Check if the request is still valid using the timestamp
            var reqTimeStamp = Convert.ToInt64(req.Headers[ApiCustomHttpHeaders.TimeStamp]);            
            float minsTimeDifference = Math.Abs((float)(serverTime.TotalMilliseconds - reqTimeStamp) / 60000);
            if(minsTimeDifference > requestExpirationTime)
            {
                //Send code 400 Bad Request with error message
                string errorMsg = string.Format(
                    "The request timestamp must be within {0} minutes of the server time. Your request is {1:0.000} minutes compared to the server. Server time is currently {2} {3} (UTC)",
                    requestExpirationTime,
                    minsTimeDifference,
                    DateTime.UtcNow.ToLongDateString(),
                    DateTime.UtcNow.ToLongTimeString());
                res.StatusCode = 400;
                res.StatusDescription = errorMsg;
                return;
            }

            //Check for valid request id
            var reqId = req.Headers[ApiCustomHttpHeaders.ReqId];
            if (string.IsNullOrEmpty(reqId))
            {
                //Send code 400 Bad Request with error message
                string errorMsg = string.Format("You must provide a valid request ID");
                res.StatusCode = 400;
                res.StatusDescription = errorMsg;
                return;
            }
        }        
    }

    //Class to add the respective headers to the server response
    public class ResponseHeaderAddition : ServiceStack.ResponseFilterAttribute, IHasResponseFilter
    {
        //Overloaded servicestack function automatically called to send a response to the client
        public override void Execute(IRequest req, IResponse res, object response)
        {
            AddResponseHeaders(req, res, response);
        }

        //Own function that adds the custom Http headers to the server's response
        private void AddResponseHeaders(IRequest req, IResponse res, object dto)
        {
            res.ContentType = MimeTypes.Json;

            //Get TimeStamp
            System.DateTime initDate = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan tsUtcTime = new TimeSpan(System.DateTime.UtcNow.Ticks - initDate.Ticks);
            //var token = ApiSignature.CreateToken(res, dto == null ? string.Empty : dto.SerializeToString(), _secret);  

            //Add custom fields to header
            if(!string.IsNullOrEmpty(ApiCustomHttpHeaders.UserId))
                res.AddHeader(ApiCustomHttpHeaders.UserId, req.GetHeader(ApiCustomHttpHeaders.UserId));
            if (!string.IsNullOrEmpty(ApiCustomHttpHeaders.DeviceId))
                res.AddHeader(ApiCustomHttpHeaders.DeviceId, req.GetHeader(ApiCustomHttpHeaders.DeviceId));
            res.AddHeader(ApiCustomHttpHeaders.Signature, "sdgthdtyj");
            res.AddHeader(ApiCustomHttpHeaders.VEWSVersion, "V1R0");
            res.AddHeader(ApiCustomHttpHeaders.SignatureMethod, "HMAC_SHA256");
            res.AddHeader(ApiCustomHttpHeaders.TimeStamp, ((ulong)tsUtcTime.TotalMilliseconds).ToString());
            if (!string.IsNullOrEmpty(ApiCustomHttpHeaders.ReqId))
                res.AddHeader(ApiCustomHttpHeaders.ReqId, req.GetHeader(ApiCustomHttpHeaders.ReqId));                                              
        }
    }
}
