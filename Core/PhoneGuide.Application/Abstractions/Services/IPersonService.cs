using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IPersonService
    {
        Task<bool> CreateAsync(DtoPerson dto);

        Task<bool> CreateMultipleAsync(List<DtoPerson> dtos);

        Task<bool> UpdateAsync(DtoPerson dto);

        bool DeleteById(Guid id);

        Task<List<DtoPerson>> GetAllAsync();

        Task<DtoPerson> GetByIdAsync(Guid id);
    }
}
