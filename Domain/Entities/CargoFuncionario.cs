using Domain.Validations;

namespace Domain.Entities
{
    public class CargoFuncionario : BaseEntity
    {
        public CargoFuncionario(string descricao)
        {
            Validation.ValidationString(descricao, "É obrigatório informar a descrição do cargo .");
            Validation.ValidationMaxLengthString(descricao,50, "O tamanho da descrição ultrapassou o limite de 50 caracteres.");
            Validation.ValidationMinLengthString(descricao, 5, "O tamanho mínimo da descrição é 5 caracteres.");

            Descricao = descricao;
        }
        public string Descricao { get; private set; }
        public List<Funcionario> Funcionarios { get; set; } = null!;
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
    }
}
