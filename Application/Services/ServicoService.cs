using Application.Dtos.Generic;
using Application.Dtos.ServicoDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;
        

        public ServicoService(IServicoRepository servicoRepository,
            IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarServicoAsync(ServicoCreatedDto servicoCreatedDto, Guid empresaId)
        {
            try
            {
                var servico = new Servico(
                    servicoCreatedDto.Descricao,servicoCreatedDto.Preco);

                servico.EmpresaId = empresaId;

                return await _servicoRepository.AdicionarServicoAsync(servico);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditarServicoAsync(ServicoEditDto servicoEditDto)
        {
            var servico = await _servicoRepository.GetByIdAsync(servicoEditDto.Id);

            if (servico == null) return false;

            servico.Edit(servicoEditDto.Descricao, servicoEditDto.Preco);

            return await _servicoRepository.EditServicoAsync(servico);
        }

        public async Task<bool> ExcluirServicoAsync(Guid id)
        {
            var servico = await _servicoRepository.GetByIdAsync(id);

            if (servico == null)
                throw new Exception("Serviço não localizado.");

            servico.Excluir();

            return await _servicoRepository.ExcluirServicoAsync(servico);
        }

        public async Task<List<ServicoViewDto>> GetAllServicoAsync(Guid empresaId)
        {
            var servicos = await _servicoRepository.GetAllServicosAsync(empresaId);

            return _mapper.Map<List<ServicoViewDto>>(servicos);
        }

        public async Task<PaginacaoResponse<ServicoViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest)
        {
            try
            {
                Expression<Func<Servico, bool>> predicateWhere = !string.IsNullOrEmpty(paginacaoRequest.Search) ?
                    x => x.EmpresaId == paginacaoRequest.EmpresaId && x.DataDeExclusao == null && x.Descricao.ToUpper().Contains(paginacaoRequest.Search.ToUpper()) :
                    x => x.EmpresaId == paginacaoRequest.EmpresaId && x.DataDeExclusao == null;

                Expression<Func<Servico, object>> predicateOrder = x => x.DataDeCadastro;

                var paginacao = await _servicoRepository.GetPaginationAsync(paginacaoRequest.Page, predicateWhere, predicateOrder, null);

                return new PaginacaoResponse<ServicoViewDto>(
                    paginacao.TotalPages, _mapper.Map<List<ServicoViewDto>>(paginacao.Values));

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServicoViewDto> GetServicoViewAsync(Guid id)
        {
            var servico = await _servicoRepository.GetByIdAsync(id);

            if (servico == null) throw new Exception("Não foi possível localizar o registro de serviço.");

            return _mapper.Map<ServicoViewDto>(servico);
        }
    }
}
