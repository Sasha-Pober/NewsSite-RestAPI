using DAL.Entities;
using DAL.Interfaces;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RubricRepository(NewsSiteContext context) : BaseRepository<Rubric>(context), IRepository<Rubric>
{
    public async Task<List<Rubric>> GetByIdWithNews(int id)
    {
        return await ApplySpecification(new RubricByIdWithNewsSpecification(id)).ToListAsync();
    }
}
