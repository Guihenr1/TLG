namespace TLG.Application.ViewModels
{
  public class ContentPaginationViewModel
  {
    public int Count { get; set; }
    public List<ContentViewModel> Contents { get; set; }
  }

  public class ContentViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public bool IsFavorite { get; set; }
  }
}