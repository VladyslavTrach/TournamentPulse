using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPulse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Academies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociationId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Academies_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Academies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeightClassId = table.Column<int>(type: "int", nullable: false),
                    RankClassId = table.Column<int>(type: "int", nullable: false),
                    AgeClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AgeClasses_AgeClassId",
                        column: x => x.AgeClassId,
                        principalTable: "AgeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_RankClasses_RankClassId",
                        column: x => x.RankClassId,
                        principalTable: "RankClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_WeightClasses_WeightClassId",
                        column: x => x.WeightClassId,
                        principalTable: "WeightClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeightClassId = table.Column<int>(type: "int", nullable: false),
                    RankClassId = table.Column<int>(type: "int", nullable: false),
                    AgeClassId = table.Column<int>(type: "int", nullable: false),
                    AcademyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fighters_Academies_AcademyId",
                        column: x => x.AcademyId,
                        principalTable: "Academies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fighters_AgeClasses_AgeClassId",
                        column: x => x.AgeClassId,
                        principalTable: "AgeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fighters_RankClasses_RankClassId",
                        column: x => x.RankClassId,
                        principalTable: "RankClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fighters_WeightClasses_WeightClassId",
                        column: x => x.WeightClassId,
                        principalTable: "WeightClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Academies_AssociationId",
                table: "Academies",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Academies_CountryId",
                table: "Academies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AgeClassId",
                table: "Categories",
                column: "AgeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RankClassId",
                table: "Categories",
                column: "RankClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WeightClassId",
                table: "Categories",
                column: "WeightClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterCategories_CategoryId",
                table: "FighterCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_AcademyId",
                table: "Fighters",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_AgeClassId",
                table: "Fighters",
                column: "AgeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_RankClassId",
                table: "Fighters",
                column: "RankClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_WeightClassId",
                table: "Fighters",
                column: "WeightClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FighterCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fighters");

            migrationBuilder.DropTable(
                name: "Academies");

            migrationBuilder.DropTable(
                name: "AgeClasses");

            migrationBuilder.DropTable(
                name: "RankClasses");

            migrationBuilder.DropTable(
                name: "WeightClasses");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
