using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class forweb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAboutSectionStartHomeContents",
                columns: table => new
                {
                    IdAboutSectionStartHomeContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOneAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleOneEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoAr = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    TitleTwoEn = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAboutSectionStartHomeContents", x => x.IdAboutSectionStartHomeContent);
                });

            migrationBuilder.CreateTable(
                name: "TBBrandProducts",
                columns: table => new
                {
                    IdBrandProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitelOneAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitelOneEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    URlButtonEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    URlButtonAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBBrandProducts", x => x.IdBrandProduct);
                });

            migrationBuilder.CreateTable(
                name: "TBCategoryServics",
                columns: table => new
                {
                    IdCategoryServic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOneAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleOneEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleThreAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleThreEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleForAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleForEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitlefiveAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitlefiveEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleButtonAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleButtonEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UrlButtonAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UrlButtonEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategoryServics", x => x.IdCategoryServic);
                });

            migrationBuilder.CreateTable(
                name: "TBHomeSliderContents",
                columns: table => new
                {
                    IdHomeSliderContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOneAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleOneEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleButtonAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleButtonEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UrlButtonAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UrlButtonEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBHomeSliderContents", x => x.IdHomeSliderContent);
                });

            migrationBuilder.CreateTable(
                name: "TBPhotoHomeSliderContents",
                columns: table => new
                {
                    IdPhotoHomeSliderContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHomeSliderContent = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPhotoHomeSliderContents", x => x.IdPhotoHomeSliderContent);
                });

            migrationBuilder.CreateTable(
                name: "TBServiceSectionStartHomeContents",
                columns: table => new
                {
                    IServiceSectionStartContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOneAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleOneEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleTwoEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleThreAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleThreEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleForAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleForEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitlefiveAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitlefiveEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitlesixAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitlesixEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleSevenAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleSevenEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleEightAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleEightEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBServiceSectionStartHomeContents", x => x.IServiceSectionStartContent);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAboutSectionStartHomeContents");

            migrationBuilder.DropTable(
                name: "TBBrandProducts");

            migrationBuilder.DropTable(
                name: "TBCategoryServics");

            migrationBuilder.DropTable(
                name: "TBHomeSliderContents");

            migrationBuilder.DropTable(
                name: "TBPhotoHomeSliderContents");

            migrationBuilder.DropTable(
                name: "TBServiceSectionStartHomeContents");
        }
    }
}
