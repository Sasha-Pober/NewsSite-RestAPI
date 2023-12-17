using AutoMapper;
using Azure;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class TagService(IUnitOfWork unit, IMapper mapper) : QueryService(unit, mapper), ITagService
{
    private readonly TagValidator _validator = new();
    public async Task Create(TagDTO entity)
    {
        _validator.Validate(entity);

        var tag = _mapper.Map<Tag>(entity);

        await _unit.TagRepository.Create(tag);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var tag = await _unit.TagRepository.GetById(id) ?? throw new NullReferenceException();
        _unit.TagRepository.Delete(tag);
        await _unit.SaveAsync();
    }

    public async Task<IEnumerable<TagDTO>> GetAll()
    {
        var entities = await _unit.TagRepository.GetAll();
        var tags = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(entities);
        return tags;
    }

    public async Task<TagDTO> GetById(int id)
    {
        var entity = await _unit.TagRepository.GetById(id);
        var tag = _mapper.Map<TagDTO>(entity);
        return tag;
    }

    public async Task Update(int id, TagDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var tag = await _unit.TagRepository.GetById(id);
        tag.Name = entity.Name;

        _unit.TagRepository.Update(tag);
        await _unit.SaveAsync();
    }
}
