using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AdicionarAsync(T entity);
        Task<bool> EditarAsync(T entity);
        Task<bool> ExcluirAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        ValueTask<(List<T> Values, int TotalPages)> GetPagnationAsync(int page,
            Expression<Func<T, bool>> predicateWhere,
            Expression<Func<T, object>> predicateOrder,
            List<Expression<Func<T, object>>>? predicateInclude);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicateWhere);
    }
}
