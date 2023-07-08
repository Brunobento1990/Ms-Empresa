using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<bool> AdicionarFuncionarioAsync(Funcionario funcionario);
        Task<Funcionario?> GetFuncionarioByEmail(string email);

        ValueTask<(List<Funcionario> Values, int TotalPages)> GetPaginationAsync(int page,
            Expression<Func<Funcionario, bool>> predicateWhere,
            Expression<Func<Funcionario, object>> predicateOrder,
            List<Expression<Func<Funcionario, object>>>? predicateInclude);
        Task<List<Funcionario>> GetAllFuncionarioAsync(Guid empresaId);
    }
}
