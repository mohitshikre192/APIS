using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIS.Migrations
{
    /// <inheritdoc />
    public partial class initialmg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    d_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    d_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    mobileno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    licenseno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.d_id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    r_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    distance = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.r_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    v_no = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    v_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    sitting_cap = table.Column<int>(type: "int", nullable: false),
                    v_type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    fare = table.Column<int>(type: "int", nullable: false),
                    d_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.v_no);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_d_id",
                        column: x => x.d_id,
                        principalTable: "Drivers",
                        principalColumn: "d_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    b_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    v_id = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Journey_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    r_id = table.Column<int>(type: "int", nullable: false),
                    drop_Point = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boarding_Point = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noofPassenger = table.Column<int>(type: "int", nullable: false),
                    bookingstatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.b_id);
                    table.ForeignKey(
                        name: "FK_Bookings_Routes_r_id",
                        column: x => x.r_id,
                        principalTable: "Routes",
                        principalColumn: "r_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_v_id",
                        column: x => x.v_id,
                        principalTable: "Vehicles",
                        principalColumn: "v_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_r_id",
                table: "Bookings",
                column: "r_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_v_id",
                table: "Bookings",
                column: "v_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_d_id",
                table: "Vehicles",
                column: "d_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
