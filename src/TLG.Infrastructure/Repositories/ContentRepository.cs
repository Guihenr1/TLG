using Microsoft.EntityFrameworkCore;
using TLG.Core.Dtos;
using TLG.Core.Entities;
using TLG.Core.Repositories;
using TLG.Infrastructure.Data;
using TLG.Infrastructure.Repositories.Base;

namespace TLG.Infrastructure.Repositories
{
  public class ContentRepository : Repository<Content>, IContentRepository
  {
    public ContentRepository(Context dbContext) : base(dbContext)
    {
    }

    public async Task<ContentPagination> GetAll(int pageNumber, int pageSize)
    {
      var result = new ContentPagination()
      {
        Contents = new List<Content>()
      };
      result.Count = _dbContext.Contents.Count();
      var itemsToSkip = (pageNumber - 1) * pageSize;

      result.Contents.AddRange(await _dbContext.Contents
          .Skip(itemsToSkip)
          .Take(pageSize)
          .ToListAsync());

      return result;
    }
  }
}