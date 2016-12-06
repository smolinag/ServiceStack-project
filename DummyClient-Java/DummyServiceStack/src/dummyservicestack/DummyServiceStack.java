/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dummyservicestack;



import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.stream.JsonReader;
import dtos.dto.EventPostResponse;
import dtos.dto.HelloResponse;
import dtos.dto.ReadingsPost;
import dtos.dto.ReadingsPostResponse;
import java.io.IOException;
import java.io.Reader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.cert.PKIXRevocationChecker.Option;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.ws.Response;
import net.servicestack.client.WebServiceException;
import net.servicestack.client.AsyncResult;
import net.servicestack.client.ConnectionFilter;
import net.servicestack.client.ExceptionFilter;
import net.servicestack.client.HttpHeaders;
import net.servicestack.client.JsonServiceClient;
import static net.servicestack.client.Log.e;
import net.servicestack.client.Utils;



 
/**
 *
 * @author Cesar
 */
public class DummyServiceStack {

    /**
     * @param args the command line arguments
     * @throws java.io.IOException
     */
    public static void main(String[] args) throws IOException {
       
      // String uri = "http://192.168.3.29:2266";
       String uri = "http://localhost:2266";
       JsonServiceClient client = new JsonServiceClient(uri);
     
        //Adding headers
        client.RequestFilter = ClientSecurity::AddRequestHeaders;
       ////////////////////////POST SERVICE////////////////////////////////// 
       
       ReadingsPost readingsDTO = new ReadingsPost();
       readingsDTO.deviceMeasurementID = 12314;
       readingsDTO.smartboxSN = "A345346";
       readingsDTO.priority = 5;
       readingsDTO.readings.add(10F);
       readingsDTO.readings.add(12F);
       readingsDTO.readings.add(13F);
       readingsDTO.breakerStatusID = 2;
       readingsDTO.periodicalTaskID = 10;
       readingsDTO.meterSN = 1489021;
       readingsDTO.dateUTCAcquired = 2318972401L;
       readingsDTO.dateUTCStoredInGateway = 12489210347L;
       readingsDTO.meterStatusFlags = 7863479L;
       readingsDTO.meterStatusAnomaliesFlags = 986290457L;
       readingsDTO.meterCommErrorTypeID = 30;
       readingsDTO.isSynchronized = 2;
      //Reader reader = null;
     // client.getGson().newJsonReader(reader).setLenient(true);
  
       try
       {
         
         ReadingsPostResponse resPost = client.post(uri+"/readings", readingsDTO, ReadingsPostResponse.class);
         System.out.println(resPost.getResponsesMsg());
         
       }
       catch(WebServiceException webEx)
       {
          System.out.println(webEx.getStatusDescription());
           // Get error Message from response body
          // int index = webEx.getMessage().lastIndexOf("{");//.getErrorMessage().lastIndexOf("{");
         //  String errorMsg = "";
           //if (index > 0)
             //  errorMsg = webEx.getMessage().substring(0, index);
       }
       
           
       
      ////////////////////////GET SERVICE////////////////////////////////// 
       
      //HelloResponse response = client.get(uri+"/hello/Cesar", HelloResponse.class);
      // System.out.println( client.get("/hello/Cesar").getInputStream().read());
       

        
    } 
   
}

