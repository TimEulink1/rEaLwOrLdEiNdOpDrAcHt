using EindProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EindProject.Services
{
    public class ApiService
    {
        public async Task<EnvBenfitsResult> GetEnvBenifitsAsync( string siteId, string apiKey)
        {
            string uri = "https://monitoringapi.solaredge.com/site/"+ siteId + "/envBenefits?systemUnits=Metrics&api_key=" + apiKey;
            // Move these lines to a "service" or something
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            var env = JsonSerializer.Deserialize<EnvBenfitsResult>(content);
            return env;
        }
        public async Task<InverterResult> GetInverterDataAsync(string siteId, string apiKey)
        {
            string uri = "https://monitoringapi.solaredge.com/site/" + siteId + "/overview?api_key=" + apiKey;
            // Move these lines to a "service" or something
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            var env = JsonSerializer.Deserialize<InverterResult>(content);
            return env;
        }

        public async Task<WheaterData> GetWheaterDataAsync(string postcode)
        {
            string uri = "https://data.meteoserver.nl/api/solar.php?pc=" + postcode + "&key=6db1cddca4";
            // Move these lines to a "service" or something
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            var wheaterData = JsonSerializer.Deserialize<WheaterData>(content);
            return wheaterData;
        }
    }
}
