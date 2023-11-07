using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acesvv.Migrations
{
    public partial class ChaveADM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Chave_ADMId",
                table: "Dados",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Chave_ADM = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dados_Chave_ADMId",
                table: "Dados",
                column: "Chave_ADMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dados_UsuarioModel_Chave_ADMId",
                table: "Dados",
                column: "Chave_ADMId",
                principalTable: "UsuarioModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dados_UsuarioModel_Chave_ADMId",
                table: "Dados");

            migrationBuilder.DropTable(
                name: "UsuarioModel");

            migrationBuilder.DropIndex(
                name: "IX_Dados_Chave_ADMId",
                table: "Dados");

            migrationBuilder.DropColumn(
                name: "Chave_ADMId",
                table: "Dados");
        }
    }
}
