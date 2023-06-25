using Application.Dtos.CargoFuncionarioDtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICargoFuncionarioService
    {
        Task<CargoFuncionario> AdicionarCargoFuncionarioAsync(CargoFuncionarioCreateDto cargoFuncionarioCreateDto);
        Task<CargoFuncionario> GetCargoFuncionarioByDescricaoAsync(string descricao);
    }
}
