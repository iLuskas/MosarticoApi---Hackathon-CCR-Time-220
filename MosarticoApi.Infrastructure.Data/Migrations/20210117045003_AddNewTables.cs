using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MosarticoApi.Infrastructure.Data.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cad_Ong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Ong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cad_Oficiona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OngId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Link = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cad_Oficiona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cad_Oficiona_Cad_Ong_OngId",
                        column: x => x.OngId,
                        principalTable: "Cad_Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemOngs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OngId = table.Column<int>(type: "INTEGER", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemOngs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemOngs_Cad_Ong_OngId",
                        column: x => x.OngId,
                        principalTable: "Cad_Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemOficinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OficinasId = table.Column<int>(type: "INTEGER", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemOficinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemOficinas_Cad_Oficiona_OficinasId",
                        column: x => x.OficinasId,
                        principalTable: "Cad_Oficiona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioOficina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    OficinasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOficina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioOficina_Cad_Oficiona_OficinasId",
                        column: x => x.OficinasId,
                        principalTable: "Cad_Oficiona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOficina_Cad_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Cad_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cad_Oficiona_OngId",
                table: "Cad_Oficiona",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemOficinas_OficinasId",
                table: "ImagemOficinas",
                column: "OficinasId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemOngs_OngId",
                table: "ImagemOngs",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOficina_OficinasId",
                table: "UsuarioOficina",
                column: "OficinasId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOficina_UsuarioID",
                table: "UsuarioOficina",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagemOficinas");

            migrationBuilder.DropTable(
                name: "ImagemOngs");

            migrationBuilder.DropTable(
                name: "UsuarioOficina");

            migrationBuilder.DropTable(
                name: "Cad_Oficiona");

            migrationBuilder.DropTable(
                name: "Cad_Ong");
        }
    }
}
