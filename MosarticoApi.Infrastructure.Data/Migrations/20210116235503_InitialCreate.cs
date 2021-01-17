using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MosarticoApi.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cad_Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cad_TipoArte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_TipoArte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cad_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PerfilId = table.Column<int>(type: "INTEGER", nullable: false),
                    CpfCnpj = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Foto = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cad_Usuario_Cad_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Cad_Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cad_Arte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DataCricao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipoArteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Arte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cad_Arte_Cad_TipoArte_TipoArteId",
                        column: x => x.TipoArteId,
                        principalTable: "Cad_TipoArte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cad_Arte_Cad_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Cad_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cad_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pais_end = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Estado_end = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Cidade_end = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Bairro_end = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Rua_end = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Numero_end = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Cep_end = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cad_Endereco_Cad_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Cad_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cad_Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ddd_tel = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    Telefone_tel = table.Column<string>(type: "TEXT", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cad_Telefone_Cad_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Cad_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemArtes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemArtes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemArtes_Cad_Arte_ArteId",
                        column: x => x.ArteId,
                        principalTable: "Cad_Arte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cad_Perfil",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1, "Membro" });

            migrationBuilder.InsertData(
                table: "Cad_Perfil",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2, "Artísta" });

            migrationBuilder.InsertData(
                table: "Cad_Perfil",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 3, "Empresa" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1, "Música" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2, "Dança" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 3, "Pintura" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 4, "Escultura" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 5, "Teatro" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 6, "Literatura" });

            migrationBuilder.InsertData(
                table: "Cad_TipoArte",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 7, "Cinema" });

            migrationBuilder.CreateIndex(
                name: "IX_Cad_Arte_TipoArteId",
                table: "Cad_Arte",
                column: "TipoArteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cad_Arte_UsuarioId",
                table: "Cad_Arte",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cad_Endereco_UsuarioId",
                table: "Cad_Endereco",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cad_Telefone_UsuarioId",
                table: "Cad_Telefone",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cad_Usuario_PerfilId",
                table: "Cad_Usuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemArtes_ArteId",
                table: "ImagemArtes",
                column: "ArteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cad_Endereco");

            migrationBuilder.DropTable(
                name: "Cad_Telefone");

            migrationBuilder.DropTable(
                name: "ImagemArtes");

            migrationBuilder.DropTable(
                name: "Cad_Arte");

            migrationBuilder.DropTable(
                name: "Cad_TipoArte");

            migrationBuilder.DropTable(
                name: "Cad_Usuario");

            migrationBuilder.DropTable(
                name: "Cad_Perfil");
        }
    }
}
