using PhoneGuide.Application.Dto.Person;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IPersonService
    {
        Task<bool> CreateAsync(DtoCreatePerson dtoPerson);

        Task<bool> CreateMultipleAsync(List<DtoCreatePerson> dtoPersons);

        Task<bool> UpdateAsync(DtoUpdatePerson dtoPerson);

        Task<bool> DeleteByIdAsync(Guid id);

        List<DtoDisplayPerson> GetAll();

        Task<DtoDisplayPerson> GetByIdAsync(Guid id);
    }
}
