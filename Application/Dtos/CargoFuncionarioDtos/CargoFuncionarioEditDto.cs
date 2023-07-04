using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.CargoFuncionarioDtos
{
    public class CargoFuncionarioEditDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; } = string.Empty;
    }
}
