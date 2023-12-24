using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Request;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class AuthorService(IUnitOfWork unit, IMapper mapper, IAuthService auth) : QueryService(unit, mapper), IAuthorService
{
    private readonly AuthorValidator validator = new();
    private readonly IAuthService _auth = auth;

    public async Task Create(AuthorDTO entity)
    {
        validator.ValidateAndThrow(entity);

        if (await _auth.CheckIfRegistered(entity.Email)) throw new Exception("Author is already registered");

        var ent = _mapper.Map<Author>(entity);
        ent.Password = PasswordHashingService.GetHashedPassword(ent.Password);

        await _unit.AuthorRepository.Create(ent);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var author = await _unit.AuthorRepository.GetById(id) ?? throw new Exception("There is no such author");
        _unit.AuthorRepository.Delete(author);
        await _unit.SaveAsync();
    }

    public async Task<IEnumerable<AuthorDTO>> GetAll()
    {
        var entities = await _unit.AuthorRepository.GetAll();
        var collection = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(entities);
        return collection;
    }

    public async Task<AuthorDTO> GetById(int id)
    {
        var entity = await _unit.AuthorRepository.GetById(id) ?? throw new Exception("There is no such author");
        var author =  _mapper.Map<AuthorDTO>(entity);
        return author;
    }

    public async Task Update(int id, AuthorDTO entity)
    {
        validator.ValidateAndThrow(entity);

        if (await CheckIfExists(entity)) throw new Exception("This author is already exists");

        var author = await _unit.AuthorRepository.GetById(id) ?? throw new Exception("There is no such author");

        author.Name = entity.Name;
        author.Email = entity.Email;
        author.Password = PasswordHashingService.GetHashedPassword(entity.Password);

        _unit.AuthorRepository.Update(author);
        await _unit.SaveAsync();
    }

    public async Task<Author> GetEntity(LoginRequest author)
    {
        return await _unit.AuthorRepository.GetByEmailAndPassword(author.Email, author.Password)
            ?? throw new NullReferenceException();
    }

    private async Task<bool> CheckIfExists(AuthorDTO author)
    {
        var collection = await _unit.AuthorRepository.GetAll();

        return collection.Any(n => n.Name.Equals(author.Name) && n.Email.Equals(author.Email));
    }


}
