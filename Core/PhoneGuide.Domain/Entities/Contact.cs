using PhoneGuide.Domain.Entities.Common;
using PhoneGuide.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneGuide.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public ContactTypes ContactType { get; set; }

        public string Content { get; set; }

        public Guid PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
