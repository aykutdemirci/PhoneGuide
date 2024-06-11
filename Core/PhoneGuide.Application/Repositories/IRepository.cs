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

        bool Delete(T entity);

        bool DeleteById(string id);

        Task<bool> DeleteRangeAsync(List<T> entities);

        Task<T> GetByIdAsync(string id, bool tracking = true);

        IQueryable<T> GetAll(bool tracking = false);
    }
}
