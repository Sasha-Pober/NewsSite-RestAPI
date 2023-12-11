using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repositories;

public class NewsRepository(NewsSiteContext context) : BaseRepository<News>(context), IRepository<News> 
{
    private readonly NewsSiteContext _context = context;


}
