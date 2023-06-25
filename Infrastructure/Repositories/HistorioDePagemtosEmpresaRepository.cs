using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HistorioDePagemtosEmpresaRepository : IHistorioDePagemtosEmpresaRepository
    {
        protected MsContext _dbContext;

        public HistorioDePagemtosEmpresaRepository(MsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HistoricoPagamentoEmpresa> GetUltimoPagamentoEmpresaAsync(Guid empresaId)
        {
            try
            {
                return await _dbContext.HistoricoPagamentosEmpresa
                    .AsNoTracking()
                    .OrderByDescending(p => p.DataDeCadastro)
                    .FirstOrDefaultAsync(x => x.EmpresaId == empresaId && x.DataDeExclusao == null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
