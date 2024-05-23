using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace H3SamuraiProject.Repo.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClanDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClanLeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samurais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HorseId = table.Column<int>(type: "int", nullable: true),
                    ClanId = table.Column<int>(type: "int", nullable: true),
                    ClansId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samurais_Clans_ClansId",
                        column: x => x.ClansId,
                        principalTable: "Clans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Samurais_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Horses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red Hare" },
                    { 2, "ShadowFax" }
                });

            migrationBuilder.InsertData(
                table: "Samurais",
                columns: new[] { "Id", "Age", "ClanId", "ClansId", "Description", "HorseId", "Name" },
                values: new object[,]
                {
                    { 1, 25, null, null, "A samurai warrior who has been sent to the future by an evil demon named Aku.", 1, "Samurai Jack" },
                    { 2, 15, null, null, "Just another guy with sword.", 2, "DarkOne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clans_ClanLeaderId",
                table: "Clans",
                column: "ClanLeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_ClansId",
                table: "Samurais",
                column: "ClansId");

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais",
                column: "HorseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clans_Samurais_ClanLeaderId",
                table: "Clans",
                column: "ClanLeaderId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clans_Samurais_ClanLeaderId",
                table: "Clans");

            migrationBuilder.DropTable(
                name: "Samurais");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropTable(
                name: "Horses");
        }
    }
}
