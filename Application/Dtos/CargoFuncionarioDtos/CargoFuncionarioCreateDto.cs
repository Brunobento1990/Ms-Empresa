using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.CargoFuncionarioDtos
{
    public class CargoFuncionarioCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; } = string.Empty;
    }
}
