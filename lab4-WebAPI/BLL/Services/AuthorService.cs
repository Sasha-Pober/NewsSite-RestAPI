using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class AuthorService(IUnitOfWork unit, IMapper mapper) : QueryService(unit, mapper), IAuthorService
{
    private readonly AuthorValidator validator = new();
    public async Task Create(AuthorDTO entity)
    {
        validator.ValidateAndThrow(entity);

        var ent = _mapper.Map<Author>(entity);

        await _unit.AuthorRepository.Create(ent);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var author = await _unit.AuthorRepository.GetById(id) ?? throw new NullReferenceException();
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
        var entity = await _unit.AuthorRepository.GetById(id) ?? throw new NullReferenceException();
        var author =  _mapper.Map<AuthorDTO>(entity);
        return author;
    }

    public async Task Update(int id, AuthorDTO entity)
    {
        validator.ValidateAndThrow(entity);

        var author = await _unit.AuthorRepository.GetById(id) ?? throw new NullReferenceException();

        author.Name = entity.Name;
        author.Email = entity.Email;
        author.Password = entity.Password;

        _unit.AuthorRepository.Update(author);
        await _unit.SaveAsync();
    }
}
