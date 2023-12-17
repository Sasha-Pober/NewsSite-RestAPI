namespace DAL.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(int id);

    Task Create(T entity);

    void Update(T entity);

    void Delete(T entity);

}
