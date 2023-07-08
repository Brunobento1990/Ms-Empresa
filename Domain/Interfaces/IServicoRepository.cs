using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IServicoRepository
    {
        ValueTask<(List<Servico> Values, int TotalPages)> GetPaginationAsync(int page,
            Expression<Func<Servico, bool>> predicateWhere,
            Expression<Func<Servico, object>> predicateOrder,
            List<Expression<Func<Servico, object>>>? predicateInclude);
        Task<bool> AdicionarServicoAsync(Servico servico);
        Task<Servico?> GetByIdAsync(Guid id);
        Task<bool> ExcluirServicoAsync(Servico servico);
        Task<bool> EditServicoAsync(Servico servico);
        Task<List<Servico>> GetAllServicosAsync(Guid empresaId);
    }
}
