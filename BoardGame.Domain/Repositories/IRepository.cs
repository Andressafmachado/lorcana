
namespace Infrastructure.Data.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
}