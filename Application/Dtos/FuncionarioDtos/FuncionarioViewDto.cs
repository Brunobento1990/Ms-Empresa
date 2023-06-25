namespace Application.Dtos.FuncionarioDtos
{
    public class FuncionarioViewDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
