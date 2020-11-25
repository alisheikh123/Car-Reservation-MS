using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class addmodel7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCars",
                columns: table => new
                {
                    carId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    Model_No = table.Column<string>(nullable: true),
                    Brand_Name = table.Column<string>(nullable: true),
                    purchase_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCars", x => x.carId);
                    table.ForeignKey(
                        name: "FK_tblCars_tblCategories_catId",
                        column: x => x.catId,
                        principalTable: "tblCategories",
                        principalColumn: "catId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCars_catId",
                table: "tblCars",
                column: "catId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCars");
        }
    }
}
