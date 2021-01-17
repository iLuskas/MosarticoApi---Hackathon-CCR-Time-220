using Microsoft.EntityFrameworkCore.Migrations;

namespace MosarticoApi.Infrastructure.Data.Migrations
{
    public partial class adjustmentTableOng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Cad_Ong",
                type: "TEXT",
                maxLength: 14,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Cad_Ong");
        }
    }
}
