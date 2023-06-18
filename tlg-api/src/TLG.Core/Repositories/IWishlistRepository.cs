using TLG.Core.Entities;
using TLG.Core.Repositories.Base;

namespace TLG.Core.Repositories
{
  public interface IWishlistRepository : IRepository<Wishlist>
  {
    Task Add(Wishlist wishlist);
    Task Remove(Wishlist wishlist);
    Task<Wishlist> GetByContentIdAndUserId(Guid contentId, string userId);
  }
}