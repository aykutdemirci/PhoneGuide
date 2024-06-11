using PhoneGuide.Application.Abstractions.HttpClient;
using PhoneGuide.Infrastructure.Configurations;
using System.Net;
using System.Net.Http.Json;

namespace PhoneGuide.Infrastructure.Services.HttpClientServices
{
    public class ReportServiceHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public ReportServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(HttpClientConfigs.ReportServiceBaseUrl);
        }

        public async Task<HttpStatusCode> PostAsync<T>(string enpointRoute, T data) where T : class
        {
            var responseMessage = await _httpClient.PostAsJsonAsync(enpointRoute, data);

           return responseMessage.StatusCode;
        }

        public async Task<HttpStatusCode> PostAsync(string enpointRoute)
        {
            var responseMessage = await _httpClient.PostAsync(enpointRoute, null);

            return responseMessage.StatusCode;
        }
    }
}
