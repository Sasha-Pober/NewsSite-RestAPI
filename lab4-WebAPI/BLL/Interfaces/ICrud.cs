﻿namespace BLL.Interfaces;

public interface ICrud<T> where T : class
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(int id);

    Task Create(T entity);

    void Update(T entity);

    Task Delete(int id);
}
