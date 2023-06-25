using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IHistorioDePagemtosEmpresaRepository
    {
        Task<HistoricoPagamentoEmpresa> GetUltimoPagamentoEmpresaAsync(Guid empresaId);
    }
}
