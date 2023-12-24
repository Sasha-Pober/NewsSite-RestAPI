using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BLL.MapperMethods;

public class MapperProfile : Profile
{
    public MapperProfile()
    {

        CreateMap<Author, AuthorDTO>().ReverseMap();

        CreateMap<Rubric, RubricDTO>().ReverseMap();

        CreateMap<Tag, TagDTO>().ReverseMap();
    }

}
