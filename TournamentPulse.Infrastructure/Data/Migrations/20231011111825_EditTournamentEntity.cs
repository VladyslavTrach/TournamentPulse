using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPulse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTournamentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Tournaments");
        }
    }
}
