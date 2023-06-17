using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLG.Core.Entities;

namespace TLG.Infrastructure.Data
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Content> Contents { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Content>(ConfigureContent);
      builder.Entity<Wishlist>(ConfigureWishlist);
    }

    private void ConfigureContent(EntityTypeBuilder<Content> builder)
    {
      builder.HasKey(content => content.Id);

      builder.Property(content => content.Title)
              .HasMaxLength(255)
              .IsRequired();

      builder.Property(content => content.Description)
              .HasMaxLength(255)
              .IsRequired();

      builder.Property(content => content.Image)
              .HasMaxLength(255)
              .IsRequired();

      builder.HasMany(content => content.Wishlists)
              .WithOne(wishlist => wishlist.Content);
    }

    private void ConfigureWishlist(EntityTypeBuilder<Wishlist> builder)
    {
      builder.HasKey(content => content.Id);

      builder.HasOne(wishlist => wishlist.Content)
              .WithMany(content => content.Wishlists)
              .IsRequired()
              .HasForeignKey(wishlist => wishlist.ContentId);
    }
  }
}