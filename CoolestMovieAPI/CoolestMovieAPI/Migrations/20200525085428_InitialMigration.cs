using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolestMovieAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorName = table.Column<string>(nullable: true),
                    ActorBirthDate = table.Column<DateTime>(nullable: false),
                    ActorCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorID);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(nullable: true),
                    DirectorBirthDate = table.Column<DateTime>(nullable: false),
                    DirectorCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(nullable: true),
                    MovieLength = table.Column<TimeSpan>(nullable: false),
                    MovieRating = table.Column<double>(nullable: false),
                    MovieDescription = table.Column<string>(nullable: true),
                    MovieReleaseYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieActorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true),
                    MovieID = table.Column<int>(nullable: true),
                    ActorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => x.MovieActorID);
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ActorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    MovieDirectorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(nullable: true),
                    DirectorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => x.MovieDirectorID);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Directors_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Directors",
                        principalColumn: "DirectorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieGenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(nullable: true),
                    GenreID = table.Column<int>(nullable: true)
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
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    TrailerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailerUrl = table.Column<string>(nullable: true),
                    TrailerTitle = table.Column<string>(nullable: true),
                    MovieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.TrailerID);
                    table.ForeignKey(
                        name: "FK_Trailers_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorID", "DirectorBirthDate", "DirectorCountry", "DirectorName" },
                values: new object[,]
                {
                    { 1, new DateTime(1962, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "David Fincher" },
                    { 2, new DateTime(1939, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Francis Ford Coppola" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "MovieDescription", "MovieLength", "MovieRating", "MovieReleaseYear", "MovieTitle" },
                values: new object[,]
                {
                    { 1, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", new TimeSpan(0, 2, 10, 0, 0), 8.8000000000000007, 1999, "Fight Club" },
                    { 2, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", new TimeSpan(0, 2, 55, 0, 0), 9.1999999999999993, 1972, "Godfather" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorID",
                table: "MovieActors",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieID",
                table: "MovieActors",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_MovieID",
                table: "Trailers",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
