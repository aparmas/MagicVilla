using System.Linq.Expressions;

namespace MagicVilla_API.Repositories.IRepositories
{
    public interface IRepositories<T> where T : class
    {
        Task Create(T entity);
        Task<T> GetOne(Expression<Func<T, bool>>? filter = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task Delete(T entity);
        Task SaveChanges();
    }
}
