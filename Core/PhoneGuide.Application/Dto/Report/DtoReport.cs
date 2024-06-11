using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Application.Dto.Report
{
    public class DtoReport
    {
        public Guid Id { get; set; }

        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}
