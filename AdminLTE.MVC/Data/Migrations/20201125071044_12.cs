using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblCars");

            migrationBuilder.AddColumn<string>(
                name: "Car",
                table: "tblCars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Car",
                table: "tblCars");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblCars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
