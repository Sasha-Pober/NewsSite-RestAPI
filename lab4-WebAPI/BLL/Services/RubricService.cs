using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validators;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services;

public class RubricService(IUnitOfWork unit, IMapper mapper) : QueryService(unit, mapper), IRubricService
{
    private readonly RubricValidator _validator = new();
    public async Task Create(RubricDTO entity)
    {
        _validator.Validate(entity);

        var rubric = _mapper.Map<Rubric>(entity);

        await _unit.RubricRepository.Create(rubric);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _unit.NewsRepository.Delete(id);
        await _unit.SaveAsync();
    }

    public async Task<IEnumerable<RubricDTO>> GetAll()
    {
        var entities = await _unit.RubricRepository.GetAll();
        var rubrics = _mapper.Map<IEnumerable<Rubric>, IEnumerable<RubricDTO>>(entities);
        return rubrics;
    }

    public async Task<RubricDTO> GetById(int id)
    {
        var entity = await _unit.RubricRepository.GetById(id);
        var rubric = _mapper.Map<RubricDTO>(entity);
        return rubric;
    }

    public async void Update(RubricDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var rubric = _mapper.Map<Rubric>(entity);
        _unit.RubricRepository.Update(rubric);
        await _unit.SaveAsync();
    }
}
