using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class TagRepository(NewsSiteContext context) : BaseRepository<Tag>(context), IRepository<Tag>
{
    private readonly NewsSiteContext _context = context;
}
