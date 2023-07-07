using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IServicoExecutadoRepository
    {
        ValueTask<(List<ServicoExecutado> Values, int TotalPages)> GetPaginationAsync(int page,
            Expression<Func<ServicoExecutado, bool>> predicateWhere,
            Expression<Func<ServicoExecutado, object>> predicateOrder,
            List<Expression<Func<ServicoExecutado, object>>>? predicateInclude);
        Task<bool> AdicionarServicoExecutadoAsync(ServicoExecutado servico);
        Task<bool> ExcluirServicoExecutadoAsync(ServicoExecutado servico);
        Task<ServicoExecutado?> GetServicoExecutadoAsync(Guid id);
    }
}
