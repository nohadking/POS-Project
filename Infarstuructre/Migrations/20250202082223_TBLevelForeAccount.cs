using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBLevelForeAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLevelForeAccounts",
                columns: table => new
                {
                    IdLevelForeAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLevelThreeAccount = table.Column<int>(type: "int", nullable: false),
                    IdLevelTwoAccount = table.Column<int>(type: "int", nullable: false),
                    IdMainAccount = table.Column<int>(type: "int", nullable: false),
                    NumberAccount = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLevelForeAccounts", x => x.IdLevelForeAccount);
                });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLevelForeAccounts");
        }
    }
}
