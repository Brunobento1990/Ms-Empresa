using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class ServicoExecutadoConfig : IEntityTypeConfiguration<ServicoExecutado>
    {
        public void Configure(EntityTypeBuilder<ServicoExecutado> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Preco).HasPrecision(14, 2);

            builder.HasOne(x => x.Funcionario)
                .WithMany(x => x.ServicosExecutados)
                .HasForeignKey(x => x.FuncionarioId);

            builder.HasOne(x => x.Servico)
                .WithMany(x => x.ServicosExecutados)
                .HasForeignKey(x => x.ServicoId);
        }
    }
}
