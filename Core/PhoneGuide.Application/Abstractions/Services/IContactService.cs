using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IContactService
    {
        Task<bool> CreateAsync(DtoContact contact);

        Task<bool> CreateMultipleAsync(List<DtoContact> contacts);

        Task<bool> UpdateAsync(DtoContact contact);

        bool DeleteById(Guid id);

        Task<bool> DeleteRangeAsync(List<DtoContact> contacts);

        Task<List<DtoContact>> GetAllAsync();

        Task<DtoContact> GetByIdAsync(Guid id);
    }
}
