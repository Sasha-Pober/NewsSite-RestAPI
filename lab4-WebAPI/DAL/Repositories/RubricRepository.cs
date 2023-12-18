using DAL.Entities;
using DAL.Interfaces;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RubricRepository(NewsSiteContext context) : BaseRepository<Rubric>(context), IRubricRepository
{
    public async Task<List<Rubric>> GetByIdWithNews(int id)
    {
        return await ApplySpecification(new RubricByIdWithNewsSpecification(id)).ToListAsync();
    }

    public async Task<Rubric> GetByName(string name)
    {
        return await ApplySpecification(new RubricByNameSpecification(name)).FirstOrDefaultAsync();
    }
}
