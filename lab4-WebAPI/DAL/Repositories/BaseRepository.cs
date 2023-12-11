using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BaseRepository<T>(NewsSiteContext context) : IRepository<T> where T : class
{
    private readonly NewsSiteContext _context = context;

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity!);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Update(int id, T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
