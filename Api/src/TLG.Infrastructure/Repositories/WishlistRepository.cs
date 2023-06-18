using Microsoft.EntityFrameworkCore;
using TLG.Core.Entities;
using TLG.Core.Repositories;
using TLG.Infrastructure.Data;
using TLG.Infrastructure.Repositories.Base;

namespace TLG.Infrastructure.Repositories
{
  public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
  {
    public WishlistRepository(Context dbContext) : base(dbContext)
    {
    }

    public async Task Add(Wishlist wishlist)
    {
      await AddAsync(wishlist);
    }

    public async Task Remove(Wishlist wishlist)
    {
      await DeleteAsync(wishlist);
    }

    public async Task<Wishlist> GetByContentIdAndUserId(Guid contentId, string userId)
    {
      return await _dbContext.Wishlists.FirstOrDefaultAsync(x => x.ContentId == contentId && x.UserId == userId);
    }
  }
}