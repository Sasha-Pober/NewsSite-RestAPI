using DAL.Entities;

namespace DAL.Interfaces;

public interface INewsWithTagRepository : IRepository<NewsWithTag>
{
    Task<NewsWithTag> GetByIds(int newsId, int tagId);
    Task DeleteByIds(int newsId, int tagId);
    IEnumerable<NewsWithTag> GetByNewsId(int id);
}
