namespace Domain.Entities
{
    public class HistoricoPagamentoEmpresa : BaseEntity
    {
        public HistoricoPagamentoEmpresa(decimal valorPagamento, 
            FormaDePagamento formaDePagamento, 
            StatusPagamento statusPagamento)
        {
            ValorPagamento = valorPagamento;
            FormaDePagamento = formaDePagamento;
            StatusPagamento = statusPagamento;
        }

        public decimal ValorPagamento { get; private set; }
        public FormaDePagamento FormaDePagamento { get; private set; }
        public StatusPagamento StatusPagamento { get; private set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
    }

    public enum FormaDePagamento
    {
        Dinheiro,
        Pix,
        Cartao
    }

    public enum StatusPagamento
    {
        Pago,
        Pendente,
        Atrasado,
        Cancelado
    }
}
