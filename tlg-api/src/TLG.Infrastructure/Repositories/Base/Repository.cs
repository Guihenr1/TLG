using Microsoft.EntityFrameworkCore;
using TLG.Core.Entities.Base;
using TLG.Core.Repositories.Base;
using TLG.Infrastructure.Data;

namespace TLG.Infrastructure.Repositories.Base
{
  public class Repository<T> : IRepository<T> where T : EntityBase
  {
    protected readonly Context _dbContext;

    public Repository(Context dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
      _dbContext.Set<T>().Add(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public async Task UpdateAsync(T entity)
    {
      var oldEntity = await GetByIdAsync(entity.Id);
      _dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }
  }

}