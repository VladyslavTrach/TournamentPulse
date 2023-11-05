using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPulse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToFighter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Fighters",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Fighters");

        }
    }
}
