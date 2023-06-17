using System.Text.Json.Serialization;
using TLG.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TLG.Core.Entities
{
  public class Wishlist : EntityBase
  {
    public string UserId { get; set; }
    public Guid ContentId { get; set; }

    [JsonIgnore]
    public Content Content { get; set; }
  }
}