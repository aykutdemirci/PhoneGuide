using PhoneGuide.Application.Dto.Contact;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IContactService
    {
        Task<bool> CreateAsync(DtoCreateContact dtoContact);

        Task<bool> CreateMultipleAsync(List<DtoCreateContact> dtoContacts);

        Task<bool> UpdateAsync(DtoUpdateContact dtoContact);

        Task<bool> DeleteByIdAsync(Guid id);

        List<DtoCreateContact> GetAll();

        Task<DtoCreateContact> GetByIdAsync(Guid id);
    }
}
