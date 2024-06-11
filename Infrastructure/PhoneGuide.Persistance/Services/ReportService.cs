using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto.Report;
using PhoneGuide.Domain.Entities.Enums;
using PhoneGuide.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PhoneGuide.Persistance.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(DtoCreateReport dtoCreateReport)
        {
            var added = await _unitOfWork.ReportRepository.AddAsync(new Report
            {
                RequestedDate = dtoCreateReport.RequestedDate,
                ReportStatus = dtoCreateReport.ReportStatus,
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<List<DtoCreateReport>> GetAllAsync()
        {
            return await _unitOfWork.ReportRepository.GetAll().Select(q => new DtoCreateReport
            {
                RequestedDate = q.RequestedDate,
                ReportStatus = q.ReportStatus,
            }).ToListAsync();
        }
    }
}
