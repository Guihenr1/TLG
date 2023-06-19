using AutoMapper;
using TLG.Application.ViewModels;
using TLG.Core.Dtos;
using TLG.Core.Entities;

namespace TLG.Application.AutoMapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<ContentPagination, ContentPaginationViewModel>();
      CreateMap<Content, ContentViewModel>();
    }
  }
}