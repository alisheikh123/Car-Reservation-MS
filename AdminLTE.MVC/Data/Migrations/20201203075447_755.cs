using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class _755 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "state",
                table: "tblCustomer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "country",
                table: "tblCustomer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "city",
                table: "tblCustomer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_city",
                table: "tblCustomer",
                column: "city");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomer_tblCity_city",
                table: "tblCustomer",
                column: "city",
                principalTable: "tblCity",
                principalColumn: "city_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomer_tblCity_city",
                table: "tblCustomer");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomer_city",
                table: "tblCustomer");

            migrationBuilder.DropColumn(
                name: "city",
                table: "tblCustomer");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "tblCustomer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "tblCustomer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
