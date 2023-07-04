using Application.Dtos.CargoFuncionarioDtos;
using Application.Dtos.Generic;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{
    public class CargoFuncionarioService : ICargoFuncionarioService
    {
        private readonly ICargoFuncionarioRepository _cargoFuncionarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoFuncionarioService(ICargoFuncionarioRepository cargoFuncionarioRepository, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _cargoFuncionarioRepository = cargoFuncionarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AdicionarCargoFuncionarioAsync(CargoFuncionarioCreateDto cargoFuncionarioCreateDto, Guid empresaId)
        {
            try
            {
                var cargoFuncionario = new CargoFuncionario(cargoFuncionarioCreateDto.Descricao, empresaId);

                var result = await _cargoFuncionarioRepository.AdicionarCargoFuncionarioAsync(cargoFuncionario);

                if (!result) throw new Exception();

                return await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditarCargoAsync(CargoFuncionarioEditDto cargoFuncionarioEditDto)
        {
            var cargo = await _cargoFuncionarioRepository.GetCargoByIdAsync(cargoFuncionarioEditDto.Id);

            if(cargo == null) throw new Exception("Não foi possível localizar o registro !");

            cargo.Edit(cargoFuncionarioEditDto.Descricao);

            await _cargoFuncionarioRepository.EditCargoFuncionarioAsync(cargo);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> ExcluirCargoAsync(Guid id)
        {
            var cargo = await _cargoFuncionarioRepository.GetCargoByIdAsync(id);

            if (cargo == null) throw new Exception("Não foi possível localizar o registro !");

            cargo.Excluir();

            await _cargoFuncionarioRepository.ExcluirCargoFuncionarioAsync(cargo);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<CargoFuncionario?> GetCargoFuncionarioByDescricaoAsync(string descricao)
        {
            try
            {
                return await _cargoFuncionarioRepository.GetCargoByDescricaoAsync(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CargoFuncionarioViewDto> GetCargoIdAsync(Guid id)
        {
            var cargo = await _cargoFuncionarioRepository.GetCargoByIdAsync(id);

            if (cargo == null) throw new Exception("Não foi possível localizar o registro !");

            return _mapper.Map<CargoFuncionarioViewDto>(cargo);
        }

        public async Task<PaginacaoResponse<CargoFuncionarioViewDto>> GetPaginacaoAsync(PaginacaoRequest paginacaoRequest)
        {
            try
            {
                Expression<Func<CargoFuncionario, bool>> predicateWhere = !string.IsNullOrEmpty(paginacaoRequest.Search) ?
                    x => x.EmpresaId == paginacaoRequest.EmpresaId && x.DataDeExclusao == null && x.Descricao.ToUpper().Contains(paginacaoRequest.Search.ToUpper()) :
                    x => x.EmpresaId == paginacaoRequest.EmpresaId && x.DataDeExclusao == null;

                Expression<Func<CargoFuncionario, object>> predicateOrder = x => x.DataDeCadastro;

                var paginacao = await _cargoFuncionarioRepository.GetPaginationAsync(paginacaoRequest.Page, predicateWhere, predicateOrder, null);

                return new PaginacaoResponse<CargoFuncionarioViewDto>(
                    paginacao.TotalPages, _mapper.Map<List<CargoFuncionarioViewDto>>(paginacao.Values));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
