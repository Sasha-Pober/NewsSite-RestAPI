using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL;

public class UnitOfWork(NewsSiteContext siteContext) : IUnitOfWork
{
    private readonly NewsSiteContext _siteContext = siteContext;

    public IRepository<Author> AuthorRepository => new AuthorRepository(_siteContext);

    public IRepository<News> NewsRepository => new NewsRepository(_siteContext);

    public IRepository<Tag> TagRepository => new TagRepository(_siteContext);

    public IRepository<Rubric> RubricRepository => new RubricRepository(_siteContext);

    public async Task SaveAsync()
    {
        await _siteContext.SaveChangesAsync();
    }
}
