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

        public async Task<bool> CreateAsync(DtoContact dtoContact)
        {
            var added = await _unitOfWork.ContactRepository.AddAsync(new Contact
            {
                Content = dtoContact.Content,
                PersonId = dtoContact.PersonId,
                ContactType = dtoContact.ContactType,
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<bool> CreateMultipleAsync(List<DtoContact> dtoContacts)
        {
            var added = await _unitOfWork.ContactRepository.AddRangeAsync(dtoContacts.Select(q => new Contact
            {
                Content = q.Content,
                PersonId = q.PersonId,
                ContactType = q.ContactType,
            }).ToList());

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var deleted = await _unitOfWork.ContactRepository.DeleteByIdAsync(id.ToString());

            if (deleted) await _unitOfWork.SaveAsync();

            return deleted;
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

        public async Task<bool> UpdateAsync(DtoContact dtoContact)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(dtoContact.Id.ToString());

            contact.Id = dtoContact.Id;
            contact.Content = dtoContact.Content;
            contact.PersonId = dtoContact.PersonId;
            contact.ContactType = dtoContact.ContactType;

            var updated = _unitOfWork.ContactRepository.Update(contact);

            if (updated) await _unitOfWork.SaveAsync();

            return updated;
        }
    }
}
