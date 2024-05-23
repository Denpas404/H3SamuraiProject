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
                name: "Samurais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurais", x => x.Id);
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
                    { 2, "ShadowFax" },
                    { 3, "Black Beauty" },
                    { 4, "Silver" }
                });

            migrationBuilder.InsertData(
                table: "Samurais",
                columns: new[] { "Id", "Description", "HorseId", "Name" },
                values: new object[,]
                {
                    { 1, "A samurai warrior who has been sent to the future by the evil demon Aku", 1, "Samurai Jack" },
                    { 2, "Just another guy with sword.", 2, "DarkOne" },
                    { 3, "A wandering samurai with a heart of gold and a knack for getting into trouble", 3, "Ronin Ron" },
                    { 4, "A samurai who prefers lounging around to sword fighting, but still manages to get the job done", 4, "Lazy Blade Larry" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais",
                column: "HorseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samurais");

            migrationBuilder.DropTable(
                name: "Horses");
        }
    }
}
