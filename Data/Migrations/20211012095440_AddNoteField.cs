using Microsoft.EntityFrameworkCore.Migrations;

namespace GruppoStoricoApp.Data.Migrations
{
    public partial class AddNoteField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Vestito",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Stivale",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Cintura",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Camicia",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Calzamaglia",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Vestito");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Stivale");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Cintura");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Camicia");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Calzamaglia");
        }
    }
}
