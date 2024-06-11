using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IContactService
    {
        Task<bool> CreateAsync(DtoContact dtoContact);

        Task<bool> CreateMultipleAsync(List<DtoContact> dtoContacts);

        Task<bool> UpdateAsync(DtoContact dtoContact);

        Task<bool> DeleteByIdAsync(Guid id);

        List<DtoContact> GetAll();

        Task<DtoContact> GetByIdAsync(Guid id);
    }
}
