using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLG.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize("Bearer")]
  public class PostController : ControllerBase
  {
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll()
    {
      var response = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      return Ok(response);
    }
  }
}