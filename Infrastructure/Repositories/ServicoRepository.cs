using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly IGenericRepository<Servico> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServicoRepository(IGenericRepository<Servico> genericRepository, 
            IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AdicionarServicoAsync(Servico servico)
        {
            await _genericRepository.AdicionarAsync(servico);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> EditServicoAsync(Servico servico)
        {
            await _genericRepository.EditarAsync(servico);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> ExcluirServicoAsync(Servico servico)
        {
            await _genericRepository.ExcluirAsync(servico);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<Servico?> GetByIdAsync(Guid id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async ValueTask<(List<Servico> Values, int TotalPages)> GetPaginationAsync(int page,
            Expression<Func<Servico, bool>> predicateWhere,
            Expression<Func<Servico, object>> predicateOrder,
            List<Expression<Func<Servico, object>>>? predicateInclude)
        {
            try
            {
                return await _genericRepository.GetPagnationAsync(page, predicateWhere, predicateOrder, predicateInclude);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
