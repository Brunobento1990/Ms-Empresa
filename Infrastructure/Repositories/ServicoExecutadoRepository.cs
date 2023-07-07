using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class ServicoExecutadoRepository : IServicoExecutadoRepository
    {
        private readonly IGenericRepository<ServicoExecutado> _repository;

        public ServicoExecutadoRepository(IGenericRepository<ServicoExecutado> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AdicionarServicoExecutadoAsync(ServicoExecutado servico)
        {
            return await _repository.AdicionarAsync(servico);
        }

        public async Task<bool> ExcluirServicoExecutadoAsync(ServicoExecutado servico)
        {
            return await _repository.ExcluirAsync(servico);
        }

        public async ValueTask<(List<ServicoExecutado> Values, int TotalPages)> GetPaginationAsync(
            int page, Expression<Func<ServicoExecutado, bool>> predicateWhere, 
            Expression<Func<ServicoExecutado, object>> predicateOrder, 
            List<Expression<Func<ServicoExecutado, object>>>? predicateInclude)
        {
            return await _repository.GetPagnationAsync(page, predicateWhere, predicateOrder, predicateInclude);
        }

        public async Task<ServicoExecutado?> GetServicoExecutadoAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
