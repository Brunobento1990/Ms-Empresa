using Application.Dtos.CargoFuncionarioDtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CargoFuncionarioService : ICargoFuncionarioService
    {
        private readonly ICargoFuncionarioRepository _cargoFuncionarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CargoFuncionarioService(ICargoFuncionarioRepository cargoFuncionarioRepository, IUnitOfWork unitOfWork)
        {
            _cargoFuncionarioRepository = cargoFuncionarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CargoFuncionario> AdicionarCargoFuncionarioAsync(CargoFuncionarioCreateDto cargoFuncionarioCreateDto)
        {
            try
            {
                var cargoFuncionario = new CargoFuncionario(cargoFuncionarioCreateDto.Descricao);

                var result = await _cargoFuncionarioRepository.AdicionarCargoFuncionarioAsync(cargoFuncionario);

                if (!result) throw new Exception();

                //await _unitOfWork.CommitAsync();

                return cargoFuncionario;    

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CargoFuncionario> GetCargoFuncionarioByDescricaoAsync(string descricao)
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
    }
}
