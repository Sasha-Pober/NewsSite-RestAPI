using DAL.Interfaces;
using DAL.Entities;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class NewsRepository(NewsSiteContext context) : BaseRepository<News>(context), INewsRepository
{
    public async Task<News> GetByIdAndAuthorId(int newsId, int authorId)
    {
        return await ApplySpecification(new NewsByIdWithAuthorIdSpecification(newsId, authorId)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<News>> GetAllWithDetailsOrderByRubrics()
    {
        return await ApplySpecification(new NewsWithRubricsSpecification()).ToListAsync();
    }

    public async Task<IEnumerable<News>> GetAllWithTags()
    {
        return await ApplySpecification(new NewsWithTagsSpecification()).ToListAsync();
    }

    public async Task<IEnumerable<News>> GetByAuthorId(int id)
    {
        return await ApplySpecification(new NewsByAuthorsIdSpecification(id)).ToListAsync();
    }

    public async Task<IEnumerable<News>> GetByRubricId(int id)
    {
        return await ApplySpecification(new NewsByRubricIdSpecification(id)).ToListAsync();
    }

    public async Task<IEnumerable<News>> GetByTagId(int id)
    {
        return await ApplySpecification(new NewsByTagIdSpecification(id)).ToListAsync();
    }

    public async Task<News> GetByIdWithTags(int id)
    {
        return await ApplySpecification(new NewsByIdWithTagSpecification(id)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<News>> GetBetweenDates(DateTime dateFrom, DateTime dateTo)
    {
        return await ApplySpecification(new NewsBetweenDatesSpecification(dateFrom, dateTo)).ToListAsync();
    }
}
