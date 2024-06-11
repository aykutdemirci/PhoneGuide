using Microsoft.AspNetCore.Mvc;
using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Dto.Report;
using PhoneGuide.Domain.Entities.Enums;
using System.Net;

namespace PhoneGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public ReportController()
        {
        }

        [HttpPost("CreateReportRequest")]
        public IActionResult CreateReportRequest()
        {
            return Ok();
        }
    }
}
