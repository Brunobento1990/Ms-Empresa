using Application.Dtos.Generic;
using Application.Dtos.ServicoDtos;

namespace Application.Interfaces
{
    public interface IServicoService
    {
        Task<PaginacaoResponse<ServicoViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest);
        Task<bool> AdicionarServicoAsync(ServicoCreatedDto servicoCreatedDto,Guid empresaId);
        Task<ServicoViewDto> GetServicoViewAsync(Guid id);
        Task<bool> ExcluirServicoAsync(Guid id);
        Task<bool> EditarServicoAsync(ServicoEditDto servicoEditDto);
        Task<List<ServicoViewDto>> GetAllServicoAsync(Guid empresaId);
    }
}
