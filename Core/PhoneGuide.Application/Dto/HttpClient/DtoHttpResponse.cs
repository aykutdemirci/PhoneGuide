using System.Net;

namespace PhoneGuide.Application.Dto.HttpClient
{
    public class DtoHttpResponse<T> where T : class
    {
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
