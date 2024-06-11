using PhoneGuide.Application.Repositories;
using PhoneGuide.Domain.Entities;
using PhoneGuide.Persistance.Contexts;

namespace PhoneGuide.Persistance.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(PhoneGuideDbContext dbContext) : base(dbContext)
        {
        }
    }
}
