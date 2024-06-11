using PhoneGuide.Application.Abstractions.HttpClient;
using PhoneGuide.Application.Dto.HttpClient;
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

        public async Task<DtoHttpResponse<T>> GetAsync<T>(string endpointRoute) where T : class
        {
            var responseMessage = await _httpClient.GetAsync(endpointRoute);

            var httpResponse = new DtoHttpResponse<T> { StatusCode = responseMessage.StatusCode };

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                httpResponse.Data = await responseMessage.Content.ReadFromJsonAsync<T>();
            }

            return httpResponse;
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
