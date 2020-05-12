using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolestMovieAPI.Migrations
{
    public partial class addedGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorID", "DirectorBirthDate", "DirectorCountry", "DirectorName" },
                values: new object[] { 1, new DateTime(1962, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "David Fincher" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorID", "DirectorBirthDate", "DirectorCountry", "DirectorName" },
                values: new object[] { 2, new DateTime(1939, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Francis Ford Coppola" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "DirectorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "DirectorID",
                keyValue: 2);
        }
    }
}
