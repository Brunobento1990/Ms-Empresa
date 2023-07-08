using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MsContext _dbContext;
        public GenericRepository(MsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AdicionarAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> EditarAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).Property("DataDeCadastro").IsModified = false;
                _dbContext.Entry(entity).Property("DataDeExclusao").IsModified = false;
                _dbContext.Entry(entity).Property("EmpresaId").IsModified = false;
                _dbContext.Set<T>().Update(entity);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> ExcluirAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).Property("DataDeCadastro").IsModified = false;
                _dbContext.Entry(entity).Property("DataDeAlteracao").IsModified = false;
                _dbContext.Entry(entity).Property("EmpresaId").IsModified = false;
                _dbContext.Set<T>().Update(entity);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicateWhere)
        {
            try
            {
                return await _dbContext.Set<T>().Where(predicateWhere).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar entidade por id : {ex.Message}");
            }
        }

        public async ValueTask<(List<T> Values, int TotalPages)> GetPagnationAsync(int page,
            Expression<Func<T, bool>> predicateWhere,
            Expression<Func<T, object>> predicateOrder,
            List<Expression<Func<T, object>>>? predicateInclude)
        {
            try
            {

                const int PAGESIZE = 10;
                var total = await _dbContext.Set<T>().Where(predicateWhere).CountAsync();
                var totalPages = (int)Math.Ceiling(total / (double)PAGESIZE);
                page = Math.Min(Math.Max(1, page), totalPages);
                page = page >= 1 ? page : 1;

                var query = _dbContext.Set<T>()
                    .AsNoTracking()
                    .OrderByDescending(predicateOrder)
                    .Where(predicateWhere);

                if (predicateInclude != null)
                {
                    predicateInclude.ForEach(predicate =>
                    {
                        query = query.Include(predicate);
                    });
                }

                var values = await query
                    .Skip(((page - 1) * PAGESIZE))
                    .Take(PAGESIZE)
                    .ToListAsync();

                return (values, totalPages);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
