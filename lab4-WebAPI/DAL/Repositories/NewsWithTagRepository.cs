using DAL.Entities;
using DAL.Interfaces;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class NewsWithTagRepository(NewsSiteContext context) : BaseRepository<NewsWithTag>(context), INewsWithTagRepository
{
    public async Task<NewsWithTag> GetByIds(int newsId, int tagId)
    {
        return await ApplySpecification(new NewsWithTagByIds(newsId, tagId)).FirstOrDefaultAsync();
    }

    public async Task DeleteByIds(int newsId, int tagId)
    {
        var entity = await GetByIds(newsId, tagId);
        _context.NewsWithTags.Remove(entity);
    }

    public IEnumerable<NewsWithTag> GetByNewsId(int id)
    {
        return ApplySpecification(new NewsWithTagsByNewsIdSpecification(id));
    }
}
