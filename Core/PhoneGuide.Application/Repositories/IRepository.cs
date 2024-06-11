using Microsoft.EntityFrameworkCore;
using PhoneGuide.Domain.Entities.Common;

namespace PhoneGuide.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entites);

        bool Update(T entity);

        Task<bool> DeleteByIdAsync(string id);

        Task<T> GetByIdAsync(string id, bool tracking = true);

        IQueryable<T> GetAll(bool tracking = false);
    }
}
