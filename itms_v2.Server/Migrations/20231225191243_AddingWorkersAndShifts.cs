using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itms_v2.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddingWorkersAndShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dispatcherId = table.Column<int>(type: "int", nullable: false),
                    startDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Users_dispatcherId",
                        column: x => x.dispatcherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    truckId = table.Column<int>(type: "int", nullable: false),
                    trailerId = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workers_Trailers_trailerId",
                        column: x => x.trailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_TruckDrivers_driverId",
                        column: x => x.driverId,
                        principalTable: "TruckDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Trucks_truckId",
                        column: x => x.truckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_dispatcherId",
                table: "Shifts",
                column: "dispatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_driverId",
                table: "Workers",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ShiftId",
                table: "Workers",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_trailerId",
                table: "Workers",
                column: "trailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_truckId",
                table: "Workers",
                column: "truckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
