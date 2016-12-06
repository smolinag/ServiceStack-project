using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using System.IO;

namespace DummyClient
{
    public class ApiCustomHttpHeaders
    {
        public static string UserId = "VEWS-USERID";
        public static string DeviceId = "VEWS-DEVICEID";
        public static string Signature = "VEWS-SIGNATURE";
        public static string SignatureMethod = "VEWS-SIGN_METHOD";
        public static string VEWSVersion = "VEWS-VERSION";
        public static string ReqId = "VEWS-REQID";
        public static string TimeStamp = "VEWS-RESTIME";
    }

    public static class ClientSecurity
    {
        public static void AddRequestHeaders(System.Net.HttpWebRequest request)
        {
            request.ContentType = MimeTypes.Json;

            //Get information to make request   
            //UserId                  
            string userIdStr = "1";
            //DeviceId
            string deviceIdStr = "10";
            //Signature
            //var token = ApiSignature.CreateToken(request, reqDto == null ? string.Empty : reqDto.SerializeToString(), _secret);
            string signatureStr = "feagiserg";
            //SignatureMethod
            string signatureMethodStr = "HMAC_SHA256";
            //VEWS version
            string vewsVersionStr = "V1R1";
            //TimeStamp
            //System.DateTime initDate = new DateTime(1969, 12, 31, 23, 54, 59);
            System.DateTime initDate = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan tsUtcTime = new TimeSpan(System.DateTime.UtcNow.Ticks - initDate.Ticks);
            string timeStampStr = ((ulong)tsUtcTime.TotalMilliseconds).ToString();
            //RequestId
            string requestIdStr = userIdStr + deviceIdStr + timeStampStr;

            //Add custom fields to header
            request.Headers.Add(ApiCustomHttpHeaders.UserId, userIdStr);            
            request.Headers.Add(ApiCustomHttpHeaders.DeviceId, deviceIdStr);
            request.Headers.Add(ApiCustomHttpHeaders.Signature, signatureStr);
            request.Headers.Add(ApiCustomHttpHeaders.SignatureMethod, signatureMethodStr);
            request.Headers.Add(ApiCustomHttpHeaders.VEWSVersion, vewsVersionStr);            
            request.Headers.Add(ApiCustomHttpHeaders.TimeStamp, timeStampStr);
            request.Headers.Add(ApiCustomHttpHeaders.ReqId, requestIdStr);            
            request.SendChunked = false;
        }

        public static void ValidateResponseHeaders(System.Net.HttpWebResponse response)
        {
            string serverTimestamp = response.Headers[ApiCustomHttpHeaders.TimeStamp];
        }
    }
}
