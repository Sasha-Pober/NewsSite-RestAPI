using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AuthorDTO, Author>();
        CreateMap<NewsDTO, News>();
        CreateMap<RubricDTO, Rubric>();
        CreateMap<TagDTO, Tag>();
    }
}
