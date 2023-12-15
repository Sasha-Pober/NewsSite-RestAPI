using DAL.Entities;

namespace DAL.Interfaces;

public interface IUnitOfWork
{
    IRepository<Author> AuthorRepository { get; }
    IRepository<News> NewsRepository { get; }
    IRepository<Tag> TagRepository { get; }
    IRepository<Rubric> RubricRepository { get; }
    Task SaveAsync();
}
