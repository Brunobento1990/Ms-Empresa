using Application.Dtos.FuncionarioDtos;
using Application.Dtos.ServicoDtos;

namespace Application.Dtos.ServicosExecutadosDtos
{
    public class ServicoExecutadoViewDto
    {
        public Guid Id { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public Guid ServicoId { get; set; }
        public ServicoViewDto Servico { get; set; } = null!;
        public Guid FuncionarioId { get; set; }
        public FuncionarioViewDto Funcionario { get; set; } = null!;
    }
}
