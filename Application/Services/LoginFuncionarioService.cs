using Application.Dtos.FuncionarioDtos;
using Application.Interfaces;
using Application.Token;
using Domain.Entities;
using Domain.Interfaces;
using static BCrypt.Net.BCrypt;

namespace Application.Services
{
    public class LoginFuncionarioService : ILoginFuncionarioService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IGerarTokenService _gerarTokenService;
        private readonly IHistorioDePagemtosEmpresaRepository _historioDePagemtosEmpresaRepository;
        const string ErrorLogin = "E-mail ou senha inválidos!";

        public LoginFuncionarioService(ILoginRepository loginRepository,
            IGerarTokenService gerarTokenService,
            IHistorioDePagemtosEmpresaRepository historioDePagemtosEmpresaRepository)
        {
            _loginRepository = loginRepository;
            _gerarTokenService = gerarTokenService;
            _historioDePagemtosEmpresaRepository = historioDePagemtosEmpresaRepository;
        }

        public async Task<string> LoginAsync(FuncionarioLoginDto funcionarioLoginDto)
        {
            try
            {
                var funcionario = await _loginRepository.LoginAsync(funcionarioLoginDto.Email);

                if (funcionario is null) throw new Exception(ErrorLogin);

                if (!Verify(funcionarioLoginDto.Senha, funcionario.Senha)
                    || !funcionario.Empresa.PagamentoEmDia) throw new Exception(ErrorLogin);

                //var historicoPagamento = await _historioDePagemtosEmpresaRepository
                //    .GetUltimoPagamentoEmpresaAsync(funcionario.Empresa.Id);

                //DateTime dataAtual = DateTime.Now;
                //DateTime dataAnterior = dataAtual.AddDays(-30);

                //if(historicoPagamento == null)
                //    throw new Exception(ErrorLogin);

                //if (historicoPagamento.DataDeCadastro < dataAnterior || historicoPagamento.StatusPagamento != StatusPagamento.Pago)
                //    throw new Exception(ErrorLogin);

                return _gerarTokenService.GetToken(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
