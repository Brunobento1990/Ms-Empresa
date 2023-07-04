using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ICargoFuncionarioRepository
    {
        Task<CargoFuncionario?> GetCargoByDescricaoAsync(string descricao);
        Task<CargoFuncionario?> GetCargoByIdAsync(Guid id);
        Task<bool> AdicionarCargoFuncionarioAsync(CargoFuncionario cargoFuncionario);
        ValueTask<(List<CargoFuncionario> Values, int TotalPages)> GetPaginationAsync(int page,
            Expression<Func<CargoFuncionario, bool>> predicateWhere,
            Expression<Func<CargoFuncionario, object>> predicateOrder,
            List<Expression<Func<CargoFuncionario, object>>>? predicateInclude);
        Task<bool> EditCargoFuncionarioAsync(CargoFuncionario cargoFuncionario);
        Task<bool> ExcluirCargoFuncionarioAsync(CargoFuncionario cargoFuncionario);
    }
}
