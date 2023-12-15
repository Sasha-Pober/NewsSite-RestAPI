using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class NewsService(IUnitOfWork unit, IMapper mapper) : QueryService(unit, mapper), INewsService
{
    private readonly NewsValidator _validator = new();
    public async Task Create(NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var news = _mapper.Map<News>(entity);
        await _unit.NewsRepository.Create(news);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _unit.NewsRepository.Delete(id);
        await _unit.SaveAsync();
    }

    public async Task<IEnumerable<NewsDTO>> GetAll()
    {
        var news = await _unit.NewsRepository.GetAll();
        var collection = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(news);
        return collection;
     
    }

    public async Task<NewsDTO> GetById(int id)
    {
        var news = await _unit.NewsRepository.GetById(id);

        var result = _mapper.Map<NewsDTO>(news);

        return result;
    }

    public async void Update(NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var news = _mapper.Map<News>(entity);

        _unit.NewsRepository.Update(news);
        await _unit.SaveAsync();
    }
}
