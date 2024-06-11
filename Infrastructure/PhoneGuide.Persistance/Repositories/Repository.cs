using Microsoft.EntityFrameworkCore;
using PhoneGuide.Application.Repositories;
using PhoneGuide.Domain.Entities.Common;
using PhoneGuide.Persistance.Contexts;

namespace PhoneGuide.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PhoneGuideDbContext _dbContext;

        public Repository(PhoneGuideDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entites)
        {
            await Table.AddRangeAsync(entites);
            return true;
        }

        public bool DeleteById(string id)
        {
            var entity = Task.Run(async () => await GetByIdAsync(id)).ConfigureAwait(false).GetAwaiter().GetResult();

            var entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteRangeAsync(List<T> entities)
        {
            await Task.Run(() => Table.RemoveRange(entities));
            return true;
        }

        public IQueryable<T> GetAll(bool tracking = false)
        {
            if (!tracking) return Table.AsQueryable();

            return Table.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var queryable = Table.AsQueryable();

            if (!tracking) queryable = queryable.AsNoTracking();

            return await queryable.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
