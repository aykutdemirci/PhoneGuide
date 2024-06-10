using PhoneGuide.Domain.Entities.Enums;

namespace PhoneGuide.Application.Dto
{
    public class DtoContact
    {
        public ContactTypes ContactType { get; set; }

        public string Content { get; set; }

        public Guid PersonId { get; set; }

        public object Person { get; set; }
    }
}
