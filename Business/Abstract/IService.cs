

namespace Business.Abstract;

public interface IService<T>
{
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> GetByIDAsync(int id);
    Task<List<T>> GetAllAsync(bool asNoTracking = true);
    Task<int> SaveChangesAsync();
    IQueryable<T> GetWhere();
}
