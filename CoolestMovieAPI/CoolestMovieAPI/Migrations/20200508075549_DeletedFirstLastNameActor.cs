using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolestMovieAPI.Migrations
{
    public partial class DeletedFirstLastNameActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorFirstName",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorLastName",
                table: "Actors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActorFirstName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActorLastName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
