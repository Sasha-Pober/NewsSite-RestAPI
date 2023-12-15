using AutoMapper;
using DAL.Interfaces;

namespace BLL.Services;

public abstract class QueryService(IUnitOfWork unit, IMapper mapper)
{
    private protected readonly IUnitOfWork _unit = unit;
    private protected readonly IMapper _mapper = mapper;
}
