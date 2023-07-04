using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Funcionario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool EmailVerificado { get; private set; }
        public Guid CodigoEmailFerificado { get; private set; }
        public bool Adicionar { get; private set; }
        public bool Editar { get; private set; }
        public bool Excluir { get; private set; }
        public bool AcessoAoSistema { get; private set; }
        public bool Master { get; private set; }
        public Guid? CargoFuncionarioId { get; private set; }
        public CargoFuncionario? CargoFuncionario { get; set; } = null!;
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; set; } = null!;
        public List<ServicoExecutado> ServicosExecutados { get; set; } = null!;
        public Funcionario(string nome,
            string cpf,
            DateTime dataDeNascimento,
            string email,
            string senha,
            bool adicionar,
            bool editar,
            bool excluir,
            bool acessoAoSistema,
            Guid empresaId,
            Guid? cargoFuncionarioId,
            bool master)
        {
            const string messageError = "É obrigatório informar";

            Validation.ValidationString(nome.Trim(), $"{messageError} o nome do funcionário.");
            Validation.ValidationString(cpf.Trim(), $"{messageError} o cpf do funcionário.");
            Validation.ValidationString(email.Trim(), $"{messageError} o email do funcionário.");
            Validation.ValidationString(senha.Trim(), $"{messageError} a senha do funcionário.");
            Validation.ValidationMinLengthString(senha, 8, "Senha inválida");
            Validation.ValidationMaxLengthString(senha, 100, "Senha inválida");
            
            Nome = nome;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
            Email = email;
            Senha = senha;
            Adicionar = adicionar;
            Editar = editar;
            Excluir = excluir;
            AcessoAoSistema = acessoAoSistema;
            EmpresaId = empresaId;
            CargoFuncionarioId = cargoFuncionarioId;
            Master = master;
            Master = false;
            EmailVerificado = false;
            CodigoEmailFerificado = Guid.NewGuid();
        }
    }
}
