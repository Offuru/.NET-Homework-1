using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Database.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gundams_Users_Id",
                table: "Gundams");

            migrationBuilder.AddForeignKey(
                name: "FK_Gundams_Users_Id",
                table: "Gundams",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gundams_Users_Id",
                table: "Gundams");

            migrationBuilder.AddForeignKey(
                name: "FK_Gundams_Users_Id",
                table: "Gundams",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
