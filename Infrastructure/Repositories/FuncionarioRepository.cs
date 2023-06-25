using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Funcionario> GetFuncionarioByEmail(string email)
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
    }
}
