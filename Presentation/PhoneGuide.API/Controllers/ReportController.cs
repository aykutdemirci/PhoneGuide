using Microsoft.AspNetCore.Mvc;
using PhoneGuide.API.ServiceEndpoints;
using PhoneGuide.Application.Abstractions.HttpClient;

namespace PhoneGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IHttpClient _httpClient;

        public ReportController(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("CreateReportRequest")]
        public async Task<IActionResult> CreateReportRequest()
        {
            var statusCode = await _httpClient.PostAsync(ReportServiceEndpoints.CreateReportRequest);
            return new StatusCodeResult((int)statusCode);
        }
    }
}
