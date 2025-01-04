using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBInvoseHeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBInvoseHeders",
                columns: table => new
                {
                    IdInvoseHeder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    DateInvos = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    OutstandingBill = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBInvoseHeders", x => x.IdInvoseHeder);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBInvoseHeders");
        }
    }
}
