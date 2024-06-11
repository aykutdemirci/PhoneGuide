using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Application.Dto.Report
{
    public class DtoDisplayReport
    {
        public string Id { get; set; }

        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}
