

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstract;

public interface IRepository<T>  where T :class 
{
    DbSet<T> Table { get; }
    Task<bool> CreateAsync(T entity);
    bool DeleteAsync(T entity);
    bool Update(T entity);
    bool Update(T entity,T unchanged);
    Task<T> GetByIDAsync(int id);
    Task<List<T>> GetAllAsync(bool asNoTracking = true);
    Task<int> SaveChangesAsync();

    IQueryable<T> GetWhere();
}
