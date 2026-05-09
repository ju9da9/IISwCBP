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
    public class ProcessHubToDTEventsDistroSystem
    {
        private static readonly string adtInstanceUrl = Environment.GetEnvironmentVariable("ADT_SERVICE_URL");
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("ProcessHubToDTEventsDistroSystem")]
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
                var digitalTwinId = "Distribution_System_1";
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
                    var counter1Token = body["Count_Distro_1"];
                    var counter2Token = body["Count_Distro_2"];
                    var counter3Token = body["Count_Distro_3"];
                    var counter4Token = body["Count_Distro_4"];
                    var counter5Token = body["Count_Distro_5"];
                    var counter6Token = body["Count_Distro_6"];
                    var counter_Distr_TotalToken = body["Count_Distro_Total"];

                    // Convert tokens to nullable doubles
                    double? counter1 = counter1Token?.Value<double?>();
                    double? counter2 = counter2Token?.Value<double?>();
                    double? counter3 = counter3Token?.Value<double?>();
                    double? counter4 = counter4Token?.Value<double?>();
                    double? counter5 = counter5Token?.Value<double?>();
                    double? counter6 = counter6Token?.Value<double?>();
                    double? counter_Distr_Total = counter_Distr_TotalToken?.Value<double?>();


                    // Share extracted values in logs
                    log.LogInformation($"Device:{deviceId} Count_Distro_1:{counter1} Count_Distro_2:{counter2} Count_Distro_3:{counter3} Count_Distro_4:{counter4} Count_Distro_5:{counter5} Count_Distro_6:{counter6} Count_Distro_Total:{counter_Distr_Total}");

                    // Update twin with multiple values
                    var updateTwinData = new JsonPatchDocument();
                    bool hasUpdates = false;

                    if (counter1.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_1", counter1.Value);
                        hasUpdates = true;
                    }
                    if (counter2.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_2", counter2.Value);
                        hasUpdates = true;
                    }
                    if (counter3.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_3", counter3.Value);
                        hasUpdates = true;
                    }
                    if (counter4.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_4", counter4.Value);
                        hasUpdates = true;
                    }
                    if (counter5.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_5", counter5.Value);
                        hasUpdates = true;
                    }
                    if (counter6.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_6", counter6.Value);
                        hasUpdates = true;
                    }
                    if (counter_Distr_Total.HasValue)
                    {
                        updateTwinData.AppendReplace("/Count_Distro_Total", counter_Distr_Total.Value);
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