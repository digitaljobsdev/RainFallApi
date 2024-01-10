using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RainFallApi
{
    class Program
    {
        static async Task Main()
        {
            // Replace {id} with the actual station ID
            string stationId = "026090";

            // Create an instance of the application
            var app = new RainFallApi(new HttpClient());

            // Call the method to get and display the data
            await app.Run(stationId);
        }
    }

    public class RainFallApi
    {
        private readonly HttpClient _httpClient;

        public RainFallApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task Run(string stationId)
        {
            // Replace the base URL with the correct one
            string apiUrl = $"http://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/measures";

            try
            {
                string result = await GetData(apiUrl);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async Task<string> GetData(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}
