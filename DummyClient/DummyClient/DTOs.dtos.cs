/* Options:
Date: 2016-12-06 08:03:17
Version: 4.54
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://localhost:2266

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using DummyServer.ServiceModel;


namespace DummyServer.ServiceModel
{

    [Route("/hello", "GET")]
    [Route("/hello/{Name}", "GET")]
    public partial class DTOs
        : IReturn<HelloResponse>
    {
        public virtual string Name { get; set; }
    }

    [Route("/event", "POST")]
    public partial class EventPost
        : IReturn<EventPostResponse>
    {
        public EventPost()
        {
            parameters = new List<float>{};
        }

        public virtual int deviceEventID { get; set; }
        public virtual int eventCategoryID { get; set; }
        public virtual int eventSeverityID { get; set; }
        public virtual string type { get; set; }
        public virtual List<float> parameters { get; set; }
        public virtual string username { get; set; }
        public virtual long dateUTC { get; set; }
        public virtual long dateUTCStoredInGateway { get; set; }
        public virtual string smartBoxSN { get; set; }
        public virtual string meterSN { get; set; }
        public virtual int isSynchronized { get; set; }
        public virtual int priority { get; set; }
        public virtual int isExecuted { get; set; }
        public virtual int periodicalTaskID { get; set; }
    }

    public partial class EventPostResponse
    {
        public virtual string responsesMsg { get; set; }
    }

    public partial class HelloResponse
    {
        public virtual ResponseStatus ResponseStatus { get; set; }
        public virtual string Result { get; set; }
    }

    [Route("/periodicaltaskget", "GET")]
    public partial class PeriodicalTaskGet
        : IReturn<PeriodicalTaskGetResponse>
    {
        public PeriodicalTaskGet()
        {
            periodicalTasksRequested = new List<int>{};
        }

        public virtual List<int> periodicalTasksRequested { get; set; }
    }

    public partial class PeriodicalTaskGetResponse
    {
        public PeriodicalTaskGetResponse()
        {
            periodicalTasks = new List<PeriodicalTaskGetResponse.PeriodicalTask>{};
        }

        public virtual List<PeriodicalTaskGetResponse.PeriodicalTask> periodicalTasks { get; set; }

        public partial class PeriodicalTask
        {
            public virtual int periodicalTaskID { get; set; }
            public virtual int deviceRequestTypeID { get; set; }
            public virtual int periodicalTaskVersion { get; set; }
            public virtual string name { get; set; }
            public virtual string description { get; set; }
            public virtual string smartBoxSN { get; set; }
            public virtual int serviceUserID { get; set; }
            public virtual long programmingDate { get; set; }
            public virtual long validityStartDate { get; set; }
            public virtual long validityEndDate { get; set; }
            public virtual int frequencyID { get; set; }
            public virtual int frequencyValue { get; set; }
            public virtual string username { get; set; }
            public virtual int isSystemDefault { get; set; }
            public virtual int isEnabled { get; set; }
            public virtual int isSynchronized { get; set; }
            public virtual int isScheduled { get; set; }
        }
    }

    [Route("/periodicaltaskquery", "GET")]
    public partial class PeriodicalTaskQuery
        : IReturn<PeriodicalTaskQueryResponse>
    {
    }

    public partial class PeriodicalTaskQueryResponse
    {
        public PeriodicalTaskQueryResponse()
        {
            periodicalTasksID = new List<int>{};
        }

        public virtual List<int> periodicalTasksID { get; set; }
    }

    [Route("/readings", "POST")]
    public partial class ReadingsPost
        : IReturn<ReadingsPostResponse>
    {
        public ReadingsPost()
        {
            readings = new List<float>{};
        }

        public virtual int deviceMeasurementID { get; set; }
        public virtual string smartboxSN { get; set; }
        public virtual int priority { get; set; }
        public virtual List<float> readings { get; set; }
        public virtual int breakerStatusID { get; set; }
        public virtual int periodicalTaskID { get; set; }
        public virtual string meterSN { get; set; }
        public virtual long dateUTCAcquired { get; set; }
        public virtual long dateUTCStoredInGateway { get; set; }
        public virtual long meterStatusFlags { get; set; }
        public virtual long meterStatusAnomaliesFlags { get; set; }
        public virtual int meterCommErrorTypeID { get; set; }
        public virtual int isSynchronized { get; set; }
    }

    public partial class ReadingsPostResponse
    {
        public virtual string responsesMsg { get; set; }
    }
}

