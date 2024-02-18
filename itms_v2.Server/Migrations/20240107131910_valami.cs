using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itms_v2.Server.Migrations
{
    /// <inheritdoc />
    public partial class valami : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dispatcher",
                table: "Shifts",
                newName: "dispatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_driverId",
                table: "Workers",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_trailerId",
                table: "Workers",
                column: "trailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_truckId",
                table: "Workers",
                column: "truckId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_dispatcherId",
                table: "Shifts",
                column: "dispatcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_dispatcherId",
                table: "Shifts",
                column: "dispatcherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Trailers_trailerId",
                table: "Workers",
                column: "trailerId",
                principalTable: "Trailers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_TruckDrivers_driverId",
                table: "Workers",
                column: "driverId",
                principalTable: "TruckDrivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Trucks_truckId",
                table: "Workers",
                column: "truckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Users_dispatcherId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Trailers_trailerId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_TruckDrivers_driverId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Trucks_truckId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_driverId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_trailerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_truckId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_dispatcherId",
                table: "Shifts");

            migrationBuilder.RenameColumn(
                name: "dispatcherId",
                table: "Shifts",
                newName: "dispatcher");
        }
    }
}
