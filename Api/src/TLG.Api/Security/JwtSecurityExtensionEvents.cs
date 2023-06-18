using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;

namespace TLG.Api.Security
{
  public sealed class JwtSecurityExtensionEvents : JwtBearerEvents
  {
    private readonly ILogger<JwtSecurityExtensionEvents> _logger;

    public JwtSecurityExtensionEvents(ILogger<JwtSecurityExtensionEvents> logger)
    {
      _logger = logger;
    }

    public override async Task Challenge(JwtBearerChallengeContext context)
    {
      _logger.LogError("Invalid token, expired or not provide...");
      await base.Challenge(context);
    }
  }
}