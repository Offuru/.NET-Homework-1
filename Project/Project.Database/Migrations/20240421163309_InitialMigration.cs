using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gundams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: false),
                    Scale = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gundams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gundams_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gundams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
