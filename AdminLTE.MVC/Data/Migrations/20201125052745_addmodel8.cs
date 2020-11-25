using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class addmodel8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    cusid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(nullable: false),
                    Last_Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CNIC = table.Column<string>(nullable: false),
                    mobileno = table.Column<int>(nullable: false),
                    state = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.cusid);
                });

            migrationBuilder.CreateTable(
                name: "tbllocation",
                columns: table => new
                {
                    locationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetNo = table.Column<string>(nullable: false),
                    streetAddress = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    stateabre = table.Column<string>(nullable: false),
                    state = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbllocation", x => x.locationId);
                });

            migrationBuilder.CreateTable(
                name: "tblReservation",
                columns: table => new
                {
                    resId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carId = table.Column<int>(nullable: false),
                    cusid = table.Column<int>(nullable: false),
                    Pick_location = table.Column<string>(nullable: true),
                    Pick_Date = table.Column<DateTime>(nullable: false),
                    Return_location = table.Column<string>(nullable: true),
                    Return_Date = table.Column<DateTime>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReservation", x => x.resId);
                    table.ForeignKey(
                        name: "FK_tblReservation_tblCars_carId",
                        column: x => x.carId,
                        principalTable: "tblCars",
                        principalColumn: "carId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReservation_tblCustomer_cusid",
                        column: x => x.cusid,
                        principalTable: "tblCustomer",
                        principalColumn: "cusid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPhone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNo = table.Column<string>(nullable: false),
                    locid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPhone_tbllocation_locid",
                        column: x => x.locid,
                        principalTable: "tbllocation",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPhone_locid",
                table: "tblPhone",
                column: "locid");

            migrationBuilder.CreateIndex(
                name: "IX_tblReservation_carId",
                table: "tblReservation",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReservation_cusid",
                table: "tblReservation",
                column: "cusid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPhone");

            migrationBuilder.DropTable(
                name: "tblReservation");

            migrationBuilder.DropTable(
                name: "tbllocation");

            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}
