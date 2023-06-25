using Domain.Validations;

namespace Domain.Entities
{
    public class Servico : BaseEntity
    {
        public Servico(string descricao, decimal preco)
        {
            Validation.ValidationString(descricao, "É obrigatório informar a descriçõ do serviço.");
            Validation.ValidationMaxLengthString(descricao, 50, "O tamanho da descrição do serviço ultrapasou o limite de caracteres.");
            Validation.ValidationNumberZero(preco, "O preço do serviço deve ser maior que zero.");

            Descricao = descricao;
            Preco = preco;
        }

        public void Edit(string descricao,decimal preco)
        {
            Validation.ValidationString(descricao, "É obrigatório informar a descriçõ do serviço.");
            Validation.ValidationMaxLengthString(descricao, 50, "O tamanho da descrição do serviço ultrapasou o limite de caracteres.");
            Validation.ValidationNumberZero(preco, "O preço do serviço deve ser maior que zero.");

            Descricao = descricao;
            Preco = preco;
            DataDeAlteracao = DateTime.Now;
        }

        public void Excluir()
        {
            DataDeExclusao = DateTime.Now;
        }

        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
        public List<ServicoExecutado> ServicosExecutados { get; set; } = null!;
    }
}
