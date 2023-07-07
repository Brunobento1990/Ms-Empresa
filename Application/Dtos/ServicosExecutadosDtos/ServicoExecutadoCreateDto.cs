namespace Application.Dtos.ServicosExecutadosDtos
{
    public class ServicoExecutadoCreateDto
    {
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public Guid ServicoId { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}
