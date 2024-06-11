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
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("CreateReportRequest")]
        public async Task<IActionResult> Create()
        {
            var dtoReport = new DtoCreateReport { ReportStatus = ReportStatus.Preparing, RequestedDate = DateTime.UtcNow };

            var result = await _reportService.CreateAsync(dtoReport);

            if (result) return new StatusCodeResult((int)HttpStatusCode.Created);

            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("GetAllReportRequests")]
        public async Task<IActionResult> GetAllReportRequests()
        {
            var reports = await _reportService.GetAllAsync();

            return Ok(reports);
        }
    }
}
