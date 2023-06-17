using TLG.Core.Dtos;
using TLG.Core.Entities;

namespace TLG.Application.Interfaces
{
  public interface IContentService
  {
    Task<ContentPagination> GetAll(int pageNumber, int pageSize);
  }
}