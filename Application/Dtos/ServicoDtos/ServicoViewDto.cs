namespace Application.Dtos.ServicoDtos
{
    public class ServicoViewDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
