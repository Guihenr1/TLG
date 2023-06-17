using TLG.Core.Dtos;
using TLG.Core.Entities;
using TLG.Core.Repositories.Base;

namespace TLG.Core.Repositories
{
  public interface IContentRepository : IRepository<Content>
  {
    Task<ContentPagination> GetAll(int pageNumber, int pageSize);
    Task<ContentPagination> GetAllByWishlist(int pageNumber, int pageSize, string userId);
  }
}