using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto;
using PhoneGuide.Domain.Entities;

namespace PhoneGuide.Persistance.Services
{
    public sealed class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(DtoContact dto)
        {
            return await _unitOfWork.ContactRepository.AddAsync(new Contact
            {
                Content = dto.Content,
                PersonId = dto.PersonId,
                ContactType = dto.ContactType,
            });
        }

        public async Task<bool> CreateMultipleAsync(List<DtoContact> dtos)
        {
            return await _unitOfWork.ContactRepository.AddRangeAsync(dtos.Select(q => new Contact
            {
                Content = q.Content,
                PersonId = q.PersonId,
                ContactType = q.ContactType,
            }).ToList());
        }

        public bool DeleteById(Guid id)
        {
            return _unitOfWork.ContactRepository.DeleteById(id.ToString());
        }

        public Task<bool> DeleteRangeAsync(List<DtoContact> contacts)
        {
            return _unitOfWork.ContactRepository.DeleteRangeAsync(contacts.Select(q => new Contact
            {
                Id = q.Id,
                Content = q.Content,
                PersonId = q.PersonId,
                ContactType = q.ContactType,
            }).ToList());
        }

        public List<DtoContact> GetAll()
        {
            var contacts = _unitOfWork.ContactRepository.GetAll();

            return contacts.Select(q => new DtoContact
            {
                Person = q.Person,
                Content = q.Content,
                PersonId = q.PersonId,
                ContactType = q.ContactType,
            }).ToList();
        }

        public async Task<DtoContact> GetByIdAsync(Guid id)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(id.ToString());

            return new DtoContact
            {
                Person = contact.Person,
                Content = contact.Content,
                PersonId = contact.PersonId,
                ContactType = contact.ContactType,
            };
        }

        public async Task<bool> UpdateAsync(DtoContact dto)
        {
            return await _unitOfWork.ContactRepository.UpdateAsync(new Contact
            {
                Content = dto.Content,
                PersonId = dto.PersonId,
                ContactType = dto.ContactType,
            });
        }
    }
}
