using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class CargoFuncionarioConfig : IEntityTypeConfiguration<CargoFuncionario>
    {
        public void Configure(EntityTypeBuilder<CargoFuncionario> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Descricao).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.CargoFuncionario)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
