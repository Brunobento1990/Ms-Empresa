using Application.Dtos.Generic;
using Application.Dtos.ServicosExecutadosDtos;

namespace Application.Interfaces
{
    public interface IServicoExecutadoService
    {
        Task<bool> AdicionarServicoExecutadoAsync(ServicoExecutadoCreateDto servicoExecutadoCreateDto);
        Task<bool> ExcluirServicoExecutadoAsync(Guid id);
        Task<PaginacaoResponse<ServicoExecutadoViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest);
    }
}
