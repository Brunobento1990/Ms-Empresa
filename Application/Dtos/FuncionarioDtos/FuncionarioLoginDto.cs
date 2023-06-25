using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.FuncionarioDtos
{
    public class FuncionarioLoginDto
    {
        [Required(ErrorMessage = "E-mail inválido.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Senha inválida.")]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string Senha { get; set; } = string.Empty;
    }
}
