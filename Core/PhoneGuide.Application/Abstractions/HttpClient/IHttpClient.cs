using PhoneGuide.Application.Dto.HttpClient;
using System.Net;

namespace PhoneGuide.Application.Abstractions.HttpClient
{
    public interface IHttpClient
    {
        Task<HttpStatusCode> PostAsync<T>(string enpointRoute, T data) where T : class;

        Task<HttpStatusCode> PostAsync(string endpointRoute);

        Task<DtoHttpResponse<T>> GetAsync<T>(string endpointRoute) where T : class;
    }
}
