using PhoneGuide.Application.Dto.Report;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<bool> CreateAsync(DtoReport dtoCreateReport);

        Task<List<DtoReport>> GetAllAsync();
    }
}
