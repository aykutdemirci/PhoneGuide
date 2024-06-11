using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IPersonService
    {
        Task<bool> CreateAsync(DtoCreatePerson dtoPerson);

        Task<bool> CreateMultipleAsync(List<DtoCreatePerson> dtoPersons);

        Task<bool> UpdateAsync(DtoUpdatePerson dtoPerson);

        Task<bool> DeleteByIdAsync(Guid id);

        List<DtoCreatePerson> GetAll();

        Task<DtoCreatePerson> GetByIdAsync(Guid id);
    }
}
