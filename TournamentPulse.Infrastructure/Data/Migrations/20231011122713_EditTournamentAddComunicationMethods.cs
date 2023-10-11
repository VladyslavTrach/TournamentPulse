using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPulse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTournamentAddComunicationMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCard",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tournaments");
        }
    }
}
