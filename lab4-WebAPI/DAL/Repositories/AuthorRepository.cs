using DAL.Entities;
using DAL.Interfaces;
using DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Repositories;

public class AuthorRepository(NewsSiteContext context) : BaseRepository<Author>(context), IAuthorRepository
{
    public async Task<Author> GetByEmailAndPassword(string email, string password)
    {
        return await ApplySpecification(new AuthorByEmailAndPasswordSpecification(email, password)).FirstOrDefaultAsync();
    }

    public async Task<Author> GetByName(string name)
    {
        return await ApplySpecification(new AuthorByNameSpecification(name)).FirstOrDefaultAsync();
    }

}
