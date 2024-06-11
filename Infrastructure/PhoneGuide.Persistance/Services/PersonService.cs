using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto;
using PhoneGuide.Domain.Entities;

namespace PhoneGuide.Persistance.Services
{
    public sealed class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(DtoPerson person)
        {
            return await _unitOfWork.PersonRepository.AddAsync(new Person
            {
                Name = person.Name,
                Company = person.Company,
                LastName = person.LastName,
            });
        }

        public async Task<bool> CreateMultipleAsync(List<DtoPerson> persons)
        {
            return await _unitOfWork.PersonRepository.AddRangeAsync(persons.Select(q => new Person
            {
                Name = q.Name,
                Company = q.Company,
                LastName = q.LastName,
            }).ToList());
        }

        public bool DeleteById(Guid id)
        {
            return _unitOfWork.PersonRepository.DeleteById(id.ToString());
        }

        public Task<bool> DeleteRangeAsync(List<DtoPerson> persons)
        {
            return _unitOfWork.PersonRepository.DeleteRangeAsync(persons.Select(q => new Person
            {
                Id = q.Id,
                Name = q.Name,
                Company = q.Company,
                LastName = q.LastName,
            }).ToList());
        }

        public List<DtoPerson> GetAll()
        {
            var persons = _unitOfWork.PersonRepository.GetAll();

            return persons.Select(q => new DtoPerson
            {
                Name = q.Name,
                Company = q.Company,
                LastName = q.LastName,
            }).ToList();
        }

        public async Task<DtoPerson> GetByIdAsync(Guid id)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(id.ToString());

            return new DtoPerson
            {
                Name = person.Name,
                Company = person.Company,
                LastName = person.LastName,
            };
        }

        public Task<bool> UpdateAsync(DtoPerson person)
        {
            return _unitOfWork.PersonRepository.UpdateAsync(new Person
            {
                Name = person.Name,
                Company = person.Company,
                LastName = person.LastName,
            });
        }
    }
}
