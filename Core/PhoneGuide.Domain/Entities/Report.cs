using PhoneGuide.Domain.Entities.Common;
using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Domain.Entities
{
    public class Report : BaseEntity
    {
        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}