using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CargoFuncionario> GetCargoByDescricaoAsync(string descricao)
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
    }
}
