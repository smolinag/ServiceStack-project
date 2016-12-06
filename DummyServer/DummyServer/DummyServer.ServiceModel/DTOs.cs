using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Web;

namespace DummyServer.ServiceModel
{
    //===================================Server Http methods================================
    [Route("/hello", "GET")]
    [Route("/hello/{Name}", "GET")]
    public class DTOs : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public ResponseStatus ResponseStatus { get; set; } //Automatic exception handling

        public string Result { get; set; }
    }

    //Post measurement
    [Route("/readings", "POST")]
    public class ReadingsPost : IReturn<ReadingsPostResponse>
    {
        public int deviceMeasurementID { get; set; }
        public string smartboxSN { get; set; }
        public int priority { get; set; }
        public List<float> readings { get; set; }
        public int breakerStatusID { get; set; }
        public int periodicalTaskID { get; set; }
        public string meterSN { get; set; }
        public long dateUTCAcquired { get; set; }
        public long dateUTCStoredInGateway { get; set; }
        public long meterStatusFlags { get; set; }
        public long meterStatusAnomaliesFlags { get; set; }
        public int meterCommErrorTypeID { get; set; }
        public int isSynchronized { get; set; }
    }

    //Response to measurement post
    public class ReadingsPostResponse
    {
        public string responsesMsg { get; set; }
    }

    //Post event
    [Route("/event", "POST")]
    public class EventPost
    {
        public int deviceEventID { get; set; }
        public int eventCategoryID { get; set; }
        public int eventSeverityID { get; set; }
        public string type { get; set; }
        public List<float> parameters { get; set; }
        public string username { get; set; }
        public long dateUTC { get; set; }
        public long dateUTCStoredInGateway { get; set; }
        public string smartBoxSN { get; set; }
        public string meterSN { get; set; }
        public int isSynchronized { get; set; }
        public int priority { get; set; }
        public int isExecuted { get; set; }
        public int periodicalTaskID { get; set; }
    }

    //Response to event post
    public class EventPostResponse
    {
        public string responsesMsg { get; set; }
    }
    
    //Query of periodical tasks (To check if there are new available)
    [Route("/periodicaltaskquery", "GET")]
    public class PeriodicalTaskQuery : IReturn<PeriodicalTaskQueryResponse>
    {
    }

    //Response to periodical tasks query (List of all tasks for the specified smartbox)
    public class PeriodicalTaskQueryResponse
    {
        public List<int> periodicalTasksID { get; set; }        
    }

    //Get periodical tasks not stored in smartbox
    [Route("/periodicaltaskget", "POST")]
    public class PeriodicalTaskGet : IReturn<PeriodicalTaskGetResponse>
    {
        public List<int> periodicalTasksRequested { get; set; }
    }

    //Response to periodical tasks get (List of all tasks not stored yet in smartbox)
    public class PeriodicalTaskGetResponse
    {
        public class PeriodicalTask
        {
            public int periodicalTaskID { get; set; }
            public int deviceRequestTypeID { get; set; }
            public int periodicalTaskVersion { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string smartBoxSN { get; set; }
            public int serviceUserID { get; set; }
            public long programmingDate { get; set; }
            public long validityStartDate { get; set; }
            public long validityEndDate { get; set; }
            public int frequencyID { get; set; }
            public int frequencyValue { get; set; }
            public string username { get; set; }
            public int isSystemDefault { get; set; }
            public int isEnabled { get; set; }
            public int isSynchronized { get; set; }
            public int isScheduled { get; set; }
        }

        public List<PeriodicalTask> periodicalTasks { get; set; }
    }

    //Class to store information
    public static class Info
    {
        public static string hmac = "oe";
    }
}