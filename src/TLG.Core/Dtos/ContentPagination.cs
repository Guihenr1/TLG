using TLG.Core.Entities;

namespace TLG.Core.Dtos
{
  public class ContentPagination
  {
    public int Count { get; set; }
    public List<Content> Contents { get; set; }
  }
}