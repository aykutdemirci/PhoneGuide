using PhoneGuide.Domain.Entities.Common;

namespace PhoneGuide.Domain.Entities
{
    public sealed class Person : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
