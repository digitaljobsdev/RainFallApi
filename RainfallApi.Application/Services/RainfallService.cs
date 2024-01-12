using RainfallApi.Application.Interfaces;
using RainfallApi.Application.Exceptions;
using RainfallApi.Core.Entities;
using RainfallApi.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RainfallApi.Application.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly IRainfallRepository _rainfallRepository;
        private readonly IExternalApiService _externalApiService;

        public RainfallService(IRainfallRepository rainfallRepository, IExternalApiService externalApiService)
        {
            _rainfallRepository = rainfallRepository ?? throw new ArgumentNullException(nameof(rainfallRepository));
            _externalApiService = externalApiService ?? throw new ArgumentNullException(nameof(externalApiService));
        }

        public async Task<RainfallReadingResponse> GetRainfallReadingsAsync(string stationId, int count)
        {
            try
            {
                string result = await _externalApiService.GetData($"http://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/measures");

                // Handle case where GetData returns null (404 Not Found)
                if (result == null)
                {
                    return new RainfallReadingResponse
                    {
                        Readings = new List<RainfallReading>() // or another appropriate handling
                    };
                }

                // Parse the JSON response into FloodMonitoringResponse using Newtonsoft.Json
                var response = JsonConvert.DeserializeObject<FloodMonitoringResponse>(result);
                Console.WriteLine($"Response API: {response.ToString}");
                // Convert the response to your RainfallReadingResponse model
                var rainfallReadingResponse = new RainfallReadingResponse
                {
                    
                    Readings = MapToFloodReadings(response.Items)
                };

                return rainfallReadingResponse;
            }
            catch (ExternalApiException ex)
            {
                // Handle external API exceptions
                Console.WriteLine($"External API Exception: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Exception: {ex.Message}");
                throw; // Re-throw the exception to allow handling at a higher level
            }
        }

        private IEnumerable<RainfallReading> MapToFloodReadings(IEnumerable<Item> items)
        {
            var rainfallReadings = new List<RainfallReading>();

            foreach (var item in items)
            {
                var latestReading = item.LatestReading;

                if (latestReading != null)
                {
                    var rainfallReading = new RainfallReading
                    {
                        dateMeasured = latestReading.dateTime, // Convert DateTime to string
                        amountMeasured = latestReading.value
                    };

                    rainfallReadings.Add(rainfallReading);
                }
            }

            return rainfallReadings;
        }
    }
}
