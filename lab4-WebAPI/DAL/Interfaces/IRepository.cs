namespace DAL.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> GetAll();

    Task<T> GetById(int id);

    Task Create(T entity);

    Task Update(int id, T entity);

    Task Delete(int id);

}
