
using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete;

public class Service<T> : IService<T> where T : class
{
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(T entity)
    {
        await _repository.CreateAsync(entity);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync(bool asNoTracking = true)
    {
        return await _repository.GetAllAsync(asNoTracking);
    }

    public async Task<T> GetByIDAsync(int id)
    {
       return  await _repository.GetByIDAsync(id);
    }

    public IQueryable<T> GetWhere()
    {
       return _repository.GetWhere();
    }

    public async Task<int> SaveChangesAsync()
    {
      return  await _repository.SaveChangesAsync(); 
    }

    public async Task UpdateAsync(T entity)
    {
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
    }
}
