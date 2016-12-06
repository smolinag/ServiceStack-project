/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dummyservicestack;

import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import static com.oracle.jrockit.jfr.DataType.UTF8;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.util.Map;
import net.servicestack.client.HttpHeaders;
import net.servicestack.client.MimeTypes;
import net.servicestack.client.Utils;
import net.servicestack.client.WebServiceException;

/**
 *
 * @author Cesar
 */
public class ClientSecurity {
   public static void AddRequestHeaders(HttpURLConnection request)
   {
     
            //Get information to make request   
            //UserId                  
            String userIdStr = "1";
            //DeviceId
            String deviceIdStr = "10";
            //Signature
            String signatureStr = "feagiserg";
            //SignatureMethod
            String signatureMethodStr = "HMAC_SHA256";
            //VEWS version
            String vewsVersionStr = "V1R0";
            //TimeStamp
            String timeStampStr = Long.toString(System.currentTimeMillis());
            //RequestId
            String requestIdStr = userIdStr + deviceIdStr + timeStampStr;
            
            request.addRequestProperty(ApiCustomHttpHeaders.UserId, userIdStr);
            request.addRequestProperty(ApiCustomHttpHeaders.DeviceId, deviceIdStr);
            request.addRequestProperty(ApiCustomHttpHeaders.Signature, signatureStr);
            request.addRequestProperty(ApiCustomHttpHeaders.SignatureMethod, signatureMethodStr);
            request.addRequestProperty(ApiCustomHttpHeaders.VEWSVersion, vewsVersionStr);
            request.addRequestProperty(ApiCustomHttpHeaders.TimeStamp, timeStampStr);
            request.addRequestProperty(ApiCustomHttpHeaders.ReqId, requestIdStr);
            request.setUseCaches(false);
            request.setDoInput(true);
            request.setDoOutput(true);
            
   }

   public static void ValidateResponseHeaders(HttpURLConnection response)
        {
            String serverTimestamp = response.getHeaderField(ApiCustomHttpHeaders.TimeStamp);
        }
}
