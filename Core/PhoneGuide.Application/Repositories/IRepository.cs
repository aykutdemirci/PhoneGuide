using Microsoft.EntityFrameworkCore;
using PhoneGuide.Domain.Entities.Common;

namespace PhoneGuide.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entites);

        Task<bool> UpdateAsync(T entity);

        bool Delete(Guid id);

        Task<bool> DeleteRangeAsync(List<T> entities);

        Task<T> GetByIdAsync(Guid id);

        Task<IQueryable<T>> GetAllAsync(bool tracking = false);
    }
}
