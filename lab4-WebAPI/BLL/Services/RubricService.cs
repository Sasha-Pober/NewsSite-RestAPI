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

        if (await CheckIfExists(entity)) throw new Exception("The rubric already exists");

        var rubric = _mapper.Map<Rubric>(entity);

        await _unit.RubricRepository.Create(rubric);
        await _unit.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var rubric = await _unit.RubricRepository.GetById(id) ?? throw new Exception("There is no such rubric");
        _unit.RubricRepository.Delete(rubric);
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
        var entity = await _unit.RubricRepository.GetById(id) ?? throw new Exception("There is no such rubric");
        var rubric = _mapper.Map<RubricDTO>(entity);
        return rubric;
    }

    public async Task Update(int id, RubricDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        if (await CheckIfExists(entity)) throw new Exception("The rubric already exists");

        var rubric = await _unit.RubricRepository.GetById(id) ?? throw new Exception("There is no such rubric");

        rubric.Name = entity.Name;

        _unit.RubricRepository.Update(rubric);
        await _unit.SaveAsync();
    }

    private async Task<bool> CheckIfExists(RubricDTO rubric)
    {
        var collection = await _unit.RubricRepository.GetAll();

        return collection.Any(n => n.Name.Equals(rubric.Name));
    }
}
