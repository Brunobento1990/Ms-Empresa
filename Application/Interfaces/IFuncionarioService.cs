using Application.Dtos.FuncionarioDtos;

namespace Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<FuncionarioViewDto> AdicionarFuncionarioAsync(
            FuncionarioCreateDto funcionarioCreateDto, Guid empresaId);
    }
}
