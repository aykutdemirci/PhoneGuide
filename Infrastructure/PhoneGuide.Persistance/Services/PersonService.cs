using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto;
using PhoneGuide.Domain.Entities;

namespace PhoneGuide.Persistance.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(DtoPerson dto)
        {
            return await _unitOfWork.PersonRepository.AddAsync(new Person
            {
                Name = dto.Name,
                Company = dto.Company,
                LastName = dto.LastName,
            });
        }

        public async Task<bool> CreateMultipleAsync(List<DtoPerson> dtos)
        {
            return await _unitOfWork.PersonRepository.AddRangeAsync(dtos.Select(q => new Person
            {
                Name = q.Name,
                Company = q.Company,
                LastName = q.LastName,
            }).ToList());
        }

        public bool DeleteById(Guid id)
        {
            return _unitOfWork.PersonRepository.Delete(id);
        }

        public async Task<List<DtoPerson>> GetAllAsync()
        {
            var persons = await _unitOfWork.PersonRepository.GetAllAsync();

            return persons.Select(q => new DtoPerson
            {
                Name = q.Name,
                Company = q.Company,
                LastName = q.LastName,
            }).ToList();
        }

        public async Task<DtoPerson> GetByIdAsync(Guid id)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(id);

            return new DtoPerson
            {
                Name = person.Name,
                Company = person.Company,
                LastName = person.LastName,
            };
        }

        public Task<bool> UpdateAsync(DtoPerson dto)
        {
            return _unitOfWork.PersonRepository.UpdateAsync(new Person
            {
                Name = dto.Name,
                Company = dto.Company,
                LastName = dto.LastName,
            });
        }
    }
}
