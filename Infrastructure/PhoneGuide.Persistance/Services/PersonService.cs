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

        public async Task<bool> CreateAsync(DtoPerson dtoPerson)
        {
            var added = await _unitOfWork.PersonRepository.AddAsync(new Person
            {
                Name = dtoPerson.Name,
                Company = dtoPerson.Company,
                LastName = dtoPerson.LastName,
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<bool> CreateMultipleAsync(List<DtoPerson> dtoPersons)
        {
            var added = await _unitOfWork.PersonRepository.AddRangeAsync(dtoPersons.Select(q => new Person
            {
                Name = q.Name,
                Company = q.Company,
                LastName = q.LastName,
            }).ToList());

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var deleted = await _unitOfWork.PersonRepository.DeleteByIdAsync(id.ToString());

            if (deleted) await _unitOfWork.SaveAsync();

            return deleted;
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

        public async Task<bool> UpdateAsync(DtoPerson dtoPerson)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(dtoPerson.Id.ToString());

            person.Name = dtoPerson.Name;
            person.Company = dtoPerson.Company;
            person.LastName = dtoPerson.LastName;

            var updated = _unitOfWork.PersonRepository.Update(person);

            if (updated) await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
