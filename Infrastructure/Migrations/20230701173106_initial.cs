using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RazaoSocial = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeFantasia = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Setor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InscricaoEstadual = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PagamentoEmDia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CargosFuncionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosFuncionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargosFuncionarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContatosEmpresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ddd = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatosEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnderecosEmpresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecosEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistoricoPagamentosEmpresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorPagamento = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    FormaDePagamento = table.Column<int>(type: "int", nullable: false),
                    StatusPagamento = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoPagamentosEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoPagamentosEmpresa_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailVerificado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CodigoEmailFerificado = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Adicionar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Editar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Excluir = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AcessoAoSistema = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Master = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CargoFuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_CargosFuncionarios_CargoFuncionarioId",
                        column: x => x.CargoFuncionarioId,
                        principalTable: "CargosFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicosExecutados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Preco = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServicoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDeExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosExecutados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicosExecutados_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosExecutados_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CargosFuncionarios_EmpresaId",
                table: "CargosFuncionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatosEmpresas_EmpresaId",
                table: "ContatosEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosEmpresas_EmpresaId",
                table: "EnderecosEmpresas",
                column: "EmpresaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoFuncionarioId",
                table: "Funcionarios",
                column: "CargoFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPagamentosEmpresa_EmpresaId",
                table: "HistoricoPagamentosEmpresa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EmpresaId",
                table: "Servicos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosExecutados_FuncionarioId",
                table: "ServicosExecutados",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosExecutados_ServicoId",
                table: "ServicosExecutados",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatosEmpresas");

            migrationBuilder.DropTable(
                name: "EnderecosEmpresas");

            migrationBuilder.DropTable(
                name: "HistoricoPagamentosEmpresa");

            migrationBuilder.DropTable(
                name: "ServicosExecutados");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "CargosFuncionarios");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
