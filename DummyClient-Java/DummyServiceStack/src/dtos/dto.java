/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dtos;


import java.math.*;
import java.util.*;
import net.servicestack.client.*;

public class dto
{
/* Options:
Date: 2016-12-02 18:16:53
Version: 4.54
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://192.168.3.29:2266

Package: sada2
GlobalNamespace: dto
//AddPropertyAccessors: True
//SettersReturnThis: True
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddDescriptionAsComments: True
//AddImplicitVersion: 
//IncludeTypes: 
//ExcludeTypes: 
//TreatTypesAsStrings: 
//DefaultImports: java.math.*,java.util.*,net.servicestack.client.*
*/

    @Route(Path="/hello", Verbs="GET")
    // @Route(Path="/hello/{Name}", Verbs="GET")
    public static class DTOs implements IReturn<HelloResponse>
    {
        public String Name = null;
        
        public String getName() { return Name; }
        public DTOs setName(String value) { this.Name = value; return this; }
        private static Object responseType = HelloResponse.class;
        public Object getResponseType() { return responseType; }
    }

    @Route(Path="/readings", Verbs="POST")
    public static class ReadingsPost implements IReturn<ReadingsPostResponse>
    {
        public Integer deviceMeasurementID = null;
        public String smartboxSN = null;
        public Integer priority = null;
        public ArrayList<Float> readings = new ArrayList<Float>();
        public Integer breakerStatusID = null;
        public Integer periodicalTaskID = null;
        public Integer meterSN = null;
        public Long dateUTCAcquired = null;
        public Long dateUTCStoredInGateway = null;
        public Long meterStatusFlags = null;
        public Long meterStatusAnomaliesFlags = null;
        public Integer meterCommErrorTypeID = null;
        public Integer isSynchronized = null;
        
        public Integer getDeviceMeasurementID() { return deviceMeasurementID; }
        public ReadingsPost setDeviceMeasurementID(Integer value) { this.deviceMeasurementID = value; return this; }
        public String getSmartboxSN() { return smartboxSN; }
        public ReadingsPost setSmartboxSN(String value) { this.smartboxSN = value; return this; }
        public Integer getPriority() { return priority; }
        public ReadingsPost setPriority(Integer value) { this.priority = value; return this; }
        public ArrayList<Float> getReadings() { return readings; }
        public ReadingsPost setReadings(ArrayList<Float> value) { this.readings = value; return this; }
        public Integer getBreakerStatusID() { return breakerStatusID; }
        public ReadingsPost setBreakerStatusID(Integer value) { this.breakerStatusID = value; return this; }
        public Integer getPeriodicalTaskID() { return periodicalTaskID; }
        public ReadingsPost setPeriodicalTaskID(Integer value) { this.periodicalTaskID = value; return this; }
        public Integer getMeterSN() { return meterSN; }
        public ReadingsPost setMeterSN(Integer value) { this.meterSN = value; return this; }
        public Long getDateUTCAcquired() { return dateUTCAcquired; }
        public ReadingsPost setDateUTCAcquired(Long value) { this.dateUTCAcquired = value; return this; }
        public Long getDateUTCStoredInGateway() { return dateUTCStoredInGateway; }
        public ReadingsPost setDateUTCStoredInGateway(Long value) { this.dateUTCStoredInGateway = value; return this; }
        public Long getMeterStatusFlags() { return meterStatusFlags; }
        public ReadingsPost setMeterStatusFlags(Long value) { this.meterStatusFlags = value; return this; }
        public Long getMeterStatusAnomaliesFlags() { return meterStatusAnomaliesFlags; }
        public ReadingsPost setMeterStatusAnomaliesFlags(Long value) { this.meterStatusAnomaliesFlags = value; return this; }
        public Integer getMeterCommErrorTypeID() { return meterCommErrorTypeID; }
        public ReadingsPost setMeterCommErrorTypeID(Integer value) { this.meterCommErrorTypeID = value; return this; }
        public Integer getIsSynchronized() { return isSynchronized; }
        public ReadingsPost setIsSynchronized(Integer value) { this.isSynchronized = value; return this; }
        private static Object responseType = ReadingsPostResponse.class;
        public Object getResponseType() { return responseType; }
    }

    @Route(Path="/event", Verbs="POST")
    public static class EventPost implements IReturn<EventPostResponse>
    {
        public Integer deviceEventID = null;
        public Integer eventCategoryID = null;
        public Integer eventSeverityID = null;
        public String type = null;
        public ArrayList<Float> parameters = null;
        public String username = null;
        public Long dateUTC = null;
        public Long dateUTCStoredInGateway = null;
        public String smartBoxSN = null;
        public String meterSN = null;
        public Integer isSynchronized = null;
        public Integer priority = null;
        public Integer isExecuted = null;
        public Integer periodicalTaskID = null;
        
        public Integer getDeviceEventID() { return deviceEventID; }
        public EventPost setDeviceEventID(Integer value) { this.deviceEventID = value; return this; }
        public Integer getEventCategoryID() { return eventCategoryID; }
        public EventPost setEventCategoryID(Integer value) { this.eventCategoryID = value; return this; }
        public Integer getEventSeverityID() { return eventSeverityID; }
        public EventPost setEventSeverityID(Integer value) { this.eventSeverityID = value; return this; }
        public String getType() { return type; }
        public EventPost setType(String value) { this.type = value; return this; }
        public ArrayList<Float> getParameters() { return parameters; }
        public EventPost setParameters(ArrayList<Float> value) { this.parameters = value; return this; }
        public String getUsername() { return username; }
        public EventPost setUsername(String value) { this.username = value; return this; }
        public Long getDateUTC() { return dateUTC; }
        public EventPost setDateUTC(Long value) { this.dateUTC = value; return this; }
        public Long getDateUTCStoredInGateway() { return dateUTCStoredInGateway; }
        public EventPost setDateUTCStoredInGateway(Long value) { this.dateUTCStoredInGateway = value; return this; }
        public String getSmartBoxSN() { return smartBoxSN; }
        public EventPost setSmartBoxSN(String value) { this.smartBoxSN = value; return this; }
        public String getMeterSN() { return meterSN; }
        public EventPost setMeterSN(String value) { this.meterSN = value; return this; }
        public Integer getIsSynchronized() { return isSynchronized; }
        public EventPost setIsSynchronized(Integer value) { this.isSynchronized = value; return this; }
        public Integer getPriority() { return priority; }
        public EventPost setPriority(Integer value) { this.priority = value; return this; }
        public Integer getIsExecuted() { return isExecuted; }
        public EventPost setIsExecuted(Integer value) { this.isExecuted = value; return this; }
        public Integer getPeriodicalTaskID() { return periodicalTaskID; }
        public EventPost setPeriodicalTaskID(Integer value) { this.periodicalTaskID = value; return this; }
        private static Object responseType = EventPostResponse.class;
        public Object getResponseType() { return responseType; }
    }

    public static class HelloResponse
    {
        public ResponseStatus ResponseStatus = null;
        public String Result = null;
        
        public ResponseStatus getResponseStatus() { return ResponseStatus; }
        public HelloResponse setResponseStatus(ResponseStatus value) { this.ResponseStatus = value; return this; }
        public String getResult() { return Result; }
        public HelloResponse setResult(String value) { this.Result = value; return this; }
    }

    public static class ReadingsPostResponse
    {
        public String responsesMsg = null;
        
        public String getResponsesMsg() { return responsesMsg; }
        public ReadingsPostResponse setResponsesMsg(String value) { this.responsesMsg = value; return this; }
    }

    public static class EventPostResponse
    {
        public String responsesMsg = null;
        
        public String getResponsesMsg() { return responsesMsg; }
        public EventPostResponse setResponsesMsg(String value) { this.responsesMsg = value; return this; }
    }

}



