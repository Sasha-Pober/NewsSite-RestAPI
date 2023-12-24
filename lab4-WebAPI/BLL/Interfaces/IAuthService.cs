using BLL.Request;
using DAL.Entities;

namespace BLL.Interfaces;

public interface IAuthService
{
    Task<bool> CheckIfRegistered(string email);
    string CreateToken(Author author);
}
