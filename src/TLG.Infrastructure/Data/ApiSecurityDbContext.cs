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

    public DbSet<ApplicationUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<ApplicationUser>()
            .HasMany(user => user.Wishlists)
            .WithOne(wishlist => wishlist.User);
    }
  }
}