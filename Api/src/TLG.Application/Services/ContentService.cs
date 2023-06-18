using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLG.Application.Interfaces;
using TLG.Core.Dtos;
using TLG.Core.Entities;
using TLG.Core.Repositories;

namespace TLG.Application.Services
{
  public class ContentService : IContentService
  {
    private readonly IContentRepository contentRepository;

    public ContentService(IContentRepository contentRepository)
    {
      this.contentRepository = contentRepository;
    }

    public async Task<ContentPagination> GetAll(int pageNumber, int pageSize)
    {
      return await contentRepository.GetAll(pageNumber, pageSize);
    }

    public async Task<ContentPagination> GetAllByWishlist(int pageNumber, int pageSize, string userId)
    {
      return await contentRepository.GetAllByWishlist(pageNumber, pageSize, userId);
    }
  }
}