using Application.Dtos.FuncionarioDtos;

namespace Application.Interfaces
{
    public interface IAdicionarPrimeiroFuncionarioEmpresa
    {
        Task<FuncionarioViewDto> AdicionarPrimeiroFuncionarioAsync(Guid empresaId, string email);
    }
}
