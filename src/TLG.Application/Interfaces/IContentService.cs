using TLG.Core.Dtos;
using TLG.Core.Entities;

namespace TLG.Application.Interfaces
{
  public interface IContentService
  {
    Task<ContentPagination> GetAll(int pageNumber, int pageSize);
    Task<ContentPagination> GetAllByWishlist(int pageNumber, int pageSize, string userId);
  }
}