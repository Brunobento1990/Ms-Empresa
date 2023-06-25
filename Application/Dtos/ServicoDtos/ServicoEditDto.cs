using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.ServicoDtos
{
    public class ServicoEditDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        [MaxLength(50)]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo preço é obrigatório.")]
        public decimal Preco { get; set; }
    }
}
