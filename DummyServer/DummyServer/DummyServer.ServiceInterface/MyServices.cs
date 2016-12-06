using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using DummyServer.ServiceModel;

namespace DummyServer.ServiceInterface
{
    public class MyServices : Service
    {
        public object Get(DTOs request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name + Info.hmac };
        }

        [HeaderAutentication]       //Header authentication profile
        [ResponseHeaderAddition]    //Response header addition profile
        public object Post(ReadingsPost readings)
        {
            ReadingsPostResponse res = new ReadingsPostResponse { responsesMsg = "a"};

            //Check if the response status code is correct to store info in DB and send back response
            if (Response.StatusCode == 200)
            {
                Info.hmac = readings.smartboxSN;
                res.responsesMsg = readings.readings[0].ToString();
            }
            return res;                  
        }

        [HeaderAutentication]       //Header authentication profile
        [ResponseHeaderAddition]    //Response header addition profile
        public object Post(EventPost receivedEvent)
        {
            EventPostResponse res = new EventPostResponse { responsesMsg = "a"};

            //Check if the response status code is correct to store info in DB and send back response
            if (Response.StatusCode == 200)
            {
                Info.hmac = receivedEvent.type;
                res.responsesMsg = receivedEvent.parameters[0].ToString();
            }
            return res;
        }

        [HeaderAutentication]       //Header authentication profile
        [ResponseHeaderAddition]    //Response header addition profile
        public object Get(PeriodicalTaskQuery tasksQueryRequest)
        {
            PeriodicalTaskQueryResponse tasksIDs = new PeriodicalTaskQueryResponse(); 

            //Check if the response status code is correct to store info in DB and send back response
            if (Response.StatusCode == 200)
            {
                string smartBoxSN = Request.Headers[ApiCustomHttpHeaders.DeviceId];

                //----Perform query in DB for smartbox tasks, return list with tasks IDs------
                //CODE HERE
                //------------------------------------------------------------------------

                //----TEST CODE----
                tasksIDs.periodicalTasksID = new List<int>();
                tasksIDs.periodicalTasksID.Add(0);
                tasksIDs.periodicalTasksID.Add(1);
                tasksIDs.periodicalTasksID.Add(2);
                tasksIDs.periodicalTasksID.Add(3);
                //-----------------
            }

            return tasksIDs;
        }

        [HeaderAutentication]       //Header authentication profile
        [ResponseHeaderAddition]    //Response header addition profile
        public object Post(PeriodicalTaskGet taskGetRequest)
        {
            PeriodicalTaskGetResponse tasksList = new PeriodicalTaskGetResponse { };
            tasksList.periodicalTasks = new List<PeriodicalTaskGetResponse.PeriodicalTask>();

            //Check if the response status code is correct to store info in DB and send back response
            if (Response.StatusCode == 200)
            {
                string smartBoxSN = Request.Headers[ApiCustomHttpHeaders.DeviceId];

                //----Perform query in DB for smartbox tasks, return list with tasks IDs------
                //CODE HERE
                //------------------------------------------------------------------------

                //----TEST CODE----
                //List of all tasks for SmartBox
                List<PeriodicalTaskGetResponse.PeriodicalTask> allTasksList = CreatePeriodicalTasksDUMMY();

                //Get all requested tasks from the list
                for (int i=0; i<allTasksList.Count; i++)
                {
                    if(taskGetRequest.periodicalTasksRequested.IndexOf(allTasksList[i].periodicalTaskID) != -1)
                        tasksList.periodicalTasks.Add(allTasksList[i]);
                }                
                //-----------------
            }
            return tasksList;
        }

        //DUMMY FUNCTION TO CREATE PERIODICAL TASKS
        public List<PeriodicalTaskGetResponse.PeriodicalTask> CreatePeriodicalTasksDUMMY()
        {
            List<PeriodicalTaskGetResponse.PeriodicalTask> tasksList = new List<PeriodicalTaskGetResponse.PeriodicalTask>();
            PeriodicalTaskGetResponse.PeriodicalTask task = new PeriodicalTaskGetResponse.PeriodicalTask();
            int ntasks = 5;

            for (int i=0; i<ntasks; i++)
            {
                //Conform periodical task
                task.periodicalTaskID = i;
                task.deviceRequestTypeID = Int32.Parse(Request.Headers[ApiCustomHttpHeaders.DeviceId]);
                task.periodicalTaskVersion = i;
                task.name = "Monthly request";
                task.description = "Task for getting the monthly consumption";
                task.smartBoxSN = Request.Headers[ApiCustomHttpHeaders.DeviceId];
                task.serviceUserID = Int32.Parse(Request.Headers[ApiCustomHttpHeaders.UserId]);
                task.programmingDate = i * 5738346;
                task.validityStartDate = i * 17489675;
                task.validityEndDate = i * 57836589;
                task.frequencyID = i * 4;
                task.frequencyValue = i * 5;
                task.username = "SGO";
                task.isSystemDefault = 1;
                task.isEnabled = 1;
                task.isSynchronized = 1;
                task.isScheduled = 0;

                tasksList.Add(task.CreateCopy());
            }

            return tasksList;
        }
    }
}

