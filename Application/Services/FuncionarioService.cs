using Application.Dtos.FuncionarioDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        const string ErrorAdicionarFuncionario = "Ocorreu um erro interno ao adicionar o funcionário, tente novamente mais tarde.";
        const string ErrorFuncionarioEncontrado = "Este e-mail do funcionário já se encontra cadastrado em nossa base de dados.";

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FuncionarioViewDto> AdicionarFuncionarioAsync(
            FuncionarioCreateDto funcionarioCreateDto, Guid empresaId)
        {
            try
            {
                var funcionarioCadastrado = await _funcionarioRepository.GetFuncionarioByEmail(funcionarioCreateDto.Email);

                if (funcionarioCadastrado != null)
                    throw new Exception(ErrorFuncionarioEncontrado);

                var funcionario = new Funcionario(
                        funcionarioCreateDto.Nome,
                        funcionarioCreateDto.Cpf,
                        funcionarioCreateDto.DataDeNascimento,
                        funcionarioCreateDto.Email,
                        funcionarioCreateDto.Senha,
                        funcionarioCreateDto.Adicionar,
                        funcionarioCreateDto.Editar,
                        funcionarioCreateDto.Excluir,
                        funcionarioCreateDto.AcessoAoSistema);

                funcionario.EmpresaId = empresaId;
                funcionario.CargoFuncionarioId = funcionarioCreateDto.CargoFuncionarioId;

                var result = await _funcionarioRepository.AdicionarFuncionarioAsync(funcionario);

                if (!result) 
                    throw new Exception(ErrorAdicionarFuncionario);

                result = await _unitOfWork.CommitAsync();

                if (!result)
                    throw new Exception(ErrorAdicionarFuncionario);

                return _mapper.Map<FuncionarioViewDto>(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
