using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack;
using DummyServer.ServiceModel;
using System.Net;

namespace DummyClient
{
    public partial class Form1 : Form
    {
        static string uri = "http://localhost:2266";
        static JsonServiceClient client = new JsonServiceClient(uri);
        
        public Form1()
        {
            client.RequestFilter += ClientSecurity.AddRequestHeaders;
            client.ResponseFilter += ClientSecurity.ValidateResponseHeaders;
            InitializeComponent();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Hello = client.Get<HelloResponse>("/hello/Cesar");
            label1.Text = Hello.Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create readingsDTO
            ReadingsPost readingsDTO = new ReadingsPost();
            readingsDTO.deviceMeasurementID = 12314;
            readingsDTO.smartboxSN = "A345346";
            readingsDTO.priority = 5;
            readingsDTO.readings.Add(10);
            readingsDTO.readings.Add(12);
            readingsDTO.readings.Add(13);
            readingsDTO.breakerStatusID = 2;
            readingsDTO.periodicalTaskID = 10;
            readingsDTO.meterSN = "a1489021";
            readingsDTO.dateUTCAcquired = 2318972401;
            readingsDTO.dateUTCStoredInGateway = 12489210347;
            readingsDTO.meterStatusFlags = 7863479;
            readingsDTO.meterStatusAnomaliesFlags = 0986290457;
            readingsDTO.meterCommErrorTypeID = 30;
            readingsDTO.isSynchronized = 2;

            //Try to POST readings to server
            try
            {
                var response = client.Post<ReadingsPostResponse>("/readings", readingsDTO);
                label1.Text = response.responsesMsg;
            }
            catch (WebServiceException webEx)
            {
                //Get error Message               
                label1.Text = webEx.GetStatus().ToString() + ": " + webEx.StatusDescription;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create eventDTO
            EventPost eventDTO = new EventPost();
            eventDTO.deviceEventID = 12314;
            eventDTO.eventCategoryID = 2;
            eventDTO.eventSeverityID = 5;
            eventDTO.type = "UNAUTHORIZED_OPENING";
            eventDTO.parameters.Add(1414);
            eventDTO.parameters.Add(12);
            eventDTO.parameters.Add(13);
            eventDTO.username = "cesarinho";
            eventDTO.dateUTC = 153464256;
            eventDTO.dateUTCStoredInGateway = 12489210347;
            eventDTO.smartBoxSN = "Sfw9498";
            eventDTO.meterSN = "A49238";
            eventDTO.isSynchronized = 2;
            eventDTO.priority = 5;
            eventDTO.isExecuted = 1;
            eventDTO.periodicalTaskID = 9999;           
            
            //Try to POST readings to server
            try
            {
                var response = client.Post<EventPostResponse>("/event", eventDTO);
                label1.Text = response.responsesMsg;
            }
            catch (WebServiceException webEx)  
            {
                //Get error Message               
                label1.Text = webEx.GetStatus().ToString() + ": " + webEx.StatusDescription;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            //Try to Query periodical task from server
            try
            {
                //TEST INFO---Tasks that are already in SmartBox
                List<int> tasksInSmartBox = new List<int>();
                tasksInSmartBox.Add(0);
                tasksInSmartBox.Add(2);
                //----------------------------------------------

                //Query for all periodical tasks for the smartbox
                var queryRes = client.Get<PeriodicalTaskQueryResponse>("/periodicaltaskquery");

                //Check for new tasks
                List<int> newTasksIDs = new List<int>();
                foreach (int taskID in queryRes.periodicalTasksID)
                {
                    if (tasksInSmartBox.IndexOf(taskID) == -1)
                        newTasksIDs.Add(taskID);
                }

                //Try to Get new tasks from server
                PeriodicalTaskGet newTasksToGet = new PeriodicalTaskGet();
                newTasksToGet.periodicalTasksRequested = newTasksIDs;
                try
                {
                    var getRes = client.Post<PeriodicalTaskGetResponse>("/periodicaltaskget", newTasksToGet);
                    label1.Text = getRes.periodicalTasks[0].description;
                }
                catch (WebServiceException webEx)
                {
                    //Get error Message               
                    label1.Text = webEx.GetStatus().ToString() + ": " + webEx.StatusDescription;
                }
            }
            catch (WebServiceException webEx)
            {
                //Get error Message               
                label1.Text = webEx.GetStatus().ToString() + ": " + webEx.StatusDescription;
            }
        }
    }
}
