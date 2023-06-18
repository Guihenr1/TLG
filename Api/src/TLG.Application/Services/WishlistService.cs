using TLG.Application.Interfaces;
using TLG.Core.Entities;
using TLG.Core.Repositories;

namespace TLG.Application.Services
{
  public class WishlistService : IWishlistService
  {
    private readonly IWishlistRepository wishlistRepostory;

    public WishlistService(IWishlistRepository wishlistRepostory)
    {
      this.wishlistRepostory = wishlistRepostory;
    }

    public async Task Add(Wishlist wishlist)
    {
      await wishlistRepostory.Add(wishlist);
    }

    public async Task Remove(Guid contentId, string userId)
    {
      var content = await wishlistRepostory.GetByContentIdAndUserId(contentId, userId);

      await wishlistRepostory.Remove(content);
    }
  }
}