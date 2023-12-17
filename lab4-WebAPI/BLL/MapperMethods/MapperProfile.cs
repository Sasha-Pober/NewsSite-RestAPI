using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BLL.MapperMethods;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AuthorDTO, Author>().ReverseMap();

        CreateMap<News, NewsDTO>().ForMember(news => news.Tags, source => source.Ignore()).ReverseMap();

        CreateMap<RubricDTO, Rubric>().ReverseMap();

        CreateMap<TagDTO, Tag>().ReverseMap();
    }
}
