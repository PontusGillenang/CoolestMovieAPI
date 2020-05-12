using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolestMovieAPI.Migrations
{
    public partial class testas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieDirectors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieDirectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
