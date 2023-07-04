using Application.Dtos.FuncionarioDtos;
using Application.Dtos.Generic;

namespace Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<FuncionarioViewDto> AdicionarFuncionarioAsync(
            FuncionarioCreateDto funcionarioCreateDto, Guid empresaId);
        Task<PaginacaoResponse<FuncionarioViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest);
    }
}
