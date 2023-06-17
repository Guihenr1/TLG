using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace TLG.Core.Entities
{
  public class ApplicationUser : IdentityUser
  {
    [JsonIgnore]
    public List<Wishlist> Wishlists { get; set; }
  }
}