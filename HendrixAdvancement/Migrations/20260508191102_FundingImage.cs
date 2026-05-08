using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HendrixAdvancement.Migrations
{
    /// <inheritdoc />
    public partial class FundingImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Funded",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funded",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Projects");
        }
    }
}
