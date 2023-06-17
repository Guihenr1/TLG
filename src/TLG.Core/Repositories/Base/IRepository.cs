using TLG.Core.Entities.Base;

namespace TLG.Core.Repositories.Base
{
  public interface IRepository<T> where T : EntityBase
  {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
  }
}