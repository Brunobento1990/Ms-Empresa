using Application.Dtos.Generic;
using Application.Dtos.ServicosExecutadosDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ServicoExecutadoService : IServicoExecutadoService
    {
        private readonly IServicoExecutadoRepository _servicoExecutadoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicoExecutadoService(IServicoExecutadoRepository servicoExecutadoRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _servicoExecutadoRepository = servicoExecutadoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarServicoExecutadoAsync(ServicoExecutadoCreateDto servicoExecutadoCreateDto)
        {
            var servicoExecutado = new ServicoExecutado(
                servicoExecutadoCreateDto.Preco,
                servicoExecutadoCreateDto.Quantidade,
                servicoExecutadoCreateDto.FuncionarioId,
                servicoExecutadoCreateDto.ServicoId);

            await _servicoExecutadoRepository.AdicionarServicoExecutadoAsync(servicoExecutado);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> ExcluirServicoExecutadoAsync(Guid id)
        {
            var servicoExecutado = await _servicoExecutadoRepository.GetServicoExecutadoAsync(id);

            if (servicoExecutado == null) throw new Exception("Não foi possível localizar o registro!");

            servicoExecutado.Excluir();

            await _servicoExecutadoRepository.ExcluirServicoExecutadoAsync(servicoExecutado);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<PaginacaoResponse<ServicoExecutadoViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest)
        {
            Expression<Func<ServicoExecutado, bool>> predicateWhere = x => x.DataDeExclusao == null;

            Expression<Func<ServicoExecutado, object>> predicateOrder = x => x.DataDeCadastro;

            var paginacao = await _servicoExecutadoRepository.GetPaginationAsync(paginacaoRequest.Page, predicateWhere, predicateOrder, null);

            return new PaginacaoResponse<ServicoExecutadoViewDto>(
                paginacao.TotalPages, _mapper.Map<List<ServicoExecutadoViewDto>>(paginacao.Values));
        }
    }
}
