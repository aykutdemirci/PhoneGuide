using Microsoft.EntityFrameworkCore;
using PhoneGuide.Domain.Entities.Common;
using System.Linq.Expressions;

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

        Task<T> GetSingleAsync(Expression<Func<bool, T>> predicate);

        Task<IQueryable<T>> GetAllAsync(bool tracking = false);
    }
}
