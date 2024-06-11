using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Dto.Contact;
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

        public async Task<bool> CreateAsync(DtoCreateContact dtoContact)
        {
            var added = await _unitOfWork.ContactRepository.AddAsync(new Contact
            {
                Content = dtoContact.Content,
                ContactType = dtoContact.ContactType,
                PersonId = Guid.Parse(dtoContact.PersonId),
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<bool> CreateMultipleAsync(List<DtoCreateContact> dtoContacts)
        {
            var added = await _unitOfWork.ContactRepository.AddRangeAsync(dtoContacts.Select(q => new Contact
            {
                Content = q.Content,
                ContactType = q.ContactType,
                PersonId = Guid.Parse(q.PersonId),
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

        public List<DtoCreateContact> GetAll()
        {
            var contacts = _unitOfWork.ContactRepository.GetAll();

            return contacts.Select(q => new DtoCreateContact
            {
                Content = q.Content,
                ContactType = q.ContactType,
                PersonId = q.PersonId.ToString(),
            }).ToList();
        }

        public async Task<DtoCreateContact> GetByIdAsync(Guid id)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(id.ToString());

            return new DtoCreateContact
            {
                Content = contact.Content,
                ContactType = contact.ContactType,
                PersonId = contact.PersonId.ToString(),
            };
        }

        public async Task<bool> UpdateAsync(DtoUpdateContact dtoUpdateContact)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(dtoUpdateContact.Id.ToString());

            contact.Content = dtoUpdateContact.Content;
            contact.ContactType = dtoUpdateContact.ContactType;

            var updated = _unitOfWork.ContactRepository.Update(contact);

            if (updated) await _unitOfWork.SaveAsync();

            return updated;
        }
    }
}
