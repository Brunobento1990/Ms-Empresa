using Application.Dtos.CargoFuncionarioDtos;
using Application.Dtos.FuncionarioDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using static BCrypt.Net.BCrypt;


namespace Application.Services
{
    public class AdicionarPrimeiroFuncionarioEmpresa : IAdicionarPrimeiroFuncionarioEmpresa
    {
        const string AdicionarFuncionarioErrorMessage = "Não foi possível adicionar o funcionário admin, tente novamente mais tarde!";
        private readonly ICargoFuncionarioRepository _cargoFuncionarioRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public AdicionarPrimeiroFuncionarioEmpresa(ICargoFuncionarioRepository cargoFuncionarioRepository,
            IFuncionarioRepository funcionarioRepository,
            IMapper mapper)
        {
            _cargoFuncionarioRepository = cargoFuncionarioRepository;
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioViewDto> AdicionarPrimeiroFuncionarioAsync(Guid empresaId, string email)
        {
            var senha = string.Empty;

            for (var i = 0; i < 8; i++)
            {
                var random = new Random();
                int numeroAleatorio = random.Next(10);

                senha += numeroAleatorio.ToString();
            }

            var passwordHash = HashPassword(senha, workFactor: 10);

            var nome = "admin";

            var cargoMaster = new CargoFuncionario("Master");
            cargoMaster.EmpresaId = empresaId;
            await _cargoFuncionarioRepository.AdicionarCargoFuncionarioAsync(cargoMaster);

            var funcionario = new Funcionario(
                nome, "00000000", DateTime.Now,
                email, passwordHash,
                true, true, true, true);

            funcionario.CargoFuncionarioId = cargoMaster.Id;
            funcionario.EmpresaId = empresaId;

            var addFuncionario = await _funcionarioRepository.AdicionarFuncionarioAsync(funcionario);

            if (!addFuncionario) throw new Exception(AdicionarFuncionarioErrorMessage);

            var funcionarioView = _mapper.Map<FuncionarioViewDto>(funcionario);

            funcionarioView.Senha = senha;

            return funcionarioView;
        }
    }
}
