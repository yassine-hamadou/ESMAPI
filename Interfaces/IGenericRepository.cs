using System.Linq.Expressions;

namespace ServiceManagerApi.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        IQueryable<T> Data { get; }

        Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>> expression=null,

            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);

        Task UpdateAsync(T entity);
    }
}
