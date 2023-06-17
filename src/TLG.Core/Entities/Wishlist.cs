using System.Text.Json.Serialization;
using TLG.Core.Entities.Base;

namespace TLG.Core.Entities
{
  public class Wishlist : EntityBase
  {
    public string UserId { get; set; }
    public Guid ContentId { get; set; }

    [JsonIgnore]
    public ApplicationUser User { get; set; }
    [JsonIgnore]
    public Content Content { get; set; }
  }
}