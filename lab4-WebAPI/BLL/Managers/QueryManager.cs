using DAL.Interfaces;
namespace BLL.Managers;

public abstract class QueryManager<T>(IRepository<T> repo)
{
    private protected IRepository<T> repository = repo;
}
