using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto.Report;
using PhoneGuide.Domain.Entities.Enums;
using PhoneGuide.Domain.Entities;

namespace PhoneGuide.Persistance.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(DtoReport dtoCreateReport)
        {
            var added = await _unitOfWork.ReportRepository.AddAsync(new Report
            {
                RequestedDate = DateTime.UtcNow,
                ReportStatus = ReportStatus.Preparing,
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<List<DtoReport>> GetAllAsync()
        {
            return await _unitOfWork.ReportRepository.GetAll().Select(q => new DtoReport
            {
                RequestedDate = q.RequestedDate,
                ReportStatus = q.ReportStatus,
            }).ToListAsync();
        }
    }
}
