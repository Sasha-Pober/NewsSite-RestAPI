using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces;

public interface INewsService : ICrud<NewsDTO>
{
    Task<IEnumerable<NewsDTO>> GetAllWithRubrics();
    Task<IEnumerable<NewsDTO>> GetByRubricId(int id);
    Task<IEnumerable<NewsDTO>> GetByTagId(int id);
    Task<IEnumerable<NewsDTO>> GetByAuthorId(int id);
    Task DeleteByIdAndAuthorId(int newsId, int authorId);
    Task UpdateByIdAndAuthorId(NewsDTO entity, int newsId, int authorId);
}
