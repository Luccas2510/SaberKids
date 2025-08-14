using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaberKids.Migrations
{
    /// <inheritdoc />
    public partial class Pagamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartaoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCartao = table.Column<int>(type: "int", nullable: false),
                    TipoCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BandeiraCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVenci = table.Column<DateOnly>(type: "date", nullable: false),
                    CodeCartao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartoesPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoId = table.Column<int>(type: "int", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartoesPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartoesPagamentos_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartoesPagamentos_Pagamentos_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CartaoId",
                table: "Usuarios",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CartoesPagamentos_CartaoId",
                table: "CartoesPagamentos",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CartoesPagamentos_PagamentoId",
                table: "CartoesPagamentos",
                column: "PagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cartoes_CartaoId",
                table: "Usuarios",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cartoes_CartaoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "CartoesPagamentos");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CartaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CartaoId",
                table: "Usuarios");
        }
    }
}
