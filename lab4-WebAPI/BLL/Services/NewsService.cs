using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.MapperMethods;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class NewsService(IUnitOfWork unit) : QueryService(unit, null), INewsService
{
    private readonly NewsValidator _validator = new();
    private readonly NewsMapper _newsMapper = new(unit);
    public async Task Create(NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var news = await _newsMapper.MapNewsFromDTO(entity);

        news.Date = DateTime.Now;

        await _unit.NewsRepository.Create(news);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var news = await _unit.NewsRepository.GetById(id) ?? throw new NullReferenceException();
        _unit.NewsRepository.Delete(news);
        await _unit.SaveAsync();
    }

    public async Task DeleteByIdAndAuthorId(int newsId, int authorId)
    {
        var entity = await _unit.NewsRepository.GetByIdAndAuthorId(newsId, authorId) ?? throw new NullReferenceException();

        _unit.NewsRepository.Delete(entity);
        await _unit.SaveAsync();
    }

    public async Task<IEnumerable<NewsDTO>> GetAll()
    {
        var news = await _unit.NewsRepository.GetAllWithTags();
        var collection = await _newsMapper.MapNewsToDTO(news);
        return collection;
     
    }

    public async Task<IEnumerable<NewsDTO>> GetAllWithRubrics()
    {
        var collection = await _unit.NewsRepository.GetAllWithRubrics();
        var result = await _newsMapper.MapNewsToDTO(collection);

        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByAuthorId(int id)
    {
        var collection = await _unit.NewsRepository.GetByAuthorId(id) ?? throw new NullReferenceException();
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task<NewsDTO> GetById(int id)
    {
        var news = await _unit.NewsRepository.GetById(id) ?? throw new NullReferenceException();

        var result = await _newsMapper.MapNewsToDTO(news);

        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByRubricId(int id)
    {
        var collection = await _unit.NewsRepository.GetByRubricId(id) ?? throw new NullReferenceException();
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByTagId(int id)
    {
        var collection = await _unit.NewsRepository.GetByTagId(id) ?? throw new NullReferenceException();
        var result = await _newsMapper.MapNewsToDTO(collection);
        return result;
    }

    public async Task Update(int id, NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var news = await _unit.NewsRepository.GetById(id) ?? throw new NullReferenceException();

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

        var news = await _unit.NewsRepository.GetByIdAndAuthorId(newsId, authorId) ?? throw new NullReferenceException();

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
}
