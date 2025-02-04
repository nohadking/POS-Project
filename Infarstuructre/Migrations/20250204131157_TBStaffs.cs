using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBStaffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBStaffs",
                columns: table => new
                {
                    IdStaff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFullname = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBStaffs", x => x.IdStaff);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBStaffs");
        }
    }
}
