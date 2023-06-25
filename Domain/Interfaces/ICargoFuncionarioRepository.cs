using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICargoFuncionarioRepository
    {
        Task<CargoFuncionario> GetCargoByDescricaoAsync(string descricao);
        Task<bool> AdicionarCargoFuncionarioAsync(CargoFuncionario cargoFuncionario);
    }
}
