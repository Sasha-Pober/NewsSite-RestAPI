using DAL.Entities;
using DAL.Interfaces;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BaseRepository<T>(NewsSiteContext context) : IRepository<T> where T : BaseEntity
{
    private protected readonly NewsSiteContext _context = context;

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity!);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    protected IQueryable<T> ApplySpecification(Specification<T> specification)
    {
        return SpecificationEvaluator.GetQuery(_context.Set<T>(), specification);
    }
}
