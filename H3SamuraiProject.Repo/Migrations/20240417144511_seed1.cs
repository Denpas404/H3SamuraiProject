using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace H3SamuraiProject.Repo.Migrations
{
    /// <inheritdoc />
    public partial class seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "Age", "Description", "HorseId", "Name" },
                values: new object[,]
                {
                    { 1, 25, "A samurai warrior who has been sent to the future by an evil demon named Aku.", 1, "Samurai Jack" },
                    { 2, 15, "Just another guy with sword.", 2, "DarkOne" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
