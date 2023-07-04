using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CargoFuncionarioRepository : ICargoFuncionarioRepository
    {
        protected MsContext _dbContext;
        private readonly IGenericRepository<CargoFuncionario> _genericRepository;

        public CargoFuncionarioRepository(MsContext dbContext,
            IGenericRepository<CargoFuncionario> genericRepository)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> AdicionarCargoFuncionarioAsync(CargoFuncionario cargoFuncionario)
        {
            try
            {
                return await _genericRepository.AdicionarAsync(cargoFuncionario); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CargoFuncionario?> GetCargoByDescricaoAsync(string descricao)
        {
            try
            {
                return await _dbContext.CargosFuncionarios
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Descricao == descricao && x.DataDeExclusao == null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async ValueTask<(List<CargoFuncionario> Values, int TotalPages)> GetPaginationAsync(int page, 
            Expression<Func<CargoFuncionario, bool>> predicateWhere, Expression<Func<CargoFuncionario, object>> predicateOrder, 
            List<Expression<Func<CargoFuncionario, object>>>? predicateInclude)
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

        public async Task<CargoFuncionario?> GetCargoByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.CargosFuncionarios
                    .FirstOrDefaultAsync(x => x.Id == id && x.DataDeExclusao == null);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<bool> EditCargoFuncionarioAsync(CargoFuncionario cargoFuncionario)
        {
            _genericRepository.EditarAsync(cargoFuncionario);

            return Task.FromResult(true);
        }

        public Task<bool> ExcluirCargoFuncionarioAsync(CargoFuncionario cargoFuncionario)
        {
            _genericRepository.ExcluirAsync(cargoFuncionario);

            return Task.FromResult(true);
        }
    }
}
