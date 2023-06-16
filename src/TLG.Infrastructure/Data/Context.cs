using Microsoft.EntityFrameworkCore;

namespace TLG.Infrastructure.Data
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}