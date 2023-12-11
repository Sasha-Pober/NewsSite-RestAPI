using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class RubricRepository(NewsSiteContext context) : BaseRepository<Rubric>(context), IRepository<Rubric>
{
    private readonly NewsSiteContext _context = context;
}
