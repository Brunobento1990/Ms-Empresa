using Application.Dtos.EmpresaDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Services
{
    public class AdicionarEmpresaService : IAdicionarEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdicionarPrimeiroFuncionarioEmpresa _adicionarPrimeiroFuncionarioEmpresa;
        const string EmpresaCnpjCadastradaErrorMessage = "A empresa com CNPJ : {0}, já se encontra cadastrada em nossa base de dados.";
        const string EmpresaAdicionarErroMessage = "Não foi possível adicionar a empresa: {0}";

        public AdicionarEmpresaService(IEmpresaRepository empresaRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAdicionarPrimeiroFuncionarioEmpresa adicionarPrimeiroFuncionarioEmpresa)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _adicionarPrimeiroFuncionarioEmpresa = adicionarPrimeiroFuncionarioEmpresa;
        }
        public async Task<EmpresaViewDto> AdicionarEmpresaAsync(EmpresaCreateDto empresaCreateDto)
        {
            if (!await _empresaRepository.ValidarCnpjCadastradoAsync(empresaCreateDto.Cnpj))
                throw new ArgumentException(string.Format(EmpresaCnpjCadastradaErrorMessage, empresaCreateDto.Cnpj));

            var enderecoEmpresa = new EnderecoEmpresa(
                empresaCreateDto.EnderecoEmpresa.Cep,
                empresaCreateDto.EnderecoEmpresa.Rua,
                empresaCreateDto.EnderecoEmpresa.Bairro,
                empresaCreateDto.EnderecoEmpresa.Cidade,
                empresaCreateDto.EnderecoEmpresa.Estado,
                empresaCreateDto.EnderecoEmpresa.Numero);

            var empresa = new Empresa(
                    empresaCreateDto.RazaoSocial,
                    empresaCreateDto.NomeFantasia,
                    empresaCreateDto.Cnpj,
                    empresaCreateDto.Setor,
                    empresaCreateDto.InscricaoEstadual,
                    empresaCreateDto.InscricaoMunicipal
                );

            empresa.EnderecoEmpresa = enderecoEmpresa;
            empresa.ContatosEmpresa = new List<ContatoEmpresa>();

            foreach(var contato in empresaCreateDto.ContatosEmpresa)
            {
                var contatoEmpresa = new ContatoEmpresa(
                    contato.Ddd,
                    contato.Telefone,
                    contato.Email
                    );
                empresa.ContatosEmpresa.Add(contatoEmpresa);
            }

            var result = await _empresaRepository.AdicionarEmpresaAsync(empresa);

            if (!result) throw new Exception(string.Format(EmpresaAdicionarErroMessage, empresaCreateDto.RazaoSocial));

            var empresaViewModel = _mapper.Map<EmpresaViewDto>(empresa);

            var email = empresaCreateDto.ContatosEmpresa[0].Email;

            empresaViewModel.Funcionario =
                await _adicionarPrimeiroFuncionarioEmpresa
                .AdicionarPrimeiroFuncionarioAsync(empresa.Id, email);

            await _unitOfWork.CommitAsync();

            return empresaViewModel;
        }

    }
}
