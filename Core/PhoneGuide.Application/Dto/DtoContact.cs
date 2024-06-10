using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Application.Dto
{
    public sealed class DtoContact
    {
        public Guid Id { get; set; }

        public ContactTypes ContactType { get; set; }

        public string Content { get; set; }

        public Guid PersonId { get; set; }

        public object Person { get; set; }
    }
}
