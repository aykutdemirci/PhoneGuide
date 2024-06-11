using Microsoft.AspNetCore.Mvc;
using PhoneGuide.API.ServiceEndpoints;
using PhoneGuide.Application.Abstractions.HttpClient;
using PhoneGuide.Application.Dto.Report;
using System.Net;

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

        [HttpGet("GetReportRequests")]
        public async Task<IActionResult> GetReportRequests()
        {
            var reponse = await _httpClient.GetAsync<List<DtoDisplayReport>>(ReportServiceEndpoints.GetReportRequests);

            if (reponse.StatusCode != HttpStatusCode.OK)
            {
                return new StatusCodeResult((int)reponse.StatusCode);
            }

            return Ok(reponse.Data);
        }
    }
}
