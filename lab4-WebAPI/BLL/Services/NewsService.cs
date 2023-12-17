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

        news.Date = DateTime.Now;
        news.Tags = await MapTagsFromDTO(entity.Tags);

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
        var collection = _mapper.Map<IEnumerable<News>, List<NewsDTO>>(news);
        MapTagsToDTO(news, collection);
        return collection;
     
    }

    public async Task<IEnumerable<NewsDTO>> GetAllWithRubrics()
    {
        var collection = await _unit.NewsRepository.GetAllWithRubrics();
        var result = _mapper.Map<IEnumerable<News>, List<NewsDTO>>(collection);
        MapTagsToDTO(collection, result);
        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByAuthorId(int id)
    {
        var collection = await _unit.NewsRepository.GetByAuthorId(id) ?? throw new NullReferenceException();
        var result = _mapper.Map<IEnumerable<News>, List<NewsDTO>>(collection);
        MapTagsToDTO(collection, result);
        return result;
    }

    public async Task<NewsDTO> GetById(int id)
    {
        var news = await _unit.NewsRepository.GetById(id) ?? throw new NullReferenceException();

        var result = _mapper.Map<NewsDTO>(news);

        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByRubricId(int id)
    {
        var collection = await _unit.NewsRepository.GetByRubricId(id) ?? throw new NullReferenceException();
        var result = _mapper.Map<IEnumerable<News>, List<NewsDTO>>(collection);
        MapTagsToDTO(collection, result);
        return result;
    }

    public async Task<IEnumerable<NewsDTO>> GetByTagId(int id)
    {
        var collection = await _unit.NewsRepository.GetByTagId(id) ?? throw new NullReferenceException();
        var result = _mapper.Map<IEnumerable<News>, List<NewsDTO>>(collection);
        MapTagsToDTO(collection, result);
        return result;
    }

    public async Task Update(int id, NewsDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var news = await _unit.NewsRepository.GetById(id) ?? throw new NullReferenceException();

        news.Title = entity.Title;
        news.Body = entity.Body;
        news.AuthorId = entity.AuthorId;
        news.RubricId = entity.RubricId;
        news.Tags = await MapTagsFromDTO(entity.Tags);

        _unit.NewsRepository.Update(news);
        await _unit.SaveAsync();
    }

    public async Task UpdateByIdAndAuthorId(NewsDTO entity, int newsId, int authorId)
    {
        _validator.ValidateAndThrow(entity);

        var news = await _unit.NewsRepository.GetByIdAndAuthorId(newsId, authorId) ?? throw new NullReferenceException();

        news.Title = entity.Title;
        news.Body = entity.Body;
        news.AuthorId = entity.AuthorId;
        news.RubricId = entity.RubricId;

        _unit.NewsRepository.Update(news);
        await _unit.SaveAsync();
    }

    private async Task<List<Tag>> MapTagsFromDTO(List<string> tagNames)
    {
        var tags = new List<Tag>();
        foreach (var tag in tagNames)
        {
            var tg = await _unit.TagRepository.GetByName(tag);
            if (tg != null)
                tags.Add(tg);

        }
        return tags;
    }

    private List<string> MapTagsToDTO(List<Tag> tags)
    {
        var tagNames = new List<string>();
        foreach (var tag in tags)
        {
            tagNames.Add(tag.Name);
        }
        return tagNames;
    }


    private void MapTagsToDTO(IEnumerable<News> news, List<NewsDTO> newsDto)
    {
        var newsList = news.ToList();
        for(int i = 0; i < newsDto.Count; i++) 
        {
            newsDto[i].Tags = MapTagsToDTO(newsList[i].Tags);
        }
    }
}
