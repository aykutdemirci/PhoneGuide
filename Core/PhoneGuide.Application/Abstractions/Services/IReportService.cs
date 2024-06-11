using PhoneGuide.Application.Dto.Report;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<bool> CreateAsync(DtoCreateReport dtoCreateReport);

        Task<List<DtoDisplayReport>> GetAllAsync();
    }
}
