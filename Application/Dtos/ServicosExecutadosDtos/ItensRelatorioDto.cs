namespace Application.Dtos.ServicosExecutadosDtos
{
    public class ItensRelatorioDto
    {
        public string NomeFuncionario { get; set; } = string.Empty;
        public string DescricaoServico { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataPrestacao { get; set; }
    }
}
