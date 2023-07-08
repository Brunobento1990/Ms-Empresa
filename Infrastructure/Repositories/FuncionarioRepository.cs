using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IGenericRepository<Funcionario> _genericRepository;
        private readonly MsContext _dbContext;

        public FuncionarioRepository(IGenericRepository<Funcionario> genericRepository, 
            MsContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> AdicionarFuncionarioAsync(Funcionario funcionario)
        {
            try
            {
                return await _genericRepository.AdicionarAsync(funcionario); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Funcionario>> GetAllFuncionarioAsync(Guid empresaId)
        {
            return await _genericRepository.GetAllAsync(x => x.EmpresaId == empresaId && x.DataDeExclusao == null);
        }

        public async Task<Funcionario?> GetFuncionarioByEmail(string email)
        {
            try
            {
                return await _dbContext.Funcionarios
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Email == email && x.DataDeExclusao == null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async ValueTask<(List<Funcionario> Values, int TotalPages)> GetPaginationAsync(int page, Expression<Func<Funcionario, bool>> predicateWhere, Expression<Func<Funcionario, object>> predicateOrder, List<Expression<Func<Funcionario, object>>>? predicateInclude)
        {
            try
            {
                return await _genericRepository.GetPagnationAsync(page, predicateWhere, predicateOrder, predicateInclude);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
