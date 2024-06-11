using PhoneGuide.Application.Repositories;
using PhoneGuide.Domain.Entities;
using PhoneGuide.Persistance.Contexts;

namespace PhoneGuide.Persistance.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneGuideDbContext dbContext) : base(dbContext)
        {
        }
    }
}
