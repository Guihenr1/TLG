using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TLG.Core.Entities;

namespace TLG.Infrastructure.Data
{
  public class ApiSecurityDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApiSecurityDbContext(DbContextOptions<ApiSecurityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}