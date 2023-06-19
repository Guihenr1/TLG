using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLG.Application.Interfaces;

namespace TLG.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize("Bearer")]
  public class ContentController : ControllerBase
  {
    private readonly IContentService contentService;

    public ContentController(IContentService contentService)
    {
      this.contentService = contentService;
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var result = await contentService.GetAll(pageNumber, pageSize, userId);

      return Ok(result);
    }

    [HttpGet]
    [Route("get-all-by-wishlist")]
    public async Task<IActionResult> GetAllByWishList(int pageNumber, int pageSize)
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var result = await contentService.GetAllByWishlist(pageNumber, pageSize, userId!);

      return Ok(result);
    }
  }
}