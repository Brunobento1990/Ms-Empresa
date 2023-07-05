﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MsContext))]
    partial class MsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.CargoFuncionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("CargosFuncionarios");
                });

            modelBuilder.Entity("Domain.Entities.ContatoEmpresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ddd")
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("ContatosEmpresas");
                });

            modelBuilder.Entity("Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InscricaoEstadual")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("InscricaoMunicipal")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("PagamentoEmDia")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Setor")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Domain.Entities.EnderecoEmpresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId")
                        .IsUnique();

                    b.ToTable("EnderecosEmpresas");
                });

            modelBuilder.Entity("Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("AcessoAoSistema")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Adicionar")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("CargoFuncionarioId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CodigoEmailFerificado")
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Editar")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("EmailVerificado")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Excluir")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Master")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CargoFuncionarioId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Domain.Entities.HistoricoPagamentoEmpresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<int>("FormaDePagamento")
                        .HasColumnType("int");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorPagamento")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("HistoricoPagamentosEmpresa");
                });

            modelBuilder.Entity("Domain.Entities.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Domain.Entities.ServicoExecutado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("Quantidade")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<Guid>("ServicoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicosExecutados");
                });

            modelBuilder.Entity("Domain.Entities.CargoFuncionario", b =>
                {
                    b.HasOne("Domain.Entities.Empresa", "Empresa")
                        .WithMany("CargoFuncionario")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Entities.ContatoEmpresa", b =>
                {
                    b.HasOne("Domain.Entities.Empresa", "Empresa")
                        .WithMany("ContatosEmpresa")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Entities.EnderecoEmpresa", b =>
                {
                    b.HasOne("Domain.Entities.Empresa", "Empresa")
                        .WithOne("EnderecoEmpresa")
                        .HasForeignKey("Domain.Entities.EnderecoEmpresa", "EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("Domain.Entities.CargoFuncionario", "CargoFuncionario")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoFuncionarioId");

                    b.HasOne("Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoFuncionario");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Entities.HistoricoPagamentoEmpresa", b =>
                {
                    b.HasOne("Domain.Entities.Empresa", "Empresa")
                        .WithMany("HistoricoPagamentosEmpresa")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Entities.Servico", b =>
                {
                    b.HasOne("Domain.Entities.Empresa", "Empresa")
                        .WithMany("Servicos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Entities.ServicoExecutado", b =>
                {
                    b.HasOne("Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("ServicosExecutados")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Servico", "Servico")
                        .WithMany("ServicosExecutados")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Domain.Entities.CargoFuncionario", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("Domain.Entities.Empresa", b =>
                {
                    b.Navigation("CargoFuncionario");

                    b.Navigation("ContatosEmpresa");

                    b.Navigation("EnderecoEmpresa")
                        .IsRequired();

                    b.Navigation("Funcionarios");

                    b.Navigation("HistoricoPagamentosEmpresa");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Domain.Entities.Funcionario", b =>
                {
                    b.Navigation("ServicosExecutados");
                });

            modelBuilder.Entity("Domain.Entities.Servico", b =>
                {
                    b.Navigation("ServicosExecutados");
                });
#pragma warning restore 612, 618
        }
    }
}
