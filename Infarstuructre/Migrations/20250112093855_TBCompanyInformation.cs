using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBCompanyInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCompanyInformations",
                columns: table => new
                {
                    IdCompanyInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCompanyAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NameCompanyEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameOner = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PhoneOner = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailOner = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ShortDescriptionAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShortDescriptionEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AddressAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AddressEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FaceBoock = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YouTube = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Mabs = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCompanyInformations", x => x.IdCompanyInformation);
                });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCompanyInformations");
        }
    }
}
