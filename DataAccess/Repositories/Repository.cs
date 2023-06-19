

using DataAccess.Abstract;
using DataAccess.Concrete;
using Entitiy.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly EasyCashContext _context;

    public Repository(EasyCashContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> CreateAsync(T entity)
    {
       EntityEntry<T> entityEntry = await Table.AddAsync(entity);
       return entityEntry.State == EntityState.Added;
    }

    public bool DeleteAsync(T entity)
    {
      EntityEntry<T> entityEntry = Table.Remove(entity);
      return entityEntry.State == EntityState.Deleted;
    }

    public async Task<List<T>> GetAllAsync(bool asNoTracking = true)
    => asNoTracking?await Table.AsNoTracking().ToListAsync():await Table.ToListAsync();
        
    

    public async Task<T?> GetByIDAsync(string id)
    {
        return await Table.FindAsync(id);
    }
    

    public bool Update(T entity)
    {
        EntityEntry<T> entityEntry =Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetWhere()
    {
      return Table.AsQueryable();
    }

    bool IRepository<T>.Update(T entity, T unchanged)
    {
        _context.Entry(entity).CurrentValues.SetValues(unchanged);
        return true;
    }
}
