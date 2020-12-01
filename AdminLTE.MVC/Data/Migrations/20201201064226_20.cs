using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    country_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.country_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblState",
                columns: table => new
                {
                    state_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_Id = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblState", x => x.state_Id);
                    table.ForeignKey(
                        name: "FK_tblState_tblCountry_country_Id",
                        column: x => x.country_Id,
                        principalTable: "tblCountry",
                        principalColumn: "country_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCity",
                columns: table => new
                {
                    city_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state_Id = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCity", x => x.city_Id);
                    table.ForeignKey(
                        name: "FK_tblCity_tblState_state_Id",
                        column: x => x.state_Id,
                        principalTable: "tblState",
                        principalColumn: "state_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCity_state_Id",
                table: "tblCity",
                column: "state_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblState_country_Id",
                table: "tblState",
                column: "country_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCity");

            migrationBuilder.DropTable(
                name: "tblState");

            migrationBuilder.DropTable(
                name: "tblCountry");
        }
    }
}
