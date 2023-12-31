﻿namespace Application.Dtos.ServicosExecutadosDtos
{
    public class ServicoExecutadoViewDto
    {
        public Guid Id { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string NomeFuncionario { get; set; } = string.Empty;
        public string DescricaoServico { get; set; } = string.Empty;
    }
}
