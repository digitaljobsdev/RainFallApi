using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiUrl = "http://environment.data.gov.uk/flood-monitoring/id/stations/{id}/measures";
        string stationId = "026090"; // Replace with the actual station ID

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Make the GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl.Replace("{id}", stationId));

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read and output the response content
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
