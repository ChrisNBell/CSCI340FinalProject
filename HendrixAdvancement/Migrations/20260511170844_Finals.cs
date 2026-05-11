using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HendrixAdvancement.Migrations
{
    /// <inheritdoc />
    public partial class Finals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Projects_ProjectID",
                table: "Opportunity");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Opportunity",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Projects_ProjectID",
                table: "Opportunity",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Projects_ProjectID",
                table: "Opportunity");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Opportunity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Projects_ProjectID",
                table: "Opportunity",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
