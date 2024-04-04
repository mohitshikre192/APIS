using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIS.Migrations
{
    /// <inheritdoc />
    public partial class i4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Drivers_d_id",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_d_id",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "d_id",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "d_id",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_d_id",
                table: "Vehicles",
                column: "d_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Drivers_d_id",
                table: "Vehicles",
                column: "d_id",
                principalTable: "Drivers",
                principalColumn: "d_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
