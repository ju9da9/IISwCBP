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
    public class ProcessHubToDTEventsConveyorTracking
    {
        private static readonly string adtInstanceUrl = Environment.GetEnvironmentVariable("ADT_SERVICE_URL");
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("ProcessHubToDTEventsConveyorTracking")]
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
                var digitalTwinId = "Conveyor_Tracking_1";
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
                    var vel_CT3Token = body["vel_CT3"];
                    var vel_CT4Token = body["vel_CT4"];
                    var vel_CT5Token = body["vel_CT5"];
                    var vel_CT6Token = body["vel_CT6"];
                    var vel_CT7Token = body["vel_CT7"];


                    // Convert tokens to nullable doubles
                    double? vel_CT3 = vel_CT3Token?.Value<double?>();
                    double? vel_CT4 = vel_CT4Token?.Value<double?>();
                    double? vel_CT5 = vel_CT5Token?.Value<double?>();
                    double? vel_CT6 = vel_CT6Token?.Value<double?>();
                    double? vel_CT7 = vel_CT7Token?.Value<double?>();


                    // Share extracted values in logs
                    log.LogInformation($"Device:{deviceId} vel_CT3:{vel_CT3} vel_CT4:{vel_CT4} vel_CT5:{vel_CT5} vel_CT6:{vel_CT6} vel_CT7:{vel_CT7}");

                    // Update twin with multiple values
                    var updateTwinData = new JsonPatchDocument();
                    bool hasUpdates = false;

                    if (vel_CT3.HasValue)
                    {
                        updateTwinData.AppendReplace("/vel_CT3", vel_CT3.Value);
                        hasUpdates = true;
                    }
                    if (vel_CT4.HasValue)
                    {
                        updateTwinData.AppendReplace("/vel_CT4", vel_CT4.Value);
                        hasUpdates = true;
                    }
                    if (vel_CT5.HasValue)
                    {
                        updateTwinData.AppendReplace("/vel_CT5", vel_CT5.Value);
                        hasUpdates = true;
                    }
                    if (vel_CT6.HasValue)
                    {
                        updateTwinData.AppendReplace("/vel_CT6", vel_CT6.Value);
                        hasUpdates = true;
                    }
                    if (vel_CT7.HasValue)
                    {
                        updateTwinData.AppendReplace("/vel_CT7", vel_CT7.Value);
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