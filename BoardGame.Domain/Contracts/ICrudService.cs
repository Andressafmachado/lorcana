using System.Collections.Generic;

namespace boardGame;


public interface ICrudService<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task Delete(int id);
} 