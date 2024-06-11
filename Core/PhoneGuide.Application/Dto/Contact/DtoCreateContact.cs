using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Application.Dto.Contact
{
    public sealed class DtoCreateContact
    {
        public ContactTypes ContactType { get; set; }

        public string Content { get; set; }

        public string PersonId { get; set; }
    }
}
