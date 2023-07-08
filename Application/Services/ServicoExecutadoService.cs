using Application.Dtos.Generic;
using Application.Dtos.ServicosExecutadosDtos;
using Application.Interfaces;
using Application.ITextSharp.Relatorios;
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
        private readonly IRelatorioServicoExecutado _relatorioServicoExecutado;

        public ServicoExecutadoService(IServicoExecutadoRepository servicoExecutadoRepository, 
            IUnitOfWork unitOfWork, IMapper mapper, IRelatorioServicoExecutado relatorioServicoExecutado)
        {
            _servicoExecutadoRepository = servicoExecutadoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _relatorioServicoExecutado = relatorioServicoExecutado;
        }

        public async Task<bool> AdicionarServicoExecutadoAsync(ServicoExecutadoCreateDto servicoExecutadoCreateDto, Guid empresaId)
        {
            var servicoExecutado = new ServicoExecutado(
                servicoExecutadoCreateDto.Preco,
                servicoExecutadoCreateDto.Quantidade,
                servicoExecutadoCreateDto.FuncionarioId,
                servicoExecutadoCreateDto.ServicoId,
                empresaId);

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

        public async Task<byte[]> GerarRelarotioServicoExecutadoAsync(
            RelatorioServicoExecutadoRequest relatorioServicoExecutadoRequest, Guid empresaId, string cnpj, string nomeEmpresa)
        {
            var servicosExecutados = await _servicoExecutadoRepository
                .GetRelatorioServicoExecutadoAsync(
                relatorioServicoExecutadoRequest.DataInicial, 
                relatorioServicoExecutadoRequest.DataFinal, 
                relatorioServicoExecutadoRequest.ServicoId,
                relatorioServicoExecutadoRequest.FuncionarioId,
                empresaId);

            var relatorioDto = new RelatorioDto
            {
                CnpjEmpresa = cnpj,
                NomeEmpresa = nomeEmpresa
            };

            relatorioDto.ItensRelatorioDtos = servicosExecutados.Select(x =>
            {
                return new ItensRelatorioDto
                {
                    DataPrestacao = x.DataDeCadastro,
                    DescricaoServico = x.Servico.Descricao,
                    NomeFuncionario = x.Funcionario.Nome,
                    Preco = x.Preco,
                    Quantidade = x.Quantidade
                };
            }).ToList();

            var pdf = _relatorioServicoExecutado.GerarPdf(relatorioDto);

            return pdf;
        }

        public async Task<PaginacaoResponse<ServicoExecutadoViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest)
        {
            Expression<Func<ServicoExecutado, bool>> predicateWhere = x => x.DataDeExclusao == null && x.EmpresaId == paginacaoRequest.EmpresaId;

            Expression<Func<ServicoExecutado, object>> predicateOrder = x => x.DataDeCadastro;

            List<Expression<Func<ServicoExecutado, object>>> predicateInclude = new List<Expression<Func<ServicoExecutado, object>>>
            {
                x => x.Servico,
                x => x.Funcionario
            };


            var paginacao = await _servicoExecutadoRepository.GetPaginationAsync(paginacaoRequest.Page, predicateWhere, predicateOrder, predicateInclude);

            var paginacaoView = paginacao.Values.Select(x => new ServicoExecutadoViewDto
            {
                DescricaoServico = x.Servico.Descricao,
                NomeFuncionario = x.Funcionario.Nome,
                Preco = x.Preco,
                Quantidade = x.Quantidade,
                Id = x.Id
            }).ToList();

            return new PaginacaoResponse<ServicoExecutadoViewDto>(
                paginacao.TotalPages, paginacaoView);
        }
    }
}
