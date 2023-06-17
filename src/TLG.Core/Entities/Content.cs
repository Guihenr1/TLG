using System.Text.Json.Serialization;
using TLG.Core.Entities.Base;

namespace TLG.Core.Entities
{
  public class Content : EntityBase
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    [JsonIgnore]
    public List<Wishlist> Wishlists { get; set; }
  }
}