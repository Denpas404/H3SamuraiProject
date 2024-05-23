using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace H3SamuraiProject.Repo.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clans",
                columns: new[] { "Id", "ClanDescription", "ClanLeaderId", "ClanName" },
                values: new object[,]
                {
                    { 1, "The Shogun Clan is the most powerful clan in the land.", 1, "Shogun" },
                    { 2, "The Ronin Clan is a group of masterless samurai.", 2, "Ronin" }
                });

            migrationBuilder.UpdateData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClanId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClanId",
                value: null);
        }
    }
}
