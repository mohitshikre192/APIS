using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIS.Migrations
{
    /// <inheritdoc />
    public partial class l2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mobile_no",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "mobileno",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "UniqueIndex",
                table: "Users",
                column: "mobile_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UniqueIndexD",
                table: "Drivers",
                column: "mobileno",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueIndex",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UniqueIndexD",
                table: "Drivers");

            migrationBuilder.AlterColumn<string>(
                name: "mobile_no",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "mobileno",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
