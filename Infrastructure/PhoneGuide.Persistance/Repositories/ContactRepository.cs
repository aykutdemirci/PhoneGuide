using PhoneGuide.Application.Repositories;
using PhoneGuide.Domain.Entities;
using PhoneGuide.Persistance.Contexts;

namespace PhoneGuide.Persistance.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PhoneGuideDbContext dbContext) : base(dbContext)
        {
        }
    }
}
