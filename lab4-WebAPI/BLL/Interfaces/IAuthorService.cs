using BLL.DTO;
using BLL.Request;
using DAL.Entities;

namespace BLL.Interfaces;

public interface IAuthorService : ICrud<AuthorDTO>
{
    Task<Author> GetEntity(LoginRequest author);
}
