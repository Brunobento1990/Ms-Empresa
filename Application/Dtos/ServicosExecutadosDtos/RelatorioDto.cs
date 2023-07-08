namespace Application.Dtos.ServicosExecutadosDtos
{
    public class RelatorioDto
    {
        public string NomeEmpresa { get; set; } = string.Empty;
        public string CnpjEmpresa { get; set; } = string.Empty;
        public List<ItensRelatorioDto> ItensRelatorioDtos { get; set; } = new();
    }
}
