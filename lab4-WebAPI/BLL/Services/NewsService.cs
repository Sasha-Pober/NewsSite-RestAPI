using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.MapperMethods;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class NewsService(IUnitOfWork unit, IMapper mapper) : QueryService(unit, mapper), INewsService
{
    private readonly NewsValidator _validator = new();
    private readonly NewsMapper _newsMapper = new(unit);


    public async Task Create(NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        if (await CheckIfExists(entity)) throw new Exception("The item already exists");

        var news = await _newsMapper.MapNewsFromDTO(entity);

        news.Date = DateTime.Now;

        await _unit.NewsRepository.Create(news);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var news = await _unit.NewsRepository.GetById(id) ?? throw new Exception("There is no such piece of news");
        _unit.NewsRepository.Delete(news);
        await _unit.SaveAsync();
    }

    public async Task DeleteByIdAndAuthorId(int newsId, int authorId)
    {
        var entity = await _unit.NewsRepository.GetByIdAndAuthorId(newsId, authorId) ?? throw new Exception("There is no such piece of news");

        _unit.NewsRepository.Delete(entity);
        await _unit.SaveAsync();
    }

    public async Task<IEnumerable<NewsDTO>> GetAll()
    {
        var collection = await _unit.NewsRepository.GetAllWithDetailsOrderByRubrics();
        var result = await _newsMapper.MapNewsToDTO(collection);

        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByAuthorId(int id)
    {
        var collection = await _unit.NewsRepository.GetByAuthorId(id) ?? throw new Exception("There is no such piece of news");
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task<NewsDTO> GetById(int id)
    {
        var news = await _unit.NewsRepository.GetByIdWithTags(id) ?? throw new Exception("There is no such piece of news");

        var result = await _newsMapper.MapNewsToDTO(news);

        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByRubricId(int id)
    {
        var collection = await _unit.NewsRepository.GetByRubricId(id) ?? throw new Exception("There is no such piece of news");
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByTagId(int id)
    {
        var collection = await _unit.NewsRepository.GetByTagId(id) ?? throw new Exception("There is no such piece of news");
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetBetweenDates(DateTime dateFrom, DateTime dateTo)
    {
        var collection = await _unit.NewsRepository.GetBetweenDates(dateFrom, dateTo);
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task Update(int id, NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        if (await CheckIfExists(entity)) throw new Exception("The item already exists");

        var news = await _unit.NewsRepository.GetById(id) ?? throw new Exception("There is no such piece of news");

        var author = await _unit.AuthorRepository.GetByName(entity.AuthorName);
        var rubric = await _unit.RubricRepository.GetByName(entity.RubricName);
        var tags = await _newsMapper.UpdateMapTagsFromDTO(id, entity.Tags);

        news.Title = entity.Title;
        news.Body = entity.Body;
        news.AuthorId = author.Id;
        news.RubricId = rubric.Id;
        news.Tags = tags;

        _unit.NewsRepository.Update(news);
        await _unit.SaveAsync();
    }

    public async Task UpdateByIdAndAuthorId(NewsDTO entity, int newsId, int authorId)
    {
        _validator.ValidateAndThrow(entity);

        if (await CheckIfExists(entity)) throw new Exception("The item already exists");

        var news = await _unit.NewsRepository.GetByIdAndAuthorId(newsId, authorId) ?? throw new Exception("There is no such piece of news");

        var author = await _unit.AuthorRepository.GetByName(entity.AuthorName);
        var rubric = await _unit.RubricRepository.GetByName(entity.RubricName);
        var tags = await _newsMapper.UpdateMapTagsFromDTO(newsId, entity.Tags);

        news.Title = entity.Title;
        news.Body = entity.Body;
        news.AuthorId = author.Id;
        news.RubricId = rubric.Id;
        news.Tags = tags;

        _unit.NewsRepository.Update(news);
        await _unit.SaveAsync();
    }

    private async Task<bool> CheckIfExists(NewsDTO news)
    {
        var collection = await _unit.NewsRepository.GetAll();

        return collection.Any(n => n.Title.Equals(news.Title) && n.Body.Equals(news.Body));
    }
}


