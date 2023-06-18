using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLG.Application.Interfaces;
using TLG.Core.Entities;

namespace TLG.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize("Bearer")]
  public class WishlistController : ControllerBase
  {
    private readonly IWishlistService wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
      this.wishlistService = wishlistService;
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(Guid contentId)
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      await wishlistService.Add(new Wishlist
      {
        Id = Guid.NewGuid(),
        ContentId = contentId,
        UserId = userId!
      });

      return Ok();
    }

    [HttpDelete]
    [Route("remove")]
    public async Task<IActionResult> Remove(Guid contentId)
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      await wishlistService.Remove(contentId, userId!);

      return Ok();
    }
  }
}