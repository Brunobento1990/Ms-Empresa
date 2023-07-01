namespace Domain.Entities
{
    public class ServicoExecutado : BaseEntity
    {
        public decimal Preco { get; private set; }
        public decimal Quantidade { get; private set; }
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; } = null!;
        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; } = null!;
    }
}
