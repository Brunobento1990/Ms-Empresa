using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class ServicoConfig : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Descricao).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Preco).HasPrecision(14, 2);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Servicos)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
