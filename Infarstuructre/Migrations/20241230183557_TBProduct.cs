using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBProducts",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNameAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProductNameEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProducts", x => x.IdProduct);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBProducts");
        }
    }
}
