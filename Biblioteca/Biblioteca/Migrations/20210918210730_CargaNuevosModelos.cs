using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class CargaNuevosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BibliotecaId",
                table: "Copias",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibrosPrestamo = table.Column<int>(nullable: false),
                    Multa = table.Column<DateTime>(nullable: false),
                    Copias = table.Column<string>(nullable: true),
                    BibliotecaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectors_Bibliotecas_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "Bibliotecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Copias_BibliotecaId",
                table: "Copias",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectors_BibliotecaId",
                table: "Lectors",
                column: "BibliotecaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copias_Bibliotecas_BibliotecaId",
                table: "Copias",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copias_Bibliotecas_BibliotecaId",
                table: "Copias");

            migrationBuilder.DropTable(
                name: "Lectors");

            migrationBuilder.DropTable(
                name: "Bibliotecas");

            migrationBuilder.DropIndex(
                name: "IX_Copias_BibliotecaId",
                table: "Copias");

            migrationBuilder.DropColumn(
                name: "BibliotecaId",
                table: "Copias");
        }
    }
}
