using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL;

public class UnitOfWork(NewsSiteContext siteContext) : IUnitOfWork
{
    private readonly NewsSiteContext _siteContext = siteContext;

    public IAuthorRepository AuthorRepository => new AuthorRepository(_siteContext);

    public INewsRepository NewsRepository => new NewsRepository(_siteContext);

    public ITagRepository TagRepository => new TagRepository(_siteContext);

    public IRubricRepository RubricRepository => new RubricRepository(_siteContext);

    public async Task SaveAsync()
    {
        await _siteContext.SaveChangesAsync();
    }
}
