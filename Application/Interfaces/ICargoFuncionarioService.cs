using Application.Dtos.CargoFuncionarioDtos;
using Application.Dtos.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICargoFuncionarioService
    {
        Task<PaginacaoResponse<CargoFuncionarioViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest);
        Task<bool> AdicionarCargoFuncionarioAsync(CargoFuncionarioCreateDto cargoFuncionarioCreateDto, Guid empresaId);
        Task<CargoFuncionario?> GetCargoFuncionarioByDescricaoAsync(string descricao);
        Task<CargoFuncionarioViewDto> GetCargoIdAsync(Guid id);
        Task<bool> EditarCargoAsync(CargoFuncionarioEditDto cargoFuncionarioEditDto);
        Task<bool> ExcluirCargoAsync(Guid id);
    }
}
