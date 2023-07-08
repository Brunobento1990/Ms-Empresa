namespace Application.Dtos.ServicosExecutadosDtos
{
    public class RelatorioServicoExecutadoRequest
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public Guid? ServicoId { get; set; }
        public Guid? FuncionarioId { get; set; }
    }
}
