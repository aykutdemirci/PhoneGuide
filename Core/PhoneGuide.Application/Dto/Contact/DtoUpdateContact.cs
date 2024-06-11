using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Application.Dto.Contact
{
    public class DtoUpdateContact
    {
        public Guid Id { get; set; }

        public ContactTypes ContactType { get; set; }

        public string Content { get; set; }
    }
}
