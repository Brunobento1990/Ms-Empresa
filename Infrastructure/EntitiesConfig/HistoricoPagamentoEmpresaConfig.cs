using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesConfig
{
    public class HistoricoPagamentoEmpresaConfig : IEntityTypeConfiguration<HistoricoPagamentoEmpresa>
    {
        public void Configure(EntityTypeBuilder<HistoricoPagamentoEmpresa> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.StatusPagamento);
            builder.Property(e => e.FormaDePagamento);
            builder.Property(e => e.ValorPagamento).HasPrecision(14,2);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.HistoricoPagamentosEmpresa)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
