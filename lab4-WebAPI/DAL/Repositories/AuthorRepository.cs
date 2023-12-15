using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class AuthorRepository(NewsSiteContext context) : BaseRepository<Author>(context), IAuthorRepository
{
}
