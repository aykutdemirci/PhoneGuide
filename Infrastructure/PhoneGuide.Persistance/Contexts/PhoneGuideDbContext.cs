using Microsoft.EntityFrameworkCore;
using PhoneGuide.Domain.Entities;
using PhoneGuide.Domain.Entities.Common;

namespace PhoneGuide.Persistance.Contexts
{
    public sealed class PhoneGuideDbContext : DbContext
    {
        public PhoneGuideDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
