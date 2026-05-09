using System;
using Azure;
using System.Net.Http;
using System.Threading.Tasks;                     
using Azure.DigitalTwins.Core;
using Azure.Identity;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.EventGrid.Models;          
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SampleFunctionsApp    
{
    public class ProcessHubToDTEventsMachine2
    {
        private static readonly string adtInstanceUrl = Environment.GetEnvironmentVariable("ADT_SERVICE_URL");
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("ProcessHubToDTEventsMachine2")]
        // While async void should generally be used with caution, it's not uncommon for Azure function apps, since the function app isn't awaiting the task.

        public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log) 

        {
            if (adtInstanceUrl == null) log.LogError("Application setting \"ADT_SERVICE_URL\" not set");

            try
            {
                // Authenticate with Digital Twins instance using DefaultAzureCredential 
                var cred = new DefaultAzureCredential();
                var client = new DigitalTwinsClient(new Uri(adtInstanceUrl), cred);
                //In the line below, replace with the name of the Digital twin created in the twin graph ($dtId) that you want to update
                var digitalTwinId = "Machine_2";
                log.LogInformation($"ADT service client connection created.");
            
                if (eventGridEvent != null && eventGridEvent.Data != null)
                {
                    // Log the raw event data for debugging purposes
                    log.LogInformation(eventGridEvent.Data.ToString());

                    // Parse the event data to extract device message and device ID
                    JObject deviceMessage = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());
                    string deviceId = (string)deviceMessage["systemProperties"]["iothub-connection-device-id"];

                    // The body is base64-encoded JSON
                    // Decode it to get the actual message
                    string bodyBase64 = deviceMessage["body"]?.ToString();
                    string bodyJson = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(bodyBase64));
                    JObject body = JObject.Parse(bodyJson);

                    // extract multiple telemetry/properties (variables from the device message)
                    var counter_Part_MachineToken = body["Counter_Part_Machine"];
                    var level_tankToken = body["Level_Tank"];
                    var valv_Descharge_TankToken = body["Valv_Descharge_Tank"];
                    var valv_Filling_TankToken = body["Valv_Filling_Tank"];

                    // Convert tokens to nullable doubles
                    double? counter_Part_Machine = counter_Part_MachineToken?.Value<double?>();
                    double? level_tank = level_tankToken?.Value<double?>();
                    double? valv_Descharge_Tank = valv_Descharge_TankToken?.Value<double?>();
                    double? valv_Filling_Tank = valv_Filling_TankToken?.Value<double?>();



                    // Share extracted values in logs
                    log.LogInformation($"Device:{deviceId} Counter_Part_Machine:{counter_Part_Machine} Level_Tank:{level_tank} Valv_Descharge_Tank:{valv_Descharge_Tank} Valv_Filling_Tank:{valv_Filling_Tank}");

                    // Update twin with multiple values
                    var updateTwinData = new JsonPatchDocument();
                    bool hasUpdates = false;

                    if (counter_Part_Machine.HasValue)
                    {
                        updateTwinData.AppendReplace("/Counter_Part_Machine", counter_Part_Machine.Value);
                        hasUpdates = true;
                    }
                    if (level_tank.HasValue)
                    {
                        updateTwinData.AppendReplace("/Level_Tank", level_tank.Value);
                        hasUpdates = true;
                    }
                    if (valv_Descharge_Tank.HasValue)
                    {
                        updateTwinData.AppendReplace("/Valv_Descharge_Tank", valv_Descharge_Tank.Value);
                        hasUpdates = true;
                    }
                    if (valv_Filling_Tank.HasValue)
                    {
                        updateTwinData.AppendReplace("/Valv_Filling_Tank", valv_Filling_Tank.Value);
                        hasUpdates = true;
                    }

                    // Update twin with multiple values
                    if (hasUpdates)
                    {
                        await client.UpdateDigitalTwinAsync(digitalTwinId, updateTwinData);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Error in ingest function: {ex.Message}");
            }
        }
    }
}