using DAL.Entities;

namespace DAL.Interfaces;

public interface INewsRepository : IRepository<News>
{
    Task<IEnumerable<News>> GetAllWithTags();
    Task<IEnumerable<News>> GetAllWithRubrics();
    Task<IEnumerable<News>> GetByRubricId(int id);
    Task<IEnumerable<News>> GetByTagId(int id);
    Task<IEnumerable<News>> GetByAuthorId(int id);
    Task<News> GetByIdAndAuthorId(int newsId, int authorId);
}
