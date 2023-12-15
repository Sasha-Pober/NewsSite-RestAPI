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
        await _unit.AuthorRepository.Delete(id);
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
        var entity = await _unit.AuthorRepository.GetById(id);
        var author =  _mapper.Map<AuthorDTO>(entity);
        return author;
    }

    public async void Update(AuthorDTO entity)
    {
        validator.ValidateAndThrow(entity);

        var ent = _mapper.Map<Author>(entity);

        _unit.AuthorRepository.Update(ent);
        await _unit.SaveAsync();
    }
}
