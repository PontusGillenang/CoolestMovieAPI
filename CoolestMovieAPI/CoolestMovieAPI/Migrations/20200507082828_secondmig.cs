using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolestMovieAPI.Migrations
{
    public partial class secondmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Actors_ActorID",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieID",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailers",
                table: "Trailers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "MovieDirectors");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "MovieActors");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Actors");

            migrationBuilder.AddColumn<int>(
                name: "TrailerID",
                table: "Trailers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "TrailerTitle",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Length",
                table: "Movies",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieDirectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorID",
                table: "MovieDirectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieDirectorID",
                table: "MovieDirectors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieActors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorID",
                table: "MovieActors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieActorID",
                table: "MovieActors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Roll",
                table: "MovieActors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DirectorBirthDate",
                table: "Directors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DirectorCountry",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DirectorName",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActorBirthDate",
                table: "Actors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ActorCountry",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActorID",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ActorName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailers",
                table: "Trailers",
                column: "TrailerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors",
                column: "MovieDirectorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors",
                column: "MovieActorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "DirectorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ActorID");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieGenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: true),
                    GenreID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.MovieGenreID);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Description", "Genre", "Length", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 1, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "Drama", new TimeSpan(0, 2, 10, 0, 0), 8.8000000000000007, 1999, "Fight Club" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Description", "Genre", "Length", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 2, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Crime", new TimeSpan(0, 2, 55, 0, 0), 9.1999999999999993, 1972, "Godfather" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_MovieID",
                table: "MovieDirectors",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreID",
                table: "MovieGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieID",
                table: "MovieGenre",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Actors_ActorID",
                table: "MovieActors",
                column: "ActorID",
                principalTable: "Actors",
                principalColumn: "ActorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieID",
                table: "MovieActors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID",
                principalTable: "Directors",
                principalColumn: "DirectorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Actors_ActorID",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieID",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailers",
                table: "Trailers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors");

            migrationBuilder.DropIndex(
                name: "IX_MovieDirectors_MovieID",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TrailerID",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "TrailerTitle",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieDirectorID",
                table: "MovieDirectors");

            migrationBuilder.DropColumn(
                name: "MovieActorID",
                table: "MovieActors");

            migrationBuilder.DropColumn(
                name: "Roll",
                table: "MovieActors");

            migrationBuilder.DropColumn(
                name: "DirectorBirthDate",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DirectorCountry",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DirectorName",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "ActorBirthDate",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorCountry",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorID",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorName",
                table: "Actors");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Trailers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieDirectors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DirectorID",
                table: "MovieDirectors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "MovieDirectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieActors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorID",
                table: "MovieActors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "MovieActors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Directors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Actors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailers",
                table: "Trailers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors",
                columns: new[] { "MovieID", "DirectorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Actors_ActorID",
                table: "MovieActors",
                column: "ActorID",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieID",
                table: "MovieActors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieID",
                table: "MovieDirectors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
