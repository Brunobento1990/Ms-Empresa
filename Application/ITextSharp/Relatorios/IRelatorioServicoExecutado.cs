using Application.Dtos.ServicosExecutadosDtos;

namespace Application.ITextSharp.Relatorios
{
    public interface IRelatorioServicoExecutado
    {
        byte[] GerarPdf(RelatorioDto relatorioDto);
    }
}
