using TLG.Core.Entities;

namespace TLG.Application.Interfaces
{
  public interface IWishlistService
  {
    Task Add(Wishlist wishlist);
    Task Remove(Guid contentId, string userId);
  }
}