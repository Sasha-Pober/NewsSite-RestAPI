using DAL.Entities;
using DAL.Interfaces;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TagRepository(NewsSiteContext context) : BaseRepository<Tag>(context), ITagRepository
{
    public async Task<Tag> GetByName(string name)
    {
        return await ApplySpecification(new TagByNameSpecification(name)).FirstOrDefaultAsync();
    }
}
