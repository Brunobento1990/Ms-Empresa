using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class ServicoExecutadoRepository : IServicoExecutadoRepository
    {
        private readonly IGenericRepository<ServicoExecutado> _repository;
        private readonly MsContext _msContext;

        public ServicoExecutadoRepository(IGenericRepository<ServicoExecutado> repository,
            MsContext msContext)
        {
            _msContext = msContext;
            _repository = repository;
        }

        public async Task<bool> AdicionarServicoExecutadoAsync(ServicoExecutado servico)
        {
            return await _repository.AdicionarAsync(servico);
        }

        public async Task<bool> ExcluirServicoExecutadoAsync(ServicoExecutado servico)
        {
            return await _repository.ExcluirAsync(servico);
        }

        public async ValueTask<(List<ServicoExecutado> Values, int TotalPages)> GetPaginationAsync(
            int page, Expression<Func<ServicoExecutado, bool>> predicateWhere, 
            Expression<Func<ServicoExecutado, object>> predicateOrder, 
            List<Expression<Func<ServicoExecutado, object>>>? predicateInclude)
        {
            return await _repository.GetPagnationAsync(page, predicateWhere, predicateOrder, predicateInclude);
        }

        public async Task<List<ServicoExecutado>> GetRelatorioServicoExecutadoAsync(
            DateTime dataInicial, DateTime dataFinal, Guid? servicoId, Guid? funcionarioId, Guid empresaId)
        {
            var servicosExecutado = _msContext.ServicosExecutados
                .AsNoTracking()
                .Include(x => x.Funcionario)
                .Include(x => x.Servico)
                .Where(x => x.DataDeExclusao == null &&
                    x.EmpresaId == empresaId &&
                    x.DataDeCadastro.Date >= dataInicial &&
                    x.DataDeCadastro.Date <= dataFinal)
                .AsQueryable();

            if(funcionarioId != null )
            {
                servicosExecutado = servicosExecutado.Where(x => x.FuncionarioId == funcionarioId);
            }

            if (servicoId != null)
            {
                servicosExecutado = servicosExecutado.Where(x => x.ServicoId == servicoId);
            }

            return await servicosExecutado.ToListAsync();
        }

        public async Task<ServicoExecutado?> GetServicoExecutadoAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
