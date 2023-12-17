using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AuthorDTO, Author>().ReverseMap();
        CreateMap<NewsDTO, News>().ReverseMap();
        CreateMap<RubricDTO, Rubric>().ReverseMap();
        CreateMap<TagDTO, Tag>().ReverseMap();
    }
}
