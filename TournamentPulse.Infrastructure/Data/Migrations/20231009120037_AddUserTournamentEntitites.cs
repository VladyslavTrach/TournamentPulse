using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPulse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTournamentEntitites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AgeClasses_AgeClassId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_RankClasses_RankClassId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_WeightClasses_WeightClassId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Academies_AcademyId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_AgeClasses_AgeClassId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_RankClasses_RankClassId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_WeightClasses_WeightClassId",
                table: "Fighters");

            migrationBuilder.DropTable(
                name: "FighterCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Fighters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Fighters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Fighters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FighterCategoryTournaments",
                columns: table => new
                {
                    FighterId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterCategoryTournaments", x => new { x.FighterId, x.CategoryId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_FighterCategoryTournaments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FighterCategoryTournaments_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FighterCategoryTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_CategoryId",
                table: "Fighters",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_TournamentId",
                table: "Fighters",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_UserId",
                table: "Fighters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterCategoryTournaments_CategoryId",
                table: "FighterCategoryTournaments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterCategoryTournaments_TournamentId",
                table: "FighterCategoryTournaments",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AgeClasses_AgeClassId",
                table: "Categories",
                column: "AgeClassId",
                principalTable: "AgeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_RankClasses_RankClassId",
                table: "Categories",
                column: "RankClassId",
                principalTable: "RankClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_WeightClasses_WeightClassId",
                table: "Categories",
                column: "WeightClassId",
                principalTable: "WeightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Academies_AcademyId",
                table: "Fighters",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_AgeClasses_AgeClassId",
                table: "Fighters",
                column: "AgeClassId",
                principalTable: "AgeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Categories_CategoryId",
                table: "Fighters",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_RankClasses_RankClassId",
                table: "Fighters",
                column: "RankClassId",
                principalTable: "RankClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Tournaments_TournamentId",
                table: "Fighters",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Users_UserId",
                table: "Fighters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_WeightClasses_WeightClassId",
                table: "Fighters",
                column: "WeightClassId",
                principalTable: "WeightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AgeClasses_AgeClassId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_RankClasses_RankClassId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_WeightClasses_WeightClassId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Academies_AcademyId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_AgeClasses_AgeClassId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Categories_CategoryId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_RankClasses_RankClassId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Tournaments_TournamentId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Users_UserId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_WeightClasses_WeightClassId",
                table: "Fighters");

            migrationBuilder.DropTable(
                name: "FighterCategoryTournaments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Fighters_CategoryId",
                table: "Fighters");

            migrationBuilder.DropIndex(
                name: "IX_Fighters_TournamentId",
                table: "Fighters");

            migrationBuilder.DropIndex(
                name: "IX_Fighters_UserId",
                table: "Fighters");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Fighters");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Fighters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fighters");

            migrationBuilder.CreateTable(
                name: "FighterCategories",
                columns: table => new
                {
                    FighterId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterCategories", x => new { x.FighterId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_FighterCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FighterCategories_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FighterCategories_CategoryId",
                table: "FighterCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AgeClasses_AgeClassId",
                table: "Categories",
                column: "AgeClassId",
                principalTable: "AgeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_RankClasses_RankClassId",
                table: "Categories",
                column: "RankClassId",
                principalTable: "RankClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_WeightClasses_WeightClassId",
                table: "Categories",
                column: "WeightClassId",
                principalTable: "WeightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Academies_AcademyId",
                table: "Fighters",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_AgeClasses_AgeClassId",
                table: "Fighters",
                column: "AgeClassId",
                principalTable: "AgeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_RankClasses_RankClassId",
                table: "Fighters",
                column: "RankClassId",
                principalTable: "RankClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_WeightClasses_WeightClassId",
                table: "Fighters",
                column: "WeightClassId",
                principalTable: "WeightClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
