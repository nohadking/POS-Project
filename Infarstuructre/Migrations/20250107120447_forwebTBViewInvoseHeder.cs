using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class forwebTBViewInvoseHeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCustomerCategorie",
                table: "TBInvoseHeders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCustomerCategorie",
                table: "TBInvoseHeders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
