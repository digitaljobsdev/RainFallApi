using RainfallApi.Application.Interfaces;
using RainfallApi.Application.Exceptions;
using RainfallApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RainfallApi.Infrastructure
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetData(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ExternalApiException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exceptions
                throw new ExternalApiException($"HTTP Request Exception: {ex.Message}", ex);
            }
        }
    }
}
