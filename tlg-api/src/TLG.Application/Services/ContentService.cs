using AutoMapper;
using TLG.Application.Interfaces;
using TLG.Application.ViewModels;
using TLG.Core.Dtos;
using TLG.Core.Repositories;

namespace TLG.Application.Services
{
  public class ContentService : IContentService
  {
    private readonly IContentRepository contentRepository;
    private readonly IMapper mapper;

    public ContentService(IContentRepository contentRepository, IMapper mapper)
    {
      this.contentRepository = contentRepository;
      this.mapper = mapper;
    }

    public async Task<ContentPaginationViewModel> GetAll(int pageNumber, int pageSize, string userId)
    {
      var contents = await contentRepository.GetAll(pageNumber, pageSize);
      var wishList = await contentRepository.GetAllByWishlist(userId);

      var result = mapper.Map<ContentPaginationViewModel>(contents);

      for (int i = 0; i < result.Contents.Count; i++)
      {
        result.Contents[i].IsFavorite = wishList.Contents.Any(x => x.Id == result.Contents[i].Id);
      }

      return result;
    }

    public async Task<ContentPaginationViewModel> GetAllByWishlist(int pageNumber, int pageSize, string userId)
    {
      var contents = await contentRepository.GetAllByWishlist(pageNumber, pageSize, userId);

      var result = mapper.Map<ContentPaginationViewModel>(contents);
      result.Contents.All(x => x.IsFavorite = true);

      return result;
    }
  }
}