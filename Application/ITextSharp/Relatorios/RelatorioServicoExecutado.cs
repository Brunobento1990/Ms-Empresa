using Application.Dtos.ServicosExecutadosDtos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;

namespace Application.ITextSharp.Relatorios
{
    public class RelatorioServicoExecutado : IRelatorioServicoExecutado
    {
        public byte[] GerarPdf(RelatorioDto relatorioDto)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    var celulas = new List<string>
                    {
                        "Data",
                        "Funcionário",
                        "Serviço",
                        "Quantidade",
                        "Preço"
                    };

                    CultureInfo cultureInfo = new CultureInfo("pt-BR");

                    NumberFormatInfo formato = new NumberFormatInfo();
                    formato.NumberDecimalSeparator = ",";
                    formato.NumberGroupSeparator = ".";
                    formato.NumberDecimalDigits = 2;

                    var font = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                    var fontCabecalho = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    float border = 0.5f;

                    var document = new Document(PageSize.A4);
                    document.SetMargins(15f, 15f, 15f, 20f);

                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    var table = new PdfPTable(1);
                    table.PaddingTop = 0;
                    table.DefaultCell.FixedHeight = 100;
                    table.WidthPercentage = 100;

                    var cellEmpresa = new PdfPCell(new Phrase($" \n Empresa : {relatorioDto.NomeEmpresa} \n\n\n\n\n CNPJ : {relatorioDto.CnpjEmpresa} \n ", fontCabecalho));
                    table.AddCell(cellEmpresa);

                    var tableCabecalhoProdutos = new PdfPTable(celulas.Count());
                    tableCabecalhoProdutos.DefaultCell.FixedHeight = 15;
                    tableCabecalhoProdutos.WidthPercentage = 100;

                    float[] columnWidths = new float[celulas.Count()];

                    for (int i = 0; i < celulas.Count(); i++)
                    {
                        var newCell = new PdfPCell(new Phrase(celulas.ElementAt(i), font));

                        newCell.HorizontalAlignment = 0;
                        newCell.VerticalAlignment = 1;
                        newCell.BorderWidth = 0;
                        newCell.BorderWidthBottom = border;
                        columnWidths[i] = 20f;
                        tableCabecalhoProdutos.AddCell(newCell);
                    }

                    tableCabecalhoProdutos.SetWidths(columnWidths);

                    var tableDadosProdutos = new PdfPTable(celulas.Count());
                    tableDadosProdutos.DefaultCell.FixedHeight = 15;
                    tableDadosProdutos.WidthPercentage = 100;

                    var contador = 0;

                    decimal quantidadeTotal = 0;
                    decimal vlrTotalPedido = 0;

                    foreach (var itens in relatorioDto.ItensRelatorioDtos)
                    {
                        quantidadeTotal += Math.Round(itens.Quantidade, 2);
                        vlrTotalPedido += Math.Round(itens.Preco, 2);

                        var data = new PdfPCell(new Phrase(itens.DataPrestacao.ToString("dd/MM/yyyy HH:mm:ss"), font));
                        var funcionario = new PdfPCell(new Phrase(itens.NomeFuncionario, font));
                        var servico = new PdfPCell(new Phrase(itens.DescricaoServico, font));
                        var quantidade = new PdfPCell(new Phrase(itens.Quantidade.ToString("N", formato), font));
                        var preco = new PdfPCell(new Phrase(itens.Preco.ToString("C", cultureInfo), font));


                        funcionario.BorderWidth = 0;
                        servico.BorderWidth = 0;
                        quantidade.BorderWidth = 0;
                        preco.BorderWidth = 0;
                        data.BorderWidth = 0;

                        if(contador == (relatorioDto.ItensRelatorioDtos.Count - 1))
                        {
                            funcionario.CellEvent = new BottomBorder();
                            servico.CellEvent = new BottomBorder();
                            quantidade.CellEvent = new BottomBorder();
                            preco.CellEvent = new BottomBorder();
                            data.CellEvent = new BottomBorder();
                        }

                        tableDadosProdutos.AddCell(data);
                        tableDadosProdutos.AddCell(funcionario);
                        tableDadosProdutos.AddCell(servico);
                        tableDadosProdutos.AddCell(quantidade);
                        tableDadosProdutos.AddCell(preco);

                        contador++;

                    }

                    tableDadosProdutos.SetWidths(columnWidths);

                    var eventHelper = new CustomPageEventHandler();
                    writer.PageEvent = eventHelper;

                    var tableTotalizacao = new PdfPTable(2);
                    tableTotalizacao.DefaultCell.FixedHeight = 15;
                    tableTotalizacao.WidthPercentage = 50;
                    tableTotalizacao.HorizontalAlignment = Element.ALIGN_RIGHT;

                    var cellQtdTotal = new PdfPCell(new Phrase($" Total :  {quantidadeTotal.ToString("N", formato)}", fontCabecalho));
                    cellQtdTotal.BorderWidth = 0;
                    cellQtdTotal.PaddingLeft = 20;
                    cellQtdTotal.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    var cellTotal = new PdfPCell(new Phrase($" {vlrTotalPedido.ToString("C", cultureInfo)}", fontCabecalho));
                    cellTotal.BorderWidth = 0;
                    cellTotal.PaddingRight = 70;
                    cellTotal.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    tableTotalizacao.AddCell(cellQtdTotal);
                    tableTotalizacao.AddCell(cellTotal);

                    document.Open();

                    document.Add(table);
                    document.Add(tableCabecalhoProdutos);
                    document.Add(tableDadosProdutos);
                    document.Add(tableTotalizacao);

                    document.Close();

                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
