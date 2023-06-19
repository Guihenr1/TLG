using TLG.Application.ViewModels;
using TLG.Core.Dtos;
using TLG.Core.Entities;

namespace TLG.Application.Interfaces
{
  public interface IContentService
  {
    Task<ContentPaginationViewModel> GetAll(int pageNumber, int pageSize, string userId);
    Task<ContentPaginationViewModel> GetAllByWishlist(int pageNumber, int pageSize, string userId);
  }
}