using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
      var response = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var result = await contentService.GetAll(pageNumber, pageSize);

      return Ok(result);
    }
  }
}