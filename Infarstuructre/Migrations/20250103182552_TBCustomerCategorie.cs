using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBCustomerCategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCustomerCategories",
                columns: table => new
                {
                    IdCustomerCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryNameAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryNameEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCustomerCategories", x => x.IdCustomerCategorie);
                });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCustomerCategories");
        }
    }
}
