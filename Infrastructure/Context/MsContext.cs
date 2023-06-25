using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class MsContext : DbContext
    {
        public MsContext(DbContextOptions<MsContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ContatoEmpresa> ContatosEmpresas { get; set; }
        public DbSet<EnderecoEmpresa> EnderecosEmpresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<CargoFuncionario> CargosFuncionarios { get; set; }
        public DbSet<HistoricoPagamentoEmpresa> HistoricoPagamentosEmpresa { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoExecutado> ServicosExecutados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsContext).Assembly);
        }
    }
}
