using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IContactService
    {
        Task<bool> CreateAsync(DtoContact dto);

        Task<bool> CreateMultipleAsync(List<DtoContact> dtos);

        Task<bool> UpdateAsync(DtoContact dto);

        bool DeleteById(Guid id);

        Task<List<DtoContact>> GetAllAsync();

        Task<DtoContact> GetByIdAsync(Guid id);
    }
}
