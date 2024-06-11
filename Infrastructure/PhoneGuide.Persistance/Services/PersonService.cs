using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneGuide.Application.Abstractions.Caching;
using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto.Person;
using PhoneGuide.Domain.Entities;

namespace PhoneGuide.Persistance.Services
{
    public sealed class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        private readonly ILogger<PersonService> _looger;

        public PersonService(IUnitOfWork unitOfWork, ICacheService cacheService, ILogger<PersonService> looger)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
            _looger = looger;
        }

        public async Task<bool> CreateAsync(DtoCreatePerson dtoPerson)
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

        public async Task<bool> CreateMultipleAsync(List<DtoCreatePerson> dtoPersons)
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

        public async Task<List<DtoDisplayPerson>> GetAllAsync()
        {
            var exists = _cacheService.TryGetValue("all_persons_list", out List<DtoDisplayPerson> personsInCache);

            if (exists)
            {
                _looger.LogInformation("all persons list getting from cache");
                return personsInCache;
            }

            var persons = await _unitOfWork.PersonRepository.GetAll().Select(q => new DtoDisplayPerson
            {
                Name = q.Name,
                Company = q.Company,
                Id = q.Id.ToString(),
                LastName = q.LastName,
            }).ToListAsync();

            _cacheService.Add("all_persons_list", persons);

            return persons;
        }

        public async Task<DtoDisplayPerson> GetByIdAsync(Guid id)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(id.ToString());

            return new()
            {
                Name = person.Name,
                Company = person.Company,
                Id = person.Id.ToString(),
                LastName = person.LastName,
            };
        }

        public async Task<bool> UpdateAsync(DtoUpdatePerson dtoPerson)
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
