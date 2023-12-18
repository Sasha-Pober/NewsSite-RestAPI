using BLL.Request;
using DAL.Entities;

namespace BLL.Interfaces;

public interface IAuthService
{
    Task<bool> CheckIfRegistered(string email);
    Task<Author> GetEntity(LoginRequest author);
    string CreateToken(Author author);
}
