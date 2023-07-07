using Domain.Validations;

namespace Domain.Entities
{
    public sealed class ServicoExecutado : BaseEntity
    {
        public ServicoExecutado(decimal preco, 
            decimal quantidade, 
            Guid funcionarioId, 
            Guid servicoId)
        {
            Validation.ValidationNumberZero(preco, "O preço do serviço deve ser maior que zero.");
            Validation.ValidationNumberZero(quantidade, "A quantidade deve ser maior que zero.");

            Preco = preco;
            Quantidade = quantidade;
            FuncionarioId = funcionarioId;
            ServicoId = servicoId;
        }

        public void Excluir()
        {
            DataDeExclusao = DateTime.Now;
        }

        public decimal Preco { get; private set; }
        public decimal Quantidade { get; private set; }
        public Guid FuncionarioId { get; private set; }
        public Funcionario Funcionario { get; set; } = null!;
        public Guid ServicoId { get; private set; }
        public Servico Servico { get; set; } = null!;
    }
}
