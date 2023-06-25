using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Empresa : BaseEntity
    {
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string? Setor { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public string? InscricaoMunicipal { get; private set; }
        public bool PagamentoEmDia { get; private set; }
        public EnderecoEmpresa EnderecoEmpresa { get; set; } = null!;
        public List<ContatoEmpresa> ContatosEmpresa { get; set; } = null!;
        public List<Funcionario> Funcionarios { get; set; } = null!;
        public List<Servico> Servicos { get; set; } = null!;
        public List<CargoFuncionario> CargoFuncionario { get; set; } = null!;
        public List<HistoricoPagamentoEmpresa> HistoricoPagamentosEmpresa { get; set; } = null!;

        public Empresa(string razaoSocial, 
            string nomeFantasia, 
            string cnpj, 
            string? setor, 
            string? inscricaoEstadual, 
            string? inscricaoMunicipal)
        {

            const string messageError = "É obrigatório informar";
            Validation.ValidationString(razaoSocial, $"{messageError} a razão social da empresa.");
            Validation.ValidationString(nomeFantasia, $"{messageError} o nome fantasia da empresa.");
            Validation.ValidationString(cnpj, $"{messageError} o CNPJ da empresa.");
            Validation.ValidationMaxLengthString(razaoSocial, 250, "O tamanho da razão social ultrapassou o limite de 250 caracteres.");
            Validation.ValidationMaxLengthString(nomeFantasia, 250, "O tamanho do nome fantasia da empresa ultrapassou o limite de 250 caracteres.");
            
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Setor = setor;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            PagamentoEmDia = true;
        }
    }
}
