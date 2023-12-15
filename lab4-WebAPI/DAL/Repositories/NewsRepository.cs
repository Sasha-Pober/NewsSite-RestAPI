using DAL.Interfaces;
using DAL.Entities;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class NewsRepository(NewsSiteContext context) : BaseRepository<News>(context), IRepository<News> 
{
    public async Task<IEnumerable<News>> GetAllWithRubrics()
    {
        return await ApplySpecification(new NewsWithRubricsSpecification()).ToListAsync();
    }

    public async Task<IEnumerable<News>> GetByRubricName(string name)
    {
        return await ApplySpecification(new NewsByRubricNameSpecification(name)).ToListAsync();
    }

    public async Task<IEnumerable<News>> GetByTagName(string name)
    {
        return await ApplySpecification(new NewsByTagNameSpecification(name)).ToListAsync();
    }
}
